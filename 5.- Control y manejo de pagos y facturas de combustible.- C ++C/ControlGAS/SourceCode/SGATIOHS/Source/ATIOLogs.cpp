
#include <stdio.h>
#include <string.h>
#include <stdarg.h>
#include <svc.h>
#include <logsys.h>

#include <ceif.h>
#include <svc_net.h>

#include <ATIOLogs.h>

char cLogType = LOG_MODE_OFF;
int inATIOLogSocketHandle = 0;

int inATIOLogInit(char cType)
{
	cLogType = cType;

	if(cLogType == LOG_USB_MODE || cLogType == LOG_COM_MODE)
	{
		LOG_INIT("SGATIOHS", LOGSYS_COMM, 0xFFFFFFFF);
	}

	return 0;
}

int inATIOLogBuffer(char *pchFmt, ... )
{
	if(cLogType == LOG_MODE_OFF)
		return 0;
	else
	{
		char pchFormatMessageBuf[2048 + 1];	
		char *pTemp;
		va_list pArg;

		pchFormatMessageBuf[0] = 0;

		if (pchFmt != 0)
		{
			pTemp = strchr(pchFmt,'%');

			if(pTemp)
			{
				va_start(pArg, pchFmt);
				vsprintf(pchFormatMessageBuf, pchFmt, pArg);
				va_end(pArg);
			}
			else
			{
				strcpy(pchFormatMessageBuf, pchFmt);
			}
		}

		if(cLogType == LOG_DSP_MODE)
		{
			gotoxy(1, 5);
			printf("                                                                                    ");
			gotoxy(1, 5);
			printf(pchFormatMessageBuf);
			SVC_WAIT(3000);
		}

		if(cLogType == LOG_USB_MODE || cLogType == LOG_COM_MODE)
		{
			LOG_PRINTF((pchFormatMessageBuf));
			SVC_WAIT(10);
		}

		if(cLogType == LOG_IP_MODE)
		{
			unsigned int uiRetLen;
			stNI_IPConfig stIPConfig;

			ceGetNWParamValue(0, IP_CONFIG, (void *) &stIPConfig, sizeof(stIPConfig), &uiRetLen);

			if(stIPConfig.ncIsConnected == 1)
			{
				if(inATIOLogSocketHandle == 0)
				{
					char szSodexoIP[20] = {0};
					int inSodexoPort = 0;
					struct sockaddr_in stSocketHost;

					strcpy(szSodexoIP, "10.10.100.16");
					inSodexoPort = 2007;

					memset(&stSocketHost, 0, sizeof(struct sockaddr_in));

					stSocketHost.sin_family = AF_INET;
					memset(stSocketHost.sin_zero, 0, 8);
					stSocketHost.sin_addr.s_addr = htonl(inet_addr(szSodexoIP));
					stSocketHost.sin_port = htons(inSodexoPort);

					inATIOLogSocketHandle = socket(AF_INET, SOCK_STREAM, IP_PROTOTCP);	

					connect(inATIOLogSocketHandle, (struct sockaddr *) &stSocketHost, sizeof(struct sockaddr_in));

					SVC_WAIT(3000);
				}
				else
				{
					send(inATIOLogSocketHandle, pchFormatMessageBuf, strlen(pchFormatMessageBuf), 0);
				}
			}
		}
	}

	return 0;
}

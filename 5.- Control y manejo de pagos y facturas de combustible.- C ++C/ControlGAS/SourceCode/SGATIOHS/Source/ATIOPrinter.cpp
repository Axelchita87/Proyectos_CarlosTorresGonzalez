/*
 * ===========================================================================
 * Programa		: control de procesamiento
 
 * ===========================================================================
 *
 * Autor:		Comentario:
 * ---------------------------------------------------------------------------
 * 	Ctorres		Código inicial
 * 								(Basado en el original de 2014)
 *
 * ===========================================================================
 */

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <svc.h>
#include <ctype.h>
#include <printer.h>
#include <errno.h>

#include <aclconio.h>
#include <aclstr.h>
#include <ascii.h>
#include <formater.h>


#include <vos_ioctl.h>
#include <vos_ddi_app_evt.h>
#include <ceifconst.h>
#include <ceif.h>
#include <vmc.h>


#include <sgatiohs.h>

#include <EMVTypeDefs.hpp>

#include <ATIOMsg.h>
#include <main.h>
#include <ATIOEMVProc.h>
#include <atiographics.h>
#include <ATIOUI.h>
#include <ATIOSivemax.h>		
#include <gvars.h>
#include <applic.h>
#include <ATIOComm.h>
#include <ATIOLogs.h>

#include <OpenSSL\md5.h>
#include <OpenSSL\des.h>

#include <atioprinter.h>
#include <ATIOMSGERR.h>

int hPrinter = -1;		
static char puerto[9];
static char szDW[9];
static char szNW[9];
static char szFF[9];

short typeterm;
int PosEntMode;

//int estac;

char NomEst[41]; 

FORMATER stFormater;
FORMATER stFormaterTAC11;
unsigned long ulHeaderCondition = 0L;
unsigned long ulMiddleCondition = 0L;
unsigned long ulMiddleExtraCondition = 0L;
unsigned long ulBottomCondition = 0L;

stNIInfo *pNIInfo;	


BOOL SendToPrn(BOOL fNegrita, char *pPrintBuffer)
{
	//LOG_PRINTF(("--SendToPrn--"));
	//LOG_PRINTF(("pPrintBuffer = [%s]", pPrintBuffer));

	ulHeaderCondition = 0L;

	if(strcmp(pPrintBuffer, "FF") == 0)
	{
		memset(ATIOBuffer1, 0x00, sizeof(ATIOBuffer1));

		if (!fSendToPrn(START_FF, END_FF, ulHeaderCondition))
			return FALSE;

		if(shTermModel == VX680_ID)
		{
			if (!fSendToPrn(START_FF, END_FF, ulHeaderCondition))
				return FALSE;
		}
	}
	else if(strcmp(pPrintBuffer, "FF2") == 0)
	{
		memset(ATIOBuffer1, 0x00, sizeof(ATIOBuffer1));

		if (!fSendToPrn(START_FF2, END_FF2, ulHeaderCondition))
			return FALSE;
	}
	
	else if(strcmp(pPrintBuffer, "FFFF") == 0)
	{
		memset(ATIOBuffer1, 0x00, sizeof(ATIOBuffer1));

		ATIOBuffer1[0] = 0x1B;
		ATIOBuffer1[1] = 0x0A;
		write(hPrinter, ATIOBuffer1, 2);

		ATIOBuffer1[0] = 0x1B;
		ATIOBuffer1[1] = 0x00;
		write(hPrinter, ATIOBuffer1, 2);
	}
	
	else
	{
		memset(ATIOBuffer1, 0x00, sizeof(ATIOBuffer1));

		strcpy(ATIOBuffer1, pPrintBuffer);

		if(fNegrita == FALSE)
		{
			ulHeaderCondition |= 0x00000001L;

			if (!fSendToPrn(START_GENERIC_PRINT, END_GENERIC_PRINT, ulHeaderCondition))
				return FALSE;
		}
		else
		{
			ulHeaderCondition |= 0x00000002L;

			if(strlen(ATIOBuffer1) > 20)
			{
				char szTempBuffer[42 + 1] = { 0 };

				memcpy(szTempBuffer, ATIOBuffer1, strlen(ATIOBuffer1));

				memcpy(ATIOBuffer1, szTempBuffer, 20);
				ATIOBuffer1[20] = 0x00;
				if (!fSendToPrn(START_GENERIC_PRINT, END_GENERIC_PRINT, ulHeaderCondition))
					return FALSE;
				
				SVC_WAIT(250);

				memcpy(ATIOBuffer1, szTempBuffer + 20, (strlen(szTempBuffer) - 20));
				ATIOBuffer1[strlen(szTempBuffer) - 20] = 0x00;

				if (!fSendToPrn(START_GENERIC_PRINT, END_GENERIC_PRINT, ulHeaderCondition))
					return FALSE;
			}
			else
			{
				if (!fSendToPrn(START_GENERIC_PRINT, END_GENERIC_PRINT, ulHeaderCondition))
					return FALSE;
			}
		}
	}
	return TRUE;
}

/*---------------------------------------------------------------------------*/
/* TRUE si se imprime la cadena str										      */
/*---------------------------------------------------------------------------*/

BOOL SendToPrnOrig(char *str) 
{
	char temp[4];
	unsigned long InitTime = 0;
	unsigned long LastTime = 0;

	InitTime = read_ticks();
	LastTime = InitTime + 40 * TICKS_PER_SEC;

	if (write(hPrinter, str, strlen(str)) == -1)
	{
	
		if (write(hPrinter, str, strlen(str)) == -1)
		{
			vdATIODisplayError(E039_ErrRedFile, str);
			return FALSE;
		}
	}

	/*  Valida el estado del puerto */
	while (get_port_status(hPrinter, temp) > 0)
	{
		if (read_ticks() > LastTime)
			return FALSE;
	}

	return TRUE;
}
/*---------------------------------------------------------------------------*/
/* Lee un argumento de un Track con separacion de | (4.9.28 10JUN11 )		 */
/*---------------------------------------------------------------------------*/
char *LeerArgumentoPipe(char *szTrack, int nPos)
{
	static char szArg[256];
	static char szTxt[256];
	static char* pArg;
	static int nArg;

	strcpy(szArg, "");
	if (nPos == 1)
		strcpy(szTxt, szTrack);
	else
		strcpy(szTxt, szTrack + 1);
	pArg = strtok(szTxt, "|");
	nArg = 0;
	while (pArg != NULL)
	{
		if (++nArg == nPos)
		{
			strcpy(szArg, pArg);
			break;
		}
		pArg = strtok(NULL, "|");
	}

	return szArg;
}

/*---------------------------------------------------------------------------*/
/* Lee un argumento de un Track con separacion de ^ (4.7.14 19NOV07)         */
/*---------------------------------------------------------------------------*/
char *LeerArgumento(char *szTrack, int nPos)
{
	static char szArg[256];
	static char szTxt[256];
	static char* pArg;
	static int nArg;

	strcpy(szArg, "");
	if (nPos == 1)
		strcpy(szTxt, szTrack);
	else
		strcpy(szTxt, szTrack + 1);
	pArg = strtok(szTxt, "^=");
	nArg = 0;
	while (pArg != NULL)
	{
		if (++nArg == nPos)
		{
			strcpy(szArg, pArg);
			break;
		}
		pArg = strtok(NULL, "^=");
	}

	return szArg;
}

/*---------------------------------------------------------------------------*/
/* Obtiene el formato del ticket                                             */
/*---------------------------------------------------------------------------*/
BOOL ReadFile(int hFile, char *buffer, int size, char *szFile)
{
	lseek(hFile, 0L, SEEK_SET);

	memset(buffer, 0, size);

	if (read(hFile, buffer, size) != size)
	{
		vdATIODisplayError(E039_ErrRedFile, szFile);
		return FALSE;
	}

	return TRUE;
}

int p3700_direct(FORMATER *formater, int init_time_out)
{
	int inReturn;

	formater->output_close = p3700_close;


	if(shTermModel == E355_ID)
	{
		formater->direct = 0;
		formater->output_print = shATIOBTPrint;
	}
	else
	{
		formater->output_print = p3700_print;
		formater->direct = 1;
	}


	formater->output_mode = p3700_mode;
	//formater->direct = 1;		
	formater->max_buffers = 2;

	inReturn = p3700_init(formater->h_comm_port, init_time_out);

	while (inReturn == -1)
	{
		SVC_WAIT(200);
		inReturn = p3300_init(formater->h_comm_port, (short) init_time_out);
	}

	return 0;
}

/*---------------------------------------------------------------------------*/
/* Abre e inicializa el puerto de impresion                                  */
/*---------------------------------------------------------------------------*/
BOOL OpenPrinter(const char *port)
{
	struct Opn_Blk devSettings;

	//LOG_PRINTF(("-- OpenPrinter --"));

	strcpy(puerto, port);


	if (shTermModel == E355_ID)
	{
		if(IPRMode == 0)
		{
			/*  - Impresora Bluetooth VeriFone */
			if(hPrinter < 0)
			{
				hPrinter = inATIOOpenBTPrinter();

				if(hPrinter < 0)
				{
					vdATIODisplayError(E008_ErrOpnPort, "PRINTER");
					SVC_WAIT(WAIT_ERROR);
					return FALSE;
				}

				p3700_init(hPrinter, 6);
				SVC_WAIT(100);
			
			}
			/*  - Impresora Bluetooth VeriFone */
			return TRUE;
		}
		else if(IPRMode == 4 || IPRMode == 10)
		{
			hPrinter = 999999;
			return TRUE;
		}
		else
			return FALSE;
	}


	if ((hPrinter = open(port, O_WRONLY)) == -1)
	{
		vdATIODisplayError(E008_ErrOpnPort, "PRINTER");
		SVC_WAIT(WAIT_ERROR);
		return FALSE;
	}

/*  Fix MiniPrinter */
	devSettings.rate = Rt_19200;
	//devSettings.format = Fmt_A8N1;
	devSettings.format = Fmt_A8N1 | Fmt_auto;
	devSettings.protocol = P_char_mode;
	devSettings.parameter = 0;
/*  - Fix MiniPrinter */

	if(IPRMode == 4)	/*  Fix MiniPrinter */
	{
		devSettings.rate = Rt_9600;
		devSettings.format = Fmt_A7E1 | Fmt_auto;
		devSettings.protocol = P_char_mode;
		devSettings.parameter = 0;
	}

	/*	Inicializa el puerto de comunicaciones */
	if (set_opn_blk(hPrinter, &devSettings) != 0)
	{
		vdATIODisplayError(E009_ErrIniPort, "PRINTER");
		SVC_WAIT(WAIT_ERROR);
		hPrinter = 0;
		return FALSE;
	}

	if(IPRMode == 10)
	{
		char szInitPrinter[16 + 1];

		szInitPrinter[0] = 0x1B;
		szInitPrinter[1] = 0x40;
		write(hPrinter, szInitPrinter, 2);

		SVC_WAIT(250);

		szInitPrinter[0] = 0x1B;
		szInitPrinter[1] = 0x53;
		write(hPrinter, szInitPrinter, 2);

		//szInitPrinter[0] = 0x1D;
		//szInitPrinter[1] = 0x28;
		//szInitPrinter[2] = 0x02;
		//szInitPrinter[3] = 0x00;
		//write(hPrinter, szInitPrinter, 4);
	}
	else if(IPRMode == 4)		/*  Impresión en matriz */
	{
		char szInitPrinter[16 + 1];

		szInitPrinter[0] = 0x1B;
		szInitPrinter[1] = 0x40;
		write(hPrinter, szInitPrinter, 2);

		SVC_WAIT(250);

		szInitPrinter[0] = 0x1B;
		szInitPrinter[1] = 0x53;
		write(hPrinter, szInitPrinter, 2);
	}							/*  Impresión en matriz */
	else
	{
		SVC_WAIT(200);
		p3700_init(hPrinter, 6);
		SVC_WAIT(100);

		//formater_main(gvardata);
		//formater_open(hPrinter, &stFormater, "ATIOtkt.frm", p3700_direct, 12);
	}

	return TRUE;
}

/*---------------------------------------------------------------------------*/
/* Cierra el puerto de impresion                                             */
/*---------------------------------------------------------------------------*/
void ClosePrinter(void)
{
	if (hPrinter > 0)
	{
		if(IPRMode == 10 || IPRMode == 4)
		{
			close(hPrinter);
			hPrinter = -1;
		}
		else
		{
	
			if(shTermModel == E355_ID)
			{
				shBTClosePrinter(hPrinter);
				hPrinter = -1;
			}
			else
			{
				close(hPrinter);
				hPrinter = -1;
			}
		
		}
	}
}

/*---------------------------------------------------------------------------*/
/* TRUE si se imprime el buffer		                                         */
/*---------------------------------------------------------------------------*/
BOOL fSendToPrn(int inStartLine, int inEndLine, unsigned long ulCondition)
{
	//LOG_PRINTF(("-- fSendToPrn --%ld", ulCondition));

	if(IPRMode == 10)
	{
		char temp[4];
		unsigned long InitTime = 0;
		unsigned long LastTime = 0;
		char szPrintfBuffer[42 + 10 + 1];

		InitTime = read_ticks();
		LastTime = InitTime + 40 * TICKS_PER_SEC;

		memset(szPrintfBuffer, 0x00, sizeof(szPrintfBuffer));

		if(ulCondition == 2L)
		{
			sprintf(szPrintfBuffer, "%s%s%s\n", szDW, ATIOBuffer1, szNW);
		}
		else
		{
			if(inStartLine == START_FF && inEndLine == END_FF)
			{
				sprintf(szPrintfBuffer, "\n%cd%c%cm\n", 0x01B, 12, 0x1B);
			}
			else if(inStartLine == START_FF2 && inEndLine == END_FF2)
			{
				strcpy(szPrintfBuffer, " \n\n");
			}
			else
			{
				sprintf(szPrintfBuffer, "%s\n", ATIOBuffer1);
			}
		}

		if (write(hPrinter, szPrintfBuffer, strlen(szPrintfBuffer)) == -1)
		{
			ClosePrinter();
			SVC_WAIT(WAIT_ERROR);

			if(!OpenPrinter(puerto))
			{
				vdATIODisplayError(E040_ErrImpresion, szPrintfBuffer);
				return FALSE;
			}

			if (write(hPrinter, szPrintfBuffer, strlen(szPrintfBuffer)) == -1)
			{
				vdATIODisplayError(E040_ErrImpresion, szPrintfBuffer);
				return FALSE;
			}
		}

		/*  Valida el estado del puerto */
		while (get_port_status(hPrinter, temp) > 0)
		{
			/* 
			read(STDIN, (char *) &key, 1);
			if (key == kbd_clear || key == kbd_cancel)
			{
				vdATIODisplayError(E041_ImpresionCancelada, NULL);
				ClosePrinter();
				return FALSE;
			}
			
			*/
			if (read_ticks() > LastTime)
				return FALSE;
		}
	}
	else if(IPRMode == 4)			/*  Impresión en matriz */
	{
		char temp[4];
		unsigned long InitTime = 0;
		unsigned long LastTime = 0;
		char szPrintfBuffer[42 + 10 + 1];

		InitTime = read_ticks();
		LastTime = InitTime + 40 * TICKS_PER_SEC;

		memset(szPrintfBuffer, 0x00, sizeof(szPrintfBuffer));

		if(ulCondition == 2L)
		{
			sprintf(szPrintfBuffer, "%s%s%s\n", szDW, ATIOBuffer1, szNW);
		}
		else
		{
			if(inStartLine == START_FF && inEndLine == END_FF)
			{
				sprintf(szPrintfBuffer, "\n%cd%c%cm\n", 0x01B, 12, 0x1B);
				//strcpy(szPrintfBuffer, " \n\n\n\n\n\n\n\n\n");
			}
			else if(inStartLine == START_FF2 && inEndLine == END_FF2)
			{
				strcpy(szPrintfBuffer, " \n\n");
			}
			else
			{
				sprintf(szPrintfBuffer, "%s\n", ATIOBuffer1);
			}
		}

		if (write(hPrinter, szPrintfBuffer, strlen(szPrintfBuffer)) == -1)
		{
			ClosePrinter();
			SVC_WAIT(WAIT_ERROR);
			if(!OpenPrinter(puerto))
			{
				vdATIODisplayError(E040_ErrImpresion, szPrintfBuffer);
				return FALSE;
			}

			if (write(hPrinter, szPrintfBuffer, strlen(szPrintfBuffer)) == -1)
			{
				vdATIODisplayError(E040_ErrImpresion, szPrintfBuffer);
				return FALSE;
			}
		}

		/*  Valida el estado del puerto */
		while (get_port_status(hPrinter, temp) > 0)
		{
			/* 
			read(STDIN, (char *) &key, 1);
			if (key == kbd_clear || key == kbd_cancel)
			{
				vdATIODisplayError(E041_ImpresionCancelada, NULL);
				ClosePrinter();
				return FALSE;
			}
			  */
			if (read_ticks() > LastTime)
				return FALSE;
		}

	}								/*  Impresión en matriz */
	else
	{
		char szPrintfBuffer[42 + 10 + 1];
		unsigned char ucPrintBuf[8 + 1];

		memset(szPrintfBuffer, 0x00, sizeof(szPrintfBuffer));

		if(ulCondition == 2L)
		{
			memset(ucPrintBuf, 0, sizeof(ucPrintBuf));
			ucPrintBuf[0] = DBL_WIDTH;
			p3700_print(hPrinter, ucPrintBuf);
			//sprintf(szPrintfBuffer, "%s%s%s\n", szDW,ATIOBuffer1, szNW);
			sprintf(szPrintfBuffer, "%s", ATIOBuffer1);
		}
		else
		{
			if(inStartLine == START_FF && inEndLine == END_FF)
			{
				// printer in NORMAl font
				memset(ucPrintBuf, 0, sizeof(ucPrintBuf));
				ucPrintBuf[0] = PRINT_NORM;
				p3700_print(hPrinter, ucPrintBuf);
				//sprintf(szPrintfBuffer, "\n%cd%c%cm\n", 0x01B, 12, 0x1B);
				strcpy(szPrintfBuffer, " \n\n\n\n");
				//sprintf(szPrintfBuffer, "%s\n", ATIOBuffer1);
			}
			else if(inStartLine == START_FF2 && inEndLine == END_FF2)
			{
				// printer in NORMAl font
				memset(ucPrintBuf, 0, sizeof(ucPrintBuf));
				ucPrintBuf[0] = PRINT_NORM;
				p3700_print(hPrinter, ucPrintBuf);
				strcpy(szPrintfBuffer, " \n\n");
			}
			else
			{
				// printer in NORMAl font
				memset(ucPrintBuf, 0, sizeof(ucPrintBuf));
				ucPrintBuf[0] = PRINT_NORM;
				p3700_print(hPrinter, ucPrintBuf);
				sprintf(szPrintfBuffer, "%s", ATIOBuffer1);
			}
		}

		if (p3700_print(hPrinter, (unsigned char *) szPrintfBuffer) < 0)
		{
			ClosePrinter();
			SVC_WAIT(WAIT_ERROR);
			if(!OpenPrinter(puerto))
			{
				vdATIODisplayError(E040_ErrImpresion, szPrintfBuffer);
				return FALSE;
			}

			if (p3700_print(hPrinter, (unsigned char *) szPrintfBuffer) < 0)
			{
				vdATIODisplayError(E040_ErrImpresion, szPrintfBuffer);
				SVC_WAIT(WAIT_ERROR);
				return FALSE;
			}
		}

		memset(ucPrintBuf, 0, sizeof(ucPrintBuf));
		ucPrintBuf[0] = 0x0A;
		p3700_print(hPrinter, (unsigned char *)ucPrintBuf);
	}
	return TRUE;
}

/*---------------------------------------------------------------------------*/
/* TRUE si se imprime la cadena str                          27ABR11         */
/*---------------------------------------------------------------------------*/
BOOL SendToPrnMiniPrint(char *str, int len)
{
	int inWrite;

	inWrite = write(hPrinter, str, len);
	SVC_WAIT(100);

	if (inWrite == -1)
	{
		vdATIODisplayString("Error Impresion", 7, CENTER_ALIGN);
		error_tone();
		SVC_WAIT(3000);

		return FALSE;
	}

	SVC_WAIT(100);

	return TRUE;
}

/*---------------------------------------------------------------------------*/
/* Conversión a Letras                                                       */
/*---------------------------------------------------------------------------*/
#define UNI    p[2]
#define DEC    p[1]
#define CEN    p[0]

char *ALetras(double num, char *mda, BOOL bNac, short size)
{
	/*static*/char alfa[20];
	/*static*/char edit[256];
	static char outs[256];

	char *p = alfa;
	char *q = 0;
	char *r = 0;
	char c = 0;
	int fact = 5;
	short len = 0;

	if (num < 0)
		num = 0 - num;
	sprintf(alfa, "%17.0lf", num);

	*edit = '\0';

	while (fact)
	{

		if (strncmp(p, "   ", 3) && strncmp(p, "000", 3))
		{
			if (!strncmp(p, "001", 3) || !strncmp(p, "  1", 3))
			{
				strcat(edit, " un");
				switch (fact)
				{
					case 5:
						strcat(edit, " bi-llon");
						break;
					case 4:
						strcat(edit, " mil mi-llo-nes");
						break;
					case 3:
						strcat(edit, " mi-llon");
						break;
					case 2:
						strcat(edit, " mil");
						break;
					case 1:
						/* No corresponde cuando es dinero
						 strcat(edit, "o");
						 */
						break;
					default:
						break;
				}
			}
			else
			{
				if (!strncmp(p, "100", 3))
				{
					strcat(edit, " cien");
					switch (fact)
					{
						case 5:
							strcat(edit, " bi-llo-nes");
							break;
						case 4:
							strcat(edit, " mil mi-llo-nes");
							break;
						case 3:
							strcat(edit, " mi-llo-nes");
							break;
						case 2:
							strcat(edit, " mil");
							break;
						default:
							break;
					}
				}
				else
				{
					switch (CEN)
					{
						case '9':
						strcat(edit, " no-ve");
						break;
						case '8':
						strcat(edit, " o-cho");
						break;
						case '7':
						strcat(edit, " se-te");
						break;
						case '6':
						strcat(edit, " seis");
						break;
						case '5':
						strcat(edit, " qui-nien-tos");
						break;
						case '4':
						strcat(edit, " cua-tro");
						break;
						case '3':
						strcat(edit, " tres");
						break;
						case '2':
						strcat(edit, " dos");
						break;
						case '1':
						strcat(edit, " cien-to");
						break;
						default:
						break;
					}
					if ((CEN != '0') && (CEN != ' ') &&
							(CEN != '1') && (CEN != '5'))
					{
						strcat(edit, "-cien-tos");
					}
				}
				switch (DEC)
				{
					case '9':
					strcat(edit, " no-ven-ta");
					break;
					case '8':
					strcat(edit, " o-chen-ta");
					break;
					case '7':
					strcat(edit, " se-ten-ta");
					break;
					case '6':
					strcat(edit, " se-sen-ta");
					break;
					case '5':
					strcat(edit, " cin-cuen-ta");
					break;
					case '4':
					strcat(edit, " cua-ren-ta");
					break;
					case '3':
					strcat(edit, " trein-ta");
					break;
					case '2':
					switch (UNI)
					{
						case ' ':
						case '0':
						strcat(edit, " vein-te");
						break;
						case '9':
						strcat(edit, " vein-ti-nue-ve");
						break;
						case '8':
						strcat(edit, " vein-tio-cho");
						break;
						case '7':
						strcat(edit, " vein-ti-sie-te");
						break;
						case '6':
						strcat(edit, " vein-ti-seis");
						break;
						case '5':
						strcat(edit, " vein-ti-cin-co");
						break;
						case '4':
						strcat(edit, " vein-ti-cua-tro");
						break;
						case '3':
						strcat(edit, " vein-ti-tres");
						break;
						case '2':
						strcat(edit, " vein-ti-dos");
						break;
						case '1':
						strcat(edit, " vein-ti-un");
						/* No corresponde cuando es dinero
						 if (fact == 1)
						 strcat(edit, "o");
						 */
						break;
						default:
						break;
					}
					break;
					case '1':
					switch (UNI)
					{
						case '9':
						strcat(edit, " die-ci-nue-ve");
						break;
						case '8':
						strcat(edit, " die-cio-cho");
						break;
						case '7':
						strcat(edit, " die-ci-sie-te");
						break;
						case '6':
						strcat(edit, " die-ci-seis");
						break;
						case '5':
						strcat(edit, " quin-ce");
						break;
						case '4':
						strcat(edit, " ca-tor-ce");
						break;
						case '3':
						strcat(edit, " tre-ce");
						break;
						case '2':
						strcat(edit, " do-ce");
						break;
						case '1':
						strcat(edit, " on-ce");
						break;
						case '0':
						case ' ':
						strcat(edit, " diez");
						break;
						default:
						break;
					}
					break;
					default:
					break;
				}
				if ((UNI != ' ') && (UNI != '0'))
				{
					if ((DEC == ' ') || (DEC == '0') || (DEC > '2'))
					{
						if (DEC > '2')
						strcat(edit, " y");
						switch (UNI)
						{
							case '9':
							strcat(edit, " nue-ve");
							break;
							case '8':
							strcat(edit, " o-cho");
							break;
							case '7':
							strcat(edit, " sie-te");
							break;
							case '6':
							strcat(edit, " seis");
							break;
							case '5':
							strcat(edit, " cin-co");
							break;
							case '4':
							strcat(edit, " cua-tro");
							break;
							case '3':
							strcat(edit, " tres");
							break;
							case '2':
							strcat(edit, " dos");
							break;
							case '1':
							strcat(edit, " un");
							/* No corresponde cuando es dinero
							 if (fact == 1)
							 strcat(edit, "o");
							 */
							break;
							case '0':
							case ' ':
							strcat(edit, " vein-te");
							break;
							default:
							break;
						}
					}
				}
				switch (fact)
				{
					case 5:
					strcat(edit, " bi-llo-nes");
					break;
					case 4:
					strcat(edit, " mil mi-llo-nes");
					break;
					case 3:
					strcat(edit, " mi-llo-nes");
					break;
					case 2:
					strcat(edit, " mil");
					break;
					default:
					break;
				}
			}
		}

		p += 3;
		fact--;
	}

	if (mda != NULL)
	{
		char *e = (edit + strlen(edit));
		char *m = mda;

		*e++ = ' ';
		while (*m)
			*e++ = tolower(*m++);
		*e++ = '\0';
	}

	sprintf(alfa, " %c%c/100%s.)", *p, *(p + 1), (bNac ? " M.N" : ""));
	strcat(edit, alfa);

	p = edit + 1;
	q = outs;

	*q++ = '(';
	len = 1;

	while ((int) *p)
	{
		if (len > size && *p != ' ')
		{
			p -= q - r;
			q = r;
			if (c == '-')
				*q++ = '-';
			else
				p++;
			*q++ = '\n';
			len = 0;
		}
		switch (*p)
		{
			case '-':
				r = q;
				c = *p;
				p++;
				break;
			case ' ':
				r = q;
				c = *p;
			default:
				*q++ = *p++;
				len++;
				break;
		}
	}
	*q = '\0';

	return (outs);
}

/*---------------------------------------------------------------------------*/
/* Rutina para Centrar Texto                                                 */
/*---------------------------------------------------------------------------*/

char *Alinear(char * sTxt, int nMax, int nPos)
{
	static char sRes[256] = { 0 };
	char sAux[256] = { 0 };
	int nCnt = 0;

	strncpy(sAux, sTxt, 132)[132] = 0;
	sRemEsp(sAux);

	if (nPos < 0 || strlen(sAux) > 40)
		strcpy(sRes, sAux);
	else if (nPos > 0)
		sprintf(sRes, "%*s", nMax, sAux);
	else
	{
		nCnt = (nMax - strlen(sAux)) / 2;
		sprintf(sRes, "%*s%s", nCnt, "", sAux);
	}

	return sRes;
}

/*---------------------------------------------------------------------------*/
/* Datos de la Empresa (Cabecera de Ticket)                                  */
/*---------------------------------------------------------------------------*/

BOOL fPrintEmpresa(void)
{
	TICKET ticket;
	char szReg[sizeof(TICKET)];
	char conEspac[41] = { 0 }; /*  */
	char regEspac[1024] = { 0 }; 
	
	//LOG_PRINTF(("-- fPrintEmpresa --"));

	if (ReadFile(hTKT, (char *) &ticket, sizeof(TICKET), FILE_TICKET))
	{
		int nPos = (ticket.centrar != '0') ? 0 : -1;
		int len = 0; 

		strcpy(conEspac, ticket.marca); 
		purge_char(conEspac, ' '); 
		len = strlen(conEspac); 
		if(len  > 0) 
		{
			if (!SendToPrn(TRUE, Alinear(ticket.marca, 20, nPos)))
				return FALSE;
		}

		strcpy(conEspac, ticket.nombre); 
		purge_char(conEspac, ' '); 
		len = strlen(conEspac); 
		if(len > 0) 
		{
			strcpy(NomEst, ticket.nombre); 
			if (!SendToPrn(FALSE, Alinear(ticket.nombre, 40, nPos)))
			{
				return FALSE;
			}
		}

		strcpy(conEspac, ticket.direccion);
		purge_char(conEspac, ' '); 
		len = strlen(conEspac); 
		if(len  > 0) 
			if (!SendToPrn(FALSE, Alinear(ticket.direccion, 40, nPos)))
				return FALSE;

		strcpy(conEspac, ticket.colonia);
		purge_char(conEspac, ' '); 
		len = strlen(conEspac); 
		if(len  > 0) 
			if (!SendToPrn(FALSE, Alinear(ticket.colonia, 40, nPos)))
				return FALSE;

		strcpy(conEspac, ticket.estado); 
		purge_char(conEspac, ' '); 
		len = strlen(conEspac); 
		if(len  > 0) 
			if (!SendToPrn(FALSE, Alinear(ticket.estado, 40, nPos)))
				return FALSE;

		strcpy(conEspac, ticket.telefono); 
		purge_char(conEspac, ' '); 
		len = strlen(conEspac); 
		if(len  > 0) 
			if (!SendToPrn(FALSE, Alinear(ticket.telefono, 40, nPos)))
				return FALSE;

		if(SESPMode)
			if (!SendToPrn(FALSE, " "))
				return FALSE;

		strcpy(conEspac, ticket.rfc); 
		purge_char(conEspac, ' '); 
		len = strlen(conEspac); 
		if(len  > 0) 
			if (!SendToPrn(FALSE, Alinear(ticket.rfc, 40, nPos)))
				return FALSE;

		strcpy(conEspac, CveCliLit); 
		purge_char(conEspac, ' '); 
		len = strlen(conEspac); 
		if(len  > 0) 
		{
			char strAux[64];
			sprintf(strAux, cATIOLeeMsgDeArchivo(MSG_ClaveCliPEMEX), CveCliLit);

			if (!SendToPrn(FALSE, Alinear(strAux, 40, nPos)))
				return FALSE;
		}

		strcpy(conEspac, PermCre);
		purge_char(conEspac, ' ');
		len = strlen(conEspac);
		if(len  > 0)
		{
			char strAux[64];
			sprintf(strAux, cATIOLeeMsgDeArchivo(MSG_PermCre), PermCre);

			if (!SendToPrn(FALSE, Alinear(strAux, 40, nPos)))
				return FALSE;
		}

		//estac = atoi(CodEst);	

		while (read(hTKT, szReg, sizeof(TICKET)) == sizeof(TICKET))
		{
			strcpy(regEspac, szReg); 
			purge_char(regEspac, ' ');
			len = strlen(regEspac);

			if(len > 1) 
			{ 
				switch (szReg[0])
				{
					case 'R':
						if (!SendToPrn(FALSE, " ")) 
							return FALSE; 
						if (!SendToPrn(FALSE, Alinear(cATIOLeeMsgDeArchivo(MSG_REGIMEN_FISCAL), 40, nPos)))
							break;

						if (!SendToPrn(FALSE, Alinear(szReg + 1, 40, nPos)))
							break; /* 4.10.19 31OCT13 */
						break;
					case 'L':
						if (!SendToPrn(FALSE, " ")) 
							return FALSE; 
						if (!SendToPrn(FALSE, Alinear(cATIOLeeMsgDeArchivo(MSG_LUGAR_DE_EXPED), 40, nPos)))
							break;

						if (!SendToPrn(FALSE, Alinear(szReg + 1, 40, nPos)))
							break;
						
						if(!SESPMode)
							if (!SendToPrn(FALSE, " "))
								return FALSE;
						
						break;
					case 'D':
						if (!SendToPrn(FALSE, Alinear(szReg + 1, 40, nPos)))
							break; /* 4.10.19 31OCT13 */
						break; /* 4.10.19 31OCT13 */
				}
			} 
		}

		if (!SendToPrn(FALSE, " "))
			return FALSE;
	}
	else
		return FALSE;

	return TRUE;
}

/*---------------------------------------------------------------------------*/
/* Rutina principal para impresión de tickets                                */
/*---------------------------------------------------------------------------*/
BOOL fPrintTicket(POSPumpData *Dat, int nCopy, BOOL bPortAux, char *CRDiTrack1, char *CRDrStream)
{
	BOOL bClienteOK;
	BOOL bTarjetaOK;
	BOOL bResponsOK;
	double dCan[MaxIdxItm];
	double dPre[MaxIdxItm];
	double dMto[MaxIdxItm];
	double dIva;
	double dIIE;
	double dMtoIva;
	double dMtoIIE;
	double dMtoTot;
	double dPtoTot;
	int bomba = atoi(stDespachoItm[0].bom);
	int i, cnt;
	char strAux[133];
	char strLin[133];
	//char strfch[8];
	//char strtrn[12];
	//char strbom[2];
	//int lentrn;
	char CRDiTrack1b[96];

	//LOG_PRINTF(("-- fPrintTicket --"));

	memset(CRDiTrack1b, 0, sizeof(CRDiTrack1b));

	ulHeaderCondition = 0L;
	ulMiddleCondition = 0L;
	ulMiddleExtraCondition = 0L;
	ulBottomCondition = 0L;

	//LOG_PRINTF(("CRDiTrack1[0] = %02X", CRDiTrack1[0]));

	for (i = 0; i <= 96; i++)
	{
		CRDiTrack1b[i] = CRDiTrack1[i + 1];
	}

	/* Inicializaciones */
	bClienteOK = atol(Dat->cli.codigo) != 0;
	bTarjetaOK = atol(Dat->cli.tarjeta) != 0;


	if(nPumpVale[inCntPumpVale]) 
	{		
		bResponsOK = atol(stResVale.codigo) != 0;
		memcpy(&Dat->res, &stResVale, sizeof(stResVale)); 
	}
	else
	{
		bResponsOK = atol(Dat->res.codigo) != 0;
	}
	
	return 0;
}



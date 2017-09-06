/*
 * =================================================================
 * Programa		: Controlar procesamiento *
 * 				  (Procesamiento funcionalidades PAYBACK)
 *
 * =================================================================
 *
 	Autor:		Comentario:
 * -----------------------------------------------------------------
 * 	Ctorres		Código inicial
 * 	Ctorres		Rediseño de funciones
 *
 * =================================================================
 */

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <svc.h>
#include <aclstr.h>
#include <aclconio.h>
#include <ctype.h>
#include <logsys.h>

#include <svc_net.h>

#include <main.h>
#include <sgatiohs.h>
#include <atiomsgerr.h>
#include <ATIOGraphics.h>
#include <atioui.h>
#include <atioprinter.h>

#include "ATIOPayback.h"

void vdATIOPaybackAcumula(char *pPAYBackMsg, int nNroBom, double dTotal, double dTotalProd, char *pCodigoEmp, POSCliente stCliente)
{
	char szTime[20] = { 0 };
	char szFechaHoraTrx[32] = { 0 };
	char szHoraTerminal[32] = { 0 };
	char szFechaTerminal[32] = { 0 };
	char szFechaSE[32] = { 0 };
	char szEffectiveDate[32] = { 0 };
	char szAuxBuffer[32 + 1] = { 0 };
	char szAuxBuffer2[32 + 1] = { 0 };
	char szProdBuffer[512 + 1] = { 0 };

	double dMontoIIVA = 0.0;
	double dMontoIIE = 0.0;
	double dMontoTotal = 0.0;
	double dProductoTotal = 0.0;
	double dIIE = 0.0;
	double dIVA = 0.0;

	double dAuxCan[MaxIdxItm];
	double dAuxPre[MaxIdxItm];
	double dAuxMto[MaxIdxItm];

	int i = 0;

	char szCodEst[5];
	
	for(i=0; i < strlen(CodEst); i++)
	{
		if (isdigit(CodEst[i]))
		{
			strncpy(szCodEst, CodEst + i, 5)[5] = 0;
			break;
		}
	}

	SVC_CLOCK(0, szTime, 15); //yyyymmddhhmmssw
	szTime[15] = 0;

	memcpy(szFechaHoraTrx, szTime + 4, 2);
	memcpy(&szFechaHoraTrx[2], szTime + 6, 2);
	memcpy(&szFechaHoraTrx[4], szTime + 8, 2);
	memcpy(&szFechaHoraTrx[6], szTime + 10, 2);
	memcpy(&szFechaHoraTrx[8], szTime + 12, 2);

	memcpy(szHoraTerminal, szTime + 8, 2);
	memcpy(&szHoraTerminal[2], szTime + 10, 2);
	memcpy(&szHoraTerminal[4], szTime + 12, 2);

	memcpy(szFechaTerminal, szTime + 4, 2);
	memcpy(&szFechaTerminal[2], szTime + 6, 2);

	memcpy(szFechaSE, szTime, 4);
	memcpy(&szFechaSE[4], szTime + 4, 2);
	memcpy(&szFechaSE[6], szTime + 6, 2);

	memcpy(szEffectiveDate, szTime, 4);
	memcpy(&szEffectiveDate[4], "-", 1);
	memcpy(&szEffectiveDate[5], szTime + 4, 2);
	memcpy(&szEffectiveDate[7], "-", 1);
	memcpy(&szEffectiveDate[8], szTime + 6, 2);
	memcpy(&szEffectiveDate[10], "T", 1);
	memcpy(&szEffectiveDate[11], szTime + 8, 2);
	memcpy(&szEffectiveDate[13], ":", 1);
	memcpy(&szEffectiveDate[14], szTime + 10, 2);
	memcpy(&szEffectiveDate[16], ":", 1);
	memcpy(&szEffectiveDate[17], szTime + 12, 2);
	memcpy(&szEffectiveDate[19], "-06:00", 6);

	sprintf(szAuxBuffer, "%c", '0' + nNroBom);
	strcpy(pPAYBackMsg, szAuxBuffer);

	strcat(pPAYBackMsg, "PBACUMULA|");

	// FechaHoraTrx
	strcat(pPAYBackMsg, szFechaHoraTrx);
	strcat(pPAYBackMsg, "|");

	// Compania
	sprintf(szAuxBuffer, "%05d", atoi(szPAYBackCompania));
	strcat(pPAYBackMsg, szAuxBuffer);
	strcat(pPAYBackMsg, "|");

	// N_Tecla
	strcat(pPAYBackMsg, "000");
	strcat(pPAYBackMsg, "|");

	// N_Caja
	sprintf(szAuxBuffer, "%05d", nNroBom);
	strcat(pPAYBackMsg, szAuxBuffer);
	strcat(pPAYBackMsg, "|");

	// N_Tienda
	if(szCodEst[0])
		strcpy(szAuxBuffer, szCodEst);
	else
		strcpy(szAuxBuffer, "00000");

	strcat(pPAYBackMsg, szAuxBuffer);
	strcat(pPAYBackMsg, "|");

	// N_Empleado
	strcat(pPAYBackMsg, szPAYBackUsuario);	
	strcat(pPAYBackMsg, "|");

	// N_Turno
	strcat(pPAYBackMsg, "00001");
	strcat(pPAYBackMsg, "|");

	// N_Ticket
	sprintf(szAuxBuffer, "%020d", atoi(stDespachoItm[0].newtrn));
	strcat(pPAYBackMsg, szAuxBuffer);
	strcat(pPAYBackMsg, "|");

	// Texto_AppPos
	SVC_INFO_PTID(szAuxBuffer2);
	memcpy(szAuxBuffer, szAuxBuffer2 + 1, 8);
	szAuxBuffer[8] = 0x00;
	strcat(pPAYBackMsg, szAuxBuffer);
	strcat(pPAYBackMsg, "|");

	// FechaSE
	strcat(pPAYBackMsg, szFechaSE);
	strcat(pPAYBackMsg, "|");

	// SwitchKey
	sprintf(szAuxBuffer, "%s%02d1%s%s", szCodEst, nNroBom, szFechaTerminal, szHoraTerminal);
	szAuxBuffer[18] = 0x00;
	strcpy(szPAYBackSwitchKeyOrg, szAuxBuffer);	
	strcat(pPAYBackMsg, szAuxBuffer);
	strcat(pPAYBackMsg, "|");

	// NoTarjeta
	if(szPAYBackCardTrack2[0] != 0)
	{
		// strcpy(szAuxBuffer, strtok(szPAYBackCardTrack2, "=")); 
		strncpy(szAuxBuffer, szPAYBackCardTrack2, 16)[16] = 0; 
		strcat(pPAYBackMsg, szAuxBuffer);
		strcat(pPAYBackMsg, "|");
	}
	else if(szPAYBackBarCode[0] != 0)
	{
		strcat(pPAYBackMsg, szPAYBackBarCode);
		strcat(pPAYBackMsg, "|");
	}

	// PartherShortName
	strcat(pPAYBackMsg, szPAYBackNomCorto);
	strcat(pPAYBackMsg, "|");

	// BranchShortName
	strcat(pPAYBackMsg, szPAYBackAfiliacion);
	strcat(pPAYBackMsg, "|");

	// EffectiveDate
	strcat(pPAYBackMsg, szEffectiveDate);
	strcat(pPAYBackMsg, "|");

	for (i = 0; i < MaxIdxItm; i++)
	{
		if (!stDespachoItm[i].estado)
			break;

		dAuxCan[i] = atof(stDespachoItm[i].newcan) / 1000.;	
		dAuxPre[i] = atof(stDespachoItm[i].newpre) / 1000.;	
		dAuxMto[i] = atof(stDespachoItm[i].newmto) / 1000.;	

		if (dAuxPre[i] == 0.0)
			dAuxPre[i] = dAuxMto[i] / dAuxCan[i];

		if (FindProductInt(atoi(stDespachoItm[i].cdp)))
		{
			dIVA = 1.0 + atof(stProducto.iva) / 10000.;
			dIIE = atof(stProducto.iie) / 10000.;
		}
		else
		{
			dIVA = 1.0 + TaxVal / 100.;
			dIIE = 0;
		}
		if (IEPMode == 0)
			dIIE = 0;

		dIIE *= dAuxCan[i]; /* 4.8 */
		dIVA = dAuxMto[i] - ((dAuxMto[i] - dIIE) / dIVA + dIIE); /* 4.8 */
		dMontoIIE += dIIE; /* 4.8 */
		dMontoIIVA += dIVA;
		dMontoTotal += dAuxMto[i];
		dProductoTotal += atof(stDespachoItm[i].pto);
	}

	// RewardableLegalValueLegalAmount
	//sprintf(szAuxBuffer, "%ld", (long)dMontoTotal); 

	sprintf(szAuxBuffer, "%.2lf", dMontoTotal);
	
	strcat(pPAYBackMsg, szAuxBuffer);
	strcat(pPAYBackMsg, "|");

	// TotalPurchaseLegalValueLegalAmount
	//sprintf(szAuxBuffer, "%ld", dMontoTotal); 
	sprintf(szAuxBuffer, "%.2lf", dMontoTotal); 
	strcat(pPAYBackMsg, szAuxBuffer);
	strcat(pPAYBackMsg, "|");

	//TotalVatLegalValueLegalAmount
	//sprintf(szAuxBuffer, "%ld", (long)dMontoIIVA); 
	sprintf(szAuxBuffer, "%.2lf", dMontoIIVA);
	strcat(pPAYBackMsg, szAuxBuffer);
	strcat(pPAYBackMsg, "|");

	//PaymentType
	if (isdigit(stDespachoItm[0].pago))
	{
		BOOL bClienteOK;
		BOOL bTarjetaOK;

		strcpy(szAuxBuffer, "1");

		bClienteOK = atol(stCliente.codigo) != 0;
		bTarjetaOK = atol(stCliente.tarjeta) != 0;

		if (bClienteOK && bTarjetaOK)
		{
			if (atol(stCliente.cdc) / 100000 == 4009L)
				strcpy(szAuxBuffer, "99");
			else if (stCliente.tipo == TC_ICIGAS)
				strcpy(szAuxBuffer, "99");
			else if (stCliente.tipo == TC_PREPAGO)
				strcpy(szAuxBuffer, "99");
			else if (stCliente.tipo == TC_DEB)
				strcpy(szAuxBuffer, "3");
			else if (stCliente.tipo == TC_CRE)
				strcpy(szAuxBuffer, "2");
			else
				strcpy(szAuxBuffer, "99");
		}
	}
	strcat(pPAYBackMsg, szAuxBuffer);
	strcat(pPAYBackMsg, "|");

	// ListaProductos
	memset(szProdBuffer, 0x00, sizeof(szProdBuffer));
	strcat(szProdBuffer, "LISTADOPROD|0|");

	for (i = 0; i < MaxIdxItm; i++)
	{
		if(atof(stDespachoItm[i].newmto) > 0)
		{
			if (stDespachoItm[i].estado == 0 || stDespachoItm[i].newcan[0] == 0x00)
				break;

			if (FindProductInt(atoi(stDespachoItm[i].cdp)) == TRUE)
			{
				if(atoi(stProducto.cve) > 0)
				{
					strcpy(szAuxBuffer, stProducto.cve);
					pad(szAuxBuffer, szAuxBuffer, 0x30, 13, RIGHT);
					szAuxBuffer[13] = 0x00;
				}
				else
				{
					strcpy(szAuxBuffer, stProducto.cdp);
					pad(szAuxBuffer, szAuxBuffer, 0x30, 13, RIGHT);
					szAuxBuffer[13] = 0x00;
				}

				//PartnerProductGroupCode
				strcat(szProdBuffer, szAuxBuffer);
				strcat(szProdBuffer, "|");

				//PartnerProductGroupName
				strcpy(szAuxBuffer, sRemEsp(stDespachoItm[i].prd));	
				strcat(szProdBuffer, szAuxBuffer);
				strcat(szProdBuffer, "|");

				// Quantity
				sprintf(szAuxBuffer, "%.3lf", (atof(stDespachoItm[i].newcan) / 1000.));	
				strcat(szProdBuffer, szAuxBuffer);
				strcat(szProdBuffer, "|");

				// QuantityUnitCode
				sprintf(szAuxBuffer, "%s", sRemEsp(stProducto.uni));
				strcat(szProdBuffer, szAuxBuffer);
				strcat(szProdBuffer, "|");

				// TotalTurnoverAmount
				//sprintf(szAuxBuffer, "%.2lf", atof(stDespachoItm[i].newmto) / 1000.);	
				sprintf(szAuxBuffer, "%.2lf", atof(stDespachoItm[i].newmto) / 1000.);	
				strcat(szProdBuffer, szAuxBuffer);
				strcat(szProdBuffer, "|");

				// TotalRewardableAmount
				//sprintf(szAuxBuffer, "%.2lf", atof(stDespachoItm[i].newmto) / 1000.);	
				sprintf(szAuxBuffer, "%.2lf", atof(stDespachoItm[i].newmto) / 1000.);	
				strcat(szProdBuffer, szAuxBuffer);
				strcat(szProdBuffer, "|");
			}
		} 
		else
		{
			if(i > 0)
				break;
		}
	} 


	if(atof(stDespachoItm[i].newmto) < 1)	
	{
		if(i > 1)
		{
			i -= 1;
		}
	}

	szProdBuffer[12] = '0' + i; 

	strcat(pPAYBackMsg, szProdBuffer);
}


BOOL fATIOPaybackRedencion(char *pPAYBackMsg, int nNroBom, double dTotal, double dTotalProd, char *pCodigoEmp)
{
	char szTime[20] = { 0 };
	char szFechaHoraTrx[32] = { 0 };
	char szHoraTerminal[32] = { 0 };
	char szFechaTerminal[32] = { 0 };
	char szFechaSE[32] = { 0 };
	char szEffectiveDate[32] = { 0 };
	char szAuxBuffer[32 + 1] = { 0 };
	char szAuxBuffer2[32 + 1] = { 0 };

	double dMontoTotal = 0.0;

	char sTextPar[16]; 
	char szMontoParcial[16 + 1] = { 0 };


	long   dMontoRes = 0;


	int i = 0;


	char szCodEst[5];
	
	for(i=0; i < strlen(CodEst); i++)
	{
		if (isdigit(CodEst[i]))
		{
			strncpy(szCodEst, CodEst + i, 5)[5] = 0;
			break;
		}
	}


	memset(sTextPar, 0, sizeof(sTextPar)); 
	
	dTotal = dTotalProd; 

	
	if(!CtlPgoPar)
	{
		int inKeyRsp = 0;

		vdATIOLimpiaDisplay();
		vdATIODisplayString("**** FORMA PAGO ****", 2, CENTER_ALIGN);
		vdATIODisplayString("1 PAGO PARCIAL", 4, LEFT_ALIGN);
		vdATIODisplayString("2 PAGO TOTAL", 5, LEFT_ALIGN);

		inKeyRsp = ReadKeyb("TIPO DE PAGO ? ", 1, 0, 1, 1, sTextPar, 0, FALSE);
		if (inKeyRsp != kbd_enter)
			return FALSE;

		if (sTextPar[0] != '1' && sTextPar[0] != '2')
			sTextPar[0] = '2';

		if (sTextPar[0] == '1')
		{
			inKeyRsp = ReadKeyb("\fIMPORTE PARCIAL ?\n ", 8, 0, 1, 0, szMontoParcial, 0, FALSE);

			if (inKeyRsp != kbd_enter)
				return FALSE;
			if (atol(szMontoParcial)  > ((dTotal / 1000.0) + (dTotalProd / 1000.0)))
			{
				vdATIODisplayError(E021_Reintente, NULL);
				return FALSE;
			}
		}
	}


	SVC_CLOCK(0, szTime, 15); //yyyymmddhhmmssw
	szTime[15] = 0;

	memcpy(szFechaHoraTrx, szTime + 4, 2);
	memcpy(&szFechaHoraTrx[2], szTime + 6, 2);
	 
	memcpy(&szFechaHoraTrx[4], szTime + 8, 2);
	memcpy(&szFechaHoraTrx[6], szTime + 10, 2);
	memcpy(&szFechaHoraTrx[8], szTime + 12, 2);
	 
	memcpy(szHoraTerminal, szTime + 8, 2);
	memcpy(&szHoraTerminal[2], szTime + 10, 2);
	memcpy(&szHoraTerminal[4], szTime + 12, 2);

	memcpy(szFechaTerminal, szTime + 4, 2);
	memcpy(&szFechaTerminal[2], szTime + 6, 2);

	memcpy(szFechaSE, szTime, 4);
	memcpy(&szFechaSE[4], szTime + 4, 2);
	memcpy(&szFechaSE[6], szTime + 6, 2);

	memcpy(szEffectiveDate, szTime, 4);
	memcpy(&szEffectiveDate[4], "-", 1);
	memcpy(&szEffectiveDate[5], szTime + 4, 2);
	memcpy(&szEffectiveDate[7], "-", 1);
	memcpy(&szEffectiveDate[8], szTime + 6, 2);
	memcpy(&szEffectiveDate[10], "T", 1);
	memcpy(&szEffectiveDate[11], szTime + 8, 2);
	memcpy(&szEffectiveDate[13], ":", 1);
	memcpy(&szEffectiveDate[14], szTime + 10, 2);
	memcpy(&szEffectiveDate[16], ":", 1);
	memcpy(&szEffectiveDate[17], szTime + 12, 2);
	memcpy(&szEffectiveDate[19], "-06:00", 6);

	sprintf(szAuxBuffer, "%c", '0' + nNroBom);
	strcpy(pPAYBackMsg, szAuxBuffer);

	strcat(pPAYBackMsg, "PBREDENCION|");

	// FechaHoraTrx
	strcat(pPAYBackMsg, szFechaHoraTrx);
	strcat(pPAYBackMsg, "|");

	// Compania
	sprintf(szAuxBuffer, "%05d", atoi(szPAYBackCompania));
	strcat(pPAYBackMsg, szAuxBuffer);
	strcat(pPAYBackMsg, "|");

	// N_Tecla
	strcat(pPAYBackMsg, "000");
	strcat(pPAYBackMsg, "|");

	// N_Caja
	sprintf(szAuxBuffer, "%05d", nNroBom);
	strcat(pPAYBackMsg, szAuxBuffer);
	strcat(pPAYBackMsg, "|");

	// N_Tienda
	if(szCodEst[0])
		strcpy(szAuxBuffer, szCodEst);
	else
		strcpy(szAuxBuffer, "00000");

	strcat(pPAYBackMsg, szAuxBuffer);
	strcat(pPAYBackMsg, "|");

	// N_Empleado
	strcat(pPAYBackMsg, szPAYBackUsuario);	
	strcat(pPAYBackMsg, "|");

	// N_Turno
	strcat(pPAYBackMsg, "00001");
	strcat(pPAYBackMsg, "|");

	// N_Ticket
	strcpy(szAuxBuffer, sRemEsp(stDespachoItm[0].newtrn)); 
	strcat(pPAYBackMsg, szAuxBuffer);
	strcat(pPAYBackMsg, "|");

	// Texto_AppPos
	SVC_INFO_PTID(szAuxBuffer2);
	memcpy(szAuxBuffer, szAuxBuffer2 + 1, 8);
	szAuxBuffer[8] = 0x00;
	strcat(pPAYBackMsg, szAuxBuffer);
	strcat(pPAYBackMsg, "|");

	// FechaSE
	strcat(pPAYBackMsg, szFechaSE);
	strcat(pPAYBackMsg, "|");

	// SwitchKey
	sprintf(szAuxBuffer, "%s%02d1%s%s", szCodEst, nNroBom, szFechaTerminal, szHoraTerminal);
	szAuxBuffer[18] = 0x00;
	strcpy(szPAYBackSwitchKeyOrg, szAuxBuffer);
	strcat(pPAYBackMsg, szAuxBuffer);
	strcat(pPAYBackMsg, "|");

	// NoTarjeta
	if(szPAYBackCardTrack2[0] != 0)
	{
		// strcpy(szAuxBuffer, strtok(szPAYBackCardTrack2, "=")); 
		strncpy(szAuxBuffer, szPAYBackCardTrack2, 16)[16] = 0; ;
		strcat(pPAYBackMsg, szAuxBuffer);
		strcat(pPAYBackMsg, "|");
	}
	else if(szPAYBackBarCode[0] != 0)
	{
		strcat(pPAYBackMsg, szPAYBackBarCode);
		strcat(pPAYBackMsg, "|");
	}

	// PartherShortName
	strcat(pPAYBackMsg, szPAYBackNomCorto);
	strcat(pPAYBackMsg, "|");

	// BranchShortName
	strcat(pPAYBackMsg, szPAYBackAfiliacion);
	strcat(pPAYBackMsg, "|");

	// EffectiveDate
	strcat(pPAYBackMsg, szEffectiveDate);
	strcat(pPAYBackMsg, "|");


	dMontoTotal = dTotal / 1000.0;

	if (sTextPar[0] == '1')
	{
		dAuxMtoTot  = dMontoTotal;
		dAuxMtoPar  = atof(szMontoParcial);
		dMontoTotal = atof(szMontoParcial);

		CtlPgoPar = 1;
	}
	

	dPAYBackMontoTotal = dMontoTotal;
	memcpy(szPAYBackNumeroTrans, stDespachoItm[0].newtrn+(strlen(stDespachoItm[0].newtrn) - 6), 6);

	// RedemptionLoyaltyValueLoyaltyAmount
	//sprintf(szAuxBuffer, "-%.2lf", dMontoTotal);
	//sprintf(szAuxBuffer, "-%ld", (long)dMontoTotal);  
	
	dMontoTotal *= 10;
	dMontoRes = (long)dMontoTotal;
	if((dMontoTotal - dMontoRes) > 0)
	{
		dMontoRes += 1;
	}
	sprintf(szAuxBuffer, "-%ld", dMontoRes);
	
	strcat(pPAYBackMsg, szAuxBuffer);		//PB20 RedemptionLoyaltyVal
	strcat(pPAYBackMsg, "|");

	// RedemptionLegalValueLegalAmount
	//sprintf(szAuxBuffer, "-%.2lf", dMontoTotal); 
	//sprintf(szAuxBuffer, "-%ld", (long)dMontoTotal);  
	dMontoTotal /= 10;
	sprintf(szAuxBuffer, "-%.2lf", dMontoTotal); 
	strcat(pPAYBackMsg, szAuxBuffer);		//PB21 RedemptionLegalValue
	strcat(pPAYBackMsg, "|");

	return TRUE;
}

void vdATIOPaybackReverso(char *pPAYBackMsg, BOOL fRevAcumula, int nNroBom, char *pCodigoEmp)
{
	char szTime[20] = { 0 };
	char szFechaHoraTrx[32] = { 0 };
	char szHoraTerminal[32] = { 0 };
	char szFechaTerminal[32] = { 0 };
	char szFechaSE[32] = { 0 };
	char szEffectiveDate[32] = { 0 };
	char szAuxBuffer[32 + 1] = { 0 };
	char szAuxBuffer2[32 + 1] = { 0 };

	SVC_CLOCK(0, szTime, 15); //yyyymmddhhmmssw	
	szTime[15] = 0;								

	int i = 0;


	char szCodEst[5];
	
	for(i=0; i < strlen(CodEst); i++)
	{
		if (isdigit(CodEst[i]))
		{
			strncpy(szCodEst, CodEst + i, 5)[5] = 0;
			break;
		}
	}


	memcpy(szFechaHoraTrx, szTime + 4, 2);
	memcpy(&szFechaHoraTrx[2], szTime + 6, 2);
	
	memcpy(&szFechaHoraTrx[4], szTime + 8, 2);
	memcpy(&szFechaHoraTrx[6], szTime + 10, 2);
	memcpy(&szFechaHoraTrx[8], szTime + 12, 2);
	 

	memcpy(szHoraTerminal, szTime + 8, 2);
	memcpy(&szHoraTerminal[2], szTime + 10, 2);
	memcpy(&szHoraTerminal[4], szTime + 12, 2);

	memcpy(szFechaTerminal, szTime + 4, 2);
	memcpy(&szFechaTerminal[2], szTime + 6, 2);

	memcpy(szFechaSE, szTime, 4);
	memcpy(&szFechaSE[4], szTime + 4, 2);
	memcpy(&szFechaSE[6], szTime + 6, 2);

	memcpy(szEffectiveDate, szTime, 4);
	memcpy(&szEffectiveDate[4], "-", 1);
	memcpy(&szEffectiveDate[5], szTime + 4, 2);
	memcpy(&szEffectiveDate[7], "-", 1);
	memcpy(&szEffectiveDate[8], szTime + 6, 2);
	memcpy(&szEffectiveDate[10], "T", 1);
	memcpy(&szEffectiveDate[11], szTime + 8, 2);
	memcpy(&szEffectiveDate[13], ":", 1);
	memcpy(&szEffectiveDate[14], szTime + 10, 2);
	memcpy(&szEffectiveDate[16], ":", 1);
	memcpy(&szEffectiveDate[17], szTime + 12, 2);
	memcpy(&szEffectiveDate[19], "-06:00", 6);

	sprintf(szAuxBuffer, "%c", '0' + nNroBom);
	strcpy(pPAYBackMsg, szAuxBuffer);

	strcat(pPAYBackMsg, "PBREVERSO|");

	if(fRevAcumula == TRUE)
		strcat(pPAYBackMsg, "ACUMULA|");
	else
		strcat(pPAYBackMsg, "REDENCION|");

	// FechaHoraTrx
	strcat(pPAYBackMsg, szFechaHoraTrx);
	strcat(pPAYBackMsg, "|");

	// FechaContable
	strcat(pPAYBackMsg, szFechaTerminal);
	strcat(pPAYBackMsg, "|");

	// FechaCaptura
	strcat(pPAYBackMsg, szFechaTerminal);
	strcat(pPAYBackMsg, "|");

	// NumeroAudit
	strcat(pPAYBackMsg, szPAYBackNumAudit);
	strcat(pPAYBackMsg, "|");

	// CodigoRespuesta
	strcat(pPAYBackMsg, szPAYBackRespuesta);
	strcat(pPAYBackMsg, "|");

	// Compania
	sprintf(szAuxBuffer, "%05d", atoi(szPAYBackCompania));
	strcat(pPAYBackMsg, szAuxBuffer);
	strcat(pPAYBackMsg, "|");

	// N_Caja
	sprintf(szAuxBuffer, "%05d", nNroBom);
	strcat(pPAYBackMsg, szAuxBuffer);
	strcat(pPAYBackMsg, "|");

	// N_Tienda
	if(szCodEst[0])
		strcpy(szAuxBuffer, szCodEst);
	else
		strcpy(szAuxBuffer, "00000");

	strcat(pPAYBackMsg, szAuxBuffer);
	strcat(pPAYBackMsg, "|");

	// N_Empleado
	strcat(pPAYBackMsg, szPAYBackUsuario);	
	strcat(pPAYBackMsg, "|");

	// N_Turno
	strcat(pPAYBackMsg, "00001");
	strcat(pPAYBackMsg, "|");

	// N_Tecla
	strcat(pPAYBackMsg, "000");
	strcat(pPAYBackMsg, "|");

	// N_Ticket
	sprintf(szAuxBuffer, "%020d", atoi(stDespachoItm[0].newtrn));
	strcat(pPAYBackMsg, szAuxBuffer);
	strcat(pPAYBackMsg, "|");

	// Texto_AppPos
	SVC_INFO_PTID(szAuxBuffer2);
	memcpy(szAuxBuffer, szAuxBuffer2 + 1, 8);
	szAuxBuffer[8] = 0x00;
	strcat(pPAYBackMsg, szAuxBuffer);
	strcat(pPAYBackMsg, "|");

	// FechaSE
	strcat(pPAYBackMsg, szFechaSE);
	strcat(pPAYBackMsg, "|");

	// SwitchKey
	sprintf(szAuxBuffer, "%s%02d1%s%s", szCodEst, nNroBom, szFechaTerminal, szHoraTerminal);
	szAuxBuffer[18] = 0x00;
	strcat(pPAYBackMsg, szAuxBuffer);
	strcat(pPAYBackMsg, "|");

	// OriginalSwitchKey
	strcat(pPAYBackMsg, szPAYBackSwitchKeyOrg);
	strcat(pPAYBackMsg, "|");

	// NoTarjeta
	if(szPAYBackCardTrack2[0] != 0)
	{
		// strcpy(szAuxBuffer, strtok(szPAYBackCardTrack2, "=")); 
		strncpy(szAuxBuffer, szPAYBackCardTrack2, 16)[16] = 0; 
		strcat(pPAYBackMsg, szAuxBuffer);
		strcat(pPAYBackMsg, "|");
	}
	else if(szPAYBackBarCode[0] != 0)
	{
		strcat(pPAYBackMsg, szPAYBackBarCode);
		strcat(pPAYBackMsg, "|");
	}

	// PartherShortName
	strcat(pPAYBackMsg, szPAYBackNomCorto);
	strcat(pPAYBackMsg, "|");

	// BranchShortName
	strcat(pPAYBackMsg, szPAYBackAfiliacion);
	strcat(pPAYBackMsg, "|");

	// EffectiveDate
	strcat(pPAYBackMsg, szEffectiveDate);
	strcat(pPAYBackMsg, "|");

	// ReceiptNumber
	strcat(pPAYBackMsg, szPAYBackNumReferencia);
	strcat(pPAYBackMsg, "|");

	// RedemptionNumber
	strcat(pPAYBackMsg, szPAYBackNumReferencia);
	strcat(pPAYBackMsg, "|");

}


/*
 * ===========================================================================
 * Programa		: pago y facturacion con tarjeta
 * Creacion		: 01-Enero-2015
 * Comentarios	:
 * ===========================================================================
 *
 *              Autor:	     	Comentario:
 * ---------------------------------------------------------------------------
 *	Ctorres / Tadeo Aguilar		Código inicial
 * 							
 *
 * ===========================================================================
 */

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <svc.h>
#include <cardslot.h>
#include <aclconio.h>
#include <aclutil.h>
#include <aclstr.h>
#include <applidl.h>
extern "C"		
{
#include <vxemvap.h>
}

#include <ctype.h>
#include <libvoy.h>

#include <svc_net.h>
#include <vmc.h>			
#include <vmcClaIns.h>		/

#if defined(__cplusplus)	
#undef SVC_KEY_TXT
#endif

#include <main.h>
#include <ATIOMSGERR.h>
#include <ATIOMsg.h>
#include <ATIOComm.h>
#include <ATIOEMVProc.h>
#include <ATIOPrinter.h>
#include <ATIOGraphics.h>
#include <ATIOUI.h>
#include <ATIOCard.h>
#include <ATIOiButton.h>

#include <qrencode.h>

#include <sgatiohs.h>

#include <atiosmartbt.h>
#include <ATIOPayback.h>	
#include <ATIOSIVEMAX.h>	
#include <ATIOLMS.h>		
#include <ATIOSODEXO.h>	
#include <ATIOLogs.h>	
extern "C"
{
/**** Librería Smartpayment ****/
#include <splib.h>
}

/*-----------------------------------------------------------------*
 * VARIABLES GLOBALES                                              *
 *-----------------------------------------------------------------*
 * Parametros recibidos del Host                                   *
 *- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*/
unsigned short Red;
unsigned short Grupo;
unsigned short Estacion;
unsigned short ClaveAut;
char TaxLit[9];
double TaxVal;
int TaxDis;
int PreNet;
int DenVeh;
int ODRAut;
int USDMod;
char NotLit[9];
char MdaLit[11];
long lnEvents; /* Switch para atrapar el numero de evento */
char CveCliLit[11];
char SerSucLit[11];
int CtlDes;
int CtlDesTik;
int CopAdi;
int inCommHandle;
short ModelTerm;
int TarBan;
char Afiliacion[16];
char LastUpdate[16];
unsigned char CtrlError;
short CtrlPin;
int nPumpGnG;
char imptkt[2] = { 0 }; 

int DPF = 0;
char CodEst[7] = { 0 };		
char ValCodEst[7];

char CodTar[4];
char DenTar[17];
char UniTar[03];
//char IepTar[5];	/* Se elimina la impresion del TAR  */
int nPumpVale[8] = { 0 }; 
int ValePres[8] = { 0 };	/*  Corregido Vales */
char CodCli[10];
char NomCli[8][50];		/*  Corregido Vales */
int inCntPumpVale = 0;	/*  Corregido Vales */


BOOL contGNG;
BOOL tarGNG;
char buffCntGNG[100];
char buffTarGNG[100];
char buffTxtGNG[100];
char prdGNG[4] = { 0 }; 


char PermCre[19] = { 0 };		
int	 SinPieAtio = 0;


int ReadValeCnt = 0;
int ReadValeCntB = 0;


char szBomUltDes[16]; 

/*-----------------------------------------------------------------*/
int hTKT = -1;
int hMSJ = -1;
int hPRD = -1;
int hPumpData = -1;

POSDespacho stDespachoItm[MaxIdxItm];
POSProducto stProducto;
POSChofer stChofer;
POSCliente stCliente;
POSCliente CliVale[8]; /*  Corregido Vales */
POSClienteExtra stClientEx;
POSClienteExtra ClxVale; 
POSControl stControl;
POSResponsable stResponsable;
POSResponsable stResVale; 
POSResponsableX stResponsableEx;
GNGtext		GNGtexto[MaxIdxItm]; 
long Opt;
unsigned long Odm;
char Aut[21];/* ODRAUT de numérico a alfanumérico: unsigned long Aut;*/

int nFacL = 33;
int nCliL = 7;
int nCliC = 12;
int nRfcL = 8;
int nRfcC = 92;
int nFchL = 9;
int nFchC = 119;
int nDi1L = 8;
int nDi1C = 12;
int nDi2L = 8;
int nDi2C = 56;
int nDi3L = 9;
int nDi3C = 12;
int nItmL = 13;
int nCanC = 27;
int nPrdC = 43;
int nPreC = 95;
int nMtoC = 115;
int nMsjL = 17;
int nMsjC = 42;
int nLetL = 21;
int nLetC = 42;
int nSubL = 23;
int nSubC = 115;
int nTaxL = 24;
int nTaxC = 115;
int nTotL = 25;
int nTotC = 115;
int nPgoL = 23;
int nPgoC = 42;
int nCveL = 5;
int nCveC = 12;
int nCopH = 0;

/*- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*
 * Parametros almacenados en variables de ambiente de la OMNI      *
 *- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*/
int Terminal;
int MANMode;
int PINMode;
int NIPMode;
int BOMMode;
int CLXCode;
int IPRMode;
int ESCMode;
int IDTMode;
int HWRType;
int TAGType;
int IDVMode;
int LIMMode;
int SCMode;
int FAMMode;
int DDVMode;
int BARMode;
int KBOMode;
int LGOMode = 0;
BOOL fCOMM6ModeOn;
int ICBMode;
int SNCMode;
int USBMode;
int IEPMode;
int TIKMode;
int NRPMode; 
int ABTMode; 
int AB1Mode; 
int AB2Mode; 
int STVMode; 
int SESPMode; 
BOOL fODMMode;	

/*- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*
 * Variables para control de Smartpayment de SmartBT               *
 *- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*/
BOOL fSBTModeOn = FALSE;
BOOL fSBTCardTran = FALSE;
BOOL fSBTCardOperation = FALSE;		/*  Fix Smartpayment */
BOOL fSBTReciboBanco = FALSE;
BOOL fTipMode = FALSE;	/*  Agregado propina */
long lnTipAmount = 0;	/*  Agregado propina */

char szSBTIDCliente[32 +1 ] = { 0 };	
char szSBTIDPuntoVenta[32 +1 ] = { 0 };	
char szSBTTipoServicio[2 + 1] = { 0 };	
char szSBTTranType[32 + 1] = { 0 };
char szSBTKeyBuffer[2048 + 1] = { 0 };
char szSBTKeyLenght[8 + 1] = { 0 };
char szSBTCodAprobacion[4 + 1] = { 0 };
char szSBTMsgAprobacion[64 + 1] = { 0 };
char szSBTNumReferencia[32 + 1] = { 0 };
char szSBTNumAprobacion[32 + 1] = { 0 };
char szSBTNomBanco[32 + 1] = { 0 };
char szSBTMarcaTarjeta[64 + 1] = { 0 };
char szSBTTipoTarjeta[64 + 1] = { 0 };
char szSBTNumAfiliacion[32 + 1] = { 0 };
char szSBTNumSecuencial[16 + 1] = { 0 };
char szSBTTagLen[4 + 1] = { 0 };
char szSBTTagBuffer[512 + 1] = { 0 };
char szSBTExtraInfo[32 + 1] = { 0 };

BOOL fSBTSDXModeOn = FALSE;					
char szSBTSDXAfiliacion[32 + 1] = { 0 };	
char szSBTSDXIDPuntoVenta[32 + 1] = { 0 };	
char szSBTSDXMsgHost[128 + 1] = { 0 };
char szSBTSDXCodigoAprobacion[2 + 1] = { 0 };	
char szSBTSDXAutorizacion[9 + 1] = { 0 };
char szSBTSDXNumLote[12 + 1] = { 0 };
char szSBTSDXNumTransaccion[9 + 1] = { 0 };
char szSBTSDXSaldo[15 + 1] = { 0 };
char szSBTSDXAfiliado[9 + 1] = { 0 };
BOOL fSBTSDXTarjeta = FALSE;
char szSBTSDXTarjeta[16 + 1] = { 0 };
char szSBTSDXFolio[9 + 1] = { 0 };
char szSBTSDXPlacas[12 + 1] = { 0 };
char szSBTSDXKilometraje[9 + 1] = { 0 };
char szSBTSDXRuta[10 + 1] = { 0 };
char szSBTSDXStatusLote[128 + 1] = { 0 };	


/*- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*
 * Variables para control del PINPad                               *
 *- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*/
int hPIN;
//int hUSB;  
int hUSBHID;
int PINiBytes;
char PINiBuffer[128];
char PINoBuffer[128];
int PINStatus = PS_WAITING;
BOOL PINAuto = TRUE;
BOOL PINKeyb = FALSE;

/*- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*
 * Variables para control del lector de tarjetas                   *
 *- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*/
int hCardReader;
BOOL CRDok;
int CRDStatus = CS_WAITING;
char CRDiBuffer[400];
int CRDiCount;
BOOL SCUsed;
BOOL CTRLPump;
int PumpBK;
int NroBomBot;
BOOL CTRLTicket; /* Modif. temporal para controlar ticket y factura */
long gTar;
char CRDiTrack2[100];
char CRDiTrack1[100];
char CRDCVV[12 + 1];
BOOL RESok;
int BomSet;
long VehSet;
long ChoSet;
unsigned long OdmSet;
BOOL DatCap;
unsigned long OdmCap;
unsigned long LimCap;

unsigned char strbank[2048];
int lentags;
BOOL fFallbackAllowed = EMV_FALSE;		
char msjgng[64];
char MtoUSD[300];

int CopiaOri; 
int CopiaAdi; 


double dAuxMtoTot = 0.0;
double dAuxMtoPar = 0.0;
double dMtoTotRes = 0.0;
int    CtlPgoPar = 0;

int ImpFac; 

char bufferr[100] = { '\0' };
int PosEntryMode;
short bomvale = 0;
short limpiapan = 0;
short esgng = 0;
short perrgng = 0;
short swta = 0;
short ctrlnip = 0;
unsigned long ctrlts = 0;
int sodexo;

/*- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*
 * Otras variables globales                                        *
 *- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*/
int hCOM;
int hClock;
int nMaxLin;
int nMaxCol;
int nClockCounter;
BOOL bProducts;

int BytesReceived = 0;
static unsigned char mensaje[2048 + 1];
static char respuesta[2048 + 1];
//static char resp_port[2048 + 1];

unsigned char pumps;

POSDespacho Des[MaxIdxDes + 1];
int IdxDes = 0;
int CntDes = 0;

//variable QR_code 10/04/13
char ScreenBuffer[128 * 64 / 8];
char szWEBidEncQR[256 + 1] = { 0 };
BOOL fWEBidEncQR = FALSE;

short shLoyaltyCard = 0;	


BOOL fPAYBackOn = FALSE;
BOOL fPAYBackOperation = FALSE;
char szPAYBackCardTrack1[100 + 1] = { 0 };
char szPAYBackCardTrack2[100 + 1] = { 0 };
char szPAYBackBarCode[100 + 1] = { 0 };
char szPAYBackUsuario[16 + 1] = { 0 };	
char szPAYBackTotalPuntos[16 + 1] = { 0 };
char szPAYBackNumReferencia[48 + 1] = { 0 };
char szPAYBackBalancePuntos[16 + 1] = { 0 };
char szPAYBackRespuesta[128 + 1] = { 0 };
char szPAYBackErrorMsg[128 + 1] = { 0 };
char szPAYBackErrorCode[128 + 1] = { 0 };
char szPAYBackNumeroTrans[6 + 1] = { 0 };
BOOL fPAYBackPagoPuntos = FALSE;
BOOL fPAYBackError = FALSE;
double dPAYBackMontoTotal = 0;
char szPAYBackCompania[16 + 1] = { 0 };
char szPAYBackNomCorto[64 + 1] = { 0 };
char szPAYBackAfiliacion[32 + 1] = { 0 };
char szPAYBackMensaje[512 + 1] = { 0 };
char szPAYBackNumAudit[6 + 1] = { 0 };
char szPAYBackNumRef[12 + 1] = { 0 };
char szPAYBackSwitchKeyOrg[18 + 1] = { 0 };
char szPAYBackCodigoAuth[6 + 1] = { 0 };
char szPAYBackCodigoResp[128 + 1] = { 0 };

BOOL fSIVEMAXOn = FALSE;
BOOL fSIVEMAXOperation = FALSE;
BOOL fSIVEMAXPagoPuntos = FALSE;
BOOL fSIVEMAXError = FALSE;
char szSIVEMAXCardTrack1[100 + 1] = { 0 };
char szSIVEMAXCardTrack2[100 + 1] = { 0 };
char szSIVEMAXBarCode[100 + 1] = { 0 };

char szSIVEMAXRespType[16 + 1] = { 0 };			// m_Resp_type
char szSIVEMAXNumReferencia[48 + 1] = { 0 };	// m_Resp_reference
char szSIVEMAXBalancePuntos[16 + 1] = { 0 };	// m_Resp_balance_points
char szSIVEMAXBalanceMonto[16 + 1] = { 0 };		// m_Resp_balance_amount
char szSIVEMAXBalanceCurrency[16 + 1] = { 0 };	// m_Resp_balance_currency
char szSIVEMAXRespDate[32 + 1] = { 0 };			// m_Resp_date
char szSIVEMAXRespTitle[42 + 1] = { 0 };		// m_Resp_title
char szSIVEMAXRespDetail[256 + 1] = { 0 };		// m_Resp_detail
char szSIVEMAXRespPuntos[16 + 1] = { 0 };		// m_Resp_points	
char szSIVEMAXRespMonto[16 + 1] = { 0 };		// m_Resp_amount

char szSIVEMAXRespErrorID[8 + 1] = { 0 };	// m_Resp_error_id
char szSIVEMAXErrorCode[128 + 1] = { 0 };

BOOL fLMSOn = FALSE;
BOOL fLMSPagoPuntos = FALSE;
BOOL fLMSOperation = FALSE;
BOOL fLMSError = FALSE;
char szLMSCardTrack1[128 + 1] = { 0 };
char szLMSCardTrack2[128 + 1] = { 0 };
char szLMSCodigoError[128 + 1] = { 0 };
char szLMSMensajeError[128 + 1] = { 0 };
char szLMSTarjetaCliente[32 + 1] = { 0 };
char szLMSNumCotizacion[128 + 1] = { 0 };
char szLMSSaldoPuntos[15 + 1] = { 0 };
char szLMSPuntosAcumCompra[15 + 1] = { 0 };
char szLMSPuntosCanjeCompra[15 + 1] = { 0 };
char szLMSPuntosTotalCompra[15 + 1] = { 0 };	
char szLMSSaldoPuntosFinal[15 + 1] = { 0 };
char szLMSSaldoPesosFinal[15 + 1] = { 0 };

BOOL fIQROn; /* v.4.12.11 09DIC16 - IQR */

char szBankCardTrack1[100 + 1] = { 0 };		
char szBankCardTrack2[100 + 1] = { 0 };		

char Ctlestado[1+1] = { 0 }; 

/*- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*
 * Literales                                                       *
 *- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*/

//char* LIT_BombaVenta = "BOMBA:#%d %s\nVENTA: $%.2lf+%.2lf";

unsigned long value = 0, valueexc = 0, valueres = 0;
unsigned long seqid;
unsigned short fecha;
short ctrlupd;


/*----------------------------   ----------------------------------
 Function : LOG_HEX_Data
 Description :dummy
 Parameters :
 Returns :
 Globals :
 Notes :
 Modification History :
 #     Date      Who                     Description
 ----- -------- ---------- ----------------------------   ------
 ----------------------------   -----------------------------------*/
void LOG_HEX_Data(char *in_buf, int offset, int num_bytes, int ascii_rep)
{
	int index = 0;
	char temp_buf[10];
	char disp_buf[2048];

	if (ascii_rep == TRUE)
	{
		if (num_bytes > 16)
		{
			// disp_buf overflow!
			inATIOLogBuffer("LOG_HEX_Data ERR - num_bytes=%d > 15", num_bytes);
			return;
		}
	}
	else
	{
		if (num_bytes > 23)
		{
			// disp_buf overflow!
			inATIOLogBuffer("LOG_HEX_Data ERR - num_bytes=%d > 20", num_bytes);
			return;
		}
	}

	MEMCLR(temp_buf, sizeof(temp_buf));
	MEMCLR(disp_buf, sizeof(disp_buf));
	sprintf(temp_buf, "%04X ", offset);
	strcat(disp_buf, temp_buf);
	for (index = 0; index < num_bytes; ++index)
	{
		MEMCLR(temp_buf, sizeof(temp_buf));
		sprintf(temp_buf, "%02X ", in_buf[offset + index]);
		strcat(disp_buf, temp_buf);

		if (!((index + 1) % 8))
			strcat(disp_buf, "   ");
	}

	if (ascii_rep == TRUE)
	{
		char c;
		strcat(disp_buf, "- ");
		for (index = 0; index < num_bytes; ++index)
		{
			MEMCLR(temp_buf, sizeof(temp_buf));
			c = (in_buf[offset + index] >= 0x20 && in_buf[offset + index] <= 0x7F) ? in_buf[offset + index] : '.';
			sprintf(temp_buf, "%c", c);
			strcat(disp_buf, temp_buf);
		}
	}

	inATIOLogBuffer("%s", disp_buf);
}

/*----------------------------   ----------------------------------
 Function : LOG_HEX_Buf
 Description :Only for debug the packet
 Parameters :
 Returns :
 Globals :
 Notes :
 Modification History :
 #     Date      Who                     Description
 ----- -------- ---------- ----------------------------   ------
 ----------------------------   -----------------------------------*/
void LOG_HEX_Buf(char *in_buf, int num_bytes, char *title)
{
	int offset = 0;
	int r = 0;

	if (strlen(title) > 0)
	{
		inATIOLogBuffer("%s (%d):", title, num_bytes);
	}

	do
	{
		LOG_HEX_Data(in_buf, offset, 16, TRUE);
		offset += 16;
	} while (offset < num_bytes);

	r = num_bytes - offset;
	if (r)
		LOG_HEX_Data(in_buf, offset, r, TRUE);
}

/*- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*
 * Función para guardar en el archivo de datos por bomba           *
 *- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*/
void TraceVersion(int nWait)
{
	char szModel[32];
	char trace[2048];
	char buff[16];
	int rsp;

	memset(trace, 0, sizeof(trace));
	memset(szModel, 0, sizeof(szModel));

	SVC_INFO_MODELNO(szModel);

	vdATIOLimpiaDisplay();
	if(shTermModel != E355_ID)	
		rsp = ReadKeyb("IMPRIME VERSION ? ", 2, 0, INPUT_YES_NO, FALSE, buff, 20, FALSE);
	else
		rsp = kbd_cancel;		

/*  Fix Printer Se inicia el handle y se mantiene abierto el puerto */

	
}

/*- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*
 * Función para guardar en el archivo de datos por bomba           *
 *- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*/

BOOL PutPumpData(unsigned char pump, POSPumpData *data)
{
	long lnRecord = pump * sizeof(POSPumpData);

	//LOG_PRINTF(("--PutPumpData--"));

	lseek(hPumpData, lnRecord, SEEK_SET);
	if (write(hPumpData, (char *) data, sizeof(POSPumpData)) != sizeof(POSPumpData))
		return FALSE;

	return TRUE;
}

/*- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*
 * Función para recuperar del archivo de datos por bomba           *
 *- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*/
BOOL GetPumpData(unsigned char pump, POSPumpData *data)
{
	long record = pump * sizeof(POSPumpData);

	//LOG_PRINTF(("--GetPumpData--"));

	lseek(hPumpData, record, SEEK_SET);
	if (read(hPumpData, (char *) data, sizeof(POSPumpData)) != sizeof(POSPumpData))
	{
		vdATIOLimpiaSinTitulo();
		vdATIODisplayString("No leyo la bomba", 5, CENTER_ALIGN);
		error_tone();
		SVC_WAIT(WAIT_ERROR);
		return FALSE;
	}

	return TRUE;
}


/*- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*
 * Función para invertir el orden de los bytes                     *
 *- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*/
short ReverseS(short shtsrc)
{
	short shtdes;
	char *src = (char *) &shtsrc;
	char *des = (char *) &shtdes;

	des[0] = src[1];
	des[1] = src[0];

	return shtdes;
}

long ReverseL(long lngsrc)
{
	long lngdes;
	char *src = (char *) &lngsrc;
	char *des = (char *) &lngdes;

	des[0] = src[3];
	des[1] = src[2];
	des[2] = src[1];
	des[3] = src[0];

	return lngdes;
}

/*- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*
 * Función para agregar datos al vector de salida al PinPad        *
 *- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*/
int PINoBufferAddS(int pos, short dat)
{
	char *d = (char *) &dat;

	PINoBuffer[pos++] = (d[1] >> 4) & 0x0F;
	PINoBuffer[pos++] = d[1] & 0x0F;
	PINoBuffer[pos++] = (d[0] >> 4) & 0x0F;
	PINoBuffer[pos++] = d[0] & 0x0F;

	return pos;
}

int PINoBufferAddL(int pos, long dat)
{
	char *d = (char *) &dat;

	PINoBuffer[pos++] = (d[3] >> 4) & 0x0F;
	PINoBuffer[pos++] = d[3] & 0x0F;
	PINoBuffer[pos++] = (d[2] >> 4) & 0x0F;
	PINoBuffer[pos++] = d[2] & 0x0F;
	PINoBuffer[pos++] = (d[1] >> 4) & 0x0F;
	PINoBuffer[pos++] = d[1] & 0x0F;
	PINoBuffer[pos++] = (d[0] >> 4) & 0x0F;
	PINoBuffer[pos++] = d[0] & 0x0F;

	return pos;
}

int PINoBufferEnd(int pos)
{
	PINoBuffer[pos++] = 0x1C;
	PINoBuffer[pos++] = 0x00;

	return pos;
}

/*- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*
 * Función para buscar un producto                                 *
 *- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*/
short FindProductExt(short cod)
{
	lseek(hPRD, 0L, SEEK_SET);

	memset(&stProducto, 0, sizeof(stProducto));

	while (read(hPRD, (char *) &stProducto, sizeof(stProducto)) == sizeof(stProducto))
	{
		if ((short) atoi(stProducto.cod) == cod)
			return TRUE;

		memset(&stProducto, 0, sizeof(stProducto));
	}
	return FALSE;
}

short FindProductInt(short cod)
{
	//LOG_PRINTF(("--FindProductInt--"));

	lseek(hPRD, 0L, SEEK_SET);

	memset(&stProducto, 0, sizeof(stProducto));

	while (read(hPRD, (char *)&stProducto, sizeof(stProducto)) == sizeof(stProducto))
	{
		if ((short)atoi(stProducto.cdp) == cod)
		{
			return TRUE;
		}

		memset(&stProducto, 0, sizeof(stProducto));
	}
	return FALSE;
}

short FindProductBar(char *bar)
{
	lseek(hPRD, 0L, SEEK_SET);

	memset(&stProducto, 0, sizeof(stProducto));
	while (read(hPRD, (char *) &stProducto, sizeof(stProducto)) == sizeof(stProducto))
	{
		if (!strcmp(bar, sRemEsp(stProducto.bar)))
			return TRUE;

		memset(&stProducto, 0, sizeof(stProducto));
	}

	return FALSE;
}
	return inRetVal;
}



/*-----------------------------------------------------------------*
 * FUNCION PRINCIPAL                                               *
 *-----------------------------------------------------------------*/
void vdSGATIOHSMain(int handle, char *host)
{
	POSPumpData PumpData;
	int p;
	int i;
	char szDisplayBuffer[21 + 1] = { 0 };


	CtrlTiming = 0;
	DetEve = 0;
	inCommHandle = handle;

	/* Apagado del sonido de las teclas */
	key_beeps(0);

	/* Configuración del video */
	nMaxCol = 21;
	nMaxLin = 8;

	/* Determinacion del numero de serie y activacion */
	while (TRUE)
	{
		BOOL bERR;
		char szUnitUID[10];
		char szUnitKEY[10];
		char szClock[20] = { 0 };
		unsigned char nCRC;
		int i, j;

		bERR = FALSE;
		memset(szUnitUID, 0, sizeof(szUnitUID));
		memset(szUnitKEY, 0, sizeof(szUnitKEY));
		SVC_INFO_PTID(szUnitUID);
		szUnitUID[0] = '0';
		if (!strcmp(szUnitUID + 3, "000000"))
		{
			int hUID;
			if ((hUID = open("UID.SYS", O_RDONLY)) != -1)
			{
				read(hUID, szUnitUID, 9);
				szUnitUID[9] = 0;
			}
			else
			{
				SVC_CLOCK(0, szClock, 15);
				strcpy(szUnitUID, szClock + 6);
				szUnitUID[9] = 0;
				if ((hUID = open("UID.SYS", O_CREAT | O_TRUNC | O_WRONLY)) != -1)
				{
					write(hUID, szUnitUID, 9);
					close(hUID);
				}
			}
		}

		strcpy(szUnitKEY, szGetEnvVar("#KEY"));

		for (i = 8; i >= 0; i--)
		{
			nCRC = szUnitUID[8 - i] - '/' * i + i;
			for (j = i - 1; j > 0; j--)
				nCRC += szUnitUID[j] - '0' * j + j;
			while (nCRC > 9)
				nCRC -= 9;
			nCRC += '0';
			if (szUnitKEY[8 - i] != nCRC)
			{
				bERR = TRUE;
				break;
			}
		}

		if (!bERR)
			break;

		sprintf(szDisplayBuffer, "UNIDAD %s SIN LICENCIA!", szUnitUID);
		vdATIODisplayString(szDisplayBuffer, 1, LEFT_ALIGN);

		if (ReadKeyb("CLAVE LICENCIA ? ", 9, 0, INPUT_NUM, 0, szUnitKEY, 0, FALSE) == kbd_enter)
			vdPutEnvVarStr("#KEY", szUnitKEY);
	}



	/* Determinacion para activar servicios de SmartBT */
	if(inGetEnvVar("#SBT") == 1)
	{
		fSBTModeOn = TRUE;
		if(inGetEnvVar("#SBTRECBAN") == 1)	
			fSBTReciboBanco = TRUE;
		else
			fSBTReciboBanco = FALSE;
	}
	else
	{
		fSBTModeOn = FALSE;
		fSBTReciboBanco = FALSE;	
	}

	if(inGetEnvVar("#PAYBACK") == 1)
		fPAYBackOn = TRUE;
	else
		fPAYBackOn = FALSE;

	/* Determinacion para Inhibir el icono del Vehiculo - Para Vx680 */
	STVMode = inGetEnvVar("#STV");	

	/* Determinacion para Inhibir la impresion de espacios en el ticket */
	SESPMode = inGetEnvVar("#SESP");

	/* Determinacion para solicitar propina */
	if(inGetEnvVar("#SBTTIP") == 1)
		fTipMode = TRUE;
	else
		fTipMode = FALSE;
	/* Determinacion para solicitar propina */

	if(inGetEnvVar("#SINODM") == 1)
		fODMMode = TRUE;
	else
		fODMMode = FALSE;

	if(inGetEnvVar("#SIVEMAX") == 1)
		fSIVEMAXOn = TRUE;
	else
		fSIVEMAXOn = FALSE;

	if(inGetEnvVar("#LMS") == 1)
		fLMSOn = TRUE;
	else
		fLMSOn = FALSE;


	if(inGetEnvVar("#IQR") == 1)
		fIQROn = TRUE;
	else
		fIQROn = FALSE;
	

	/* Determinacion de la familia del iButton*/
	if (TAGType)
	{
		do
		{
			FAMMode = inGetEnvVar("#FAMILY");
			if (!FAMMode)
			{
				vdATIOLimpiaSinTitulo();
				vdATIODisplayString("** Falta variable **", 4, CENTER_ALIGN);
				vdATIODisplayString("**    FAMILY      **", 5, CENTER_ALIGN);
				SVC_WAIT(WAIT_ERROR);
			}
			else
			{
				if (FAMMode != 1 && FAMMode != 6)
				{
					vdATIOLimpiaSinTitulo();
					vdATIODisplayString("* Parametro FAMILY *", 4, CENTER_ALIGN);
					vdATIODisplayString("*   INVALIDO       *", 5, CENTER_ALIGN);
					SVC_WAIT(WAIT_ERROR);
				}
			}
		} while (FAMMode != 1 && FAMMode != 6);
	}

	/* Abrimos el puerto pin/bar */
	if (!PINMode)
	{
		if(fCommIP == TRUE)
		{
			put_env("*KEYBOARD", "", 0);
			fATIOOpenPIN();
		}
	}

	if(USBMode)
	{
		if(shTermModel != E355_ID)	
		{
			put_env("*KEYBOARD", "3", 1);
			fATIOOpenUSBHID();
		}
		else
		{

		}
	}
	else
	{
		if(shTermModel == E355_ID)
		{
			int inRetVal = 0;

			inRetVal = vmcInit();

			if(inRetVal == VMC_OK)
			{
				inRetVal = vmcSubscribeApp(128);

				if(inRetVal == VMC_OK)
				{
					vdATIODisplayString("Iniciando VMC OK", 4, CENTER_ALIGN);
					SVC_WAIT(WAIT_NORMAL);
					SVC_WAIT(WAIT_NORMAL);

					inRetVal = vmcBcDeviceOpen();

					if(inRetVal == VMC_OK)
					{
						vdATIODisplayString("Inicializando   ", 3, CENTER_ALIGN);
						vdATIODisplayString("Codigo de Barras", 4, CENTER_ALIGN);
						vdATIODisplayString("Espere un       ", 5, CENTER_ALIGN);
						vdATIODisplayString("Momento.....    ", 6, CENTER_ALIGN);
						SVC_WAIT(35000);
					}
					else
					{
						vdATIODisplayString("Error iniciando", 4, CENTER_ALIGN);
						vdATIODisplayString("Codigo de Barras", 5, CENTER_ALIGN);
						SVC_WAIT(WAIT_ERROR);
					}
				}
			}
			else
			{
				vdATIODisplayString("Error Iniciando VMC", 4, CENTER_ALIGN);
				error_tone();
				SVC_WAIT(WAIT_ERROR);
			}

			if(IPRMode == 0)
				vdBTPairNewPrinter();
		}
	}


	/* Inicializamos el puerto para TAG */
	if (TAGType)
	{
		vdATIOLimpiaSinTitulo();
		while (!InitTAG())
			vdATIODisplayString("Conectando iButton", 4, LEFT_ALIGN);
	}

	/* Abrimos el lector de tarjetas */
	fOpenCardReader();

	/* Abrimos el puerto ICC1 TI */
	OpenSCRD();

	/* Abrimos archivo de errores */
	hATIOErrMsg = open(FILE_ERRMSG, O_RDONLY);

	/* Abrimos archivo de literales */
	hATIOMsg = open(FILE_MSG, O_RDONLY);

	/* Abrimos e inicializamos archivo de datos por bomba */
	hPumpData = open(FILE_PUMPDATA, O_CREAT | O_RDWR);

	hClock = open(DEV_CLOCK, 0);

	/* Inicialización de variables globales */
	memset(&PumpData, 0, sizeof(PumpData));
	for (p = 1; p <= 60; p++)
		PutPumpData(p, &PumpData);

	memset(Des, 0, sizeof(Des));

	/* Lectura de la configuracion del servidor */
	vdATIODisplayString("Conectando...", 4, LEFT_ALIGN);

	int inXPos = strlen("Conectando...");
	int inYPos = 4;

	if(shTermModel != E355_ID)	
	{
		for (i = 0; i < Terminal; i++)
		{
			vdAvanceProc(&inXPos, &inYPos, ".");
		}
	}

	/* Carga el archivo de configuracion, de errores y del ticket */
	ReadConfig();
	TraceVersion(5000);

	if(fSBTModeOn == TRUE)
	{
		vdATIOLimpiaDisplay();
		vdATIODisplayString("Conectando SBT...", 1, LEFT_ALIGN);

		if(inATIOSmartBTUpdateKey() != 0)
		{
			vdATIOLimpiaDisplay();
			vdATIODisplayString("Error inicializacion", 3, CENTER_ALIGN);
			vdATIODisplayString("de llaves Host SBT.", 4, CENTER_ALIGN);
			vdATIODisplayString("Procesamiento de", 6, LEFT_ALIGN);
			vdATIODisplayString("tarjetas inactivo.", 7, LEFT_ALIGN);
			error_tone();
			SVC_WAIT(5000);
			fSBTCardTran = FALSE;
		}
		else
		{
			vdATIOLimpiaDisplay();
			vdATIODisplayString("Inicializacion de", 3, CENTER_ALIGN);
			vdATIODisplayString("llaves SBT exitosa.", 4, CENTER_ALIGN);
			vdATIODisplayString("Procesamiento de", 6, LEFT_ALIGN);
			vdATIODisplayString("tarjetas activo.", 7, LEFT_ALIGN);
			normal_tone();
			SVC_WAIT(5000);
			fSBTCardTran = TRUE;
		}

		if(fSBTSDXModeOn == TRUE)
			vdATIOSodexoApertura();
	}

	if(fPAYBackOn)
	{
		if(inATIOLoadPayback() != 0)
		{
			vdATIOLimpiaDisplay();
			vdATIODisplayString("Campos incompletos", 3, CENTER_ALIGN);
			vdATIODisplayString("en configuracion.", 4, CENTER_ALIGN);
			vdATIODisplayString("SGPS para PAYBACK.", 5, CENTER_ALIGN);
			error_tone();
			SVC_WAIT(5000);

			fPAYBackOn = FALSE;
		}
	}

	int inRetValEMV = 0;

	inRetValEMV = inVXEMVAPSCInit();
	inRetValEMV = inVXEMVAPInitCardslot();

	/* Ciclo de procesamiento (sin fin) */
	vdProcesoPrincipal();
}

int inATIOLoyaltyCardSelect(void)
{
	int inRetOption = NONE_OPT;

	vdATIOFlushKeyboard();

	while(read_event() != 0)
		;

	if(fPAYBackOn == TRUE && fSIVEMAXOn == TRUE && fLMSOn == TRUE)
	{
		unsigned char ucKey;

		vdATIOLimpiaDisplay();

		if(shTermModel == E355_ID)
		{
			vdATIODisplayString("Seleccione Tarjeta", 1, CENTER_ALIGN);
			vdATIODisplayString("T1 - PAYBACK", 3, LEFT_ALIGN);
			vdATIODisplayString("T2 - SIVEMAX", 5, LEFT_ALIGN);
			vdATIODisplayString("T3 - GASONLINE", 7, LEFT_ALIGN);
			vdATIODisplayString("X - Ninguna", 8, RIGHT_ALIGN);

			ucKey = inATIOKeyPressed();

			if(ucKey == kbd_1)
				ucKey = kbd_f6;
			else if(ucKey == kbd_2)
				ucKey = kbd_f7;
			else if(ucKey == kbd_3)
				ucKey = kbd_f8;
		}
		else if(shTermModel == VX680_ID)
		{
			int inCurrX;
			int inCurrY;

			vdATIOPantallaMenuSelTarj1();

			while (TRUE)
			{
				lnEvents = -1;
				lnEvents = wait_event();

				inCurrX = inCurrY = 0;

				if (lnEvents & EVT_CONSOLE)
				{
					//break;
				}
				else
					continue;

				if (lnEvents & EVT_CONSOLE)
				{
					int inButtonTouched;

					while(read_event() != 0)
						;

					if(fATIOScreenTouched(&inCurrX, &inCurrY))
						inButtonTouched = shButtonTouched(stScreen, MENU_TARJ_LEALTAD1, inCurrX, inCurrY);
					else
						inButtonTouched = 0;

					if (inButtonTouched >= 2 && inButtonTouched <= 5)
					{
						if (inButtonTouched == 2)
						{
							lnEvents = 0;
							ucKey = kbd_f6;
						}

						if (inButtonTouched == 3)
						{
							lnEvents = 0;
							ucKey = kbd_f7;
						}

						if (inButtonTouched == 4)
						{
							lnEvents = 0;
							ucKey = kbd_f8;
						}

						if (inButtonTouched == 5)
						{
							lnEvents = 0;
							ucKey = kbd_cancel;
						}
						break;
					}
				}
			}
		}
		else
		{
			vdATIODisplayString("Seleccione Tarjeta", 1, CENTER_ALIGN);
			vdATIODisplayString("PAYBACK >>", 3, RIGHT_ALIGN);
			vdATIODisplayString("SIVEMAX >>", 5, RIGHT_ALIGN);
			vdATIODisplayString("GASONLINE >>", 7, RIGHT_ALIGN);
			vdATIODisplayString("X - Ninguna", 8, LEFT_ALIGN);

			ucKey = inATIOKeyPressed();
		}

		if(ucKey == kbd_f6)
		{
			inRetOption = PAYBACK_OPT;
		}
		else if(ucKey == kbd_f7)
		{
			inRetOption = SIVEMAX_OPT;
		}
		else if(ucKey == kbd_f8)
		{
			inRetOption = GASONLINE_OPT;
		}
		else
		{
			inRetOption = NONE_OPT;
			fPAYBackOperation = FALSE;
			fSIVEMAXOperation = FALSE;
			fLMSOperation = FALSE;
		}
	}
	else if(fPAYBackOn == TRUE && fSIVEMAXOn == TRUE && fLMSOn == FALSE)
	{
		unsigned char ucKey;

		vdATIOLimpiaDisplay();
		if(shTermModel == E355_ID)
		{
			vdATIODisplayString("Seleccione Tarjeta", 1, CENTER_ALIGN);
			vdATIODisplayString("T1 - PAYBACK", 3, LEFT_ALIGN);
			vdATIODisplayString("T2 - SIVEMAX", 5, LEFT_ALIGN);
			vdATIODisplayString("X - Ninguna", 8, RIGHT_ALIGN);

			ucKey = inATIOKeyPressed();

			if(ucKey == kbd_1)
				ucKey = kbd_f6;
			else if(ucKey == kbd_2)
				ucKey = kbd_f7;
		}
		else if(shTermModel == VX680_ID)
		{
			int inCurrX;
			int inCurrY;

			vdATIOPantallaMenuSelTarj2();

			while (TRUE)
			{
				lnEvents = -1;
				lnEvents = wait_event();

				inCurrX = inCurrY = 0;

				if (lnEvents & EVT_CONSOLE)
				{
					//break;
				}
				else
					continue;

				if (lnEvents & EVT_CONSOLE)
				{
					int inButtonTouched;

					while(read_event() != 0)
						;

					if(fATIOScreenTouched(&inCurrX, &inCurrY))
						inButtonTouched = shButtonTouched(stScreen, MENU_TARJ_LEALTAD2, inCurrX, inCurrY);
					else
						inButtonTouched = 0;

					if (inButtonTouched >= 2 && inButtonTouched <= 4)
					{
						if (inButtonTouched == 2)
						{
							lnEvents = 0;
							ucKey = kbd_f6;
						}

						if (inButtonTouched == 3)
						{
							lnEvents = 0;
							ucKey = kbd_f7;
						}

						if (inButtonTouched == 4)
						{
							lnEvents = 0;
							ucKey = kbd_cancel;
						}
						break;
					}
				}
			}
		}
		else
		{
			vdATIODisplayString("Seleccione Tarjeta", 1, CENTER_ALIGN);
			vdATIODisplayString("PAYBACK >>", 3, RIGHT_ALIGN);
			vdATIODisplayString("SIVEMAX >>", 5, RIGHT_ALIGN);
			vdATIODisplayString("X - Ninguna", 8, LEFT_ALIGN);

			ucKey = inATIOKeyPressed();
		}

		if(ucKey == kbd_f6)
		{
			inRetOption = PAYBACK_OPT;
		}
		else if(ucKey == kbd_f7)
		{
			inRetOption = SIVEMAX_OPT;
		}
		else
		{
			inRetOption = NONE_OPT;
			fPAYBackOperation = FALSE;
			fSIVEMAXOperation = FALSE;
			fLMSOperation = FALSE;
		}
	}
	else if(fPAYBackOn == TRUE && fSIVEMAXOn == FALSE && fLMSOn == TRUE)
	{
		unsigned char ucKey;

		vdATIOLimpiaDisplay();
		if(shTermModel == E355_ID)
		{
			vdATIODisplayString("Seleccione Tarjeta", 1, CENTER_ALIGN);
			vdATIODisplayString("T1 - PAYBACK", 3, LEFT_ALIGN);
			vdATIODisplayString("T2 - GASONLINE", 7, LEFT_ALIGN);
			vdATIODisplayString("X - Ninguna", 8, RIGHT_ALIGN);

			ucKey = inATIOKeyPressed();

			if(ucKey == kbd_1)
				ucKey = kbd_f6;
			else if(ucKey == kbd_2)
				ucKey = kbd_f7;
		}
		else if(shTermModel == VX680_ID)
		{
			int inCurrX;
			int inCurrY;

			vdATIOPantallaMenuSelTarj3();

			while (TRUE)
			{
				lnEvents = -1;
				lnEvents = wait_event();

				inCurrX = inCurrY = 0;

				if (lnEvents & EVT_CONSOLE)
				{
					//break;
				}
				else
					continue;

				if (lnEvents & EVT_CONSOLE)
				{
					int inButtonTouched;

					while(read_event() != 0)
						;

					if(fATIOScreenTouched(&inCurrX, &inCurrY))
						inButtonTouched = shButtonTouched(stScreen, MENU_TARJ_LEALTAD3, inCurrX, inCurrY);
					else
						inButtonTouched = 0;

					if (inButtonTouched >= 2 && inButtonTouched <= 4)
					{
						if (inButtonTouched == 2)
						{
							lnEvents = 0;
							ucKey = kbd_f6;
						}

						if (inButtonTouched == 3)
						{
							lnEvents = 0;
							ucKey = kbd_f7;
						}

						if (inButtonTouched == 4)
						{
							lnEvents = 0;
							ucKey = kbd_cancel;
						}
						break;
					}
				}
			}
		}
		else
		{
			vdATIODisplayString("Seleccione Tarjeta", 1, CENTER_ALIGN);
			vdATIODisplayString("PAYBACK >>", 3, RIGHT_ALIGN);
			vdATIODisplayString("GASONLINE >>", 5, RIGHT_ALIGN);
			vdATIODisplayString("X - Ninguna", 8, LEFT_ALIGN);

			ucKey = inATIOKeyPressed();
		}

		if(ucKey == kbd_f6)
		{
			inRetOption = PAYBACK_OPT;
		}
		else if(ucKey == kbd_f7)
		{
			inRetOption = GASONLINE_OPT;
		}
		else
		{
			inRetOption = NONE_OPT;
			fPAYBackOperation = FALSE;
			fSIVEMAXOperation = FALSE;
			fLMSOperation = FALSE;
		}
	}
	else if(fPAYBackOn == FALSE && fSIVEMAXOn == TRUE && fLMSOn == TRUE)
	{
		unsigned char ucKey;

		vdATIOLimpiaDisplay();
		if(shTermModel == E355_ID)
		{
			vdATIODisplayString("Seleccione Tarjeta", 1, CENTER_ALIGN);
			vdATIODisplayString("T1 - SIVEMAX", 5, LEFT_ALIGN);
			vdATIODisplayString("T2 - GASONLINE", 7, LEFT_ALIGN);
			vdATIODisplayString("X - Ninguna", 8, RIGHT_ALIGN);

			ucKey = inATIOKeyPressed();

			if(ucKey == kbd_1)
				ucKey = kbd_f6;
			else if(ucKey == kbd_2)
				ucKey = kbd_f7;
		}
		else if(shTermModel == VX680_ID)
		{
			int inCurrX;
			int inCurrY;

			vdATIOPantallaMenuSelTarj4();

			while (TRUE)
			{
				lnEvents = wait_event();

				inCurrX = inCurrY = 0;

				if (lnEvents & EVT_CONSOLE)
				{
					//break;
				}
				else
					continue;

				if (lnEvents & EVT_CONSOLE)
				{
					int inButtonTouched;

					while(read_event() != 0)
						;

					if(fATIOScreenTouched(&inCurrX, &inCurrY))
						inButtonTouched = shButtonTouched(stScreen, MENU_TARJ_LEALTAD4, inCurrX, inCurrY);
					else
						inButtonTouched = 0;

					if (inButtonTouched >= 2 && inButtonTouched <= 4)
					{
						if (inButtonTouched == 2)
						{
							lnEvents = 0;
							ucKey = kbd_f6;
						}

						if (inButtonTouched == 3)
						{
							lnEvents = 0;
							ucKey = kbd_f7;
						}

						if (inButtonTouched == 4)
						{
							lnEvents = 0;
							ucKey = kbd_cancel;
						}
						break;
					}
				}
			}
		}
		else
		{
			vdATIODisplayString("Seleccione Tarjeta", 1, CENTER_ALIGN);
			vdATIODisplayString("SIVEMAX >>", 3, RIGHT_ALIGN);
			vdATIODisplayString("GASONLINE >>", 5, RIGHT_ALIGN);
			vdATIODisplayString("X - Ninguna", 8, LEFT_ALIGN);

			ucKey = inATIOKeyPressed();
		}

		if(ucKey == kbd_f6)
		{
			inRetOption = SIVEMAX_OPT;
		}
		else if(ucKey == kbd_f7)
		{
			inRetOption = GASONLINE_OPT;
		}
		else
		{
			inRetOption = NONE_OPT;
			fPAYBackOperation = FALSE;
			fSIVEMAXOperation = FALSE;
			fLMSOperation = FALSE;
		}
	}
	else if(fPAYBackOn == TRUE && fSIVEMAXOn == FALSE && fLMSOn == FALSE)
	{
		unsigned char ucKey;

		vdATIOLimpiaArea();
		vdATIODisplayString("Tarj. Payback?", 6, LEFT_ALIGN);

		ucKey = inATIOKeyPressed();

		if(ucKey == kbd_enter)
		{
			inRetOption = PAYBACK_OPT;
		}
		else
		{
			inRetOption = NONE_OPT;
			fPAYBackOperation = FALSE;
			fSIVEMAXOperation = FALSE;
			fLMSOperation = FALSE;
		}
	}
	else if(fPAYBackOn == FALSE && fSIVEMAXOn == TRUE && fLMSOn == FALSE)
	{
		unsigned char ucKey;

		vdATIOLimpiaArea();
		vdATIODisplayString("Tarj. SIVEMAX?", 6, LEFT_ALIGN);

		ucKey = inATIOKeyPressed();

		if(ucKey == kbd_enter)
		{
			inRetOption = SIVEMAX_OPT;
		}
		else
		{
			inRetOption = NONE_OPT;
			fPAYBackOperation = FALSE;
			fSIVEMAXOperation = FALSE;
			fLMSOperation = FALSE;
		}
	}
	else if(fPAYBackOn == FALSE && fSIVEMAXOn == FALSE && fLMSOn == TRUE)
	{
		unsigned char ucKey;

		vdATIOLimpiaArea();
		vdATIODisplayString("Tarj. GasOnline?", 6, LEFT_ALIGN);

		ucKey = inATIOKeyPressed();

		if(ucKey == kbd_enter)
		{
			inRetOption = GASONLINE_OPT;
		}
		else
		{
			inRetOption = NONE_OPT;
			fPAYBackOperation = FALSE;
			fSIVEMAXOperation = FALSE;
			fLMSOperation = FALSE;
		}
	}

	if(inRetOption == PAYBACK_OPT)
	{
		vdATIOLimpiaDisplay();
		memset(szPAYBackUsuario, 0x00, sizeof(szPAYBackUsuario));
		ReadKeyb("Usuario Payback", 10, 0, INPUT_NUM, FALSE, szPAYBackUsuario, 20, FALSE);
	}

	return inRetOption;
}



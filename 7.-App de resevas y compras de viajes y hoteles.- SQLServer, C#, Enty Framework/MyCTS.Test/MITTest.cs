using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using serviceOpen = MyCTS.Services.com.sabre.webservices;
using serviceClose = MyCTS.Services.com.sabre.webservices1;
using MyCTS.Services.PagosMIT;
using MyCTS.Services.PrintVoucher;

namespace MyCTS.Test
{
    [TestClass]
    public class MITTest
    {
        [TestMethod]
        public void TestGetNumeroIntentos()
        {
            string recordLocalizador = "NSGDFB";
            int organizacionId = 85;
            TransaccionesTarjetaNPService Tran = new TransaccionesTarjetaNPService();
            int iRespuesta = 0;
            iRespuesta = Tran.GetNumeroIntentos(recordLocalizador, organizacionId);
        }

        [TestMethod]
        public void TestGetNumeroTransacciones()
        {
            string recordLocalizador = "NSGDFB";
            int organizacionId = 85;
            TransaccionesTarjetaNPService Tran = new TransaccionesTarjetaNPService();
            int iRespuesta = 0;
            iRespuesta = Tran.GetNumeroTransacciones(recordLocalizador,organizacionId);
        }

        [TestMethod]
        public void TestEnviaVoucher()
        {
            try
            {
                string recordLocalizador = "MyCTS-A-JRUNOA-1-2_0";
                string destinatarios = "agutierrez@ctsmex.com.mx";
                int organizacionId = 85;
                //Voucher printVoucher = new Voucher();
                //printVoucher.EnviaVoucher(recordLocalizador, destinatarios, organizacionId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}

using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCTS.Services.PagosMIT;
using MyCTS.Services.PrintVoucher;

namespace TestTransaccionesMIT
{
    /// <summary>
    /// Descripción resumida de UnitTest1
    /// </summary>
    [TestClass]
    public class MITTest
    {
        public MITTest()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Obtiene o establece el contexto de las pruebas que proporciona
        ///información y funcionalidad para la ejecución de pruebas actual.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Atributos de prueba adicionales
        //
        // Puede usar los siguientes atributos adicionales conforme escribe las pruebas:
        //
        // Use ClassInitialize para ejecutar el código antes de ejecutar la primera prueba en la clase
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup para ejecutar el código una vez ejecutadas todas las pruebas en una clase
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Usar TestInitialize para ejecutar el código antes de ejecutar cada prueba 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup para ejecutar el código una vez ejecutadas todas las pruebas
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestGetNumeroIntentos()
        {
            string recordLocalizador = "NSGDFB";
            TransaccionesTarjetaNPService Tran = new TransaccionesTarjetaNPService();
            int iRespuesta = 0;
            iRespuesta = Tran.GetNumeroIntentos(recordLocalizador);
        }

        [TestMethod]
        public void TestGetNumeroTransacciones()
        {
            string recordLocalizador = "NSGDFB";
            TransaccionesTarjetaNPService Tran = new TransaccionesTarjetaNPService();
            int iRespuesta = 0;
            iRespuesta = Tran.GetNumeroTransacciones(recordLocalizador);
        }

        [TestMethod]
        public void TestEnviaVoucher()
        {
            try
            {
                string recordLocalizador = "MyCTS-A-JRUNOA-1-2_0";
                string destinatarios = "lsegura@ctsmex.com.mx";
                Voucher printVoucher = new Voucher();
                printVoucher.EnviaVoucher(recordLocalizador, destinatarios);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}

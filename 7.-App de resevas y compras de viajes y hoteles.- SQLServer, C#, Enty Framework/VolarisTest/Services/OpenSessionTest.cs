using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using MyCTS.Services.Contracts.Volaris;
using NUnit.Framework;
using MyCTS.Services;

namespace VolarisTest.Services
{
    [TestFixture]
    public class OpenSessionTest
    {
        [Test]
        public void Call_OpenSessionSuccess_ReturnNothing()
        {

            var openSessionService = new OpenSessionService();
            openSessionService.Call();
            Assert.IsNotNullOrEmpty(openSessionService.ConversationID, "No se pudo crear el id de conversation");
            Assert.IsNotNullOrEmpty(openSessionService.SecurityToken, "No se pudo crear el token de seguridad.");

        }



    }
}

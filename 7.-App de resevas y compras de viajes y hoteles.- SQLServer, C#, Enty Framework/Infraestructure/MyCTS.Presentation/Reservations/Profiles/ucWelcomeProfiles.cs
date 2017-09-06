using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MyCTS.Entities;
using MyCTS.Business;
using MyCTS.Presentation.Components;
using MyCTS.Services;
using MyCTS.Forms.UI;

namespace MyCTS.Presentation
{
    public partial class ucWelcomeProfiles : CustomUserControl
    {

        /// <summary>
        /// Descripción: Despliega pantalla de bienvenida del modulo de perfiles 
        /// Creación:    03 febrero 2010, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Marcos Q. Ramírez
        /// </summary>


        public ucWelcomeProfiles()
        {
            InitializeComponent();
        }

        private void ucWelcomeProflies_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
        }

        private void linkPrivacy_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.cts.com.mx/politicas.asp"); 
        }
    }
}

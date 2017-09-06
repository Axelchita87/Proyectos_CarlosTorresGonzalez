using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation
{
    public partial class ucPreAirAccountingLine : CustomUserControl
    {
        public ucPreAirAccountingLine()
        {
            InitializeComponent();
        }

        private void ucPreAirAccountingLine_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            if (!ValidateItinerary)
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            else
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCAIRACCOUNTINGLINE);
        }
        private bool ValidateItinerary
        {
            get
            {
                bool status = true;
                string sabreAnswer = string.Empty;
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    sabreAnswer = objCommand.SendReceive("*IA*N*PAC*-");
                }
                int row = 0;
                int col = 0;
                CommandsQik.searchResponse(sabreAnswer, "NO ITIN", ref row, ref col, 1, 2, 1, 64);
                if (row != 0 && col >= 0)
                {
                    MessageBox.Show("NO EXISTE ITINERARIO PRESENTE", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    status = false;
                }
                row = 0;
                col = 0;
                CommandsQik.searchResponse(sabreAnswer, "NO NAMES", ref row, ref col, 1, 1, 1, 14);
                if (row != 0 && col >= 0 && status)
                {
                    MessageBox.Show("NO EXISTEN NOMBRES PRESENTES", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    status = false;
                }
                return status;
            }
        }
    }
}

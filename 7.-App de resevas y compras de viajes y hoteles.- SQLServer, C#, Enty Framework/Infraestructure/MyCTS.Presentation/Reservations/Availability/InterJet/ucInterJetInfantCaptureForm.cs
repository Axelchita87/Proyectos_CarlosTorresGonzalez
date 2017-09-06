using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Presentation.Reservations.Availability.InterJet.Handlers;
using System.Collections;

namespace MyCTS.Presentation
{
    public partial class ucInterJetInfantCaptureForm : CustomUserControl
    {


        /// <summary>
        /// 
        /// </summary>
        private InterJetInfantCaptureFormHandler _interJetInfantCaptureFormHandler = null;

        /// <summary>
        /// Gets the inter jet infant capture form handler.
        /// </summary>
        private InterJetInfantCaptureFormHandler InterJetInfantCaptureFormHandler
        {
            get
            {
                return this._interJetInfantCaptureFormHandler ??
                       (this._interJetInfantCaptureFormHandler = new InterJetInfantCaptureFormHandler
                                                                     {
                                                                         CurrentForm = this,
                                                                         InfantMainGroupBox = this.interJetInfantGroup
                                                                     });
            }
        }



        public ucInterJetInfantCaptureForm()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
            ControlStyles.UserPaint |
            ControlStyles.DoubleBuffer, true);
            //this.panel1.Visible = false;
            //this.infantsPanel.HorizontalScroll.Enabled = false;

        }

        /// <summary>
        /// Handles the Click event of the button1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, "ucInterJetPassangerCaptureForm", this.Parameter, null);
        }

        public void ucInterJetInfantCaptureFor_Load(object sender, EventArgs e)
        {
            InterJetInfantCaptureFormHandler.Initialize();
            InterJetInfantCaptureFormHandler.ToolTiper.SetToolTip(this.captureContactButton, "Continuar con la cotización a detalle de los vuelos.".ToUpper());
            InterJetInfantCaptureFormHandler.ToolTiper.SetToolTip(this.button2, "Regresar a la captura de pasajeros.".ToUpper());
        }

        /// <summary>
        /// Handles the Click event of the button2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                InterJetInfantCaptureFormHandler.ContinueToPayment();
            }
            catch (Exception exception)
            {
                //MessageBox.Show(exception.Message, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                button1_Click(sender, e);
            }
            catch (Exception exception)
            {
                //MessageBox.Show(exception.Message, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



    }
}

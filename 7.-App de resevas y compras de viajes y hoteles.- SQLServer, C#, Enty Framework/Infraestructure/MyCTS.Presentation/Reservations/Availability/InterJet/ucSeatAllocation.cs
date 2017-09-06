using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Services.Contracts;
using MyCTS.Entities;
using System.Collections;
using MyCTS.Presentation.Reservations.Availability.InterJet.Handlers;
using MyCTS.Presentation.Components;
using MyCTS.Services.APIInterJet;
using System.Runtime.Remoting.Messaging;
using System.Threading;

namespace MyCTS.Presentation
{
    public partial class ucSeatAllocation : CustomUserControl
    {
        private bool errorPlane;
        private static List<GetSeatAvailabilityResponse> response = null;
        private static Entities.InterJetTicket currentTicket = null;
        private static InterJetSelectedFlights ticket = null;
        private delegate void SenderCallBack();
        private delegate void StopControlsDelegate();
        public static MyCTS.Services.BookingManager.Booking current = null;
        List<string> passenger = null;
        private delegate void SenderInvoker();

        /// <summary>
        /// 
        /// </summary>
        private InterJetServiceManager _interJetServiceManager;

        /// <summary>
        /// Gets the inter jet service manager.
        /// </summary>
        public InterJetServiceManager InterJetServiceManager
        {
            get
            {
                InterJetServiceManager.AgentEmail = Login.Mail;
                return new InterJetServiceManager();
            }
        }

        /// <summary>
        /// Gets the session.
        /// </summary>
        private Hashtable Session
        {
            get
            {
                var interJetSession = (InterJetSession)(this.Parameter);
                if (interJetSession != null)
                {
                    return interJetSession.Session;
                }
                return new Hashtable();
            }
        }
       

        public ucSeatAllocation()
        {
            InitializeComponent();
        }

        private void ucSeatAllocation_Load(object sender, EventArgs e)
        {
            CostumerAccountInterJet.notSeatAssing = false;
            //Sell();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            lblSearch.Visible = true;
            timer1.Enabled = true;
            progressBar1.Visible = true;
            //Plane();
            SenderCallBack scb = new SenderCallBack(Plane);
            AsyncCallback callback = new AsyncCallback(OnCompleted);
            scb.BeginInvoke(callback, null);
           
         }

        private void Commit()
        {
            currentTicket = null;
            currentTicket = (MyCTS.Entities.InterJetTicket)this.Session["CurrentTicket"];
            this.InterJetServiceManager.Commit(currentTicket);

            if (currentTicket.Passangers.HasInfants || currentTicket.Passangers.HasSeniorAdult)
            {
                if ((currentTicket.Passangers.HasInfants && currentTicket.Passangers.HasSeniorAdult) || currentTicket.Passangers.HasInfants)
                {
                    if ((PriceTotalResponseInterjet.getItinearyPrice > PriceTotalResponseInterjet.sellResponse ||
                        PriceTotalResponseInterjet.commitResponse > 0 && PriceTotalResponseInterjet.sellResponse != PriceTotalResponseInterjet.commitResponse))
                    {
                        MessageBox.Show("La clase solicitada ya no esta disponible", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Loader.AddToPanel(Loader.Zone.Middle, this, "ucAvailability");
                    }
                    else
                    {
                        Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, "ucInterJetPaymentForm", this.Parameter, null);
                    }
                }
                else if (currentTicket.Passangers.HasSeniorAdult)
                {
                        Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, "ucInterJetPaymentForm", this.Parameter, null);
                    
                }
            }
            else if (PriceTotalResponseInterjet.getItinearyPrice != PriceTotalResponseInterjet.sellResponse ||
                (PriceTotalResponseInterjet.commitResponse > 0 && PriceTotalResponseInterjet.getItinearyPrice != PriceTotalResponseInterjet.commitResponse))
            {
                MessageBox.Show("La clase solicitada ya no esta disponible", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Loader.AddToPanel(Loader.Zone.Middle, this, "ucAvailability");

            }
            else
            {
                Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, "ucInterJetPaymentForm", this.Parameter, null);
            }
        }

        private void Sell()
        {
            currentTicket = null;
            currentTicket = (MyCTS.Entities.InterJetTicket)this.Session["CurrentTicket"];
            this.InterJetServiceManager.MakeReservation(currentTicket);
        }

        private void Plane()
        {
            errorPlane = false;
            currentTicket = null;
            ticket = null;
            current = null;
            currentTicket = (MyCTS.Entities.InterJetTicket)this.Session["CurrentTicket"];
            //this.InterJetServiceManager.MakeReservation(currentTicket);
            ticket = (InterJetSelectedFlights)this.Session["SelectedFlights"];
            //current = this.InterJetServiceManager.GetBooking(currentTicket.RecordLocator);
            response = null;
            response = InterJetServiceManager.GetAvailabilitySeat(ticket.GetFlights());
            if (response != null)
            {
                CostumerAccountInterJet.notSeatAssing = false;

            }
            else
            {
                CostumerAccountInterJet.notSeatAssing = true;
            }

        }

      

        private void btnAcept_Click(object sender, EventArgs e)
        {
            try
            {
                CostumerAccountInterJet.notSeatAssing = false;

                if (frmAssignSeats.listInterjetSeatsReturn != null &&
                    frmAssignSeats.listInterjetSeatsReturn.Count > 0)
                {
                    var susses = AssingSeat();
                    if (susses[0].BookingUpdateResponseData.Success != null)
                    {
                       Commit();
                        //Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, "ucInterJetPaymentForm",
                        //                    this.Parameter, null);
                    }
                    else if (susses[0].BookingUpdateResponseData.Error != null)
                    {
                        MessageBox.Show(susses[0].BookingUpdateResponseData.Error.ErrorText, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Loader.AddToPanel(Loader.Zone.Middle, this, "ucAvailability");
                    }
                    else if (susses[0].BookingUpdateResponseData.Warning.WarningText != null || susses[0].BookingUpdateResponseData.Warning.WarningText != string.Empty)
                    {
                        MessageBox.Show(susses[0].BookingUpdateResponseData.Warning.WarningText, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Loader.AddToPanel(Loader.Zone.Middle, this, "ucAvailability");
                    }
                }
                else
                {
                    CostumerAccountInterJet.notSeatAssing = true;
                    Commit();
                        //Loader.AddToPanelWithParameters(Loader.Zone.Middle, this, "ucInterJetPaymentForm",
                        //                    this.Parameter, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error");
            }
        }

        private List<AssignSeatsResponse> AssingSeat()
        {
            List<AssignSeatsResponse> responseList = new List<AssignSeatsResponse>();
            AssignSeatsResponse response = null;
            var ticket = (InterJetSelectedFlights)this.Session["SelectedFlights"];
            passenger = null;
            List<string>id= new List<string>();
            string pax = string.Empty;
            int b = 0;
            for (int a = 0; a < frmAssignSeats.listInterjetSeatsReturn.Count; a++)
            {
                passenger = new List<string>();
                bool insert = true;
                foreach (string passId in id)
                {
                    if (frmAssignSeats.listInterjetSeatsReturn[a].Id == passId)
                    {
                        insert = false;
                        break;
                    }
                    else
                    {
                        insert = true;
                    }
                }

                if (insert)
                {
                    foreach (interjetSeats pass in frmAssignSeats.listInterjetSeatsReturn)
                    {
                        if (frmAssignSeats.listInterjetSeatsReturn[a].Id == pass.Id)
                        {
                            int z = Convert.ToInt32(pass.Id) - 1;
                            pax = Convert.ToString(z) + "|" + pass.Seat + "|" + pass.Segment;
                            passenger.Add(pax);
                            id.Add(pass.Id);
                        }
                    }
                }
                if (passenger.Count > 0)
                {
                    response = InterJetServiceManager.AssingSeat(ticket.GetFlights(), passenger);
                    responseList.Add(response);
                }
            }
            frmAssignSeats.listInterjetSeatsReturn.Clear();
            return responseList;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i <= progressBar1.Maximum; i++)
            {
                progressBar1.Value = i;
                System.Threading.Thread.Sleep(10);
            }
            progressBar1.Value = 0;
        }

        /// <summary>
        /// Permite notificar que el proceso asíncrono ha terminado
        /// </summary>
        /// <param name="asyncResult">Objeto con referencia de tipo AsyncCallback</param>
        private void OnCompleted(IAsyncResult asyncResult)
        {
            AsyncResult result = (AsyncResult)asyncResult;
            SenderCallBack scb = (SenderCallBack)result.AsyncDelegate;
            scb.EndInvoke(asyncResult);
            LoadUserControl();
        }

         /// <summary>
        /// Carga user control de inicio
        /// </summary>
        private void LoadUserControl()
        {
            if (this.InvokeRequired)
            {
                //SenderCallBack scb = new SenderCallBack(LoadUserControl);
                this.Invoke(new SenderInvoker(LoadUserControl));
            }
            else
            {
                if (CostumerAccountInterJet.notSeatAssing)
                {
                    lblSearch.Visible = false;
                    timer1.Enabled = false;
                    progressBar1.Visible = false;
                    MessageBox.Show("No hay disponibilidad de asignar asientos para este vuelo.Dar clic en continuar para seguir con la compra", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    frmAssignSeats.listInterjetSeatsReturn = null;
                    frmAssignSeats frmAsign = new frmAssignSeats(response, currentTicket);
                    frmAsign.ShowDialog();
                    lblSearch.Visible = false;
                    timer1.Enabled = false;
                    progressBar1.Visible = false;
                    dataGridView1.DataSource = null;
                    dataGridView1.Visible = true;
                    lblAssingSeat.Visible = true;
                    List<paxSeats> seatPassenger = null;
                    seatPassenger = new List<paxSeats>();
                    foreach (interjetSeats pass in frmAssignSeats.listInterjetSeatsReturn)
                    {
                        paxSeats pax = new paxSeats();
                        pax.Name = pass.Name;
                        pax.Seat = pass.Seat;
                        pax.Segment = pass.Segment;

                        seatPassenger.Add(pax);
                    }
                    dataGridView1.DataSource = seatPassenger;
                    if (response.Count < ticket.GetFlights().Count)
                    {
                        lblFly.Text = "No hay asignación de asientos para el vuelo de regreso";
                        lblFly.Visible = true;
                    }
                }


            }
        }
        
    }
}

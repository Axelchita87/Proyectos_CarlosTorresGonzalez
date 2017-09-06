using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Business;
using MyCTS.Entities;
using MyCTS.Presentation.Base;
using System.ComponentModel;
using MyCTS.Services.Contracts;
using System.Threading;
using MyCTS.Services.ValidateDKsAndCreditCards;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.CustomerDK.ContextSolver
{
    public class VolarisContextSolverCustomerDkWinForms : IProcessContext<VolarisReservation>
    {

        public string UserDK { get; set; }
        public int LogOrId { get; set; }

        #region Miembros de IProcessContext<VolarisReservation>

        public EventHandler OnCompleted { get; set; }

        /// <summary>
        /// Resolves the specified reservation.
        /// </summary>
        /// <param name="reservation">The reservation.</param>
        public void Resolve(VolarisReservation reservation)
        {
            StartWorker(reservation);
        }

        private BackgroundWorker _backgroundWorker;

        /// <summary>
        /// Starts the worker.
        /// </summary>
        /// <param name="reservation">The reservation.</param>
        private void StartWorker(VolarisReservation reservation)
        {
            _backgroundWorker = new BackgroundWorker();
            _backgroundWorker.DoWork += _backgroundWorker_DoWork;
            _backgroundWorker.RunWorkerCompleted += _backgroundWorker_RunWorkerCompleted;
            _backgroundWorker.RunWorkerAsync(reservation);
        }

        /// <summary>
        /// Handles the RunWorkerCompleted event of the _backgroundWorker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        private void _backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (OnCompleted != null)
            {
                OnCompleted(null, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Handles the DoWork event of the _backgroundWorker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
        private void _backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var reservation = (VolarisReservation)e.Argument;
            Thread.Sleep(1500);
            try
            {
                ConnectToProductionServer(reservation);

            }
            catch (Exception exe)
            {
                ConnectToBackUpServer(reservation);
            }

        }


        /// <summary>
        /// Connects to production server.
        /// </summary>
        /// <param name="reservation">The reservation.</param>
        private void ConnectToProductionServer(VolarisReservation reservation)
        {

            WsMyCTS wsServ = new WsMyCTS();
            MyCTS.Services.ValidateDKsAndCreditCards.GetAttribute1 integraAttribute = wsServ.GetAttribute(UserDK, LogOrId);

            if (integraAttribute != null)
            {
                SetCustomerAttributes(reservation, UserDK, integraAttribute.Status, integraAttribute.Status_Site,integraAttribute.Attribute1);
            }
            else
            {
                SetCustomerAttributes(reservation, UserDK, string.Empty, string.Empty,
                                      string.Empty);
            }
        }

        /// <summary>
        /// Connects to back up server.
        /// </summary>
        /// <param name="reservation">The reservation.</param>
        private void ConnectToBackUpServer(VolarisReservation reservation)
        {
            try
            {
                WsMyCTS wsServ = new WsMyCTS();

                //var oracleConnection = new OracleConnection();
                MyCTS.Services.ValidateDKsAndCreditCards.GetAttribute1 integraAttribute = wsServ.GetAttribute(UserDK, LogOrId);
                //Services.MyCTSOracleConnectionDev.GetAttribute1 integraAttribute = oracleConnection.GetAttribute1Dev(UserDK, LogOrId);

                if (integraAttribute != null)
                {
                    SetCustomerAttributes(reservation, UserDK, integraAttribute.Status, integraAttribute.Status_Site,
                                          integraAttribute.Attribute1);
                }else
                {
                    SetCustomerAttributes(reservation, UserDK, string.Empty, string.Empty,
                                      string.Empty);
                }
                   
            }
            catch (Exception exe)
            {
                SetCustomerAttributes(reservation, UserDK, string.Empty, string.Empty,
                                      string.Empty);
            }
        }


        private void SetCustomerAttributes(VolarisReservation reservation, string userDK, string status, string statusActive, string attribute)
        {

            if (!string.IsNullOrEmpty(attribute))
            {
                bool isActive = status.Equals("A") && statusActive.Equals("A");
                reservation.CustomerDk.Attribute = attribute;
                reservation.CustomerDk.IsActive = true;
                reservation.CustomerDk.Exist = true;
                reservation.CustomerDk.Value = userDK;
                if (isActive)
                {

                    reservation.CustomerDk.IsActive = true;

                }
                else
                {

                    reservation.CustomerDk.IsActive = false;

                }

            }

            else
            {
                reservation.CustomerDk.Attribute = string.Empty;
                reservation.CustomerDk.IsActive = false;
                reservation.CustomerDk.Exist = false;
                reservation.CustomerDk.Value = userDK;

            }

        }

        #endregion
    }
}

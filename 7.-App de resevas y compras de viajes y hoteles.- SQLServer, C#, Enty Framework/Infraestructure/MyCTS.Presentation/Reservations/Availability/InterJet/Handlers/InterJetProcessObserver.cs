using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyCTS.Presentation.Reservations.Availability.InterJet.Handlers
{
    /// <summary>
    /// 
    /// </summary>
    public class InterJetProcessObserver
    {

        /// <summary>
        /// Gets or sets the user control.
        /// </summary>
        /// <value>
        /// The user control.
        /// </value>
        public UserControl UserControl { get; set; }


        /// <summary>
        /// Handles the event.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="keyData">The key data.</param>
        /// <returns></returns>
        public bool HandleEvent(ref Message msg, Keys keyData)
        {
            
            if (ucAvailability.IsInterJetProcess || ucEndReservation.isFlowHotel)
            {
                if(keyData == (Keys.Control | Keys.D1))
                {
                    return true;
                }
                if (keyData == (Keys.Control | Keys.NumPad1))
                {
                    return true;
                }

                if (keyData == (Keys.Control | Keys.D0))
                {
                    return true;
                }
                if (keyData == (Keys.Control | Keys.NumPad0))
                {
                    return true;
                }

                if (keyData == (Keys.Control | Keys.D2))
                {
                    return true;
                }
                if (keyData == (Keys.Control | Keys.NumPad2))
                {
                    return true;
                }

                if (keyData == (Keys.Control | Keys.D3))
                {
                    return true;
                }
                if (keyData == (Keys.Control | Keys.NumPad3))
                {
                    return true;
                }

                if (keyData == (Keys.Control | Keys.D4))
                {
                    return true;
                }
                if (keyData == (Keys.Control | Keys.NumPad4))
                {
                    return true;
                }
                if (keyData == (Keys.Control | Keys.D5))
                {
                    return true;
                }
                if (keyData == (Keys.Control | Keys.NumPad5))
                {
                    return true;
                }
                if (keyData == (Keys.Control | Keys.D6))
                {
                    return true;
                }
                if (keyData == (Keys.Control | Keys.NumPad6))
                {
                    return true;
                }
                if (keyData == (Keys.Control | Keys.D7))
                {
                    return true;
                }
                if (keyData == (Keys.Control | Keys.NumPad7))
                {
                    return true;
                }


                if (keyData == (Keys.Control | Keys.D8))
                {
                    return true;
                }
                if (keyData == (Keys.Control | Keys.NumPad8))
                {
                    return true;
                }

                if (keyData == (Keys.Control | Keys.D9))
                {
                    return true;
                }
                if (keyData == (Keys.Control | Keys.NumPad9))
                {
                    return true;
                }


                if (keyData == (Keys.Control | Keys.A))
                {
                    return true;
                }


                if (keyData == (Keys.Control | Keys.B))
                {
                    return true;
                }


                if (keyData == (Keys.Control | Keys.C))
                {
                    return true;
                }

                if (keyData == (Keys.Control | Keys.D))
                {
                    return true;
                }

                if (keyData == (Keys.Control | Keys.E))
                {
                    return true;
                }

                if (keyData == (Keys.Control | Keys.F))
                {
                    return true;
                }

                if (keyData == (Keys.Control | Keys.G))
                {
                    return true;
                }

                if (keyData == (Keys.Control | Keys.H))
                {
                    return true;
                }

                if (keyData == (Keys.Control | Keys.I))
                {
                    return true;
                }

                if (keyData == (Keys.Control | Keys.J))
                {
                    return true;
                }

                if (keyData == (Keys.Control | Keys.K))
                {
                    return true;
                }

                if (keyData == (Keys.Control | Keys.L))
                {
                    return true;
                }

                if (keyData == (Keys.Control | Keys.N))
                {
                    return true;
                }

                if (keyData == (Keys.Control | Keys.O))
                {
                    return true;
                }

                if (keyData == (Keys.Control | Keys.P))
                {
                    return true;
                }
                if (keyData == (Keys.Control | Keys.Q))
                {
                    return true;
                }

                if (keyData == (Keys.Control | Keys.R))
                {
                    return true;
                }

                if (keyData == (Keys.Control | Keys.S))
                {
                    return true;
                }

                if (keyData == (Keys.Control | Keys.T))
                {
                    return true;
                }

                if (keyData == (Keys.Control | Keys.U))
                {
                    return true;
                }

                if (keyData == (Keys.Control | Keys.V))
                {
                    return true;
                }

                if (keyData == (Keys.Control | Keys.W))
                {
                    return true;
                }

                if (keyData == (Keys.Control | Keys.Y))
                {
                    return true;
                }

                if (keyData == (Keys.Control | Keys.Z))
                {
                    return true;
                }

                if (keyData == (Keys.Control | Keys.Enter))
                {
                    return true;
                }
                if (keyData == (Keys.Control | Keys.Back))
                {
                    return true;
                }

                if (keyData == (Keys.Escape))
                {
                    return true;
                }

                if (keyData == (Keys.Alt | Keys.M))
                {
                    return true;
                }



                if (keyData == Keys.Control)
                {
                    return true;
                }
                if (keyData == (Keys.Control | Keys.E))
                {
                    return true;
                }
                if (keyData == (Keys.Control | Keys.LShiftKey | Keys.LButton))
                {
                    return true;
                }


            }


            return false;
        }
    


}
}

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
    public partial class ucArea : CustomUserControl
    {
        /// <summary>
        /// Descripción: User Control que permite realizar el cambio de área
        ///              en MySabre
        /// Creación:    Marzo - Abril 09, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Marcos Q. Ramírez
        /// </summary>
        /// 
        private string send;

        public ucArea()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);
           
        }

        /// <summary>
        /// Ejecuta las funciones de cambio de área cuando se selcciona alguna
        /// opción del combo de Areas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbArea.SelectedIndex.Equals(1))
            {
                AreaCommandsSendA();
            }
            else if (cmbArea.SelectedIndex.Equals(2))
            {
                AreaCommandsSendB();
            }
            else if (cmbArea.SelectedIndex.Equals(3))
            {
                AreaCommandsSendC();
            }
            else if (cmbArea.SelectedIndex.Equals(4))
            {
                AreaCommandsSendD();
            }
            else if (cmbArea.SelectedIndex.Equals(5))
            {
                AreaCommandsSendE();
            }
            else if (cmbArea.SelectedIndex.Equals(6))
            {
                AreaCommandsSendF();
            }
            lblArea.Focus();
        }

        #region===== MethodsClass =====


        /// <summary>
        /// Manda el comando a Mysabre para cambiar a la área A
        /// </summary>
        public void AreaCommandsSendA()
        {
            send = Resources.Constants.COMMANDS_AT_A;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
            
        }


        /// <summary>
        /// Manda el comando a Mysabre para cambiar a la área B
        /// </summary>
        public void AreaCommandsSendB()
        {
            send = Resources.Constants.COMMANDS_AT_B;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
        }


        /// <summary>
        /// Manda el comando a Mysabre para cambiar a la área C    
        /// </summary>
        public void AreaCommandsSendC()
        {
            send = Resources.Constants.COMMANDS_AT_C;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
        }


        /// <summary>
        /// Manda el comando a Mysabre para cambiar a la área D
        /// </summary>
        public void AreaCommandsSendD()
        {
            if (Login.PCC.Equals(Resources.Constants.PCC_0WY5))
            {
                send = Resources.Constants.COMMANDS_AT_D;
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    objCommand.SendReceive(send);
                    objCommand.SendReceive(Resources.Constants.COMMANDS_PPS4);
                }
                //MessageBox.Show(Resources.Reservations.FIN_CAMBIO_AREA_Y_ASIGNACION_IMPRESION, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                send = Resources.Constants.COMMANDS_AT_D;
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    objCommand.SendReceive(send);
                    objCommand.SendReceive(Resources.Constants.COMMANDS_AAA0WY5);
                    objCommand.SendReceive(Resources.Constants.COMMANDS_PPS4);
                }
                //MessageBox.Show(Resources.Reservations.FIN_CAMBIO_AREA_Y_ASIGNACION_IMPRESION, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }


        /// <summary>
        /// Manda el comando a Mysabre para cambiar a la área E
        /// </summary>
        public void AreaCommandsSendE()
        {
            if (Login.PCC.Equals(Resources.Constants.PCC_3L64))
            {
                send = Resources.Constants.COMMANDS_AT_E;
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    objCommand.SendReceive(send);
                    objCommand.SendReceive(Resources.Constants.COMMANDS_PPS5);
                }
                //MessageBox.Show(Resources.Reservations.FIN_CAMBIO_AREA_Y_ASIGNACION_IMPRESION, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                send = Resources.Constants.COMMANDS_AT_E;
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    objCommand.SendReceive(send);
                    objCommand.SendReceive(Resources.Constants.COMMANDS_AAA3L64);
                    objCommand.SendReceive(Resources.Constants.COMMANDS_PPS5);
                }
                //MessageBox.Show(Resources.Reservations.FIN_CAMBIO_AREA_Y_ASIGNACION_IMPRESION, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        /// <summary>
        /// Manda el comando a Mysabre para cambiar a la área F
        /// </summary>
        public void AreaCommandsSendF()
        {
            if (Login.PCC.Equals(Resources.Constants.PCC_X3YC))
            {
                send = Resources.Constants.COMMANDS_AT_F;
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    objCommand.SendReceive(send);
                    objCommand.SendReceive(Resources.Constants.COMMANDS_PPS1);
                }
                //MessageBox.Show(Resources.Reservations.FIN_CAMBIO_AREA_Y_ASIGNACION_IMPRESION, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                send = Resources.Constants.COMMANDS_AT_F;
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    objCommand.SendReceive(send);
                    objCommand.SendReceive(Resources.Constants.COMMANDS_AAAX3YC);
                    objCommand.SendReceive(Resources.Constants.COMMANDS_PPS1);
                }
                //MessageBox.Show(Resources.Reservations.FIN_CAMBIO_AREA_Y_ASIGNACION_IMPRESION, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion//End MethodsClass
    }
}

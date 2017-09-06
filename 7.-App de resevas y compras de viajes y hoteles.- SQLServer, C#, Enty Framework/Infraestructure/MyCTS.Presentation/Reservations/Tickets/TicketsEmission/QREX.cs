using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation
{
    public partial class ucQREX : CustomUserControl
    {

        /// <summary>
        /// Descripcion: Permite ingresar la instrucción de QREX
        /// Creación: 16/Junio/11
        /// Modificación: *
        /// Cambio: *
        /// Solicito: *
        /// Autor: Ivan Martínez
        /// </summary>

        private static string commandqrex;
        public static string CommandQREX
        {
            get { return commandqrex; }
            set { commandqrex = value; }
        }

        private static string c80;
        public static string C80
        {
            get { return c80; }
            set { c80 = value; }
        }

        public static bool Qrex = false;

        private string send = string.Empty;
        private string sabreAnswer = string.Empty;
        private bool isMessageShown = false;
        private int row = 0;
        private int col = 0;
        private string command = string.Empty;
        private string segment = string.Empty;
        private string newlabel = string.Empty;


        public ucQREX()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
               ControlStyles.UserPaint |
               ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtCommand;
            this.LastControlFocus = btnAcept;
        }

        private void ucQREX_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            send = Resources.TicketEmission.Constants.COMMANDS_AST_T;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive(send);
            }
            txtCommand.Focus();
            send = string.Empty;
            Qrex = true;
        }

        private void btnAcept_Click(object sender, EventArgs e)
        {
            if (IsValidBusinessRules)
            {
                //LoginEAreaValidation();

                if (!isMessageShown)
                {
                    PresentRecordValidation();
                    if (!isMessageShown)
                    {
                        if (rdoGenerate.Checked.Equals(true))
                        {
                            command = string.Concat("WFR", txtCommand.Text);
                            EvaluateCommand();
                            CommandQREX = command;
                            using (CommandsAPI objCommand = new CommandsAPI())
                            {
                                CommandsAPI2.send_MessageToEmulator(Resources.TicketEmission.Constants.PLEASE_WAIT);
                                objCommand.SendReceive(Resources.Constants.COMMANDS_PPO, 0, 0);
                                string res = objCommand.SendReceive("*S",0,0);
                                if (res.Substring(0, 4).Equals("3L64"))
                                {
                                    objCommand.SendReceive(Resources.Constants.COMMANDS_PPS5, 0, 0);
                                }
                                else
                                {
                                    objCommand.SendReceive(Resources.Constants.COMMANDS_PPS1, 0, 0);
                                }
                            }
                            ucMenuReservations.qualityControls = true;
                            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCFIRST_VALIDATIONS);
                        }
                        else
                        {
                            using (CommandsAPI objCommand = new CommandsAPI())
                            {
                                command = string.Concat("WFR", txtCommand.Text);
                                CommandsAPI2.send_MessageToEmulator(Resources.TicketEmission.Constants.PLEASE_WAIT);
                                objCommand.SendReceive(Resources.Constants.COMMANDS_PTR_SLASH_END, 0, 0);
                                objCommand.SendReceive(command);
                                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                            }
                        }
                    }
                }
            }
        }


        private void btnCross_Click(object sender, EventArgs e)
        {
            txtCommand.Text = string.Concat(txtCommand.Text, "‡");
            txtCommand.Focus();
        }


        #region =====Methods Class=====


        //  Validación de inicio de sesion en área E para agentes con pseudo 3L64
        private void LoginEAreaValidation()
        {

            send = string.Empty;
            sabreAnswer = string.Empty;
            row = 0;
            col = 0;
            //locatorrecord = RecordLocalizer.GetRecordLocalizer();
            //LogProductivity.PNR = locatorrecord;
            if (Login.PCC.Equals(Resources.TicketEmission.Constants.PCC_3L64))
            {
                send = Resources.TicketEmission.Constants.COMMANDS_AST_S;
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    sabreAnswer = objCommand.SendReceive(send);
                }

                CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.A, ref row, ref col, 1, 1, 15, 15);
                if (row != 0 || col != 0)
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.NECESITAS_ESTAR_AREA_E_EMITIR_ETKTS, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    isMessageShown = true;
                    return;
                }
                CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.B, ref row, ref col, 1, 1, 15, 15);
                if (row != 0 || col != 0)
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.NECESITAS_ESTAR_AREA_E_EMITIR_ETKTS, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    isMessageShown = true;
                    return;
                }
                else
                {
                    isMessageShown = false;
                    return;
                }
            }
        }



        //Validación de record presente en MySabre
        private void PresentRecordValidation()
        {
            send = string.Empty;
            sabreAnswer = string.Empty;
            send = Resources.TicketEmission.Constants.COMMANDS_AST_N_AST_IA;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive(send);
            }
            CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.NO_ITIN, ref row, ref col, 2, 3, 1, 64);
            if (row != 0 || col != 0)
            {
                MessageBox.Show(Resources.TicketEmission.Tickets.NO_RECORD_PRESENTE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isMessageShown = true;
                return;
            }
            CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.NO_NAMES, ref row, ref col, 2, 3, 1, 64);
            if (row != 0 || col != 0)
            {
                MessageBox.Show(Resources.TicketEmission.Tickets.NO_NOMBRES_PRESENTES, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isMessageShown = true;
                return;
            }
            else
            {
                isMessageShown = false;
                return;
            }
        }


        //Analiza el comando enviado, para crear la etiqueta de Quality Controls C80
        private void EvaluateCommand()
        {
            string seg = string.Empty;
            string res = string.Empty;
            string itinerary = string.Empty;
            string bysegment = string.Empty;
            string commandSegment = string.Empty;
            string konnect = string.Empty;
            int lenght = 0;
            int resplenght = 0;
            int lenghtcommand = 0;
            int aux = 0;
            int row = 0;
            int col = 0;
            int row1 = 0;
            int col1 = 0;
            int i = 0;
            int j = 0;

            if (command.Contains("‡DPE"))
            {
                command = command.Replace("‡DPE", "‡DPB");
            }
            else if (!command.Contains("‡DPB"))
            {
                command = string.Concat(command, "‡DPB");
            }

            //Obtiene segmentos
            if (command.Contains("‡S"))
            {
                char[] charCommand = command.ToCharArray();
                for (int x = 0; x <= charCommand.Length; x++)
                {
                    int y = x + 1;
                    if (charCommand[x] == '‡' & charCommand[x + 1] == 'S')
                    {
                        x++;
                        while (x < charCommand.Length)
                        {
                            if (charCommand[x] != '‡')
                            {

                                segment = string.Concat(segment, charCommand[x]);
                                x++;
                            }
                            else
                                break;
                        }
                        break;
                    }

                }
            }

            //Creación de la etiqueta C80




            if (!string.IsNullOrEmpty(segment))
            {
                segment = segment.Replace('-', '/');
                bysegment = segment.Replace('S', ' ').Trim();
                newlabel = string.Concat("5.</C80*");
                seg = string.Concat("*IA");
                using (CommandsAPI2 objCommand = new CommandsAPI2())
                {
                    res = objCommand.SendReceive(seg, 0, 0);
                }

                string[] segments1 = bysegment.Split(new char[] { '/' });



                for (int a = 0; a < segments1.Length; a++)
                {
                    col = 0; row = 0;
                    CommandsQik.searchResponse(segments1[a], "-", ref row, ref col);
                    if (col != 0 || row != 0)
                    {
                        int num1 = 0;
                        int num2 = 0;

                        string[] seg1 = segments1[a].Split(new char[] { '-' });
                        string replace = string.Empty;
                        string bysegment2 = string.Empty;

                        num1 = Convert.ToInt32(seg1[0]);
                        num2 = Convert.ToInt32(seg1[1]);

                        for (int f = num1; f <= num2; f++)
                        {
                            bysegment2 = string.Concat(bysegment2, f.ToString(), "/");
                        }
                        bysegment2 = bysegment2.Remove(bysegment2.Length - 1, 1);
                        replace = string.Concat(num1.ToString(), "-", num2.ToString());
                        bysegment = bysegment.Replace(replace, bysegment2);
                    }
                }

                string[] segments = bysegment.Split(new char[] { '/' });
                lenght = segments.Length - 1;


                string[] resp = res.Split(new char[] { '\n' });
                resplenght = resp.Length;


                for (i = 0; i <= lenght; i++)
                {
                    aux = 0;
                    for (j = 1; j < resplenght; j++)
                    {
                        j = aux + 1;

                        col = 0; row = 0; col1 = 0; row1 = 0;
                        CommandsQik.searchResponse(resp[j], "ARNK", ref row, ref col);
                        if (row == 0 || col == 0)
                        {
                            col = 0; row = 0; col1 = 0; row1 = 0;
                            CommandsQik.searchResponse(resp[j], segments[i], ref row, ref col, 1, 3, 1, 3);
                            if (row != 0 || col != 0)
                            {
                                CommandsQik.CopyResponse(resp[j], ref itinerary, row, 19, 8);
                                itinerary = itinerary.Replace("*", "").Trim();
                                commandSegment = string.Concat(commandSegment, itinerary.Substring(0, 3), ".",
                                    itinerary.Substring(3, 3), ".");
                                aux = j;
                                break;
                            }
                        }
                        aux = j;
                    }
                }

                if (!string.IsNullOrEmpty(commandSegment))
                {
                    commandSegment = commandSegment.Remove(commandSegment.Length - 1);
                    if (commandSegment.Length > 7)
                    {
                        string[] commands = commandSegment.Split(new char[] { '.' });
                        lenghtcommand = commands.Length - 1;
                        for (int z = 0; z <= lenghtcommand - 1; z++)
                        {
                            if (commands[z] == commands[z + 1])
                            {
                                commands[z] = string.Empty;
                            }
                        }

                        commandSegment = string.Empty;

                        for (int a = 0; a <= lenghtcommand; a++)
                        {
                            if (!string.IsNullOrEmpty(commands[a]))
                                commandSegment = string.Concat(commandSegment, commands[a].Trim(), ".");
                        }
                        commandSegment = commandSegment.Remove(commandSegment.Length - 1);
                    }

                    newlabel = string.Concat(newlabel, commandSegment, "/>");
                    c80 = newlabel;
                }
            }
        }

        //Evalua si la información proporcionada está completa
        private bool IsValidBusinessRules
        {
            get
            {
                bool isVAlid = false;
                if (string.IsNullOrEmpty(txtCommand.Text))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.REQUIERE_INSTRUCCION, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCommand.Focus();
                    isVAlid = false;
                }
                else if (txtCommand.Text.Contains("WFR"))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.COMANDO_NO_WFR, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCommand.Focus();
                    isVAlid = false;
                }
                else if (rdoWillPrice.Checked.Equals(false) && rdoGenerate.Checked.Equals(false))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.SELECCIONA_COTIZA_GENERA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    rdoWillPrice.Focus();
                    isVAlid = false;
                }
                else
                {
                    isVAlid = true;
                }
                return isVAlid;
            }
        }

        #endregion

        #region =====Events=====

        //Regresa al Control de Usuario Welcome o Valida Enter
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);

            if (e.KeyData == Keys.Enter)
                btnAcept_Click(sender, e);
        }

        #endregion

    }
}

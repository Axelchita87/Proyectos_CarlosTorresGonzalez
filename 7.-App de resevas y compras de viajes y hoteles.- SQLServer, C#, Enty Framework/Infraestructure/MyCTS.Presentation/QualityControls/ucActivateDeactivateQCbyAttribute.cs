using System;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using MyCTS.Presentation.Components;
using MyCTS.Business;
using MyCTS.Entities;
using System.Collections.Generic;
using MyCTS.Services.Contracts;

namespace MyCTS.Presentation
{
    public partial class ucActivateDeactivateQCbyAttribute : CustomUserControl
    {

        /// <summary>
        /// Descripcion: Insertar Catalogos en ClientsCatalogs
        /// Creación:    22-Junio-2010 , Modificación:*
        /// Cambio:      *    , Solicito *
        /// Autor:       Jessica Gutierrez 
        /// </summary>

        public ucActivateDeactivateQCbyAttribute()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
               ControlStyles.UserPaint |
               ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtAttribute;
            this.LastControlFocus = btnAccept;
        }

        //Coloca el foco en el txt 
        private void ucActivateDeactivateQCbyAttribute_Load(object sender, EventArgs e)
        {
            txtAttribute.Focus();
            ucAvailability.IsInterJetProcess = false;
        }

        //Llama a las funciones de mostrar, validar y mandar comando
        private void btnAccept_Click(object sender, EventArgs e)
        {
            ShowControls(false);
            if (IsValidBussinessRules)
                Commands();
        }

        //KeyDown
        /// <summary>
        /// Este se usa para todos los controles en general si se oprime 
        /// Esc se manda a el User control de Welcome 
        /// Enter se manda la accion de botón de Aceptar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);

            if (e.KeyData == Keys.Enter)
                btnAccept_Click(sender, e);
        }

        //KeyDown
        /// <summary>
        /// Este se usa para todos los controles en general si se oprime 
        /// Esc se manda a el User control de Welcome 
        /// Enter se manda la accion de LinkButton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEnterDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);

            if (e.KeyData == Keys.Enter)
                lnkUpdate_Click(sender, e);
        }

        //Cambia el foco 
        private void txtAttribute_TextChanged(object sender, EventArgs e)
        {
            if (txtAttribute.Text.Length > 5)
                btnAccept.Focus();
        }

        //Modifica los datos extaidos de la base de datos
        private void lnkUpdate_Click(object sender, EventArgs e)
        {
            string[] update = new string[129];
            for (int row = 0; row <= 128; row++)
            {
                update[row] = dataGridView1.Rows[row].Cells[2].Value.ToString().ToUpper();
            }

            UpdateQCbyAttribute1_ADBL.UpdateQCbyAttribute1_AD(txtAttribute.Text, update[0], update[1],
                update[2], update[3], update[4], update[5], update[6], update[7], update[8], update[9],
                update[10], update[11], update[12], update[13], update[14], update[15], update[16], update[17],
                update[18], update[19], update[20], update[21], update[22], update[23], update[24], update[25],
                update[26], update[27], update[28], update[29], update[30], update[31], update[32], update[33],
                update[34], update[35], update[36], update[37], update[38], update[39], update[40], update[41],
                update[42], update[43], update[44], update[45], update[46], update[47], update[48], update[49],
                update[50], update[51], update[52], update[53], update[54], update[55], update[56], update[57],
                update[58], update[59], update[60], update[61], update[62], update[63], update[64], update[65],
                update[66], update[67], update[68], update[69], update[70], update[71], update[72], update[73],
                update[74], update[75], update[76], update[77], update[78], update[79], update[80], update[81],
                update[82], update[83], update[84], update[85], update[86], update[87], update[88], update[89],
                update[90], update[91], update[92], update[93], update[94], update[95], update[96], update[97],
                update[98], update[99], update[100], update[101], update[102], update[103], update[104], update[105],
                update[106], update[107], update[108], update[109], update[110], update[111], update[112],
                update[113], update[114], update[115], update[116], update[117], update[118], update[119],
                update[120], update[121], update[122], update[123], update[124], update[125], update[126],
                update[127],update[128]);
            MessageBox.Show("LOS DATOS HAN SIDO MODIFICADOS CORRECTAMENTE", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        #region======MethodsClass======

        //Verifica si los datos obligatorios fueron ingresados
        private bool IsValidBussinessRules
        {
            get
            {
                bool isValid = false;
                if (string.IsNullOrEmpty(txtAttribute.Text))
                {
                    MessageBox.Show("REQUIERE INGRESAR ATRIBUTO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAttribute.Focus();
                }
                else
                    isValid = true;
                return isValid;
            }
        }

        //Extrae los datos de la BdD de la tabla de QualityControls
        private void Commands()
        {
            List<GetQCbyAttribute1_AD> list = GetQCbyAttribute1_ADBL.GetAttribute(txtAttribute.Text);
            if (list.Count > 0)
            {
                dataGridView1.DataSource = list;
                ShowControls(true);
                txtAttribute.Focus();
            }
            else
            {
                MessageBox.Show("EL ATRIBUTO NO EXISTE, INGRESE OTRO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAttribute.Focus();
            }
        }

        //Muestra u Oculta los controles 
        private void ShowControls(bool show)
        {
            dataGridView1.Visible = show;
            lblInformation.Visible = show;
            lnkUpdate.Visible = show;
        }

        #endregion

    }
}

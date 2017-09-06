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
    public partial class ucProfilesViewer : CustomUserControl
    {

        /// <summary>
        /// Descripción: User Control que obtiene los datos de pefil de pasajero por PCC
        /// Creación:    27 Enero 2010, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Marcos Q. Ramírez
        /// </summary>

        private List<CatStars1stLevel> Star1List = new List<CatStars1stLevel>();
        private List<CatStars2ndLevel> Star2List = new List<CatStars2ndLevel>();

        public ucProfilesViewer()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtPCC;
            this.LastControlFocus = btnAccept;
        }

        private void ucProfilesViewer_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            Star1List = CatStars1stLevelBL.GetStars1stLevel(Login.OrgId);
            Star2List = CatStars2ndLevelBL.GetStars2ndLevel();
            txtPCC.Text = Login.PCC;
            txtPCC.Focus();
        
        }

        private void txtPCC_TextChanged(object sender, EventArgs e)
        {
            
            lbProfileInfo.Items.Clear();
            dgvStar1List.Rows.Clear();
            dgvStar2List.Rows.Clear();
            SmartTextBox txt = (SmartTextBox)sender;
            Common.SetListBoxPCCs(txt, lbProfileInfo);
            if (txt.Text.Length.Equals(4))
            {
                foreach (CatStars1stLevel star1 in Star1List)
                {
                    if(star1.Pccid.Equals(txtPCC.Text))
                        dgvStar1List.Rows.Add(star1.Star1Name, star1.StarL2Exist);
                }
            }
        }

        private void dgvStar1List_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string StarName = string.Empty;
            int rowIndex = dgvStar1List.CurrentCell.RowIndex;
            StarName = dgvStar1List[0, rowIndex].Value.ToString();
            dgvStar2List.Rows.Clear();
            foreach (CatStars2ndLevel star2 in Star2List)
            {
                if (star2.Pccid.Equals(txtPCC.Text) & star2.Star1id.Equals(StarName))
                {
                    dgvStar2List.Rows.Add(star2.Star2Name);   
                }
                
            }
        }

        private void dgvStarsList_Enter(object sender, EventArgs e)
        {
            ((DataGridView)(sender)).BackgroundColor = Color.PaleGoldenrod;
        }

        private void dgvStarsList_Leave(object sender, EventArgs e)
        {
            ((DataGridView)(sender)).BackgroundColor = SystemColors.AppWorkspace;
        }

        private void dgvStar1List_MultiSelectChanged(object sender, EventArgs e)
        {
            
        }

        private void dgvStar1List_SelectionChanged(object sender, EventArgs e)
        {
            string StarName = string.Empty;
            int rowIndex = dgvStar1List.CurrentCell.RowIndex;
            StarName = dgvStar1List[0, rowIndex].Value.ToString();
            dgvStar2List.Rows.Clear();
            foreach (CatStars2ndLevel star2 in Star2List)
            {
                if (star2.Pccid.Equals(txtPCC.Text) & star2.Star1id.Equals(StarName))
                {
                    dgvStar2List.Rows.Add(star2.Star2Name);
                }

            }
        }
        
    }
}

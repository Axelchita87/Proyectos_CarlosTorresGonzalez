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
    public partial class ucLoadPassengerProfile : CustomUserControl
    {

        /// <summary>
        /// Descripción: User Control que obtiene los datos de pefil de pasajero por predictivos
        /// Creación:    27 Enero 2010, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Marcos Q. Ramírez
        /// </summary>

        public ucLoadPassengerProfile()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtPCC;
           this.LastControlFocus = btnAccept;
        }

        private void ucLoadPassengerProfile_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            CatStars1stLevelBL.ListStars1stLevel.Clear();
            List<CatStars1stLevel> temp = CatStars1stLevelBL.GetStars1stLevel(Login.OrgId);
            if (!temp.Count.Equals(0))
            {
                foreach (CatStars1stLevel stars in temp)
                {
                    ListItem item = new ListItem();
                    item.Value = stars.Pccid;
                    item.Text = stars.Star1Name;
                    CatStars1stLevelBL.ListTemp.Add(item);
                }
            }

            CatStars2ndLevelBL.ListStars2ndLevel.Clear();
            List<CatStars2ndLevel> temp2 = CatStars2ndLevelBL.GetStars2ndLevel();
            if (!temp.Count.Equals(0))
            {
                foreach (CatStars2ndLevel stars in temp2)
                {
                    ListItem item = new ListItem();
                    item.Value = stars.Pccid;
                    item.Text = stars.Star2Name;
                    item.Text2 = stars.Star1id;
                    CatStars2ndLevelBL.ListStars2ndLevel.Add(item);
                }
            } 
            txtPCC.Text = Login.PCC;
            txtPCC.Focus();
        }

        private void txtPCC_TextChanged(object sender, EventArgs e)
        {
            lbProfileInfo.Items.Clear();
            SmartTextBox txt = (SmartTextBox)sender;
            Common.SetListBoxPCCs(txt, lbProfileInfo);
        }

        private void txtStar1name_TextChanged(object sender, EventArgs e)
        {
            lbProfileInfo.Items.Clear();
            SmartTextBox txt = (SmartTextBox)sender;
            Common.SetListBoxStarsFirstLevel(txt, lbProfileInfo, txtStar1name.Text);
            
        }

        private void txtStar2Name_TextChanged(object sender, EventArgs e)
        {
            lbProfileInfo.Items.Clear();
            SmartTextBox txt = (SmartTextBox)sender;
            Common.SetListBoxStarsSecondLevel(txt, lbProfileInfo, txtStar2Name.Text, txtPCC.Text, txtStar1name.Text);
        }
    }
}

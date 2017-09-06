using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MyCTS.Entities;
using MyCTS.Business;
using MyCTS.Presentation.Components;
using MyCTS.Services.ValidateDKsAndCreditCards;
using System.Linq;

namespace MyCTS.Presentation
{
    public class activeStepsCorporativeQC
    {
        //Obtiene una lista de los Qualities...
        private static List<MyCTS.Services.ValidateDKsAndCreditCards.CatCorporativeQualityControls> corporativequalitycontrols;
        public static List<MyCTS.Services.ValidateDKsAndCreditCards.CatCorporativeQualityControls> CorporativeQualityControls
        {
            get { return corporativequalitycontrols; }
            set { corporativequalitycontrols = value; }

        }

        public static void loadQualityControlsList()
        {
            //Obtiene el DK (Attribute1) para validar los Qualities
            WsMyCTS wsServ = new WsMyCTS();
            corporativequalitycontrols = wsServ.GetCorporativeQualityControls(ucFirstValidations.Attribute1).ToList();
        }

        public static void loadQualityControlsHotelsList(string Attribute1)
        {
            //Obtiene el DK (Attribute1) para validar los Qualities...
            WsMyCTS wsServ = new WsMyCTS();
            corporativequalitycontrols = wsServ.GetCorporativeQualityControls(Attribute1).ToList();
            //corporativequalitycontrols = CatCorporativeQualityControlsBL.GetCorporativeQualityControls(Attribute1);
        }


    }
}

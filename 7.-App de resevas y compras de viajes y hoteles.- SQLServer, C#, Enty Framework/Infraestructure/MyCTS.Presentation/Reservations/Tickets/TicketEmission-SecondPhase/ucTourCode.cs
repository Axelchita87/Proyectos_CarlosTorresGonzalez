/// <summary>
/// Descripcion: Permite agregar TourCode a la emision del boleto actual.
/// Pertenece a: Emision de Boleto
/// Creación:    25-Mayo-2009
/// Autor:       Pedro Tomas Solis
/// </summary>

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Business;
using MyCTS.Entities;
using System.Text.RegularExpressions;
using MyCTS.Forms.UI;

namespace MyCTS.Presentation
{
    public partial class ucTourCode : CustomUserControl
    {
        //Declaracion de variables
        public static string TourCode=string.Empty;
        public static string Endorsement = string.Empty;
        public static string Taxes = string.Empty;

        //Constructor
        public ucTourCode()
        {
            InitializeComponent();
        }

        #region =====Eventos=====

        //Evento Load de ucTourCode, ejecuta todo el proceso de TourCode y Endoso
        private void ucTourCode_Load(object sender, EventArgs e)
        {
            //Paso 14.TourCode
            ucAvailability.IsInterJetProcess = false;
            TourCode = string.Empty;
            if (!string.IsNullOrEmpty(ucTicketsEmissionInstructions.tourCode))
            {
                //Concatena Sabre += LorraineCorss + Tipo_TourCode(ITCommand) + TourCode(ITCode)
                TourCode = string.Concat(TourCode, Resources.TicketEmission.Constants.CROSS_LORAINE, ucTicketsEmissionInstructions.tourCodeAgreements, ucTicketsEmissionInstructions.tourCode);
            }

            //Paso 15. Endoso
            Endorsement = string.Empty;
            if (!string.IsNullOrEmpty(ucTicketsEmissionInstructions.Endorsement))
            {
                if (ucTicketsEmissionInstructions.Endorsement.Equals(Resources.TicketEmission.Constants.Add))
                    Endorsement = string.Concat(Endorsement, Resources.TicketEmission.Constants.LORRAINE_CROSS_ED, ucTicketsEmissionInstructions.EndorsementText);
                else
                    Endorsement = string.Concat(Endorsement, Resources.TicketEmission.Constants.LORRAINE_CROSS_EO_SLASH, ucTicketsEmissionInstructions.EndorsementText);
            }

            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCTICKETEMISSIONBUILDCOMMAND);
        }

        #endregion
    }
}

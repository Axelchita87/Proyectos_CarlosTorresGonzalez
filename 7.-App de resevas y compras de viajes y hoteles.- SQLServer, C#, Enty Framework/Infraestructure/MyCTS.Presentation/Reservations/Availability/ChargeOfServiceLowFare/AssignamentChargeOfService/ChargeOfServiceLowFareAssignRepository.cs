using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Base;
using MyCTS.Entities;
using MyCTS.Business;

namespace MyCTS.Presentation.Reservations.Availability.ChargeOfServiceLowFare.AssignamentChargeOfService
{
    public class ChargeOfServiceLowFareAssignRepository : IBaseRepository
    {
        #region Miembros de IBaseRepository

        public void Initialize()
        {

        }

        private Dictionary<string, GenericFormOfPayment> _typeConverter
                                                    = new Dictionary<string, GenericFormOfPayment> {
                                                     {"CCAC",GenericFormOfPayment.AmericanExpress},
                                                     //{"CCPV",GenericFormOfPayment.Visa},
                                                   
                                                     {"CA",GenericFormOfPayment.Cash},
                                                     {"TR",GenericFormOfPayment.Transfer},
                                                     {"CH",GenericFormOfPayment.Check}
                                                     };

        private GenericFormOfPayment GetPaymentType(string type)
        {
            if (_typeConverter.ContainsKey(type))
            {
                return _typeConverter[type];
            }
            return GenericFormOfPayment.Visa;
        }

        public List<FormOfPayment> GetCards()
        {
            var listItemsPayments = CatCreditCardsCodesBL.GetFOPCTSList();
            if (listItemsPayments != null && listItemsPayments.Any())
            {
                var result = listItemsPayments.Select(p => new FormOfPayment
                {
                    Name = p.Text,
                    Type = GetPaymentType(p.Text2)

                }).ToList();
                //result.Add(new FormOfPayment
                //{
                //    Name = "TC VISA/MASTERCARD",
                //    Type = GenericFormOfPayment.Visa
                //});

                return result;

            }
            return new List<FormOfPayment> { };

        }

        //public void LoadFormPaymentCodes()
        //{
        //    List<ListItem> listFOP = CatCreditCardsCodesBL.GetFOPCTSList();

        //    foreach (ListItem FOPItem in listFOP)
        //    {
        //        ListItem litem = new ListItem();
        //        litem.Text = string.Format("{0} - {1}",
        //            FOPItem.Value,
        //            FOPItem.Text);
        //        litem.Value = FOPItem.Value;
        //        litem.Text2 = FOPItem.Text2;
        //        cmbTypeCard.Items.Add(litem);

        //    }
        //    cmbTypeCard.SelectedIndex = 0;
        //}

        #endregion
    }
}

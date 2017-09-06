using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class InterJetPreviousPricing
    {

        public InterJetPassangerPreviousPricing Adult { get; set; }

        public InterJetPassangerPreviousPricing Senior { get; set; }

        public InterJetPassangerPreviousPricing Child { get; set; }

        public InterJetPassangerPreviousPricing Infant { get; set; }
        public decimal TotalToPay
        {
            get
            {
                decimal total = 0;
                if (Adult != null)
                {
                    total += Adult.Total;
                }
                if (Senior != null)
                {

                    total += Senior.Total;
                }
                if (Child != null)
                {
                    total += Child.Total;
                }
                if (Infant != null)
                {
                    total += Infant.Total;
                }
                return total;


            }
        }
    }
}

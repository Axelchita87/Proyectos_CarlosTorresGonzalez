using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class InterJetPassangerNumberRecord
    {

        private const string DK_WITH_TEMP_DK = "990";

        public InterJetPassangers Passangers
        {
            get;
            set;
        }

        public string DK
        {
            get;
            set;
        }

        public InterJetFlights Segments
        {
            get;
            set;
        }

        private string currentRemarks;

        public string Remarks
        {
            get
            {
                return this.currentRemarks;
            }
            set
            {

                this.currentRemarks = value;

            }
        }


        public bool NeedBillAddress
        {
            get{

                return this.DK.EndsWith(InterJetPassangerNumberRecord.DK_WITH_TEMP_DK);

            }
        }
        public string StoredUserFeeCommand
        {
            get;
            set;
        }

        public string ItineraryCommand
        {
            get;
            set;
        }

        public string LimitTimeEntryCommand
        {
            get;
            set;
        }

        private List<string> passangerCommands = new List<string>();
        public List<string> PassangersCommand
        {
            get{

                return this.passangerCommands;
            }
        }

        private List<string> accountingLines = new List<string>();

        public List<string> AccountingLines
        {
            get{
                return this.accountingLines;
            }
        }


    }
}

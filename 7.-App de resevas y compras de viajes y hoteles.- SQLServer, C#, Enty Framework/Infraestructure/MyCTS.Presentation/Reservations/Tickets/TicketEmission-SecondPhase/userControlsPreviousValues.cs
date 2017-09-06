using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Presentation
{
    public class userControlsPreviousValues
    {
        static private string[] ticketsemissioninstructionsparameters;
        static public string[] TicketsEmissionInstructionsParameters
        {
            get { return ticketsemissioninstructionsparameters; }
            set { ticketsemissioninstructionsparameters = value; }
        }

        //private string[] ticketEmissionParameters;
        //public string[] TicketsEmissionParameters
        //{
        //    get { return ticketEmissionParameters; }
        //    set { ticketEmissionParameters = value; }
        //}

        static private string[] phase35375ticketsparameters;
        static public string[] Phase35375TicketsParameters
        {
            get { return phase35375ticketsparameters; }
            set { phase35375ticketsparameters = value; }
        }
        
        
        static private string[] formpaymentparameters;
        static public string[] FormPaymentParameters
        {
            get { return formpaymentparameters; }
            set { formpaymentparameters = value; }
        }

        static private string[] taxes;
        static public string[] Taxes
        {
            get { return taxes; }
            set { taxes = value; }
        }

        static private string[] ticketemissionconfirmation;
        static public string[] TicketEmissionConfirmation
        {
            get { return ticketemissionconfirmation; }
            set { ticketemissionconfirmation = value; }
        }

        static private string[] concludereservation;
        static public string[] Conlcudreservation
        {
            get { return concludereservation; }
            set { concludereservation = value; }
        }

        static private string[] revisedcharge;
        static public string[] Revisedcharge
        {
            get { return revisedcharge; }
            set { revisedcharge = value; }
        }
    }
}

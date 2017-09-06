using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class AuthCode
    {
        private  string pnr;
        public  string PNR
        {
            get { return pnr; }
            set { pnr = value; }
        }

        private  string code;
        public  string Code
        {
            get { return code; }
            set { code = value; }
        }

        private  string cardType;
        public  string CardType
        {
            get { return cardType; }
            set { cardType = value; }
        }

        private  string amount;
        public  string Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        private  string bank;
        public  string Bank
        {
            get { return bank; }
            set { bank = value; }
        }

        private string ticket;
        public string Ticket
        {
            get { return ticket; }
            set { ticket = value; }
        }

        private DateTime date;
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        private string commandWP;
        public string CommandWP
        {
            get { return commandWP; }
            set { commandWP = value; }
        }
    }
}

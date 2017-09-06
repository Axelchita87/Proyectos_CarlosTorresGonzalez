using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class Hotels
    {
        private string hotelid;
        public string HotelID
        {
            get { return hotelid; }
            set { hotelid = value; }
        }

        private string hotelnamechain;
        public string HotelNameChain
        {
            get { return hotelnamechain; }
            set { hotelnamechain = value; }
        }
    }
}

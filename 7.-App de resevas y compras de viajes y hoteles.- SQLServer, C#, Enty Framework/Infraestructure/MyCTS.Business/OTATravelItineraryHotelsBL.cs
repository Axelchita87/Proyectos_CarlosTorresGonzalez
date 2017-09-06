using System;
using System.Collections.Generic;
using MyCTS.DataAccess;
using MyCTS.Entities;

namespace MyCTS.Business
{
    public class OTATravelItineraryHotelsBL
    {
        static bool existRecLog;
        static bool chaincodeEquals;


        public static void getEstatusCancel(List<OTATravelItineraryObjectHotel> lstItineraryHotel)
        {
            List<ListItem> lstChaincode = new List<ListItem>();
            chaincodeEquals = false;
            if (lstItineraryHotel.Count > 0)
            {
                if (lstItineraryHotel[0].CancelNumberList.Count != 0)
                {
                    for (int j = 0; j < lstItineraryHotel[0].CancelNumberList.Count; j++)
                    {
                        // string var = lstItineraryHotel[0].CancelNumberList[j].Split('/')[0].ToString().Trim();

                        lstChaincode = GetChainCodeBL.GetChainCode(lstItineraryHotel[0].Record,
                                                                   lstItineraryHotel[0].CancelNumberList[j].Split('/')[0].Trim());

                        if (lstChaincode.Count > 0)
                        {
                            for (int k = 0; k < lstChaincode.Count; k++)
                            {

                                // existRecLog = false;


                                if (lstChaincode.Count >= 1 && lstChaincode.Count < k)
                                {
                                    if (lstChaincode[k].Text != lstChaincode[k + 1].Text)
                                        existRecLog = false;
                                    else
                                    {
                                        existRecLog = false;
                                        for (int n = 0; n < lstItineraryHotel[0].CancelNumberList.Count; n++)
                                        {
                                            chaincodeEquals = true;
                                            //actualizacion cuando las cadenas hoteeras son iguales
                                            UpdateDetailPNRHotelsBL.UpdateDetailPNRHotels
                                               (lstItineraryHotel[0].Record, lstItineraryHotel[0].CancelNumberList[n].Split('/')[0], false,
                                               lstItineraryHotel[0].CancelNumberList[n].Split('/')[1]);
                                        }
                                    }

                                }

                                if (chaincodeEquals != true)
                                    for (int i = 0; i < lstItineraryHotel[0].CancelNumberList.Count; i++)
                                    {
                                        if (lstItineraryHotel[0].CancelNumberList[i].Split('/')[0].Trim() == lstChaincode[k].Text)
                                        {

                                            existRecLog = false;
                                            //string r = lstItineraryHotel[0].CancelNumberList[i].Split('/')[1];
                                            //actualizacion cuando cadenas hoteleras son distintas
                                            UpdateDetailPNRHotelsBL.UpdateDetailPNRHotels
                                                (lstItineraryHotel[0].Record, lstItineraryHotel[0].CancelNumberList[i].Split('/')[0], true,
                                                lstItineraryHotel[0].CancelNumberList[i].Split('/')[1]);
                                        }
                                        else { existRecLog = true; }
                                    }
                            }
                        }
                        else
                        {
                            existRecLog = true;
                        }
                    }
                }
                else
                {
                    existRecLog = true;
                }
            }

        }




        public static bool InsertItineraryHotel(List<OTATravelItineraryObjectHotel> lstItineraryHotel)
        {
            bool insert = false;
            OTATravelItineraryHotelDAL objItineraryHotel = new OTATravelItineraryHotelDAL();
            //List<ListItem> lstChaincode= new List<ListItem>();
            existRecLog = true;

            try
            {
                try
                {
                    //getEstatusCancel(lstItineraryHotel);
                    if (lstItineraryHotel.Count > 0)
                    {
                        foreach (OTATravelItineraryObjectHotel item in lstItineraryHotel)
                        {
                            if (!string.IsNullOrEmpty(item.Hotel))
                            {
                                if (item.StatusSabre.ToUpper() == "HK")
                                {
                                    if (existRecLog)
                                    {
                                        insert = objItineraryHotel.InsertPNR(item, CommonENT.MYCTSDB_CONNECTION);
                                    }
                                }
                                else
                                {
                                    insert = true;
                                }
                            }
                        }
                    }
                }

                catch (Exception ex)
                {
                    //string err = e.Message + e.Source + e.InnerException;
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    getEstatusCancel(lstItineraryHotel);
                    foreach (OTATravelItineraryObjectHotel item in lstItineraryHotel)
                    {
                        if (!string.IsNullOrEmpty(item.Hotel))
                        {
                            if (item.StatusSabre.ToUpper() == "HK")
                            {
                                if (existRecLog)
                                {
                                    objItineraryHotel.InsertPNR(item, CommonENT.MYCTSDBBACKUP_CONNECTION);
                                }
                            }
                        }
                    }
                }
            }
            catch { }
            return insert;
        }
    }
}

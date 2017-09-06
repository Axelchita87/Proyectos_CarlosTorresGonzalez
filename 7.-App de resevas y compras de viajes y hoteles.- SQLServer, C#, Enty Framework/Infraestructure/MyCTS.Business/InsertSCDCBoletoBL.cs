using MyCTS.DataAccess;
using MyCTS.Entities;
using System;


namespace MyCTS.Business
{
    public class InsertSCDCBoletoBL
    {
        public string InsertSCDCBoleto(SCDCBoleto boleto)
        {
            string result = string.Empty;

            try
            {
                InsertSCDCBoletoDAL objBoleto = new InsertSCDCBoletoDAL();

                try
                {
                    result = objBoleto.InsertSCDCBoleto(boleto, CommonENT.MYCTSDB_CONNECTION);
                }
                catch(Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    result = objBoleto.InsertSCDCBoleto(boleto, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch { }

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


namespace MyCTS.DataAccess
{
    public class SetAirLinesFareDAL
    {
        public void SetAirLinesFare(string catAirLinFarId, string catAirLinFarName, bool ccAut, bool ccMan,
                                    bool cash, bool pMix, bool misc,Byte[] data, bool opManual, string connectionName)
        {
            SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings[connectionName].ToString());
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand(Resources.SetAirLinesFareResources.SP_SetAirLinesFare, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(Resources.SetAirLinesFareResources.PARAM_QUERY,catAirLinFarId);
                cmd.Parameters.AddWithValue(Resources.SetAirLinesFareResources.PARAM_QUERY2,catAirLinFarName);
                cmd.Parameters.AddWithValue(Resources.SetAirLinesFareResources.PARAM_QUERY3,ccAut);
                cmd.Parameters.AddWithValue(Resources.SetAirLinesFareResources.PARAM_QUERY4,ccMan);
                cmd.Parameters.AddWithValue(Resources.SetAirLinesFareResources.PARAM_QUERY5,cash);
                cmd.Parameters.AddWithValue(Resources.SetAirLinesFareResources.PARAM_QUERY6,pMix);
                cmd.Parameters.AddWithValue(Resources.SetAirLinesFareResources.PARAM_QUERY7,misc);
                cmd.Parameters.AddWithValue(Resources.SetAirLinesFareResources.PARAM_QUERY8,data);
                cmd.Parameters.AddWithValue(Resources.SetAirLinesFareResources.PARAM_QUERY9,opManual);
                cmd.ExecuteNonQuery();
            }
            catch { }
            finally 
            {
                cnn.Close();
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace MyCTS.DataAccess
{
    public class UpdateImagesDAL
    {
        public int UpdateImgTicketPrinter(Byte[] data, string connection)
        {
            int rowsAfected = 0;
            SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings[connection].ToString());
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand(Resources.UpdateImagesResources.SP_UPDATEBANNERIMAGETICKETPRINTER, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(Resources.UpdateImagesResources.PARAM_CONTENT, data);
                rowsAfected = cmd.ExecuteNonQuery();
            }
            catch { }
            finally 
            {
                cnn.Close();
            }
            return rowsAfected;
        }

        public int UpdateImgAirline(Byte[] data, string codeAirline, string connection)
        {
            int rowsAfected = 0;
            SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings[connection].ToString());
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand(Resources.UpdateImagesResources.SP_SETLOGOAIRLINE, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(Resources.UpdateImagesResources.PARAM_LOGOAIRLINE, data);
                cmd.Parameters.AddWithValue(Resources.UpdateImagesResources.PARAM_IDAIRLINE, codeAirline);
                rowsAfected = cmd.ExecuteNonQuery();
            }
            catch { }
            finally 
            {
                cnn.Close();
            }
            return rowsAfected;
        }

        public int InsertBannerImage(Byte[] data, string name, string extension, string url,
            string activate, string connection)
        {
            int rowsAfected = 0;
            SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings[connection].ToString());
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand(Resources.UpdateImagesResources.SP_SETBANNERIMAGE, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(Resources.UpdateImagesResources.PARAM_CONTENT, data);
                cmd.Parameters.AddWithValue(Resources.UpdateImagesResources.PARAM_NAME, name);
                cmd.Parameters.AddWithValue(Resources.UpdateImagesResources.PARAM_EXTENSION, extension);
                cmd.Parameters.AddWithValue(Resources.UpdateImagesResources.PARAM_URL, url);
                cmd.Parameters.AddWithValue(Resources.UpdateImagesResources.PARAM_ACTIVATE, activate);
                rowsAfected = cmd.ExecuteNonQuery();
            }
            catch { }
            finally 
            {
                cnn.Close();
            }
            return rowsAfected;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.IO;
using System.Data;
using System.Data.Common;
using MyCTS.Entities;
using MyCTS.Components.NullableHelper;
using System.Collections;

namespace MyCTS.DataAccess
{
    public class CatalogsDAL
    {
        public List<string> GetCatalogsFileNames(string connectionName)
        {
            List<string> catalogsList = new List<string>();
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand("GetCatalogsFileNames");

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                while (dr.Read())
                {
                    catalogsList.Add(dr.GetString(0));
                }
            }

            return catalogsList;

        }
        public ArrayList GetMissingCatalog(string filesLeft, string connectionName)
        {
            ArrayList catalogCollection = new ArrayList();

            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand("GetMissingCatalogs");
            db.AddInParameter(dbCommand, "filesLeft", DbType.String, filesLeft);

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                FetchCatalogs(dr, catalogCollection);
            }

            return catalogCollection;
        }

        private void FetchCatalogs(IDataReader dr, ArrayList catalogCollection)
        {
            List<ListItem> catalogsList = null;

            catalogsList = GetSingleCatalogCollection(dr);
            catalogCollection.Add(catalogsList);
            if (dr.NextResult())
                FetchCatalogs(dr, catalogCollection);
        }

        public ArrayList GetAllCatalogs(string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand("GetAllCatalogs");

            ArrayList catalogCollection = new ArrayList();
            List<ListItem> catalogsList = null;

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {

                int _text = 0;
                int _text2 = 0;
                int _text3 = 0;
                int _value = 0;

                //************GetCatalog_AirPortCityCountry_MIN****************
                _text = dr.GetOrdinal("Text");
                _value = dr.GetOrdinal("Value");
                catalogsList = new List<ListItem>();
                while (dr.Read())
                {
                    ListItem item = new ListItem();
                    item.Text = dr.GetString(_text);
                    item.Value = dr.GetString(_value);
                    catalogsList.Add(item);
                }
                catalogCollection.Add(catalogsList);

                //************GetCatalog_AirPortCityCountry_MAJ****************
                dr.NextResult();
                _text = dr.GetOrdinal("Text");
                _text2 = dr.GetOrdinal("Text2");
                _text3 = dr.GetOrdinal("Text3");
                _value = dr.GetOrdinal("Value");
                catalogsList = new List<ListItem>();
                while (dr.Read())
                {
                    ListItem item = new ListItem();
                    item.Text = dr.GetString(_text);
                    item.Text2 = dr.GetString(_text2);
                    item.Text3 = dr.GetString(_text3);
                    item.Value = dr.GetString(_value);
                    catalogsList.Add(item);
                }
                catalogCollection.Add(catalogsList);

                //************GetCatalog_AirLines****************
                dr.NextResult();
                catalogsList = GetSingleCatalogCollection(dr);
                catalogCollection.Add(catalogsList);

                //************GetCatalog_Countries****************
                dr.NextResult();
                catalogsList = GetSingleCatalogCollection(dr);
                catalogCollection.Add(catalogsList);

                //************GetCatalog_BusCodes****************
                dr.NextResult();
                catalogsList = GetSingleCatalogCollection(dr);
                catalogCollection.Add(catalogsList);

                //************GetCatalog_Hotels****************
                dr.NextResult();
                catalogsList = GetSingleCatalogCollection(dr);
                catalogCollection.Add(catalogsList);

                //************GetCatalog_CreditCardsCodes****************
                dr.NextResult();
                catalogsList = GetSingleCatalogCollection(dr);
                catalogCollection.Add(catalogsList);

                //************GetCatalog_SeaVendorsCodes****************
                dr.NextResult();
                catalogsList = GetSingleCatalogCollection(dr);
                catalogCollection.Add(catalogsList);

                //************GetCatalog_CurrenciesCountries****************
                dr.NextResult();
                _text = dr.GetOrdinal("Text");
                _text2 = dr.GetOrdinal("Text2");
                _text3 = dr.GetOrdinal("Text3");
                _value = dr.GetOrdinal("Value");
                catalogsList = new List<ListItem>();
                while (dr.Read())
                {
                    ListItem item = new ListItem();
                    item.Text = dr.GetString(_text);
                    item.Text2 = dr.GetString(_text2);
                    item.Text3 = dr.GetString(_text3);
                    item.Value = dr.GetString(_value);
                    catalogsList.Add(item);
                }
                catalogCollection.Add(catalogsList);

                //************GetCatalog_StatusCodes****************
                dr.NextResult();
                catalogsList = GetSingleCatalogCollection(dr);
                catalogCollection.Add(catalogsList);


                //************GetCatalog_StatesUSA * ***************
                dr.NextResult();
                catalogsList = GetSingleCatalogCollection(dr);
                catalogCollection.Add(catalogsList);

                //************GetCatalog_AirLinesClasses * ***************
                dr.NextResult();
                catalogsList = GetSingleCatalogCollection(dr);
                catalogCollection.Add(catalogsList);

                //************GetCatalog_Cities * ***************
                dr.NextResult();
                catalogsList = GetSingleCatalogCollection(dr);
                catalogCollection.Add(catalogsList);

                //************GetCatalog_CarType * ***************
                dr.NextResult();
                catalogsList = GetSingleCatalogCollection(dr);
                catalogCollection.Add(catalogsList);

                //************GetCatalog_EquipmentCodes * ***************
                dr.NextResult();
                catalogsList = GetSingleCatalogCollection(dr);
                catalogCollection.Add(catalogsList);

                //************GetCatalog_VendorCodes * ***************
                dr.NextResult();
                catalogsList = GetSingleCatalogCollection(dr);
                catalogCollection.Add(catalogsList);

                //************GetCatalog_ChargePerService ****************
                dr.NextResult();
                _text = dr.GetOrdinal("Text");
                _text2 = dr.GetOrdinal("Text2");
                _text3 = dr.GetOrdinal("Text3");
                _value = dr.GetOrdinal("Value");
                catalogsList = new List<ListItem>();
                while (dr.Read())
                {
                    ListItem item = new ListItem();
                    item.Text = dr.GetString(_text);
                    item.Text2 = dr.GetString(_text2);
                    item.Text3 = dr.GetString(_text3);
                    item.Value = dr.GetString(_value);
                    catalogsList.Add(item);
                }
                catalogCollection.Add(catalogsList);

                //************GetCatalog_PCCs * ***************
                dr.NextResult();
                catalogsList = GetSingleCatalogCollection(dr);
                catalogCollection.Add(catalogsList);

                //************GetCatalog_DK * ***************
                dr.NextResult();
                catalogsList = GetSingleCatalogCollection(dr);
                catalogCollection.Add(catalogsList);

                //************GetCatalog_PAirlinesFare * ***************
                dr.NextResult();
                catalogsList = GetSingleCatalogCollection(dr);
                catalogCollection.Add(catalogsList);

                //************GetCatalog_CostCenters * ***************
                dr.NextResult();
                catalogsList = GetSingleCatalogCollection(dr);
                catalogCollection.Add(catalogsList);


                //************GetCatalog_MealCodes ****************
                dr.NextResult();
                _text = dr.GetOrdinal("Text");
                _text2 = dr.GetOrdinal("Text2");
                _text3 = dr.GetOrdinal("Text3");
                _value = dr.GetOrdinal("Value");
                catalogsList = new List<ListItem>();
                while (dr.Read())
                {
                    ListItem item = new ListItem();
                    item.Text = dr.GetString(_text);
                    item.Text2 = dr.GetString(_text2);
                    item.Text3 = dr.GetString(_text3);
                    item.Value = dr.GetString(_value);
                    catalogsList.Add(item);
                }
                catalogCollection.Add(catalogsList);


            }

            return catalogCollection;
        }

        private List<ListItem> GetSingleCatalogCollection(IDataReader dr)
        {
            List<ListItem> catalogsList = new List<ListItem>();

            while (dr.Read())
            {
                ListItem item = new ListItem();
                item.Value = dr.GetString(0);
                item.Text = dr.GetString(1);
                item.Text2 = dr.GetString(2);
                item.Text3 = dr.GetString(3);
                item.Text5 = dr.GetString(4);
                item.Text6 = dr.GetString(5);
                item.Text7 = dr.GetString(6);
                item.Text8 = dr.GetString(7);
                catalogsList.Add(item);
            }

            return catalogsList;
        }

        public List<ListItem> GetAirPortCityCountryMin()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetCatalog_AirPortCityCountry_MIN");

            List<ListItem> catalogsList = new List<ListItem>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {

                int _text = dr.GetOrdinal("Text");
                int _value = dr.GetOrdinal("Value");

                while (dr.Read())
                {
                    ListItem item = new ListItem();
                    item.Text = dr.GetString(_text);
                    item.Value = dr.GetString(_value);
                    catalogsList.Add(item);
                }
            }

            return catalogsList;
        }

        public List<ListItem> GetAirPortCityCountryMaj()
        {
            try
            {
                return GetCatalogThreeCriteria("GetCatalog_AirPortCityCountry_MAJ");
            }
            catch
            {
                return GetCatalogThreeCriteria("GetCatalog_AirPortCityCountry_MAJ", CommonENT.MYCTSDBBACKUP_CONNECTION);
            }
        }

        public List<ListItem> GetAirLines()
        {
            try
            {
                return GetCatalog("GetCatalog_AirLines");
            }
            catch
            {
                return GetCatalog("GetCatalog_AirLines", CommonENT.MYCTSDBBACKUP_CONNECTION);
            }

        }

        public List<ListItem> GetCountries()
        {
            try
            {
                return GetCatalog("GetCatalog_Countries");
            }
            catch
            {
                return GetCatalog("GetCatalog_Countries", CommonENT.MYCTSDBBACKUP_CONNECTION);
            }

        }

        public List<ListItem> GetBusCodes()
        {
            try
            {
                return GetCatalog("GetCatalog_BusCodes");
            }
            catch
            {
                return GetCatalog("GetCatalog_BusCodes", CommonENT.MYCTSDBBACKUP_CONNECTION);
            }

        }

        public List<ListItem> GetHotels()
        {
            try
            {
                return GetCatalog("GetCatalog_Hotels");
            }
            catch
            {
                return GetCatalog("GetCatalog_Hotels", CommonENT.MYCTSDBBACKUP_CONNECTION);
            }

        }

        public List<ListItem> GetCreditCardsCodes()
        {
            try
            {
                return GetCatalog("GetCatalog_CreditCardsCodes");
            }
            catch
            {
                return GetCatalog("GetCatalog_CreditCardsCodes", CommonENT.MYCTSDBBACKUP_CONNECTION);
            }

        }

        public List<ListItem> GetSeaVendorsCodes()
        {
            try
            {
                return GetCatalog("GetCatalog_SeaVendorsCodes");
            }
            catch
            {
                return GetCatalog("GetCatalog_SeaVendorsCodes", CommonENT.MYCTSDBBACKUP_CONNECTION);
            }

        }

        public List<ListItem> GetCurrenciesCountries()
        {
            try
            {
                return GetCatalogThreeCriteria("GetCatalog_CurrenciesCountries");
            }
            catch
            {
                return GetCatalogThreeCriteria("GetCatalog_CurrenciesCountries", CommonENT.MYCTSDBBACKUP_CONNECTION);
            }

        }

        public List<ListItem> GetStatusCodes()
        {
            try
            {
                return GetCatalog("GetCatalog_StatusCodes");
            }
            catch
            {
                return GetCatalog("GetCatalog_StatusCodes", CommonENT.MYCTSDBBACKUP_CONNECTION);
            }

        }

        private List<ListItem> GetCatalog(string spName)
        {
            return GetCatalog(spName, CommonENT.MYCTSDB_CONNECTION);
        }

        private List<ListItem> GetCatalog(string spName, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(spName);

            List<ListItem> catalogsList = new List<ListItem>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _text = dr.GetOrdinal("Text");
                int _text2 = dr.GetOrdinal("Text2");
                int _text3 = dr.GetOrdinal("Text3");
                int _value = dr.GetOrdinal("Value");

                while (dr.Read())
                {
                    ListItem item = new ListItem();
                    item.Text = dr.GetString(_text);
                    item.Text2 = dr.GetString(_text2);
                    item.Text3 = dr.GetString(_text3);
                    item.Value = dr.GetString(_value);
                    catalogsList.Add(item);
                }
            }

            return catalogsList;
        }

        private List<ListItem> GetCatalogThreeCriteria(string spName)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(spName);

            List<ListItem> catalogsList = new List<ListItem>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _text = dr.GetOrdinal("Text");
                int _text2 = dr.GetOrdinal("Text2");
                int _text3 = dr.GetOrdinal("Text3");
                int _value = dr.GetOrdinal("Value");

                while (dr.Read())
                {
                    ListItem item = new ListItem();
                    item.Text = dr.GetString(_text);
                    item.Text2 = dr.GetString(_text2);
                    item.Text3 = dr.GetString(_text3);
                    item.Value = dr.GetString(_value);
                    catalogsList.Add(item);
                }
            }

            return catalogsList;
        }

        private List<ListItem> GetCatalogThreeCriteria(string spName, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(spName);

            List<ListItem> catalogsList = new List<ListItem>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _text = dr.GetOrdinal("Text");
                int _text2 = dr.GetOrdinal("Text2");
                int _text3 = dr.GetOrdinal("Text3");
                int _value = dr.GetOrdinal("Value");

                while (dr.Read())
                {
                    ListItem item = new ListItem();
                    item.Text = dr.GetString(_text);
                    item.Text2 = dr.GetString(_text2);
                    item.Text3 = dr.GetString(_text3);
                    item.Value = dr.GetString(_value);
                    catalogsList.Add(item);
                }
            }

            return catalogsList;
        }


        public List<ListItem> GetCities()
        {
            try
            {
                return GetCatalog("GetCatalog_Cities");
            }
            catch
            {
                return GetCatalog("GetCatalog_Cities", CommonENT.MYCTSDBBACKUP_CONNECTION);
            }

        }

        public List<ListItem> GetStatesUSA()
        {
            try
            {
                return GetCatalog("GetCatalog_StatesUSA");
            }
            catch
            {
                return GetCatalog("GetCatalog_StatesUSA", CommonENT.MYCTSDBBACKUP_CONNECTION);
            }

        }


        public List<ListItem> GetAirLinesClasses()
        {
            try
            {
                return GetCatalog("GetCatalog_AirLinesClasses");
            }
            catch
            {
                return GetCatalog("GetCatalog_AirLinesClasses", CommonENT.MYCTSDBBACKUP_CONNECTION);
            }

        }


        public List<ListItem> GetCarType()
        {
            try
            {
                return GetCatalog("GetCatalog_TypesCodes");
            }
            catch
            {
                return GetCatalog("GetCatalog_TypesCodes", CommonENT.MYCTSDBBACKUP_CONNECTION);
            }

        }

        public List<ListItem> GetEquipmentCodes()
        {
            try
            {
                return GetCatalog("GetCatalog_EquipmentCodes");
            }
            catch
            {
                return GetCatalog("GetCatalog_EquipmentCodes", CommonENT.MYCTSDBBACKUP_CONNECTION);
            }

        }

        public List<ListItem> GetVendorCodes()
        {
            try
            {
                return GetCatalog("GetCatalog_VendorCodes");
            }
            catch
            {
                return GetCatalog("GetCatalog_VendorCodes", CommonENT.MYCTSDBBACKUP_CONNECTION);
            }

        }

        public List<ListItem> GetChargePerService()
        {
            try
            {
                return GetCatalog("GetCatalog_ChargePerService");
            }
            catch
            {
                return GetCatalog("GetCatalog_ChargePerService", CommonENT.MYCTSDBBACKUP_CONNECTION);
            }

        }

        public List<ListItem> GetPCCs()
        {
            try
            {
                return GetCatalog("GetCatalog_Pccs");
            }
            catch
            {
                return GetCatalog("GetCatalog_Pccs", CommonENT.MYCTSDBBACKUP_CONNECTION);
            }

        }

        public List<ListItem> GetConfirmDK()
        {
            try
            {
                return GetCatalog("GetCatalog_ConfirmDK");
            }
            catch
            {
                return GetCatalog("GetCatalog_ConfirmDK", CommonENT.MYCTSDBBACKUP_CONNECTION);
            }

        }

        public List<ListItem> GetPAirlinesFare()
        {
            try
            {
                return GetCatalog("GetCatalog_PAirlinesFare");
            }
            catch
            {
                return GetCatalog("GetCatalog_PAirlinesFare", CommonENT.MYCTSDBBACKUP_CONNECTION);
            }

        }

        public List<ListItem> GetCostCenter()
        {
            try
            {
                return GetCatalog("GetCatalog_CostCenters");
            }
            catch
            {
                return GetCatalog("GetCatalog_CostCenters", CommonENT.MYCTSDBBACKUP_CONNECTION);
            }

        }

        public List<ListItem> GetMealCodes()
        {
            try
            {
                return GetCatalog("GetCatalog_MealCodes");
            }
            catch
            {
                return GetCatalog("GetCatalog_MealCodes", CommonENT.MYCTSDBBACKUP_CONNECTION);
            }
        }


        public List<ListItem> GetClientsNextel()
        {
            try
            {
                return GetCatalog("GetCatalog_ClientsCatalogs_Nextel");
            }
            catch
            {
                return GetCatalog("GetCatalog_ClientsCatalogs_Nextel", CommonENT.MYCTSDBBACKUP_CONNECTION);
 
            }
        }
    }
}

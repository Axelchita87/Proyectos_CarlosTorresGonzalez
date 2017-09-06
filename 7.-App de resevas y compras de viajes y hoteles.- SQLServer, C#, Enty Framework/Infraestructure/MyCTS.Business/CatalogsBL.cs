using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;
using System.Collections;

namespace MyCTS.Business
{
    public class CatalogsBL
    {
        public enum CatalogName
        {
            AirPortCityCountryMin = 0,
            AirPortCityCountryMaj = 1,
            AirLines = 2,
            Countries = 3,
            BusCodes = 4,
            Hotels = 5,
            CreditCardsCodes = 6,
            SeaVendorsCodes = 7,
            CurrenciesCountries = 8,
            StatusCodes = 9,
            Cities = 10,
            StatesUSA=11,
            AirLinesClasses=12,
            CarType=13,
            EquipmentCodes=14,
            VendorCodes=15,
            ChargePerService=16,
            PCCs=17,
            ConfirmDK = 18,
            PAirlinesFare = 19,
            CostCenter=20,
            MealCodes=21,
            ClientsCatalogs = 22,
            ClientsNextel = 23
        }

        public static List<string> GetCatalogsFileNames()
        {
            List<string> catalogsList = null;

            try
            {
                try
                {
                    catalogsList = new CatalogsDAL().GetCatalogsFileNames(CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    catalogsList = new CatalogsDAL().GetCatalogsFileNames(CommonENT.MYCTSDBBACKUP_CONNECTION);
                }                
            }
            catch 
            {
            
            }

            return catalogsList;

        }
        public static ArrayList GetMissingCatalog(string filesLeft)
        {
            ArrayList catalogsCollection = null;
            try
            {
                try
                {
                    catalogsCollection = new CatalogsDAL().GetMissingCatalog(filesLeft, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    catalogsCollection = new CatalogsDAL().GetMissingCatalog(filesLeft, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
                

            }
            catch { }

            return catalogsCollection;

        }

        public static ArrayList GetAllCatalogs()
        {
            ArrayList catalogsCollection = null;
            CatalogsDAL objCatalogs = new CatalogsDAL(); 
            try
            {
                try
                {
                    catalogsCollection = objCatalogs.GetAllCatalogs(CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    catalogsCollection = objCatalogs.GetAllCatalogs(CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch { }

            return catalogsCollection;

        }
        public static List<ListItem> GetCatalogs(CatalogName catalog)
        {
            List<ListItem> listCatalogs = new List<ListItem>();
            try
            {
                CatalogsDAL objCatalogs = new CatalogsDAL();

                switch (catalog)
                {
                    case CatalogName.AirPortCityCountryMin:
                        listCatalogs = objCatalogs.GetAirPortCityCountryMin();
                        break;
                    case CatalogName.AirPortCityCountryMaj:
                        listCatalogs = objCatalogs.GetAirPortCityCountryMaj();
                        break;
                    case CatalogName.AirLines:
                        listCatalogs = objCatalogs.GetAirLines();
                        break;
                    case CatalogName.Countries:
                        listCatalogs = objCatalogs.GetCountries();
                        break;
                    case CatalogName.BusCodes:
                        listCatalogs = objCatalogs.GetBusCodes();
                        break;
                    case CatalogName.Hotels:
                        listCatalogs = objCatalogs.GetHotels();
                        break;
                    case CatalogName.CreditCardsCodes:
                        listCatalogs = objCatalogs.GetCreditCardsCodes();
                        break;
                    case CatalogName.SeaVendorsCodes:
                        listCatalogs = objCatalogs.GetSeaVendorsCodes();
                        break;
                    case CatalogName.CurrenciesCountries:
                        listCatalogs = objCatalogs.GetCurrenciesCountries();
                        break;
                    case CatalogName.StatusCodes:
                        listCatalogs = objCatalogs.GetStatusCodes();
                        break;
                    case CatalogName.Cities:
                        listCatalogs = objCatalogs.GetCities();
                        break;

                    case CatalogName.StatesUSA:
                        listCatalogs = objCatalogs.GetStatesUSA();
                        break;
                    case CatalogName.AirLinesClasses:
                        listCatalogs = objCatalogs.GetAirLinesClasses();
                        break;
                    case CatalogName.CarType:
                        listCatalogs = objCatalogs.GetCarType();
                        break;
                    case CatalogName.EquipmentCodes:
                        listCatalogs = objCatalogs.GetEquipmentCodes();
                        break;
                    case CatalogName.VendorCodes:
                        listCatalogs = objCatalogs.GetVendorCodes();
                        break;
                    case CatalogName.ChargePerService:
                        listCatalogs = objCatalogs.GetChargePerService();
                        break;
                    case CatalogName.PCCs:
                        listCatalogs = objCatalogs.GetPCCs();
                        break;
                    case CatalogName.ConfirmDK:
                        listCatalogs = objCatalogs.GetConfirmDK();
                        break;
                    case CatalogName.PAirlinesFare:
                        listCatalogs = objCatalogs.GetPAirlinesFare();
                        break;
                    case CatalogName.CostCenter:
                        listCatalogs = objCatalogs.GetCostCenter();
                        break;
                    case CatalogName.MealCodes:
                        listCatalogs = objCatalogs.GetMealCodes();
                        break;
                    case CatalogName.ClientsNextel:
                        listCatalogs = objCatalogs.GetClientsNextel();
                        break;
                }

            }
            catch
            { }
            return listCatalogs;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace MyCTS.DataAccess
{
    public class InterJeTaxDAL
    {

        /// <summary>
        /// Gets the inter jet tax.
        /// </summary>
        /// <param name="departureStation">The departure station.</param>
        /// <returns></returns>
        public InterJetTax GetInterJetTax(string departureStation)
        {

            return Taxes.FirstOrDefault(tax => tax.DepartureStation.Equals(departureStation));
        }


        /// <summary>
        /// 
        /// </summary>
        private static List<InterJetTax> taxes;

        /// <summary>
        /// Gets the taxes.
        /// </summary>
        private static List<InterJetTax> Taxes
        {
            get
            {
                return taxes ?? (taxes = GetInterJetTaxes());
            }
        }


        /// <summary>
        /// Gets the inter jet taxes.
        /// </summary>
        /// <returns></returns>
        private static List<InterJetTax> GetInterJetTaxes()
        { 
            try
            {
                return GetInterJetTaxObject(CommonENT.MYCTSDB_CONNECTION);
            }
            catch (Exception ex)
            {
                try
                {
                    return GetInterJetTaxObject(CommonENT.MYCTSDBBACKUP_CONNECTION);
                }catch
                {
                    return new List<InterJetTax>();
                }
            }
        }
        /// <summary>
        /// Gets the inter jet tax object.
        /// </summary>
        /// <param name="stringConnection">The string connection.</param>
        /// <returns></returns>
        private static List<InterJetTax> GetInterJetTaxObject(string stringConnection)
        {

            Database dataBase = DatabaseFactory.CreateDatabase(stringConnection);
            DbCommand dataBaseCommand = dataBase.GetStoredProcCommand("GetInterJetTaxes");
            var taxes = new List<InterJetTax>();

            using (IDataReader dataReader = dataBase.ExecuteReader(dataBaseCommand))
            {
                int departureStation = dataReader.GetOrdinal("DepartureStation");
                int Iva = dataReader.GetOrdinal("IVA");
                int tua = dataReader.GetOrdinal("TUA");

                while (dataReader.Read())
                {
                    var tax = new InterJetTax();
                    tax.DepartureStation = dataReader.GetString(departureStation);
                    tax.IVA = dataReader.GetString(Iva);
                    tax.TUA = dataReader.GetString(tua);

                    taxes.Add(tax);

                }

            }
            return taxes;

        }

    }
}

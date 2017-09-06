using MyCTS.DataAccess;
using MyCTS.Entities;


namespace MyCTS.Business
{

    public class InterJetTaxBL
    {

        private InterJeTaxDAL _dataAcces;

        private InterJeTaxDAL DataAcces
        {
            get{

                if(_dataAcces == null)
                {
                    _dataAcces = new InterJeTaxDAL();
                }
                return _dataAcces;
            }
        }


        public InterJetTax GetInterJetTax(string departureStation)
        {

            return DataAcces.GetInterJetTax(departureStation);

        }

    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;


namespace ADMIN2.DAL
{
    internal class DBParamBuilder
    {                
        internal IDataParameter GetParameter(DBParameter parameter)
        {            
            IDbDataParameter dbParam = GetParameter();         
            dbParam.ParameterName = parameter.Name;         
            dbParam.Value = parameter.Value;
            dbParam.Direction = parameter.ParamDirection;            
            dbParam.DbType = parameter.Type;

            return dbParam;            
        }

        internal List<IDataParameter> GetParameterCollection(DBParameterCollection parameterCollection)
        {
            List<IDataParameter> dbParamCollection = new List<IDataParameter>();
            IDataParameter dbParam = null;
            foreach(DBParameter param in parameterCollection.Parameters)
            {
                dbParam = GetParameter(param);
                dbParamCollection.Add(dbParam);
            }
            
            return dbParamCollection;
        }

        #region Private Methods
        private IDbDataParameter GetParameter()
        {
            string typeName = AssemblyProvider.GetInstance(Configuration.ProviderName).GetParameterType();
            IDbDataParameter dbParam = (IDbDataParameter)AssemblyProvider.GetInstance(Configuration.ProviderName).DBProviderAssembly.CreateInstance(typeName);
            return dbParam;
        }

  

        #endregion
    }
}

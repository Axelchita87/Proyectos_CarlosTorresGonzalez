using System.Data;
using System.Data.Common;
using System.IO;
using Microsoft.Practices.EnterpriseLibrary.Data;
using MyCTS.Entities;

namespace MyCTS.DataAccess
{
    public class DocumentsDAL
    {

        public Documents GetSingleDocument(string docname, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand("GetSingleDocument");
            dbCommand.CommandTimeout = 60;
            db.AddInParameter(dbCommand, "docname", DbType.String, docname);

            Documents item = null;

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _docid = dr.GetOrdinal("DocId");
                int _content = dr.GetOrdinal("Documento");
                int _filename = dr.GetOrdinal("NombreDoc");
                int _extension = dr.GetOrdinal("Extension");

                if (dr.Read())
                {
                    item = new Documents {DocID = dr.GetInt32(_docid)};
                    // comienza la descarga en chunks
                    byte[] data = new byte[1000];
                    MemoryStream ms = new MemoryStream();
                    int index = 0;
                    while (true)
                    {
                        long count = dr.GetBytes(_content,index, data, 0, data.Length);
                        if (count == 0)
                        {
                            break;
                        }
                        index = index + (int)count;
                        ms.Write(data, 0, (int)count);
                    }
                    item.Content = ms.ToArray();
                    item.FileName = dr.GetString(_filename);
                    item.Extension = dr.GetString(_extension);
                }
            }

            return item;
        }

    }
}

using System;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Excel = Microsoft.Office.Interop.Excel;

namespace AdminEvents
{
    public class ActDAL
    {
        private string conx = string.Empty;
        private MySqlConnection conm = null;
        private MySqlTransaction tranm = null;

        public ActDAL(string opc)
        {
            if (opc=="org")
                conx = ConfigurationManager.ConnectionStrings["cnxDia"].ConnectionString;
            else
                conx = ConfigurationManager.ConnectionStrings["cnxDiadest"].ConnectionString;
            conm = new MySqlConnection(conx);
            conm.Open();
        }
        public bool begTran()
        {
            bool ini = false;
            try
            {

                tranm = conm.BeginTransaction();
                ini = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ini;
        }
        public void roll_back()
        {
            try
            {
                tranm.Rollback();
                conm.Close();
                conm.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void commit()
        {
            try
            {
                tranm.Commit();
                if (conm != null && conm.State == ConnectionState.Open)
                {
                    conm.Close();
                    conm.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void close()
        {

            conm.Close();
            conm.Dispose();

        }
        public List<EntGeneral> LeerTablas() {
            List<EntGeneral> lst = new List<EntGeneral>();
            MySqlDataReader dr = null;
            int i=0;
            try
            {
                string sql = "show tables";
                MySqlCommand com = new MySqlCommand(sql, conm);
                dr = com.ExecuteReader();
                while (dr.Read()) {
                    //if (!dr[0].ToString().Contains("d2") && !dr[0].ToString().Contains("d7"))
                    //{
                        EntGeneral g = new EntGeneral();
                        i += 1;
                        g.Id = i;
                        g.Descripcion = dr[0].ToString();
                        lst.Add(g);
                    //}
                }
            }
            catch (Exception ex) {
                throw ex;
            }
            return lst;
        }
        public DataTable LeerTabla(string tabla) {
            DataTable dt = new DataTable();
            try
            {
                string sql = "Select * from "+tabla;
                MySqlCommand com = new MySqlCommand(sql, conm);
                //com.Parameters.AddWithValue("tabla", tabla);
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                da.Fill(dt);
            }
            catch (Exception ex) {
                throw ex;
            }
            return dt;
        }
        public bool InsTablaHist(string tabla,DataRow r)
        {
            string sql = string.Empty;
            bool res = false;
            try
            {
                //switch (tabla) { 
                //    case "d3iperm":
                //        sql = "INSERT INTO " + tabla + " VALUES ('"+r[0].ToString()+"','"+r[1].ToString()+"','"+r[2].ToString()+"','"+r[3]+"','"+r[4];
                //}
                ////ring sql = "Select * from " + tabla;
                //MySqlCommand com = new MySqlCommand(sql, conm,tranm);
                //com.ExecuteNonQuery();
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }
        public bool ActTabla(DataTable tb, out string script) {
            bool res = false;
            string nomtable = string.Empty;
            MySqlCommand com = new MySqlCommand();
            string sql = string.Empty;
            Var v=new Var();
            int j = 0;
            try
            {
                script = string.Empty;
                com.Connection = conm;
                nomtable = tb.TableName;
                var bh = v.TabHist.Where(x => x.TablaHist == nomtable);
                if (bh.ToList().Count == 0)
                {
                    sql = "Delete from " + nomtable;
                    com.CommandText = sql;
                    com.ExecuteNonQuery();
                    script = sql+";\r\n";
                }
                foreach (DataRow r in tb.Rows) {
                    if (r.RowState != DataRowState.Deleted)
                    {
                        j += 1;
                        if (j == 11)
                            j = 11;
                        sql = string.Empty;
                        sql = "Insert into " + nomtable + " values ('";
                        for (int i = 0; i < tb.Columns.Count; i++)
                        {


                            if (r[i] == DBNull.Value)
                            {
                                if (sql.Substring(sql.Length - 1, 1) == "'")
                                    sql = sql.Substring(0, sql.Length - 1);
                                sql += "null,'";
                            }
                            else if (tb.Columns[i].DataType == typeof(DateTime))
                            {
                                if (Convert.ToDateTime(r[i]).ToShortDateString() == "01/01/1900")
                                {
                                    if (sql.Substring(sql.Length - 1, 1) == "'")
                                        sql = sql.Substring(0, sql.Length - 1);
                                    sql += "null,'";
                                }
                                else
                                    sql += Convert.ToDateTime(r[i]).ToString("yyyyMMdd") + "','";
                            }
                            else if (tb.Columns[i].DataType == typeof(Double) || tb.Columns[i].DataType == typeof(Double) || tb.Columns[i].DataType == typeof(int) || tb.Columns[i].DataType == typeof(Int16) || tb.Columns[i].DataType == typeof(Int32) || tb.Columns[i].DataType == typeof(Int64) || tb.Columns[i].DataType == typeof(SByte))
                            {
                                if (sql.Substring(sql.Length - 1, 1) == "'")
                                    sql = sql.Substring(0, sql.Length - 1);
                                sql += r[i].ToString() + ",'";
                            }
                            else
                            {
                                if (r[i].ToString() == "True" || r[i].ToString() == "False")
                                {
                                    if (sql.Substring(sql.Length - 1, 1) == "'")
                                        sql = sql.Substring(0, sql.Length - 1);
                                    if (r[i].ToString() == "True")
                                        sql += "1,'";
                                    else
                                        sql += "0,'";
                                }
                                else
                                {
                                    if (!((string)r[i]).Contains(@"\'") && ((string)r[i]).Contains("'"))
                                        r[i] = ((string)r[i]).Replace("'", @"\'");
                                    sql += r[i] + "','";
                                }



                            }

                        }
                        sql = sql.Substring(0, sql.Length - 2);
                        sql += ")";
                        com.CommandText = sql;
                        com.ExecuteNonQuery();
                        script += sql + ";\r\n";
                    }
                }
                res = true;

            }
            catch (Exception ex)
            {
                throw new Exception("Reng j="+j.ToString()+ex.Message);
            }
            finally {
                com.Dispose();
            }
            return res;
        }
        public DataTable LeerExcel(string path) {
            DataTable dt = new DataTable();
            try
            {
                string cnxex = ConfigurationManager.AppSettings["conxex"];
                cnxex = string.Format(cnxex, path);
                OleDbConnection con = new OleDbConnection(cnxex);
                con.Open();
                string sql = "SELECT * FROM [HOJA1$]";
                OleDbDataAdapter da = new OleDbDataAdapter(sql, con);
                da.Fill(dt);
                con.Close();
                
            }
            catch (Exception ex) {
                throw ex;
            }
            return dt;
        }
        public bool ExpExcel(string path, DataTable dt) {
            bool res = false;
            string nomt = string.Empty;
            Var v = new Var();
            bool existecod = false;
            bool cambiaatexto = false;
            bool cambiacolumna = false;
            try {
                Excel.Application ap = new Excel.Application();
                Excel.Workbook wb = ap.Workbooks.Add();
                Excel.Worksheet s = (Excel.Worksheet)wb.ActiveSheet; //wb.Sheets.Add();
                nomt=dt.TableName;
                var b = v.TablasCodigo.Where(x => x.ToUpper() == nomt.ToUpper());
                var bt = v.TablacampoTexto.Where(x => x.Tabla.ToUpper() == nomt.ToUpper());
                if (b.ToList().Count >= 1)
                    existecod = true;
                if (bt.ToList().Count == 1)
                    cambiaatexto = true;
               for (int i = 0; i < dt.Rows.Count; i++)
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        
                        if (i == 0) {
                            for (int e = 0; e < dt.Columns.Count; e++)
                                s.Cells[i + 1, e+1] = dt.Columns[e].ColumnName;
                        }
                        cambiacolumna=false;
                        if (cambiaatexto) {
                            var vcampo = bt.ToList().First().Campos.Where(x => x == j);
                            if (vcampo.ToList().Count == 1)
                                cambiacolumna=true;
                        }
                        if (existecod && (dt.Columns[j].ColumnName.ToUpper() == "CODIGO" || dt.Columns[j].ColumnName.ToUpper() =="CODIGOPAN"))
                            s.Cells[i + 2, j + 1] ="'"+ dt.Rows[i][j];
                        else if (cambiaatexto && cambiacolumna) {
                                s.Cells[i + 2, j + 1] = "'" + dt.Rows[i][j];
                        }
                        else
                            s.Cells[i + 2, j + 1] = dt.Rows[i][j];

                    }

                wb.SaveAs(path);
                wb.Close();
                ap.Quit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }
    }
}

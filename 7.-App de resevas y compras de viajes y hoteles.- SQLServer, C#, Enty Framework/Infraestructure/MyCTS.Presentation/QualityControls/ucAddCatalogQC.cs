using System;
using System.Reflection;
using System.Windows.Forms;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using MyCTS.Presentation.Components;
using MyCTS.Business;
using MyCTS.Entities;
using System.Linq;
using System.Threading;
using System.Diagnostics;

namespace MyCTS.Presentation
{
    public partial class ucAddCatalogQC : CustomUserControl
    {

        /// <summary>
        /// Descripcion: Insertar Catalogos en ClientsCatalogs
        /// Creación:    16-Junio-2010 , Modificación:*
        /// Cambio:      *    , Solicito *
        /// Autor:       Jessica Gutierrez 
        /// </summary>

        string path = string.Empty;

        public ucAddCatalogQC()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint |
               ControlStyles.UserPaint |
               ControlStyles.DoubleBuffer, true);
            InitialControlFocus = txtAttribute;
            LastControlFocus = btnAccept;
            ucAvailability.IsInterJetProcess = false;
        }

        //Llama el metodo de validación y verifica si existe archivo
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidBussinessRules)
            {
                if (File.Exists(path))
                {
                    Procesar(new FileInfo(path));
                    ClearControls(string.Empty);
                }
            }
        }

        //KeyDown
        /// <summary>
        /// Este se usa para todos los controles en general si se oprime 
        /// Esc se manda a el User control de Welcome 
        /// Enter se manda la accion de botón de Aceptar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);

            if (e.KeyData == Keys.Enter)
                btnAccept_Click(sender, e);
        }

        /// <summary>
        /// Abre el dialog en la Ruta C y si seleccionan el archivo 
        /// se despliga la ruta en el textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "xls files (*.xls)|*.xls|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            txtDirectory.Text = openFileDialog1.FileName;
                            path = openFileDialog1.FileName;
                        }
                    }
                }
                catch 
                {
                    MessageBox.Show("Error: No se pudo leer el archivo desde el disco original");
                }
            }
        }

        #region===== Methods ======

        //Valida campos obligatiorios 
        private bool IsValidBussinessRules
        {
            get
            {
                bool isValid = false;
                if(string.IsNullOrEmpty(txtAttribute.Text))
                {
                    MessageBox.Show("REQUIERES INGRESAR ATTRIBUTE1", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAttribute.Focus();
                }
                else if (string.IsNullOrEmpty(txtDirectory.Text))
                {
                    MessageBox.Show("REQUIERES INGRESAR LA RUTA DEL ARCHIVO", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDirectory.Focus();
                }
                else
                    isValid = true;
                return isValid;
            }
        }

        delegate bool DType(FileInfo f, string attribute);

        private bool GetQualityCotrols(FileInfo file, string attribute)
        {
            try
            {
                var excel = new LinqToExcel.ExcelQueryFactory(file.ToString());
                
                var columnsNames = excel.GetColumnNames(excel.GetWorksheetNames().ToList().First()).ToList();
                foreach (var item in excel.GetWorksheetNames().ToList())
                {
                    foreach (LinqToExcel.Row r in excel.Worksheet(item).ToList())
                    {
                        var enumerator = r.GetEnumerator();

                        while (enumerator.MoveNext())
                        {
                            if (string.IsNullOrEmpty(enumerator.Current.Value.ToString()))
                            {
                                enumerator.MoveNext();
                                continue;
                            }
                            var coded = enumerator.Current.Value.ToString();
                            GetIdRemarkLabel remarkId = GetIdRemarkLabelBL.GetIdRemarkLabel(columnsNames[r.IndexOf(enumerator.Current)]);
                            enumerator.MoveNext();
                            SetClientsCatalogsNextelBL.SetClientsCatalogsNextel(attribute, remarkId.IDRemarkLabel, coded, enumerator.Current.Value.ToString());
                        }
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Busca el archivo en la Ruta seleccionada y lee el contenido
        /// para insertar los nuevos quality controls
        /// </summary>
        /// <param name="file"></param>
        private void Procesar(FileInfo file)
        {
            if (MessageBox.Show("La carga de Quality Controls tomara unos minutos, puedes continuar trabajando mientras se procesa.", "Quality Controls", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                ucAddCatalogQC c = new ucAddCatalogQC();
                DType m = new DType(c.GetQualityCotrols);

                IAsyncResult a = m.BeginInvoke(file, txtAttribute.Text, (res) =>
                {
                    bool r = m.EndInvoke(res);
                    string result = (r) ? " exitoso" : " con errores";
                    MessageBox.Show("La carga de Quality Controls termino " + result, "Quality Controls", MessageBoxButtons.OK, (r) ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                }, null);
            }
        }

        

        //Limpia los controles y coloca el foco
        private void ClearControls(string Empty)
        {
            txtAttribute.Text = Empty;
            txtDirectory.Text = Empty;
            txtAttribute.Focus();
        }

        #endregion
    }
}

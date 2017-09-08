using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ADMIN2.BR;
using ADMIN2.DAL;
using ADMIN2.Entity;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using Microsoft.Win32;
using System.IO;
using ADMIN2.Controls;
using ClosedXML.Excel;
using System.Data;

namespace ADMIN2
{
    /// <summary>
    /// Lógica de interacción para Cliente.xaml
    /// </summary>
    public partial class frmCatologoGenerico : BaseWindow
    {
        #region Variables Globales
        public static frmCatologoGenerico openWindow = new frmCatologoGenerico();
        /// <summary>
        /// Contiene el Listado del universo de la Entidad
        /// </summary>
        
        public object SearchSource = null;
        private string currentColname = string.Empty;
        private string Encabezado = string.Empty;
        private ListSortDirection _sortDirection;
        private static MethodInfo catalogo = null;
        private object[] param = null;
        private string entidad = string.Empty;
        private string Tabla = string.Empty;
        private bool btnAltasEnabled = true;
        private bool btnBajasEnabled = false;
        private bool btnCambioEnabled = false;
        string aduana = string.Empty;
        string NomEnt = string.Empty;
        private bool resBox = false;
        private CatalogConfigElement current;
        public string ImportExport = string.Empty;
        public string TblDescripciones = string.Empty;       
        public bool SoloEsconderAlCerrar;
        private bool BusquedaEquivalencias;      
        public object SeleccionGenerica = null;
        public bool BusquedaProvee { get; set; }
        public bool BusquedaOMA { get; set; }
        public bool BusquedaUMCT { get; set; }
        public bool BusquedaSect { get; set; }
        public int banderParte = 0;
        avisosis messageBox = new avisosis();
        /// <summary>
        /// Registro del Gird Genérico seleccionado por el Usuario
        /// </summary>
        public int selectedIndexRow;
        private bool EliminarReg;
        public bool BusquedaGenerica;
        public object selectedRow;
        public int bandera = 0;
        private bool KeyEnter;
        private bool ImportarReporte;
        public int banMenu = 0;
        public int cvedep = 0;
        /// <summary>
        /// variable para identificar a que formulario va a ingresar, cuando un módulo cuenta con submódolos
        /// </summary>
        public int TipoMenu = 0;
        public static bool InsertaSiguienteIndex;
        EntCliente entclienteSuc = new EntCliente();
        EntSucursal entSucursal = new EntSucursal();
        private frmCatologoGenerico frmCatologoGenerico1;
        #endregion

        #region Métodos
        public frmCatologoGenerico()
        {
            try
            {
                InitializeComponent();
                //WindowState = WindowState.Maximized;
                //this.Size = Screen.PrimaryScreen.WorkingArea.Size;
                this.Loaded += frmCatologoGenerico_Loaded;
                this.Closed += (a, b) => openWindow = null;

            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex.InnerException.Message, txtTitulo.Text, MessageBoxButton.OK, MessageBoxImage.Stop);
                messageBox.ShowDialog();
            }

        }


        public frmCatologoGenerico(frmCatologoGenerico frmCatologoGenerico1, EntCliente EntclienteSuc)
        {
            // TODO: Complete member initialization
            this.frmCatologoGenerico1 = frmCatologoGenerico1;
            entclienteSuc = EntclienteSuc;
            InitializeComponent();
            //WindowState = WindowState.Maximized;
            //this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Loaded += frmCatologoGenerico_Loaded;
            this.Closed += (a, b) => openWindow = null;
        }

        void frmCatologoGenerico_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (openWindow == null)
                {
                    openWindow = this;
                }
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex.InnerException.Message, txtTitulo.Text, MessageBoxButton.OK, MessageBoxImage.Stop);
                messageBox.ShowDialog();
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dgvGenerico.IsReadOnly = true;
                dgvGenerico.CanUserAddRows = false;
                btnNuevo.IsEnabled = true;
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, txtTitulo.Text, MessageBoxButton.OK, MessageBoxImage.Stop);
                messageBox.ShowDialog();
            }
        }

        #region Botones a,c,e
        //filtros =0; altas =1; baja=2; cambios =3;
        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                selectedIndexRow = -1;
                //se utiliza cuando se tiene otro catalogo dentro del mismo catalogo poner valor a 1.
                if (TipoMenu == 1)
                {
                    RealizaAccion(1, null, dgvGenerico.SelectedItem);
                }
                else
                {
                    RealizaAccion(1, null, null);
                }

            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, txtTitulo.Text, MessageBoxButton.OK, MessageBoxImage.Stop);
                messageBox.ShowDialog();
            }
        }

        private void btnCambio_Click(object sender, RoutedEventArgs e)
        {
            frmProcesando wp = new frmProcesando();
            try
            {
                wp.txtLeyenda.Text = "Cargando información, espere...";
                wp.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                wp.Show();
                selectedRow = dgvGenerico.SelectedItem;
                selectedIndexRow = dgvGenerico.SelectedIndex;
                EliminarReg = false;
                RealizaAccion(3, null, dgvGenerico.SelectedItem);
                wp.Close();
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, txtTitulo.Text, MessageBoxButton.OK, MessageBoxImage.Stop);
                messageBox.ShowDialog();
                wp.Close();
            }
        }

        private void btnBaja_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgvGenerico.SelectedItem != null)
                {
                    procesando.Visibility = Visibility.Visible;
                    selectedIndexRow = dgvGenerico.SelectedIndex;
                    selectedRow = dgvGenerico.SelectedItem;
                    EliminarReg = true;
                    //se utiliza cuando se tiene otro catalogo dentro del mismo catalogo poner valor a 1.
                    if (TipoMenu == 1)
                        RealizaAccion(2, null, dgvGenerico.SelectedItem);
                    else
                        RealizaAccion(2, null, dgvGenerico.SelectedItem);
                }
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, txtTitulo.Text, MessageBoxButton.OK, MessageBoxImage.Stop);
                messageBox.ShowDialog();
            }
        }

        #endregion

        #region Acciones

        private void RealizaAccion(int accion, List<Filter> filter, object item, int rango = 0, int pedimentoGc = 0)
        {
            try
            {
                #region
                //if (usuarioSesion == null || usuarioSesion.PantallaEnEjecucion.ST_C_AP_LEERYESCRIBIR)
                //{
                if (accion == 2)
                {
                    switch (entidad)
                    {
                        case Genericas.EntBitacora:
                            messageBox = new avisosis("¿Desea exportar los registros?", txtTitulo.Text, MessageBoxButton.YesNo, MessageBoxImage.Question);
                            resBox = Convert.ToBoolean(messageBox.ShowDialog());
                            break;
                        default:
                            messageBox = new avisosis("¿Desea eliminar el registro actual?", txtTitulo.Text, MessageBoxButton.YesNo, MessageBoxImage.Question);
                            resBox = Convert.ToBoolean(messageBox.ShowDialog());
                        break;
                    }                    

                    if (resBox == false)
                    {
                        procesando.Visibility = Visibility.Hidden;
                        return;
                    }
                    procesando.Visibility = Visibility.Hidden;
                        
                }
                switch (entidad)
                {
                    #region Clientes
                    case Genericas.EntEntidades:
                        //filtros
                        if (accion==0)
                            Utils.LlenaGridGenerico<EntEntidades>(currentColname, SearchSource, filter, _sortDirection, ref dgvGenerico);
                        break;
                    case Genericas.EntCliente:
                        switch (accion)
                        {
                            //filtros
                            case 0:
                                Utils.LlenaGridGenerico<EntCliente>(currentColname, SearchSource, filter, _sortDirection, ref dgvGenerico);
                                break;
                            //altas
                            case 1:                              
                                ADMIN2.Clientes.FrmCliente frm =new  ADMIN2.Clientes.FrmCliente(this);
                                frm.ActIns = Comunes.AGREGA;
                                frm.CmbEstatus.IsEnabled = false;
                                frm.ShowDialog();
                                BindGrid<EntCliente>(current, string.Empty, 1);
                                txtBusqueda.Text = string.Empty;
                                break;
                            //bajas
                            case 2:
                                break;
                            //cambios
                            case 3:
                                if (item != null)
                                {
                                    ADMIN2.Clientes.FrmCliente frmC = new ADMIN2.Clientes.FrmCliente(this);
                                    EntCliente EntCliente = item as EntCliente;
                                    frmC.ActIns = Comunes.CAMBIA;
                                    frmC.Consulta(EntCliente);
                                    frmC.CmbEjecutivoVentas.Visibility = Visibility.Hidden;
                                    frmC.ShowDialog();
                                    BindGrid<EntCliente>(current, string.Empty, 1);
                                }
                                txtBusqueda.Text = string.Empty;
                                break;
                        }
                        break;
                    case Genericas.EntSucursal:
                        switch (accion)
                        {
                            //filtros
                            case 0:
                                Utils.LlenaGridGenerico<EntSucursal>(currentColname, SearchSource, filter, _sortDirection, ref dgvGenerico);
                                break;
                            //altas
                            case 1:
                                ADMIN2.Clientes.FrmSucursal frm = new ADMIN2.Clientes.FrmSucursal(this);
                                frm.ActIns = Comunes.AGREGA;
                                frm.CmbEstatus.IsEnabled = false;
                                frm.ConsultaDatosCliente(entclienteSuc, entSucursal);
                                frm.ShowDialog();
                                BindGrid<EntSucursal>(current, string.Empty, 1);
                                txtBusqueda.Text = string.Empty;
                                break;
                            //bajas
                            case 2:
                                EntSucursal EntSuc = item as EntSucursal;
                                BrCliente cliente = new BrCliente();
                                Respuesta<int> result = cliente.InsUpdSucursal(EntSuc, "B", "");
                                BindGrid<EntSucursal>(current, string.Empty, 1);
                                //EliminaRegistro<EntUsuario>(item as EntUsuario, current, string.Empty, 0);    //si aplica
                                txtBusqueda.Text = string.Empty;
                                break;
                            //cambios
                            case 3:
                                if (item != null)
                                {
                                    ADMIN2.Clientes.FrmSucursal frmC = new ADMIN2.Clientes.FrmSucursal(this);
                                    EntSucursal EntSucursal= item as EntSucursal;
                                    frmC.ActIns = Comunes.CAMBIA;
                                    frmC.ConsultaDatosCliente(entclienteSuc, EntSucursal);
                                    frmC.ShowDialog();
                                    BindGrid<EntSucursal>(current, string.Empty, 1);
                                }
                                txtBusqueda.Text = string.Empty;
                                break;
                        }
                        break;
                    #endregion

                    #region Producción

                    #endregion

                    #region Administración
                        
                    #region Bitacora Cambios
                    case Genericas.EntBitacora:
                        try
                        {
                            EntBitacora entBit = new EntBitacora();
                            List<EntBitacora> lstBit = new List<EntBitacora>();
                            System.Windows.Forms.FolderBrowserDialog f = new System.Windows.Forms.FolderBrowserDialog();
                            f.Description = "Seleccione una ruta";
                            f.RootFolder = Environment.SpecialFolder.DesktopDirectory;
                            switch (accion)
                            {
                                case 0:
                                    Utils.LlenaGridGenerico<EntBitacora>(currentColname, SearchSource, filter, _sortDirection, ref dgvGenerico);                                                                      
                                    lstBit = new List<EntBitacora>();
                                    foreach (EntBitacora rv in dgvGenerico.Items)
                                    {
                                        entBit = new EntBitacora();
                                        entBit.Usuario = rv.Usuario.ToString();
                                        entBit.Accion = rv.Accion.ToString();
                                        entBit.Descripcion = rv.Descripcion.ToString();
                                        entBit.FechaRegistro = rv.FechaRegistro.ToString();
                                        lstBit.Add(entBit);
                                    }
                                    break;

                                //Exportar a Excel
                                case 2:
                                    if (dgvGenerico.Items.Count > 0)
                                    {
                                        f.ShowDialog();                                        
                                        lstBit = new List<EntBitacora>();
                                        foreach (EntBitacora rv in dgvGenerico.Items)
                                        {
                                            entBit = new EntBitacora();
                                            entBit.Usuario = rv.Usuario.ToString();
                                            entBit.Accion = rv.Accion.ToString();
                                            entBit.Descripcion = rv.Descripcion.ToString();
                                            entBit.FechaRegistro = rv.FechaRegistro.ToString();
                                            lstBit.Add(entBit);
                                        }
                                    }
                                    break;
                            }
                            if (lstBit.Count > 0 && accion==2)
                            {
                                DataTable dt = new DataTable();

                                /* creación de la Hoja correspondiente a Remesa,Facturas y Partidas  */
                                var workbook = new XLWorkbook();
                                IXLWorksheet worsheet = workbook.Worksheets.Add("BitácoraCambios");

                                //creacion de las filas en excel
                                worsheet.Cell("A1").Value = "Nombre de Usuario";
                                worsheet.Cell("B1").Value = "Acción";
                                worsheet.Cell("C1").Value = "Descripción";
                                worsheet.Cell("D1").Value = "Fecha de Registro";                               

                                //creación de la tabla 
                                dt.Columns.Add("Nombre de Usuario", typeof(string));
                                dt.Columns.Add("Acción", typeof(string));
                                dt.Columns.Add("Descripción", typeof(string));
                                dt.Columns.Add("Fecha de Registro", typeof(DateTime));

                                //se asigna información
                                foreach (var bitacora in lstBit)
                                {
                                    dt.Rows.Add(bitacora.Usuario,bitacora.Accion,bitacora.Descripcion,bitacora.FechaRegistro);
                                }

                                worsheet.Cell(2, 1).Value = dt.AsEnumerable();
                                
                                worsheet.Range(1, 1, 1, 4).Style.Font.Bold = true;
                                worsheet.Range(1, 1, 1, 4).SetAutoFilter();
                                worsheet.Range(1, 1, 1, 4).IsMerged();
                                //ajustar celdas
                                worsheet.Columns().AdjustToContents();
                                worsheet.Range(1, 1, 1, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Justify;

                                // crea el archivo
                                workbook.SaveAs(f.SelectedPath + "\\BitacoraCambios.xlsx");

                                messageBox = new avisosis("Se ha generado correctamente el archivo.", "Bitácora de Cambios", MessageBoxButton.OK, MessageBoxImage.Information);
                                messageBox.ShowDialog();
                            }

                        }
                        catch (Exception)
                        {
                            messageBox = new avisosis("Se ha producido un error al generar el archivo.", "Bitácora de Cambios", MessageBoxButton.OK, MessageBoxImage.Error);
                            messageBox.ShowDialog();
                        }                        
                    break;

                    #endregion
                    
                    #endregion

                    #region Consultoría

                    #endregion

                    #region Soporte Técnico

                    #endregion

                    #region Reportes

                    #endregion

                    #region Configuracion

                    case Genericas.EntUsuario:
                        #region EntUsuario

                        switch (accion) 
                        {
                            //filtros
                            case 0:
                                Utils.LlenaGridGenerico<EntUsuario>(currentColname, SearchSource, filter, _sortDirection, ref dgvGenerico);
                            break;
                                //altas
                            case 1:

                                ADMIN2.Configuración.FrmUsuarios frm = new ADMIN2.Configuración.FrmUsuarios(this);
                                frm.ActIns = Comunes.AGREGA;
                                frm.ShowDialog();
                                txtBusqueda.Text = string.Empty;
                                BindGrid<EntUsuario>(current, string.Empty, 0);
                            break;
                                //bajas
                            case 2:
                                EntUsuario EntUserB = item as EntUsuario;
                                BrConfiguracion conf = new BrConfiguracion();
                                EntUserB.IdUsuarioModifico = App.IdUsuario;
                                Respuesta<int> result = conf.InsUpdUsuarios(EntUserB, "B", "");
                                BindGrid<EntUsuario>(current, string.Empty, 0);
                                //EliminaRegistro<EntUsuario>(item as EntUsuario, current, string.Empty, 0);    //si aplica
                                txtBusqueda.Text = string.Empty;                                
                            break;
                                //cambios
                            case 3:
                                if (item != null)
                                {
                                    ADMIN2.Configuración.FrmUsuarios frmUC = new ADMIN2.Configuración.FrmUsuarios(this);
                                    EntUsuario EntUser = item as EntUsuario;
                                    frmUC.ActIns = Comunes.CAMBIA;
                                    frmUC.Consulta(EntUser);
                                    frmUC.ShowDialog();
                                    BindGrid<EntUsuario>(current, string.Empty, 0);
                                }
                                txtBusqueda.Text = string.Empty;                                
                            break;                            
                        }                        
                        #endregion
                    break;

                    case Genericas.EntPerfil:
                        #region EntPerfil

                        switch (accion)
                        {
                            //filtros
                            case 0:
                                Utils.LlenaGridGenerico<EntPerfil>(currentColname, SearchSource, filter, _sortDirection, ref dgvGenerico);
                                break;
                            //altas
                            case 1:
                                ADMIN2.Configuración.FrmPerfiles frm = new ADMIN2.Configuración.FrmPerfiles(this);
                                frm.ActIns = Comunes.AGREGA;
                                frm.ShowDialog();
                                txtBusqueda.Text = string.Empty;
                                break;
                            //bajas
                            case 2:
                                //EntPerfil EntUserB = item as EntPerfil;
                                //BrConfiguracion conf = new BrConfiguracion();
                                //Respuesta<int> result = conf.InsUpdUsuarios(EntUserB, "B", "");

                                //EliminaRegistro<EntUsuario>(item as EntUsuario, current, string.Empty, 0);    //si aplica                                 
                                txtBusqueda.Text = string.Empty;
                                break;
                            //cambios
                            case 3:
                                if (item != null)
                                {
                                    ADMIN2.Configuración.FrmPerfiles frmUC = new ADMIN2.Configuración.FrmPerfiles(this);
                                    EntPerfil EntUser = item as EntPerfil;
                                    frmUC.ActIns = Comunes.CAMBIA;
                                    frmUC.Consulta(EntUser);
                                    frmUC.ShowDialog();
                                    BindGrid<EntPerfil>(current, string.Empty, 0);
                                }
                                txtBusqueda.Text = string.Empty;
                                break;
                        }                        
                        #endregion
                    break;
                    #endregion                    
                }

                EliminarReg = false;
                //}
                //else
                //{
                //    messageBox = new avisosis("Acceso restringido por el administrador del sistema, Favor de contactar a su administrador", "Acceso denegado", MessageBoxButton.OK, MessageBoxImage.Warning);
                //    messageBox.ShowDialog();
                //    procesando.Visibility = Visibility.Hidden;
                //}
                #endregion
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, txtTitulo.Text, MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
            }
        }

        #endregion

        //Muestra controles
        private void dgvGenerico_Sorting(object sender, DataGridSortingEventArgs e)
        {
            try
            {
               
                lblTipoBusqueda.Visibility = Visibility.Visible;
                DataGridColumn header = e.Column;
                if (header != null && header.Header != null)
                {
                    if (currentColname != header.SortMemberPath)
                    {
                        txtBusqDeci.Text = string.Empty;
                        txtBusqueda.Text = string.Empty;
                        txtBusqueda_KeyUp(null, null);
                    }
                    _sortDirection = e.Column.SortDirection.HasValue ? e.Column.SortDirection.Value : ListSortDirection.Ascending;
                    currentColname = header.SortMemberPath;
                    Encabezado = header.Header.ToString();
                    if (header.Header.ToString().Contains("Fecha") == true)
                    {
                        txtBusqueda.Visibility = Visibility.Hidden;
                        dpEntr.Visibility = Visibility.Visible;
                           
                        txtBusqDeci.Visibility = Visibility.Hidden;
                        txtmes.Visibility = Visibility.Hidden;
                        cmbMes.Visibility = Visibility.Hidden;
                        lblAño.Visibility = Visibility.Hidden;
                        txtAño.Visibility = Visibility.Hidden;
                        cmbMes.Text = string.Empty;
                        txtAño.Text = string.Empty;
                        txtBusqDeci.Text = string.Empty;                      
                    }
                    else
                    {
                        txtBusqueda.Visibility = Visibility.Visible;
                        dpEntr.Visibility = Visibility.Hidden;
                        txtBusqDeci.Visibility = Visibility.Hidden;
                        txtmes.Visibility = Visibility.Hidden;
                        cmbMes.Visibility = Visibility.Hidden;
                        lblAño.Visibility = Visibility.Hidden;
                        txtAño.Visibility = Visibility.Hidden;
                        cmbMes.Text = string.Empty;
                        txtAño.Text = string.Empty;
                        if(bandera==1)
                        {
                            txtBusqueda.Visibility = Visibility.Hidden;
                            txtBusqDeci.Visibility = Visibility.Visible;
                        }                        
                    }
                    lblTipoBusqueda.Text= header.Header.ToString() ;
                }
                if(bandera==5)
                {
                    lblTipoBusqueda.Visibility = Visibility.Collapsed;
                    txtBusqueda.Visibility = Visibility.Collapsed;
                }
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, txtTitulo.Text, MessageBoxButton.OK, MessageBoxImage.Stop);
                messageBox.ShowDialog();
            }
        }

        private void txtBusqueda_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e != null)
                {
                    if(e.Key == Key.Down)
                    {
                        dgvGenerico.SelectedIndex = 0;

                        //Seleccionando la primera fila de la busqueda
                        dgvGenerico.SelectionUnit = System.Windows.Controls.DataGridSelectionUnit.Cell;
                        List<KeyValuePair<int, int>> cellIndexes = new List<KeyValuePair<int, int>>();
                        /* select the first cell of the first row */
                        cellIndexes.Add(new KeyValuePair<int, int>(0, 1));
                        SelectGrid.SelectCellsByIndexes(dgvGenerico, cellIndexes);

                        dgvGenerico.SelectionUnit = System.Windows.Controls.DataGridSelectionUnit.FullRow;
                        SelectGrid.SelectRowByIndex(dgvGenerico, 0);
                        return;
                    }
                    if (e.Key != Key.Escape && SearchSource != null)
                    {
                        List<Filter> filter = new List<Filter>()
                    { 
                        new Filter{
                            PropertyName = currentColname,
                            Value = txtBusqueda.Text.Trim(),
                            Operation = Op.Contains
                        }
                    };
                        RealizaAccion(0, filter, null);

                        VerificaBotones();
                    }
                }
                else
                {
                    if (!Encabezado.Contains("Fecha"))
                    {
                        List<Filter> filter = new List<Filter>()
                    { 
                        new Filter{
                            PropertyName = currentColname,
                            Value = txtBusqueda.Text.Trim(),
                            Operation = Op.Contains
                        }
                    };
                        RealizaAccion(0, filter, null);

                        VerificaBotones();
                    }
                    else
                    {
                        List<Filter> filter = new List<Filter>()
                    { 
                        
                        new Filter{
                            PropertyName = currentColname,
                            Value = Convert.ToString(DateTime.MinValue),
                            Operation = Op.Contains
                        }
                    };
                        RealizaAccion(0, filter, null);
                    }
                }
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, txtTitulo.Text, MessageBoxButton.OK, MessageBoxImage.Stop);
                messageBox.ShowDialog();
            }
        }

        private void dpEntr_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if ( SearchSource != null)
                {
                    List<Filter> filter = new List<Filter>()
                    { 
                        
                        new Filter{
                            PropertyName = currentColname,
                            Value = Convert.ToString(dpEntr.Text),
                            Operation = Op.Contains
                        }
                    };
                    RealizaAccion(0, filter, null);

                    VerificaBotones();
                    dpEntr.Visibility = Visibility.Visible;
                    txtBusqueda.Visibility = Visibility.Collapsed;

                }
                if(string.IsNullOrEmpty(dpEntr.Text))
                {
                    dpEntr.Visibility = Visibility.Collapsed;
                    txtBusqueda.Visibility = Visibility.Visible;
                    lblTipoBusqueda.Text = string.Empty;
                }
                if (bandera == 5)
                {
                    lblTipoBusqueda.Visibility = Visibility.Collapsed;
                    txtBusqueda.Visibility = Visibility.Collapsed;
                }
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, txtTitulo.Text, MessageBoxButton.OK, MessageBoxImage.Stop);
                messageBox.ShowDialog();
            }
        }

        private void dpEntr_KeyUp(object sender, KeyEventArgs e)
        {
          if (!string.IsNullOrEmpty(dpEntr.Text))
            {
                if (dpEntr.Text.Length == 8 || dpEntr.Text.Length == 10)
                {
                    DateTime dateValue;
                    if (DateTime.TryParse(dpEntr.Text, out dateValue))
                    {
                        dpEntr_SelectedDateChanged(null, null);
                    }
                }
            }
            else
            {
                List<Filter> filter = new List<Filter>()
                    { 
                        new Filter{
                            PropertyName = currentColname,
                            Value = DateTime.MinValue.ToShortDateString(),
                            Operation = Op.Contains,
                           
                        }
                    };
                RealizaAccion(0, filter, null);
                VerificaBotones();
                dpEntr.Visibility = Visibility.Visible;
                txtBusqueda.Visibility = Visibility.Collapsed;
            }
        }

        private void VerificaBotones()
        {
            try
            {
                if (dgvGenerico.SelectedItem != null)
                {
                    btnCambio.IsEnabled = current.Cambios;
                    btnBaja.IsEnabled =current.Bajas;
                    btnNuevo.IsEnabled = current.Altas;
                    if (bandera != 1 && !(lblTipoBusqueda.Text.Contains("Fecha")))
                    {
                    txtBusqueda.Visibility = Visibility.Visible;
                    dpEntr.Visibility = Visibility.Collapsed;
                    }
                }
                else
                {
                    btnCambio.IsEnabled = current.Cambios;
                    btnBaja.IsEnabled = current.Bajas;
                    dpEntr.Visibility = Visibility.Collapsed;
                    txtBusqueda.Visibility = Visibility.Visible;
                    btnNuevo.IsEnabled = current.Altas;
                }

                 if (bandera == 5)
                 {
                     lblTipoBusqueda.Visibility = Visibility.Collapsed;
                     txtBusqueda.Visibility = Visibility.Collapsed;
                 }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void DockPanel_SizeChanged_1(object sender, SizeChangedEventArgs e)
        {
            try
            {
                if (e.PreviousSize.Height > 0)
                {
                    if (e.NewSize.Height > e.PreviousSize.Height)
                    {
                        dgvGenerico.Height += e.NewSize.Height - e.PreviousSize.Height;
                    }
                    else
                    {
                        dgvGenerico.Height -= e.PreviousSize.Height - e.NewSize.Height;
                    }
                }

                if (e.PreviousSize.Width > 0)
                {
                    if (e.NewSize.Width > e.PreviousSize.Width)
                    {
                        txtBusqueda.Width += e.NewSize.Width - e.PreviousSize.Width - 38;
                        gbOpc.Width += e.NewSize.Width - e.PreviousSize.Width;
                    }
                    else
                    {
                        txtBusqueda.Width -= (e.PreviousSize.Width - e.NewSize.Width) - 38;
                        gbOpc.Width -= e.PreviousSize.Width - e.NewSize.Width;
                    }
                }
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, txtTitulo.Text, MessageBoxButton.OK, MessageBoxImage.Stop);
                messageBox.ShowDialog();
            }
        }
        
        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmProcesando wp = new frmProcesando();
            try
            {
                //wp.txtLeyenda.Text = "Cargando información, espere...";
                //wp.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                //wp.Show();
                EliminarReg = false;
                selectedIndexRow = KeyEnter ? ((dgvGenerico.SelectedIndex == (dgvGenerico.Items.Count - 1)) ? dgvGenerico.SelectedIndex : dgvGenerico.SelectedIndex - 1) : dgvGenerico.SelectedIndex;
                dgvGenerico.SelectedIndex = selectedIndexRow;
                selectedRow = dgvGenerico.SelectedItem;
                if (BusquedaGenerica)
                {
                    SeleccionGenerica = dgvGenerico.SelectedItem;
                    if (SeleccionGenerica != null)
                        this.Hide();
                }
                else
                {
                    if (sender != null && (current.Altas || current.Cambios || current.Mostrar))
                    {
                        DataGridRow dgr = sender as DataGridRow;
                        RealizaAccion(3, null, dgr.Item);
                    }               
                }
                
                //wp.Close();
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, txtTitulo.Text, MessageBoxButton.OK, MessageBoxImage.Stop);
                messageBox.ShowDialog();
                wp.Close();
            }
        }

        private void dgvGenerico_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    KeyEnter = true;
                    Row_DoubleClick(null, null);
                }
                e.Handled = true;
                return;
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, txtTitulo.Text, MessageBoxButton.OK, MessageBoxImage.Error);
                messageBox.ShowDialog();
            }
        }

        public void EliminaRegistro<T>(T item, CatalogConfigElement resp, string tabla, int tipo = 0) where T : class
        {
            try
            {
                string entidad = item.ToString();
                TblDescripciones = item.ToString();
                object respuesta = null;                
                #region
                switch (tipo)
                {
                    case 1:
                        catalogo = typeof(BrCliente).GetMethod(resp.MetodoBorrar);
                        break;
                    case 2:
                        catalogo = typeof(BrProduccion).GetMethod(resp.MetodoBorrar);
                        break;
                    case 3:
                        catalogo = typeof(BrAdminstracion).GetMethod(resp.MetodoBorrar);
                        break;
                    case 4:
                        catalogo = typeof(BrConsultoria).GetMethod(resp.MetodoBorrar);
                        break;
                    case 5:
                        catalogo = typeof(BrSoporteTecnico).GetMethod(resp.MetodoBorrar);
                        break;
                    case 6:
                        catalogo = typeof(BrReporte).GetMethod(resp.MetodoBorrar);
                        break;
                    case 0:
                        catalogo = typeof(BrConfiguracion).GetMethod(resp.MetodoBorrar);
                        break;                   
                }
                if (tabla != string.Empty)
                {
                    param = new object[] { item, Comunes.BORRAR, tabla };
                }
                    //aqui
                else
                {
                    param = new object[] { item, Comunes.BORRAR };
                }                    
                switch (tipo)
                {
                    case 1:
                        respuesta = catalogo.Invoke(new BrCliente(), param);
                        break;
                    case 2:
                        respuesta = catalogo.Invoke(new BrProduccion(), param);
                        break;
                    case 3:
                        respuesta = catalogo.Invoke(new BrAdminstracion(), param);
                        break;
                    case 4:
                        respuesta = catalogo.Invoke(new BrConsultoria(), param);
                        break;
                    case 5:
                        respuesta = catalogo.Invoke(new BrSoporteTecnico(), param);
                        break;
                    case 6:
                        respuesta = catalogo.Invoke(new BrReporte(), param);
                        break;
                    case 0:
                        respuesta = catalogo.Invoke(new BrConfiguracion(), param);
                        break;
                }
                #endregion
                Respuesta<int> eliminado = (Respuesta<int>)respuesta;
               
                if (eliminado.EsExitoso)
                {
                    if (entidad == "SITA.Entity.Ent_Referencia_Bloqueada")
                    {
                        messageBox = new avisosis("La Referencia se ha desbloqueado correctamente.", txtTitulo.Text, MessageBoxButton.OK, MessageBoxImage.None);
                        messageBox.ShowDialog();
                    }                   
                    else
                    {
                        messageBox = new avisosis("Registro eliminado correctamente.", txtTitulo.Text, MessageBoxButton.OK, MessageBoxImage.None);
                        messageBox.ShowDialog();
                    }

                    AcutualizaGrid<T>(item);
                }
                else if (eliminado.MensajeEliminacion)
                {
                    //no se puede eliminiar registro por restricciones
                    if (entidad == "SITA.Entity.Ent_Transportista")
                    {
                        messageBox = new avisosis("El Transportista no puede ser eliminado. \nEste Transportista está asociado con un Pedimento.", txtTitulo.Text, MessageBoxButton.OK, MessageBoxImage.Error);
                        messageBox.ShowDialog();
                    }
                    else if (entidad == "SITA.Entity.Ent_DirFE")
                    {
                        messageBox = new avisosis("El Domicilio  no puede ser eliminado.", txtTitulo.Text, MessageBoxButton.OK, MessageBoxImage.Error);
                        messageBox.ShowDialog();
                    }
                }
                else
                { 
                    // marco error al eliminar el registro
                    messageBox = new avisosis("Error: " + eliminado.MensajeUsuario + " " + eliminado.Error, txtTitulo.Text, MessageBoxButton.OK, MessageBoxImage.Error);
                    messageBox.ShowDialog();                 
                }
                procesando.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, txtTitulo.Text, MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
            }
        }

        public void BindGrid<T>(CatalogConfigElement resp, string tabla, int tipo = 0, object Ent=null) where T : class
        {
            try
            {
                Type pType = typeof(T);
                entidad = pType.ToString();
                Tabla = tabla;
                current = resp;
                string met = resp.Metodo;
                NomEnt = pType.ToString();               
                if (ImportExport != string.Empty)
                {
                    ValidaTextosRadioImpoExpo(met);
                }

                switch (tipo)
                {
                    case 1:
                        catalogo = typeof(BrCliente).GetMethod(resp.Metodo);
                        break;
                    case 2:
                        catalogo = typeof(BrProduccion).GetMethod(resp.Metodo);
                        break;
                    case 3:
                        catalogo = typeof(BrAdminstracion).GetMethod(resp.Metodo);
                        break;
                    case 4:
                        catalogo = typeof(BrConsultoria).GetMethod(resp.Metodo);
                        break;
                    case 5:
                        catalogo = typeof(BrSoporteTecnico).GetMethod(resp.Metodo);
                        break;
                    case 6:
                        catalogo = typeof(BrReporte).GetMethod(resp.Metodo);
                        break;
                    case 0:
                        catalogo = typeof(BrConfiguracion).GetMethod(resp.Metodo);
                        break;
                }
                if (tabla != string.Empty)
                    if (Comunes.FECHA == tabla)
                    {
                        param = new object[] { Activator.CreateInstance(typeof(T), Comunes.FECHA) };
                    }
                    else
                    {
                        if (ImportExport != string.Empty)
                        {
                            param = new object[] { Activator.CreateInstance(typeof(T), ImportExport.ToString()),tabla };
                        }
                        else
                        {
                            param = new object[] { Activator.CreateInstance(typeof(T)), tabla };
                        }
                    }
                else
                {
                    if (ImportExport == string.Empty)
                    {
                        if (tabla != string.Empty)
                        {
                            param = new object[] { Activator.CreateInstance(typeof(T), ImportExport.ToString()), tabla };
                        }                            
                        else
                        {
                            //pasa parametros para llenar catalogo
                            switch(pType.FullName.ToString())
                            {
                                case "ADMIN2.Entity.EntBitacora":
                                    param = new object[] { Activator.CreateInstance(typeof(T), App.IdSistema)};                                    
                                    break;

                                case "ADMIN2.Entity.EntSucursal":
                                    if (entclienteSuc.ClaveCliente >= 1)
                                        param = new object[] { Activator.CreateInstance(typeof(T), entclienteSuc.ClaveCliente) };
                                    //if (entSucursal.Clave_cliente >=1 && entSucursal.Nsucursal!=0)
                                    //    param = new object[] { Activator.CreateInstance(typeof(T), entSucursal.Clave_cliente, entSucursal.Nsucursal) };

                                    break;

                                default:
                                    //original no resive parametros el constructor de la entidad
                                param = new object[] { Activator.CreateInstance(typeof(T)) };
                                break;
                            }                        
                        }
                            
                    }
                    else
                        param = new object[] { Activator.CreateInstance(typeof(T), ImportExport.ToString()) };
                       
                    
                }
                switch (tipo)
                {
                    case 1:
                        SearchSource = catalogo.Invoke(new BrCliente(), param);
                        break;
                    case 2:
                        SearchSource = catalogo.Invoke(new BrProduccion(), param);
                        break;
                    case 3:
                        SearchSource = catalogo.Invoke(new BrAdminstracion(), param);
                        break;
                    case 4:
                        SearchSource = catalogo.Invoke(new BrConsultoria(), param);
                        break;
                    case 5:
                        SearchSource = catalogo.Invoke(new BrSoporteTecnico(), param);
                        break;
                    case 6:
                        SearchSource = catalogo.Invoke(new BrReporte(), param);
                        break;
                    case 0:
                        SearchSource = catalogo.Invoke(new BrConfiguracion(), param);
                        break;                    
                }

                if (SearchSource != null)
                {
                    Respuesta<List<T>> respuest = (Respuesta<List<T>>)SearchSource;
                    if (respuest.Error == string.Empty)
                    {
                        SearchSource = new ObservableCollection<T>(respuest.Resultado);
                        int countNoResize = 0;
                        btnAltasEnabled = resp.Altas;
                        btnCambioEnabled = resp.Cambios;
                        btnBajasEnabled = resp.Bajas;
                        dgvGenerico.Columns.Clear();
                        //carga los datos del grid genérico
                        foreach (ColumnConfigElement item in resp.Columnas)
                        {

                            #region creación de las columnas
                            DataGridTextColumn c = new DataGridTextColumn();
                            c.Width = item.Size == 1 ? new DataGridLength(1, DataGridLengthUnitType.Star) : item.Size;
                            c.Header = item.Name;
                            if (pType.FullName.ToString() == "SITA.Entity.Ent_Aviso")
                            {
                                if (rdbImport.IsChecked == true)
                                {
                                    if (item.Name == "Fecha de Entrada")
                                        c.Header = item.Name;
                                    else if (item.Name == "Fecha de Salida")
                                        c.Header = "Fecha de Entrada";
                                }
                                else if (rdbExport.IsChecked == true)
                                {
                                    if (item.Name == "Fecha de Entrada")
                                        c.Header = "Fecha de Salida";
                                    else if (item.Name == "Fecha de Salida")
                                        c.Header = item.Name;
                                }
                            }
                            if (pType.FullName.ToString() == "SITA.Entity.Ent_Pedimento")
                            {
                                if (rdbImport.IsChecked == true)
                                {
                                    if (item.Name == "Fecha de Entrada")
                                        c.Header = item.Name;
                                    else if (item.Name == "Fecha de Presentación")
                                        c.Header = "Fecha de Entrada";
                                    btnNuevo.IsEnabled = true;
                                }
                                else if (rdbExport.IsChecked == true)
                                {
                                    if (item.Name == "Fecha de Entrada")
                                        c.Header = "Fecha de Presentación";
                                    else if (item.Name == "Fecha de Presentación")
                                        c.Header = item.Name;
                                }
                                btnAltasEnabled = true;
                            }
                            c.Binding = new Binding(item.Binding);
                            if (item.TextFormat != string.Empty)
                                c.Binding.StringFormat = item.TextFormat;
                            c.CanUserResize = item.Resize;
                            if (!item.Resize)
                                countNoResize++;
                            c.CanUserSort = item.Sort;
                            Style cellStyle = new Style(typeof(DataGridCell));

                            TextAlignment txta = new TextAlignment();
                            switch (item.TextAlign)
                            {
                                case DAL.Genericas.TextLeft:
                                    txta = TextAlignment.Left;
                                    break;
                                case DAL.Genericas.TextCenter:
                                    txta = TextAlignment.Center;
                                    break;
                                case DAL.Genericas.TextRight:
                                    txta = TextAlignment.Right;
                                    break;
                            }
                            Setter setter = new Setter(TextBlock.TextAlignmentProperty, txta);
                            cellStyle.Setters.Add(setter);
                            c.CellStyle = cellStyle;
                            dgvGenerico.Columns.Add(c);
                            #endregion
                        }
                        //dgvGenerico.SelectionMode = DataGridSelectionMode.Extended;

                        #region
                        Style rowStyle = new Style(typeof(DataGridRow));
                        rowStyle.Setters.Add(new EventSetter(DataGridRow.MouseDoubleClickEvent, new MouseButtonEventHandler(Row_DoubleClick)));
                        dgvGenerico.RowStyle = rowStyle;

                        dgvGenerico.ItemsSource = (ObservableCollection<T>)SearchSource;
                        dgvGenerico.IsReadOnly = true;
                        dgvGenerico.FrozenColumnCount = countNoResize;
                        currentColname = resp.InitBinding;
                        lblTipoBusqueda.Text = resp.InitSort;
                        _sortDirection = ListSortDirection.Ascending;
                        //vGenerico.Multiselect
                        btnNuevo.IsEnabled = btnAltasEnabled;
                        #endregion
                        if (((ObservableCollection<T>)SearchSource).Count > 0)
                        {
                            btnCambio.IsEnabled = btnCambioEnabled;
                            btnBaja.IsEnabled = btnBajasEnabled;
                        }
                        else
                        {
                            btnCambio.IsEnabled = false;
                            btnBaja.IsEnabled = false;
                        }
                    }
                    else
                    {
                        throw new ApplicationException(respuest.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, txtTitulo.Text != string.Empty ? txtTitulo.Text : "Genérico", MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
            }
        }

        private void ValidaTextosRadioImpoExpo(string met)
        {
            try
            {
                rdbExport.Visibility = Visibility.Visible;
                rdbImport.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        void dgvGenerico_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (dgvGenerico.SelectedItem != null)
                {
                    selectedRow = dgvGenerico.SelectedItem;
                    btnCambio.Content = "Editar";
                    switch(entidad)
                    {
                        case Genericas.EntCliente:
                            //Activa boton para sucursal
                            entclienteSuc = (EntCliente)dgvGenerico.SelectedItem;
                            if (entclienteSuc.TotalSucursal >= 1)
                            {
                                btnfiltroPed.IsEnabled = true;
                                btnfiltroPed.Visibility = Visibility.Visible;
                                btnfiltroPed.Content = "Ver Sucursales";
                            }
                            else
                            {
                                btnfiltroPed.IsEnabled = false;
                            }
                        break;
                        case Genericas.EntSucursal:
                            entSucursal = (EntSucursal)dgvGenerico.SelectedItem;
                        break;
                    }
                    
                }

                VerificaBotones();
                if (bandera == 5)
                {
                    lblTipoBusqueda.Visibility = Visibility.Collapsed;
                    txtBusqueda.Visibility = Visibility.Collapsed;
                }
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, txtTitulo.Text, MessageBoxButton.OK, MessageBoxImage.Stop);
                messageBox.ShowDialog();
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Escape)
                {
                    if (!SoloEsconderAlCerrar)
                    {
                        this.Close();
                    }
                    else
                    {
                        this.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, txtTitulo.Text, MessageBoxButton.OK, MessageBoxImage.Stop);
                messageBox.ShowDialog();
            }
        }

        private void dgvGenerico_RequestBringIntoView(object sender, RequestBringIntoViewEventArgs e)
        {
            try
            {
                e.Handled = true;
                if (bandera == 5)
                {
                    lblTipoBusqueda.Visibility = Visibility.Collapsed;
                    txtBusqueda.Visibility = Visibility.Collapsed;
                }
                else if (bandera == 1)
                {
                    lblTipoBusqueda.Visibility = Visibility.Collapsed;
                    txtBusqueda.Visibility = Visibility.Collapsed;
                    dpEntr.Visibility = Visibility.Collapsed;
                }
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, txtTitulo.Text, MessageBoxButton.OK, MessageBoxImage.Stop);
                messageBox.ShowDialog();
            }
        }

        private void btnRango_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RealizaAccion(1, null, null, 1);
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, txtTitulo.Text, MessageBoxButton.OK, MessageBoxImage.Stop);
                messageBox.ShowDialog();
            }
        }

        private void btnSincronizaEDo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //bucein
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, txtTitulo.Text, MessageBoxButton.OK, MessageBoxImage.Stop);
                messageBox.ShowDialog();
            }
        }

        private void rdbImport_Checked(object sender, RoutedEventArgs e)
        {
            //VERIFICAR PARA ESTATUS DEL CLIENTE
            try
            {
                ImportExport = "1";
                RealizaAccion(-1, null, null, 0);
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, txtTitulo.Text, MessageBoxButton.OK, MessageBoxImage.Stop);
                messageBox.ShowDialog();
            }
        }

        private void rdbExport_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                ImportExport = "2";
                RealizaAccion(-1, null, null, 0);
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, txtTitulo.Text, MessageBoxButton.OK, MessageBoxImage.Stop);
                messageBox.ShowDialog();
            }
        }

        private void rdbTodos_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                ImportExport = "3";
                RealizaAccion(-1, null, null, 0);
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, txtTitulo.Text, MessageBoxButton.OK, MessageBoxImage.Stop);
                messageBox.ShowDialog();
            }
        }

        private void btnCopia_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // acción colo que la tres ya que la 2 eliminar el registro actual, 1 genera altas o cambios, 3 copia de la referencia
                if (dgvGenerico.SelectedItem != null)
                {
                    RealizaAccion(3, null, dgvGenerico.SelectedItem);
                }
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, txtTitulo.Text, MessageBoxButton.OK, MessageBoxImage.Stop);
                messageBox.ShowDialog();
            }
        }

        #endregion

        //filtros personalizados
        private void btnfiltroPed_Click(object sender, RoutedEventArgs e)
        {
            string impexp = string.Empty;
            impexp = rdbImport.IsChecked == true ? "1" : rdbExport.IsChecked == true ? "2" : "1";
            //Respuesta<List<Ent_Pedimento>> lstped = new Respuesta<List<Ent_Pedimento>>();
            try
            {
                //Pedimento.frmFiltrosPedimento frm = new frmFiltrosPedimento();
                //frm.DatosEntrada(impexp);
                //frm.ShowDialog();
                //List<Ent_Pedimento> lstPrueba = new List<Ent_Pedimento>();
                
                //lstped = frmFiltrosPedimento.lstgridpedFilt;
                //if (lstped.TotalRegistros> 0)
                //{
                //    //dgvGenerico.ItemsSource = lstped.Resultado;
                //    Filtros<Ent_Pedimento>(lstped);
                //    txtBusqueda.Text = string.Empty;
                //} 
                //else
                //{
                //    dgvGenerico.ItemsSource = null;
                //    dgvGenerico.Columns.Clear();
                //}
                switch(entidad)
                {                        
                    case Genericas.EntCliente:                        
                        CatalogConfigElement catP = SITAConfig.GetConfigCatalogo(DAL.Genericas.CatSucursal);
                        frmCatologoGenerico frmCatalogoP = new frmCatologoGenerico(this, entclienteSuc);                                                
                        frmCatalogoP.BindGrid<EntSucursal>(catP, string.Empty, 1);
                        frmCatalogoP.Name = "FrmSucursal";
                        frmCatalogoP.Title = "Catálogo de Sucursales";
                        frmCatalogoP.txtTitulo.Text = "Catálogo de Sucursales";
                        frmCatalogoP.ShowDialog();
                    break;
                }                
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, txtTitulo.Text, MessageBoxButton.OK, MessageBoxImage.Error);
                messageBox.ShowDialog();
            }
        }
        
        public void AcutualizaGrid<T>(T Registro) where T : class
        {
            try
            {
                procesando.Visibility = Visibility.Visible;
                ObservableCollection<T> clie = SearchSource as ObservableCollection<T>;
                List<T> Universo = clie.ToList<T>();

                //si selectedRow no es nullo entonces se trata de una edición o un borrado
                if (selectedIndexRow != -1)
                {
                    int indxlst = Universo.FindIndex(selectedRow.Equals);

                    if (EliminarReg)
                        Universo.RemoveAt(indxlst);
                    else if (indxlst.ToString() != "-1")
                    {
                        if (bandera == 2)
                            Universo.RemoveAt(indxlst);
                        else
                        {
                            if(InsertaSiguienteIndex)
                            {
                                Universo.Insert(indxlst + 1, Registro);
                            }
                            else
                            {
                                Universo[indxlst] = Registro;
                            }
                        }
                    }
                    else //SI no es edicion se agregar el nuevo registro
                    {
                        Universo.Add(Registro);
                    }
                }
                else //SI no es edicion se agregar el nuevo registro
                {
                    Universo.Add(Registro);
                }

                //Llenando el Grid Generico
                SearchSource = new ObservableCollection<T>(Universo);
                
                dgvGenerico.ItemsSource = null;
                dgvGenerico.ItemsSource = (ObservableCollection<T>)SearchSource;
                if (bandera == 3)
                {
                    List<Filter> filter = new List<Filter>()
                    { 
                        
                        new Filter{
                            PropertyName = currentColname,
                             Value = Convert.ToString(DateTime.MinValue),
                            Operation = Op.Contains
                        }
                    };
                    RealizaAccion(0, filter, null);
                }
                procesando.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Metodo que abre un catálogo de Agendas Genérico
        /// </summary>
        /// <typeparam name="T">Entidad Clase que se utilizará</typeparam>
        /// <param name="Entidad">La misma entidad</param>
        /// <param name="Catalogo">Ej: DAL.Comunes.CAT_MUNICIPIOSAGAR</param>
        /// <param name="Titulo">Titulo de la ventana y de la etiqueta de título</param>
        /// <param name="Agregar">Si se muestra el botón de agregar</param>
        /// <param name="Editar">Si se muestra el botón de editar</param>
        /// <param name="Borrar">Si se muestra el botón de borrar</param>
        /// <returns>Object con la Seleccion genérica tendrá quu convertirse Ej: Ent_Mun_SAGAR Seleccion= SeleccionGenerica as Ent_Mun_SAGAR</returns>
        public object AbrirAgendaGenerica<T>(string Catalogo, string Titulo, bool Agregar, bool Editar, bool Borrar, string tabla="", int tipo = 0, object Ent=null, bool EsconderAlCerrar=true) where T : class
        {
            try
            {
                CatalogConfigElement cat = SITAConfig.GetConfigCatalogo(Catalogo);
                SoloEsconderAlCerrar = false;
                BindGrid<T>(cat, tabla, tipo, Ent);

                ConfiguracionGenerica(Catalogo, Titulo, Agregar, Editar, Borrar, EsconderAlCerrar);
                this.ShowDialog();

                return SeleccionGenerica;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void ConfiguracionGenerica(string Catalogo, string Titulo, bool Agregar, bool Editar, bool Borrar, bool EsconderAlCerrar = true)
        {
            try
            {
                BusquedaGenerica = EsconderAlCerrar;
                this.Title = Titulo;
                txtTitulo.Text = Titulo;
                gbOpc.Header = string.Empty;

                btnNuevo.Visibility = Agregar ? Visibility.Visible : Visibility.Collapsed;
                btnCambio.Visibility = Editar ? Visibility.Visible : Visibility.Collapsed;
                btnBaja.Visibility = Borrar ? Visibility.Visible : Visibility.Collapsed;

                //se muestra solamente si no se quiere usar botones de eliminar, guardar y consultar
                //if (Catalogo == DAL.Comunes.CAT_TIPOS_CAMBIO)
                //{
                //    if (App.UsuarioSession.PERFILSTRING != "Administrador")
                //    {
                //        btnCambio.Visibility = Visibility.Collapsed;
                //        btnBaja.Visibility = Visibility.Collapsed;
                //        btnNuevo.Visibility = Visibility.Collapsed;
                //    }
                //    else
                //    {
                //        btnBaja.Visibility = Visibility.Collapsed;
                //        btnCambio.IsEnabled = true;
                //    }
                //}

                btnNuevo.IsEnabled = true;

                txtBusqueda.Dispatcher.BeginInvoke((Action)(() => { txtBusqueda.Focus(); }));
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public object AbrirAgendaGenerica<T>(List<T> Universo, string Catalogo, string Titulo, bool Agregar, bool Editar, bool Borrar, bool ImpoExpo=false) where T : class
        {
            try
            {
                CatalogConfigElement cat = SITAConfig.GetConfigCatalogo(Catalogo);
                current = cat;
                procesando.Visibility = Visibility.Visible;
                int countNoResize = 0;
                Type pType = typeof(T);
                entidad = pType.ToString();

                //creando las columnas
                foreach (ColumnConfigElement item in cat.Columnas)
                {
                    #region creación de las columnas
                    DataGridTextColumn c = new DataGridTextColumn();
                    c.Width = item.Size == 1 ? new DataGridLength(1, DataGridLengthUnitType.Star) : item.Size;
                    c.Header = item.Name;
                    c.Binding = new Binding(item.Binding);
                    if (item.TextFormat != string.Empty)
                        c.Binding.StringFormat = item.TextFormat;
                    c.CanUserResize = item.Resize;
                    if (!item.Resize)
                        countNoResize++;
                    c.CanUserSort = item.Sort;
                    Style cellStyle = new Style(typeof(DataGridCell));

                    TextAlignment txta = new TextAlignment();
                    switch (item.TextAlign)
                    {
                        case DAL.Genericas.TextLeft:
                            txta = TextAlignment.Left;
                            break;
                        case DAL.Genericas.TextCenter:
                            txta = TextAlignment.Center;
                            break;
                        case DAL.Genericas.TextRight:
                            txta = TextAlignment.Right;
                            break;
                    }
                    Setter setter = new Setter(TextBlock.TextAlignmentProperty, txta);
                    cellStyle.Setters.Add(setter);
                    c.CellStyle = cellStyle;
                    dgvGenerico.Columns.Add(c);
                    #endregion
                }
                Style rowStyle = new Style(typeof(DataGridRow));
                rowStyle.Setters.Add(new EventSetter(DataGridRow.MouseDoubleClickEvent, new MouseButtonEventHandler(Row_DoubleClick)));
                dgvGenerico.RowStyle = rowStyle;
                dgvGenerico.ItemsSource = (ObservableCollection<T>)SearchSource;
                dgvGenerico.IsReadOnly = true;
                dgvGenerico.FrozenColumnCount = countNoResize;
                currentColname = cat.InitBinding;
                lblTipoBusqueda.Text = cat.InitSort;

                //Llenando el Grid Generico
                SearchSource = new ObservableCollection<T>(Universo);
                dgvGenerico.ItemsSource = null;
                dgvGenerico.ItemsSource = (ObservableCollection<T>)SearchSource;
                procesando.Visibility = Visibility.Hidden;

                SoloEsconderAlCerrar = true;

                ConfiguracionGenerica(Catalogo, Titulo, Agregar, Editar, Borrar);

                if(ImpoExpo)
                {
                    rdbImport.IsChecked = true;
                    string met = cat.Metodo;

                    ValidaTextosRadioImpoExpo(met);
                }
                btnNuevo.IsEnabled = Agregar ? true : false;

                
                this.ShowDialog();

                return SeleccionGenerica;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                base.DragMove();
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, txtTitulo.Text, MessageBoxButton.OK, MessageBoxImage.Error);
                messageBox.ShowDialog();
            }
        }

        private void cmbMes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           try
           {
               buscarFecha();
           }
            catch(Exception ex)
           {
               messageBox = new avisosis(ex, txtTitulo.Text, MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
           }
        }

        private void buscarFecha()
        {
            try
            {
                //if (entidad == Genericas.Ent_Tipo_Cambio)
                //{
                //    ObservableCollection<Ent_Tipo_Cambio> lst = SearchSource as ObservableCollection<Ent_Tipo_Cambio>;
                //    List<Ent_Tipo_Cambio> lstfilt = lst.ToList<Ent_Tipo_Cambio>();
                //    if (cmbMes.SelectedValue != null && txtAño.Text.Trim() == string.Empty)
                //    {
                //        if (cmbMes.SelectedValue.ToString() == "0")
                //            dgvGenerico.ItemsSource = (ObservableCollection<Ent_Tipo_Cambio>)SearchSource;
                //        else
                //        {
                //            lstfilt = lstfilt.Where(x => x.Fecha.Month == Convert.ToInt32(cmbMes.SelectedValue)).ToList();
                //            dgvGenerico.ItemsSource = lstfilt;
                //        }
                //    }
                //    else if (cmbMes.SelectedValue == null && txtAño.Text.Trim() != string.Empty)
                //    {
                //        lstfilt = lstfilt.Where(x => x.Fecha.Year == Convert.ToInt32(txtAño.Text)).ToList();
                //        dgvGenerico.ItemsSource = lstfilt;
                //    }
                //    else if (cmbMes.SelectedValue != null && txtAño.Text.Trim() != string.Empty)
                //    {
                //        lstfilt = lstfilt.Where(x => x.Fecha.Year == Convert.ToInt32(txtAño.Text)).ToList();
                //        lstfilt = lstfilt.Where(x => x.Fecha.Month == Convert.ToInt32(cmbMes.SelectedValue)).ToList();
                //        dgvGenerico.ItemsSource = lstfilt;
                //    }
                //    else
                //        dgvGenerico.ItemsSource = (ObservableCollection<Ent_Tipo_Cambio>)SearchSource;
                //}
                //else if (entidad == Genericas.Ent_Inpc_Recargos)
                //{
                //    ObservableCollection<Ent_Recargos_facturasINPC> lst = SearchSource as ObservableCollection<Ent_Recargos_facturasINPC>;
                //    List<Ent_Recargos_facturasINPC> lstfilt = lst.ToList<Ent_Recargos_facturasINPC>();
                //    if (cmbMes.SelectedValue != null && txtAño.Text.Trim() == string.Empty)
                //    {
                //        if (cmbMes.SelectedValue.ToString() == "0")
                //            dgvGenerico.ItemsSource = (ObservableCollection<Ent_Recargos_facturasINPC>)SearchSource;
                //        else
                //        {
                //            lstfilt = lstfilt.Where(x => x.Fecha.Month == Convert.ToInt32(cmbMes.SelectedValue)).ToList();
                //            dgvGenerico.ItemsSource = lstfilt;
                //        }
                //    }
                //    else if (cmbMes.SelectedValue == null && txtAño.Text.Trim() != string.Empty)
                //    {
                //        lstfilt = lstfilt.Where(x => x.Fecha.Year == Convert.ToInt32(txtAño.Text)).ToList();
                //        dgvGenerico.ItemsSource = lstfilt;
                //    }
                //    else if (cmbMes.SelectedValue != null && txtAño.Text.Trim() != string.Empty)
                //    {
                //        lstfilt = lstfilt.Where(x => x.Fecha.Year == Convert.ToInt32(txtAño.Text)).ToList();
                //        lstfilt = lstfilt.Where(x => x.Fecha.Month == Convert.ToInt32(cmbMes.SelectedValue)).ToList();
                //        dgvGenerico.ItemsSource = lstfilt;
                //    }
                //    else
                //        dgvGenerico.ItemsSource = (ObservableCollection<Ent_Recargos_facturasINPC>)SearchSource;
                //}
                //else if (entidad == Genericas.Ent_Equivalencias)
                //{
                //    ObservableCollection<Ent_Equivalencias> lst = SearchSource as ObservableCollection<Ent_Equivalencias>;
                //    List<Ent_Equivalencias> lstfilt = lst.ToList<Ent_Equivalencias>();
                //    if (cmbMes.SelectedValue != null && txtAño.Text.Trim() == string.Empty)
                //    {
                //        if (cmbMes.SelectedValue.ToString() == "0")
                //            dgvGenerico.ItemsSource = (ObservableCollection<Ent_Equivalencias>)SearchSource;
                //        else
                //        {
                //            lstfilt = lstfilt.Where(x => x.Fecha.Month == Convert.ToInt32(cmbMes.SelectedValue)).ToList();
                //            dgvGenerico.ItemsSource = lstfilt;
                //        }
                //    }
                //    else if (cmbMes.SelectedValue == null && txtAño.Text.Trim() != string.Empty)
                //    {
                //        lstfilt = lstfilt.Where(x => x.Fecha.Year == Convert.ToInt32(txtAño.Text)).ToList();
                //        dgvGenerico.ItemsSource = lstfilt;
                //    }
                //    else if (cmbMes.SelectedValue != null && txtAño.Text.Trim() != string.Empty)
                //    {
                //        lstfilt = lstfilt.Where(x => x.Fecha.Year == Convert.ToInt32(txtAño.Text)).ToList();
                //        lstfilt = lstfilt.Where(x => x.Fecha.Month == Convert.ToInt32(cmbMes.SelectedValue)).ToList();
                //        dgvGenerico.ItemsSource = lstfilt;
                //    }
                //    else
                //        dgvGenerico.ItemsSource = (ObservableCollection<Ent_Equivalencias>)SearchSource;
                //}
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, txtTitulo.Text, MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
            }
        }

        private void txtAño_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                buscarFecha();
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, txtTitulo.Text, MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
            }
        }

        private void cmbMes_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                buscarFecha();
            }
            catch(Exception ex)
            {
                messageBox = new avisosis(ex, txtTitulo.Text, MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
            }
        }

        private void txtBusqDeci_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                //ObservableCollection<Ent_Equivalencias> lst = SearchSource as ObservableCollection<Ent_Equivalencias>;
                //List<Ent_Equivalencias> lstfilt = lst.ToList<Ent_Equivalencias>();
                //if ( txtBusqDeci.Text.Trim() != string.Empty)
                //{
                //        lstfilt = lstfilt.Where(x => Convert.ToString(x.Eq).ToUpper().Contains(txtBusqDeci.Text)).ToList();
                //        dgvGenerico.ItemsSource = lstfilt;
                //}
                //else
                //    dgvGenerico.ItemsSource = (ObservableCollection<Ent_Equivalencias>)SearchSource;
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, txtTitulo.Text, MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
            }
        }

        private void BaseWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if(txtTitulo.Text.Length>50)
            {
                txtTitulo.FontSize = 16;
            }
            else
            {
                txtTitulo.FontSize = 23;
            }
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!SoloEsconderAlCerrar)
                {
                    Close();
                }
                else
                {
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, txtTitulo.Text, MessageBoxButton.OK, MessageBoxImage.Error);
                messageBox.ShowDialog();
            }
        }

        private void btnMinWin_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void dgvGenerico_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                //frmMenPed = new frmMenuPedimento(this);
                //if (dgvGenerico.SelectedItem != null)
                //{
                //    if (NomEnt == "SITA.Entity.Ent_Pedimento")
                //    {
                //        Ent_Pedimento ent = dgvGenerico.SelectedItem as Ent_Pedimento;
                //        string impex = string.Empty;
                //        if (rdbExport.IsChecked == true)
                //            impex = "2";
                //        else
                //            impex = "1";
                //        frmMenPed.LlenaPed(ent, SearchSource as ObservableCollection<Ent_Pedimento>, impex);

                //        if (banderParte == 0)
                //        {
                //            frmMenPed.impexport = impex;
                //            // pedimento principal
                //        frmMenPed.banActPed = 1;
                //        }
                //        else if (banderParte == 9)
                //        {
                //            // opcion 9 es para pedimento complementario TLCAN
                //            frmMenPed.banActPed = 9;
                //        }
                //        else if (banderParte == 8)
                //        {
                //            // opcion 8 es para pedimento complementario EUR
                //            frmMenPed.banActPed = 8;
                //        }
                //        frmMenPed.Show();
                //        banMenu = 1;
                //        //frm.Close();
                //    }
                //    else
                //    {
                //        Ent_Pedimento ent = dgvGenerico.SelectedItem as Ent_Pedimento;

                //        frmMenPed.banActPed = 2;
                //        frmMenPed.Show();
                //        banMenu = 1;
                //        //frm.Close();
                //    }
                //}
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, "Expediente Digital", MessageBoxButton.OK, MessageBoxImage.Error);
                messageBox.ShowDialog();
            }
        }

        private void ckePag_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                RealizaAccion(-1, null, null, 0);
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, txtTitulo.Text, MessageBoxButton.OK, MessageBoxImage.Stop);
                messageBox.ShowDialog();
            }
        }

        private void ckePag_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                RealizaAccion(-1, null, null, 0);
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, txtTitulo.Text, MessageBoxButton.OK, MessageBoxImage.Stop);
                messageBox.ShowDialog();
            }
        }

        private void BaseWindow_Activated(object sender, EventArgs e)
        {
          //  if (banMenu == 1)
          //{
          //    frmMenPed.Hide();
          //}
        }

        private void dgvGenerico_KeyDown(object sender, KeyEventArgs e)
        {
            //int posx;
            //int posy;
            //if(e.KeyCode)
        }

        
    }
}
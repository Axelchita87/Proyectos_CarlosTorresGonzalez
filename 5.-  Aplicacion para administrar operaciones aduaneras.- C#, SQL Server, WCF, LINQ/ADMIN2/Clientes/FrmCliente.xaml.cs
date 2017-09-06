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

using ADMIN2.Controls;
using ADMIN2.Entity;
using ADMIN2.BR;
using ADMIN2.DAL;
using System.Text.RegularExpressions;

namespace ADMIN2.Clientes
{
    /// <summary>
    /// Lógica de interacción para FrmCliente.xaml
    /// </summary>
    public partial class FrmCliente : BaseWindow
    {
        public FrmCliente()
        {
            InitializeComponent();
            btnAceptar.IsEnabled = false;
            btnCancelar.IsEnabled = false;
            IdPermiso = App.IdPermiso.ToString();
            if (App.IdPermiso.ToString() == "1")
            {
                BtnRuta.IsEnabled = false;
                inhabilitaControles(GridBotones2_Copy);
            }

            ConsultaTipoCliente();
            ConsultaEstatusCliente();
            ConsultaSectorCliente();
            ConsultaTipoDocumento();
            TxtFechaRegistro.IsEnabled = false;
            TxtFechaModificacion.IsEnabled = false;
            TxtEjecutivoVentas.IsEnabled = false;
            ConsultaConsecutivoCliente();

            DateTime fecha = Convert.ToDateTime(DateTime.Today);
            string fechaHoy = fecha.ToString("yyyy-MM-dd");
            TxtFechaRegistro.Text = fechaHoy;
            CmbTipoCliente.SelectedIndex = 0;
            CmbEstatus.SelectedIndex = 0;
        }

        public FrmCliente(frmCatologoGenerico frmCatologoGenerico)
        {
            // TODO: Complete member initialization
            this.frmCatologoGenerico = frmCatologoGenerico;
            InitializeComponent();
            btnAceptar.IsEnabled = false;
            btnCancelar.IsEnabled = false;
            IdPermiso = App.IdPermiso.ToString();
            if (App.IdPermiso.ToString() == "1")
            {
                BtnRuta.IsEnabled = false;
                inhabilitaControles(GridBotones2_Copy);
                BtnSucursal.IsEnabled = false;
            }

            ConsultaTipoCliente();
            ConsultaEstatusCliente();
            ConsultaSectorCliente();
            ConsultaTipoDocumento();
            TxtFechaRegistro.IsEnabled = false;
            TxtFechaModificacion.IsEnabled = false;
            TxtEjecutivoVentas.IsEnabled = false;
            ConsultaConsecutivoCliente();
            ConsultaUsuarioAreas();

            DateTime fecha = Convert.ToDateTime(DateTime.Today);
            string fechaHoy = fecha.ToString("yyyy-MM-dd");
            TxtFechaRegistro.Text = fechaHoy;
            CmbTipoCliente.SelectedIndex = 0;
            CmbEstatus.SelectedIndex = 0;
        }     

        #region Declaraciones

        avisosis messageBox = new avisosis();
        public string ActIns = string.Empty;
        public int bandera = 0;
        private frmCatologoGenerico frmCatologoGenerico;
        private EntCliente entCliente = new EntCliente();
        private List<EntEntidades> EstadosRep;
        private int idEstado = 0;
        private int idEstadoDe = 0;
        
        #endregion

        #region Eventos

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            try
            {
                base.DragMove();
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, this.Title, MessageBoxButton.OK, MessageBoxImage.Error);
                messageBox.ShowDialog();
            }
        }

        private void BtnCerrarClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, this.Title, MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
            }
        }

        private void BtnBusquedaClick(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    frmCatologoGenerico frmCatalogo = new frmCatologoGenerico();
            //    object Resp = frmCatalogo.AbrirAgendaGenerica<EntCgRecExp>(DAL.Comunes.CatCGRECEXPReferencia, "Recepción Expedientes", false, false, false, string.Empty, 5);
            //    EntCgRecExp EntCgRecExp = Resp as EntCgRecExp;

            //    if (EntCgRecExp != null)
            //    {
            //        txtreferencia.Text = EntCgRecExp.NumReferencia;
            //        TxtSub.Text = EntCgRecExp.ISub.ToString();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    messageBox = new avisosis(ex, this.Title, MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
            //}
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                base.OnClosing(e);
                if (guardar)
                {
                    cerrando = true;
                    btnAceptar_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, this.Title, MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
            }
        }

        private void btnCancelClick(object sender, RoutedEventArgs e)
        {
            if (ActIns == Comunes.AGREGA)
            {
                LimpiaTextBox(this);
            }
            else
            {
                Close();
            }
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bandera = 1;
                Guarda();
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, this.Title, MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
            }
        }

        private void CmbPedDropDownOpened(object sender, EventArgs e)
        {
            try
            {
                ComboBox Cmb = (ComboBox)sender;
                switch (Cmb.Name)
                {
                    case "CmbTipoCliente":
                        if (CmbTipoCliente.IsDropDownOpen == true)
                        {
                            ConsultaTipoCliente();
                        }
                        break;
                    case "CmbEstatus":
                        if (CmbEstatus.IsDropDownOpen == true)
                        {
                            ConsultaEstatusCliente();
                        }
                        break;
                    case "CmbSector":
                        if (CmbSector.IsDropDownOpen == true)
                        {
                            ConsultaSectorCliente();
                        }
                        break;
                    case "CmbTipoDocumento":
                        if (CmbTipoDocumento.IsDropDownOpen == true)
                        {
                            ConsultaTipoDocumento();
                        }
                        break;
                }               
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, this.Title, MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
            }
        }

        private void CmbPedPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            try
            {
                ComboBox Cmb = (ComboBox)sender;
                switch (Cmb.Name)
                {
                    case "CmbTipoCliente":
                        ConsultaTipoCliente();
                        break;
                    case "CmbEstatus":
                        ConsultaEstatusCliente();
                        break;
                    case "CmbSector":
                        ConsultaSectorCliente();
                        break;
                    case "CmbTipoDocumento":
                        ConsultaTipoDocumento();
                        break;
                }
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, this.Title, MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
            }
        }

        private void BtnSucursal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FrmSucursal frmSucursal = new FrmSucursal();
                frmSucursal.ActIns = Comunes.AGREGA;
                EntSucursal entSuc = new EntSucursal();
                frmSucursal.opcGuarda = 1;
                frmSucursal.ConsultaDatosCliente(entCliente, entSuc);
                frmSucursal.ShowDialog();

            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, this.Title, MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
            }

        }

        private void BtnColonia_Click(object sender, RoutedEventArgs e)
        {
            FrmEntidades frmEntidades = new FrmEntidades();
            frmEntidades.MuestraOpcion = 1;
            frmEntidades.MuestaOpcion();
            frmEntidades.ShowDialog();
            if (frmEntidades.ValidaDir)
            {
                TxtEstado.Text = frmEntidades.TxtEstado.Text;
                TxtMunicipio.Text = frmEntidades.TxtMunicipio.Text;
                txtcolonia.Text = frmEntidades.TxtColonia.Text;
                TxtCp.Text = frmEntidades.TxtCP.Text;
                idEstado = frmEntidades.idEstado;
                if (frmEntidades.aplicaCopia == true)
                {
                    TxtEstadoDE.Text = frmEntidades.TxtEstado.Text;
                    TxtMunicipioDE.Text = frmEntidades.TxtMunicipio.Text;
                    txtcoloniaDE.Text = frmEntidades.TxtColonia.Text;
                    TxtCpDE.Text = frmEntidades.TxtCP.Text;
                    idEstadoDe = frmEntidades.idEstado;
                }
                else
                {
                    if (TxtEstadoDE.Text == string.Empty && TxtMunicipioDE.Text == string.Empty && txtcoloniaDE.Text == string.Empty && TxtCpDE.Text == string.Empty)
                    {
                        TxtEstadoDE.Text = string.Empty;
                        TxtMunicipioDE.Text = string.Empty;
                        txtcoloniaDE.Text = string.Empty;
                        TxtCpDE.Text = string.Empty;
                        idEstadoDe = 0;
                    }
                }
            }
        }

        private void TxtRfc_LostFocus(object sender, RoutedEventArgs e)
        {
            ValidarRFC();
        }

        private void BtnColoniaDE_Click(object sender, RoutedEventArgs e)
        {
            FrmEntidades frmEntidades = new FrmEntidades();
            frmEntidades.MuestraOpcion = 0;
            frmEntidades.MuestaOpcion();
            frmEntidades.ShowDialog();
            if (frmEntidades.ValidaDir)
            {
                TxtEstadoDE.Text = frmEntidades.TxtEstado.Text;
                TxtMunicipioDE.Text = frmEntidades.TxtMunicipio.Text;
                txtcoloniaDE.Text = frmEntidades.TxtColonia.Text;
                TxtCpDE.Text = frmEntidades.TxtCP.Text;
                idEstadoDe = frmEntidades.idEstado;
            }
        }

        #endregion

        #region Métodos

        //guarda y actualiza
        public void Guarda()
        {
            EntCliente enttrC = new EntCliente();
            BrCliente cliente = new BrCliente();
            try
            {
                Genericas gen = new Genericas();
                totRequeridos = 4;
                contabilizaYValidaRequerido(TxtEmpresa);
                contabilizaYValidaRequerido(CmbTipoCliente);
                contabilizaYValidaRequerido(TxtRfc);
                contabilizaYValidaRequerido(CmbSector);
                if (totRequeridos > 0)
                {
                    messageBox = new avisosis(totRequeridos == 1 ? (string.Format("¡El campo {0} es obligatorio!", ControlInvalido)) : "Los campos son obligatorios", this.Title, MessageBoxButton.OK, MessageBoxImage.Warning);
                    messageBox.ShowDialog();
                    return;
                }

                enttrC.ClaveCliente = gen.SetCampo(Convert.ToInt32(TxtCliente.Text));
                enttrC.TipoVIP =  gen.SetCampo(CmbTipoCliente.Text);
                enttrC.Statuscliente = gen.SetCampo(Convert.ToInt32(CmbEstatus.SelectedValue));
                if (ChbIguala.IsChecked == true)
                    enttrC.Iguala = 1;
                else
                    enttrC.Iguala = 0;

                enttrC.FechaRegistro =gen.SetCampo(TxtFechaRegistro.Text);
                enttrC.FechaMoficacion="";
                enttrC.Nombrecliente = gen.SetCampo(TxtEmpresa.Text);
                enttrC.Rfccliente=gen.SetCampo(TxtRfc.Text);
                enttrC.IdRfcEua= gen.SetCampo(TxtIdTax.Text);
                enttrC.Facturacioncliente=gen.SetCampo(TxtFacturaNom.Text);
                enttrC.Sectorcliente = gen.SetCampo(CmbSector.SelectedValue.ToString());
                enttrC.Direccioncliente= gen.SetCampo(TxtDireccion.Text);
                enttrC.Coloniacliente= gen.SetCampo(txtcolonia.Text);
                enttrC.Codigopostalcliente =gen.SetCampo(TxtCp.Text );
                enttrC.Ciudadcliente=gen.SetCampo(TxtMunicipio.Text);                
                enttrC.Estadocliente = gen.SetCampo(idEstado.ToString()); 
                enttrC.Pais=gen.SetCampo(TxtPais.Text );
                enttrC.Telefono1cliente= gen.SetCampo(TxtTelefono1.Text );
                enttrC.Telefono2cliente=gen.SetCampo(TxtTelefono2.Text );
                enttrC.Emailcliente=gen.SetCampo(TxtEmailContacto.Text );
                enttrC.EmailSecEnvios=gen.SetCampo(TxtEmailCobranza.Text );                
                enttrC.Atencionpersonal1cliente = gen.SetCampo(TxtAtenciónCobranza.Text);
                if (ActIns == Comunes.AGREGA)
                {
                    enttrC.Ejecutivo = gen.SetCampo(CmbEjecutivoVentas.Text);
                }
                else
                {
                    enttrC.Ejecutivo = gen.SetCampo(TxtEjecutivoVentas.Text);
                }
                enttrC.Nombreenvios=gen.SetCampo(TxtEmpresaDE.Text );
                enttrC.Usuarioenvios=gen.SetCampo(TxtAtencionEnv.Text );
                enttrC.Direccionenvios=gen.SetCampo(TxtDireccionDE.Text );
                enttrC.Coloniaenvios=gen.SetCampo(txtcoloniaDE.Text );
                enttrC.Cpenvios=gen.SetCampo(TxtCpDE.Text );
                enttrC.Ciudadenvios=gen.SetCampo(TxtMunicipioDE.Text);
                enttrC.Edoenvios= gen.SetCampo(idEstadoDe.ToString());
                enttrC.Telenvios=gen.SetCampo(TxtTelefonoDE.Text );
                enttrC.Emailenvios = gen.SetCampo(TxtEmailContactoDE.Text);


                if (ActIns == Comunes.AGREGA)
                {
                   enttrC.IdUsuarioRegistro = App.IdUsuario;
                }
                else
                {
                    enttrC.IdUsuarioModifico = App.IdUsuario;
                }

                if(ValidaDatosRFC()== false)
                    return;

                if (ValidarRFC() == false)
                    return;

                Respuesta<int> res = cliente.InsUpdClientes(enttrC, ActIns, "A");
                if (bandera == 1)
                {
                    if (res.EsExitoso)
                    {
                        entCliente = enttrC;
                        //Actualizacion del Grid Generico
                        frmCatologoGenerico.AcutualizaGrid<EntCliente>(enttrC);
                        Editando = false;
                        messageBox = new avisosis("Se ha " + (ActIns == Comunes.AGREGA ? " agregado " : ActIns == Comunes.CAMBIA ? " actualizado " : " eliminado ") + " correctamente datos del cliente.", this.Title, MessageBoxButton.OK, MessageBoxImage.None); messageBox.ShowDialog();
                        if (!cerrando)
                            this.Close();
                    }
                    else
                    {
                        messageBox = new avisosis("Error al " + (ActIns == Comunes.AGREGA ? " agregar " : ActIns == Comunes.CAMBIA ? " actualizar " : " eliminar ") + res.Error, this.Title, MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
                    }
                }

            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, this.Title, MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
            }
        }

        public void Consulta(EntCliente enttrM)
        {
            try
            {
                Genericas gen = new Genericas();
                if (ActIns == Comunes.CAMBIA)
                {
                    entCliente = enttrM;
                    ConsultaEntidades();
                    TxtCliente.Text = gen.SetCampo(enttrM.ClaveCliente.ToString());
                    TxtCliente.IsEnabled = false;
                    CmbTipoCliente.Text = gen.SetCampo(enttrM.TipoVIP.ToString());
                    CmbEstatus.SelectedValue = gen.SetCampo(enttrM.Statuscliente.ToString());
                    if (gen.SetCampo(enttrM.Statuscliente) == 1)
                    {
                        ChbIguala.IsChecked = true;
                    }
                    TxtFechaRegistro.Text = gen.SetCampo(enttrM.FechaRegistro.ToString());
                    TxtFechaModificacion.Text = gen.SetCampo(enttrM.FechaMoficacion.ToString());
                    TxtEmpresa.Text = gen.SetCampo(enttrM.Nombrecliente.ToString());
                    TxtRfc.Text = gen.SetCampo(enttrM.Rfccliente.ToString());
                    TxtIdTax.Text = gen.SetCampo(enttrM.IdRfcEua.ToString());
                    TxtFacturaNom.Text = gen.SetCampo(enttrM.Facturacioncliente.ToString());
                    CmbSector.SelectedValue = gen.SetCampo(enttrM.Sectorcliente.ToString());
                    TxtDireccion.Text = gen.SetCampo(enttrM.Direccioncliente.ToString());
                    txtcolonia.Text = gen.SetCampo(enttrM.Coloniacliente.ToString());
                    TxtCp.Text = gen.SetCampo(enttrM.Codigopostalcliente.ToString());
                    TxtMunicipio.Text = gen.SetCampo(enttrM.Ciudadcliente.ToString());
                    EntEntidades Enti = new EntEntidades();
                    Enti= EstadosRep.Find(c=> c.IdEstado == gen.SetCampo(Convert.ToInt32(enttrM.Estadocliente)));
                    TxtEstado.Text = Enti.D_estado;
                    idEstado =Convert.ToInt32(Enti.IdEstado);
                    TxtPais.Text = gen.SetCampo(enttrM.Pais.ToString());
                    TxtTelefono1.Text = gen.SetCampo(enttrM.Telefono1cliente.ToString());
                    TxtTelefono2.Text = gen.SetCampo(enttrM.Telefono2cliente.ToString());
                    TxtEmailContacto.Text = gen.SetCampo(enttrM.Emailcliente.ToString());
                    TxtEmailCobranza.Text = gen.SetCampo(enttrM.EmailSecEnvios.ToString());
                    TxtAtenciónCobranza.Text = gen.SetCampo(enttrM.Atencionpersonal1cliente.ToString());
                    TxtEjecutivoVentas.Text = gen.SetCampo(enttrM.Ejecutivo.ToString());
                    TxtEmpresaDE.Text = gen.SetCampo(enttrM.Nombreenvios.ToString());
                    TxtAtencionEnv.Text = gen.SetCampo(enttrM.Usuarioenvios.ToString());
                    TxtDireccionDE.Text = gen.SetCampo(enttrM.Direccionenvios.ToString());
                    txtcoloniaDE.Text = gen.SetCampo(enttrM.Coloniaenvios.ToString());
                    TxtCpDE.Text = gen.SetCampo(enttrM.Cpenvios.ToString());
                    TxtMunicipioDE.Text = gen.SetCampo(enttrM.Ciudadenvios.ToString());
                    Enti = new EntEntidades();
                    Enti = EstadosRep.Find(c => c.IdEstado == gen.SetCampo(Convert.ToInt32(enttrM.Edoenvios)));
                    TxtEstadoDE.Text = Enti.D_estado;
                    idEstadoDe = Convert.ToInt32(Enti.IdEstado);
                    TxtTelefonoDE.Text = gen.SetCampo(enttrM.Telenvios.ToString());
                    TxtEmailContactoDE.Text = gen.SetCampo(enttrM.Emailenvios.ToString());
                    //if(gen.SetCampo(enttrM.TotalSucursal) > 0)
                    //    BtnSucursal.IsEnabled = true;
                    //else
                    //    BtnSucursal.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, this.Title, MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
            }
        }

        private void ConsultaConsecutivoCliente()
        {
            try
            {
                BrCliente cliente = new BrCliente();
                EntCliente entcve = new EntCliente();
                Respuesta<List<EntCliente>> resp = new Respuesta<List<EntCliente>>();
                resp = cliente.GetConsultaConsecutivoCliente(entcve);
                TxtCliente.Text = resp.Resultado[0].ClaveCliente.ToString();
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, this.Title, MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
            }
        }

        private void ConsultaEntidades()
        {
            try
            {
                BrCliente cliente = new BrCliente();
                EntEntidades ent = new EntEntidades();
                EstadosRep = cliente.GetConsultaEntidades(ent).Resultado;
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, this.Title, MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
            }
        }

        public void ConsultaTipoCliente()
        {
            try
            {
                if (CmbTipoCliente.ItemsSource == null)
                {
                    EntTipoCliente tipoCliente = new EntTipoCliente();
                    BrCliente cliente = new BrCliente();
                    Respuesta<List<EntTipoCliente>> respuesta = cliente.GetConsultaTipoCliente(tipoCliente);
                    if (respuesta.EsExitoso)
                    {
                        CmbTipoCliente.ItemsSource = respuesta.Resultado;
                    }
                }
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, this.Title, MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
            }
        }

        public void ConsultaEstatusCliente()
        {
            try
            {
                if (CmbEstatus.ItemsSource == null)
                {
                    EntEstatusCliente estatusCliente = new EntEstatusCliente();
                    BrCliente cliente = new BrCliente();
                    Respuesta<List<EntEstatusCliente>> respuesta = cliente.GetConsultaEstatusCliente(estatusCliente);
                    if (respuesta.EsExitoso)
                    {
                        CmbEstatus.ItemsSource = respuesta.Resultado;
                    }
                }
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, this.Title, MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
            }
        }

        public void ConsultaSectorCliente()
        {
            try
            {
                if (CmbSector.ItemsSource == null)
                {
                    EntSectorCliente sectorCliente = new EntSectorCliente();
                    BrCliente cliente = new BrCliente();
                    Respuesta<List<EntSectorCliente>> respuesta = cliente.GetConsultaSectorCliente(sectorCliente);
                    if (respuesta.EsExitoso)
                    {
                        CmbSector.ItemsSource = respuesta.Resultado;
                    }
                }
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, this.Title, MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
            }
        }

        public void ConsultaTipoDocumento()
        {
            try
            {
                if (CmbTipoDocumento.ItemsSource == null)
                {
                    EntTipoDocumento tipoDocumento = new EntTipoDocumento();
                    BrCliente cliente = new BrCliente();
                    Respuesta<List<EntTipoDocumento>> respuesta = cliente.GetConsultaTipoDocumento(tipoDocumento);
                    if (respuesta.EsExitoso)
                    {
                        CmbTipoDocumento.ItemsSource = respuesta.Resultado;
                    }
                }
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, this.Title, MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
            }
        }

        private bool ValidaDatosRFC()
        {            
            try
            {
                bool Valido = false;
                EntCliente entcve = new EntCliente();
                BrCliente cliente = new BrCliente();
                entcve.ClaveCliente = Convert.ToInt32(TxtCliente.Text);
                entcve.Rfccliente = TxtRfc.Text;
                Respuesta<List<EntCliente>> respuesta = cliente.GetValidaRFC(entcve);
                if (respuesta.EsExitoso)
                {
                    messageBox = new avisosis(respuesta.Resultado[0].Rfccliente, this.Title, MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
                    Valido=false;
                }
                else
                {
                    Valido= true;
                }
                return Valido;

            }
            catch (Exception ex)
            {
                return false;
                messageBox = new avisosis(ex, this.Title, MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
            }

        }

        private bool ValidarRFC()
        {
            try
            {
                bool Valido = false;
                if (TxtRfc.IsEnabled == true)
                {                   
                    string lsPatron = string.Empty;
                    if(TxtRfc.Text.Length ==12)
                        lsPatron = @"^([a-zA-ZñÑ&]{3})(\d{2})((01|03|05|07|08|10|12)(0[1-9]|[12]\d|3[01])|02(0[1-9]|[12]\d)|(04|06|09|11)(0[1-9]|[12]\d|30))([a-zA-Z,0-9][a-zA-Z,0-9][0-9A])$";
                    else
                        lsPatron = @"^([a-zA-ZñÑ&]{3,4})(\d{2})((01|03|05|07|08|10|12)(0[1-9]|[12]\d|3[01])|02(0[1-9]|[12]\d)|(04|06|09|11)(0[1-9]|[12]\d|30))([a-zA-Z,0-9][a-zA-Z,0-9][0-9A])$";

                    Regex loRE = new Regex(lsPatron);
                    if (loRE.IsMatch(TxtRfc.Text.Trim()) == false)
                    {
                        messageBox = new avisosis("El formato del RFC es inválido", this.Title, MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        messageBox.ShowDialog();                        
                    }
                    else
                    {
                        Valido = true;
                    }
                    
                }
                else
                {
                    Valido = true;
                }
                return Valido;
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, this.Title, MessageBoxButton.OK, MessageBoxImage.Error);
                messageBox.ShowDialog();

                return false;
            }
        }

        private void ConsultaUsuarioAreas()
        {
            try
            {
                EntUsuario entUsu = new EntUsuario();
                BrConfiguracion br = new BrConfiguracion();
                entUsu.IdArea = 7;
                Respuesta<List<EntUsuario>> resp = br.GetConsultaUsuarios(entUsu);
                CmbEjecutivoVentas.ItemsSource = resp.Resultado;
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, this.Title, MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
            }
        }

        //Limpia Texbox
        static public void LimpiaTextBox(Visual myMainWindow)
        {
            int childrenCount = VisualTreeHelper.GetChildrenCount(myMainWindow);
            for (int i = 0; i < childrenCount; i++)
            {
                var visualChild = (Visual)VisualTreeHelper.GetChild(myMainWindow, i);
                if (visualChild is TextBox)
                {
                    TextBox tb = (TextBox)visualChild;                    
                    tb.Clear();
                }
                LimpiaTextBox(visualChild);
            }
        }

        #endregion

    }
}

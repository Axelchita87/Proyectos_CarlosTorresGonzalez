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
using System.Windows.Shapes;

using ADMIN2.Controls;
using ADMIN2.Entity;
using ADMIN2.BR;
using ADMIN2.DAL;
using System.Text.RegularExpressions;

namespace ADMIN2.Clientes
{
    /// <summary>
    /// Lógica de interacción para FrmSucursal.xaml
    /// </summary>
    public partial class FrmSucursal : BaseWindow
    {
        public FrmSucursal()
        {
            InitializeComponent();
            btnAceptar.IsEnabled = false;
            btnCancelar.IsEnabled = false;
            IdPermiso = App.IdPermiso.ToString();
            TxtFechaRegistro.IsEnabled = false;
            TxtFechaModificacion.IsEnabled = false;

            if (App.IdPermiso.ToString() == "1")
            {
                //inhabilitaControles(GridBotones);
                inhabilitaControles(GridBotones2);
            }
        }

        public FrmSucursal(frmCatologoGenerico frmCatologoGenerico)
        {
            // TODO: Complete member initialization
            this.frmCatologoGenerico = frmCatologoGenerico;
            InitializeComponent();
            btnAceptar.IsEnabled = false;
            btnCancelar.IsEnabled = false;
            IdPermiso = App.IdPermiso.ToString();
            TxtFechaRegistro.IsEnabled = false;
            TxtFechaModificacion.IsEnabled = false;

            if (App.IdPermiso.ToString() == "1")
            {
                //inhabilitaControles(GridBotones);
                inhabilitaControles(GridBotones2);
                
            }
        }

        #region Declaraciones

        avisosis messageBox = new avisosis();
        public string ActIns = string.Empty;
        public int bandera = 0;
        private frmCatologoGenerico frmCatologoGenerico;
        private List<EntEntidades> EstadosRep;
        private int idEstado = 0;
        private int idEstadoDe = 0;
        private int noSucursal = 0;
        public int opcGuarda = 0;

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
                }
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

        public void ConsultaDatosCliente(EntCliente entCve, EntSucursal entSuc)
        {
            try
            {
                Genericas gen = new Genericas();
                DateTime fecha = Convert.ToDateTime(DateTime.Today);
                string fechaHoy = fecha.ToString("yyyy-MM-dd");
                if (ActIns == Comunes.AGREGA)
                {
                    TxtFechaRegistro.Text = fechaHoy;
                    ConsultaEntidades();
                    ConsultaTipoCliente();
                    ConsultaEstatusCliente();
                    ConsultaSectorCliente();
                    TxtCliente.Text = gen.SetCampo(entCve.ClaveCliente.ToString());
                    TxtCliente.IsEnabled = false;
                    CmbTipoCliente.Text = gen.SetCampo(entCve.TipoVIP.ToString());
                    CmbEstatus.SelectedValue = gen.SetCampo(entCve.Statuscliente.ToString());
                    TxtSucursal.Text = gen.SetCampo(entCve.Nombrecliente.ToString());
                    TxtRfc.Text = gen.SetCampo(entCve.Rfccliente.ToString());
                    TxtFacturaNom.Text = gen.SetCampo(entCve.Facturacioncliente.ToString());
                    CmbSector.SelectedValue = gen.SetCampo(entCve.Sectorcliente.ToString());
                    TxtDireccion.Text = gen.SetCampo(entCve.Direccioncliente.ToString());
                    txtcolonia.Text = gen.SetCampo(entCve.Coloniacliente.ToString());
                    TxtCp.Text = gen.SetCampo(entCve.Codigopostalcliente.ToString());
                    TxtMunicipio.Text = gen.SetCampo(entCve.Ciudadcliente.ToString());
                    EntEntidades Enti = new EntEntidades();
                    Enti = EstadosRep.Find(c => c.IdEstado == gen.SetCampo(Convert.ToInt32(entCve.Estadocliente)));
                    TxtEstado.Text = Enti.D_estado;
                    idEstado = Convert.ToInt32(Enti.IdEstado);
                    TxtTelefono1.Text = gen.SetCampo(entCve.Telefono1cliente.ToString());
                    TxtTelefono2.Text = gen.SetCampo(entCve.Telefono2cliente.ToString());                    
                    TxtEmail.Text = gen.SetCampo(entCve.Emailcliente.ToString());
                    TxtEmailCobranza.Text = gen.SetCampo(entCve.EmailSecEnvios.ToString());
                    TxtAtenciónCobranza.Text = gen.SetCampo(entCve.Atencionpersonal1cliente.ToString());
                    TxtEmpresaDE.Text = gen.SetCampo(entCve.Nombreenvios.ToString());
                    TxtAtencionEnv.Text = gen.SetCampo(entCve.Usuarioenvios.ToString());
                    TxtDireccionDE.Text = gen.SetCampo(entCve.Direccionenvios.ToString());
                    txtcoloniaDE.Text = gen.SetCampo(entCve.Coloniaenvios.ToString());
                    TxtCpDE.Text = gen.SetCampo(entCve.Cpenvios.ToString());
                    TxtMunicipioDE.Text = gen.SetCampo(entCve.Ciudadenvios.ToString());
                    Enti = new EntEntidades();
                    Enti = EstadosRep.Find(c => c.IdEstado == gen.SetCampo(Convert.ToInt32(entCve.Edoenvios)));
                    TxtEstadoDE.Text = Enti.D_estado;
                    idEstadoDe = Convert.ToInt32(Enti.IdEstado);
                    TxtTelefonoDE.Text = gen.SetCampo(entCve.Telenvios.ToString());
                    TxtEmailContactoDE.Text = gen.SetCampo(entCve.Emailenvios.ToString());
                }
                else
                {
                    //consulta datos de la sucursal
                    noSucursal = gen.SetCampo(entSuc.Nsucursal);
                    TxtFechaRegistro.Text = gen.SetCampo(entSuc.Fecha_apertura.ToString());
                    TxtFechaModificacion.Text = gen.SetCampo(entSuc.FechaModifico1.ToString());
                    ConsultaEntidades();
                    ConsultaTipoCliente();
                    ConsultaEstatusCliente();
                    ConsultaSectorCliente();
                    TxtCliente.Text = gen.SetCampo(entSuc.Clave_cliente.ToString());
                    TxtCliente.IsEnabled = false;
                    CmbTipoCliente.Text = gen.SetCampo(entCve.TipoVIP.ToString());
                    CmbEstatus.SelectedValue = gen.SetCampo(entSuc.Status_sucursal.ToString());
                    TxtSucursal.Text = gen.SetCampo(entSuc.Sucursal.ToString());
                    TxtRfc.Text = gen.SetCampo(entSuc.Rfc_sucursal.ToString());
                    TxtFacturaNom.Text = gen.SetCampo(entSuc.Factura_sucursal.ToString());
                    CmbSector.SelectedValue = gen.SetCampo(entSuc.Sector_cliente.ToString());
                    TxtDireccion.Text = gen.SetCampo(entSuc.Direccion_sucursal.ToString());
                    txtcolonia.Text = gen.SetCampo(entSuc.Colonia_sucursal.ToString());
                    TxtCp.Text = gen.SetCampo(entSuc.Codigo_postal_sucursal.ToString());
                    TxtMunicipio.Text = gen.SetCampo(entSuc.Ciudad_sucursal.ToString());
                    EntEntidades Enti = new EntEntidades();
                    Enti = EstadosRep.Find(c => c.IdEstado == gen.SetCampo(Convert.ToInt32(entSuc.Estado_sucursal)));
                    TxtEstado.Text = Enti.D_estado;
                    idEstado = Convert.ToInt32(Enti.IdEstado);
                    TxtTelefono1.Text = gen.SetCampo(entSuc.Telefono1_sucursal.ToString());
                    TxtTelefono2.Text = gen.SetCampo(entSuc.Telefono2_sucursal.ToString());                    
                    TxtAtencionEnvios.Text = gen.SetCampo(entSuc.Atencion_personal2_sucursal.ToString());
                    TxtEmail.Text = gen.SetCampo(entSuc.E_mail.ToString());
                    TxtAtenciónCobranza.Text = gen.SetCampo(entSuc.Atencion_personal1_sucursal.ToString());
                    TxtEmailCobranza.Text = gen.SetCampo(entSuc.EmailCobranza1.ToString());                    
                    TxtObservaciones.Text = gen.SetCampo(entSuc.Observaciones.ToString());
                    TxtEmpresaDE.Text = gen.SetCampo(entSuc.Nombre_envios_sucursal.ToString());
                    TxtAtencionEnv.Text = gen.SetCampo(entSuc.Usuario_envios_sucursal.ToString());
                    TxtDireccionDE.Text = gen.SetCampo(entSuc.Direccion_envios_sucursal.ToString());
                    txtcoloniaDE.Text = gen.SetCampo(entSuc.Colonia_envios_sucursal.ToString());
                    TxtCpDE.Text = gen.SetCampo(entSuc.Cp_envios_sucursal.ToString());
                    TxtMunicipioDE.Text = gen.SetCampo(entSuc.Ciudad_envios_sucursal.ToString());
                    Enti = new EntEntidades();
                    Enti = EstadosRep.Find(c => c.IdEstado == gen.SetCampo(Convert.ToInt32(entSuc.Edo_envios_sucursal)));
                    TxtEstadoDE.Text = Enti.D_estado;
                    idEstadoDe = Convert.ToInt32(Enti.IdEstado);
                    TxtTelefonoDE.Text = gen.SetCampo(entSuc.Tel_envios_sucursal.ToString());
                    TxtEmailContactoDE.Text = gen.SetCampo(entSuc.Email_envios_sucursal.ToString());
                }
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, this.Title, MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
            }

        }

        //guarda y actualiza
        public void Guarda()
        {
            EntSucursal entSuc = new EntSucursal();
            BrCliente cliente = new BrCliente();
            try
            {
                Genericas gen = new Genericas();
                totRequeridos = 4;
                contabilizaYValidaRequerido(TxtSucursal);
                contabilizaYValidaRequerido(CmbEstatus);
                contabilizaYValidaRequerido(TxtRfc);
                contabilizaYValidaRequerido(CmbSector);
                if (totRequeridos > 0)
                {
                    messageBox = new avisosis(totRequeridos == 1 ? (string.Format("¡El campo {0} es obligatorio!", ControlInvalido)) : "Los campos son obligatorios", this.Title, MessageBoxButton.OK, MessageBoxImage.Warning);
                    messageBox.ShowDialog();
                    return;
                }

                TxtFechaRegistro.Text = gen.SetCampo(entSuc.Fecha_apertura.ToString());
                TxtFechaModificacion.Text = gen.SetCampo(entSuc.FechaModifico1.ToString());
                //////////////
                entSuc.Status_sucursal = gen.SetCampo(CmbEstatus.SelectedValue.ToString());                

                if (ActIns == Comunes.CAMBIA)
                {
                    entSuc.Nsucursal = noSucursal;
                }
                entSuc.Clave_cliente = gen.SetCampo(Convert.ToInt32(TxtCliente.Text));
                entSuc.Sucursal = gen.SetCampo(TxtSucursal.Text);
                entSuc.Rfc_sucursal = gen.SetCampo(TxtRfc.Text);
                entSuc.Sector_cliente = gen.SetCampo(CmbSector.SelectedValue.ToString());
                entSuc.Factura_sucursal = gen.SetCampo(TxtFacturaNom.Text);
                entSuc.Direccion_sucursal = gen.SetCampo(TxtDireccion.Text);
                entSuc.Colonia_sucursal = gen.SetCampo(txtcolonia.Text);
                entSuc.Codigo_postal_sucursal = gen.SetCampo(Convert.ToInt32(TxtCp.Text));
                entSuc.Ciudad_sucursal = gen.SetCampo(TxtMunicipio.Text);
                entSuc.Estado_sucursal=gen.SetCampo(idEstado.ToString());
                entSuc.Telefono1_sucursal = gen.SetCampo(TxtTelefono1.Text);
                entSuc.Telefono2_sucursal = gen.SetCampo(TxtTelefono2.Text);
                entSuc.Atencion_personal2_sucursal = gen.SetCampo(TxtAtencionEnvios.Text);
                entSuc.Nombre_envios_sucursal = gen.SetCampo(TxtEmpresaDE.Text);
                entSuc.Usuario_envios_sucursal = gen.SetCampo(TxtAtencionEnv.Text);
                entSuc.Direccion_envios_sucursal = gen.SetCampo(TxtDireccionDE.Text);
                entSuc.Colonia_envios_sucursal = gen.SetCampo(txtcoloniaDE.Text);
                entSuc.Cp_envios_sucursal = gen.SetCampo(TxtCpDE.Text);
                entSuc.Ciudad_envios_sucursal = gen.SetCampo(TxtMunicipioDE.Text);
                entSuc.Edo_envios_sucursal = idEstadoDe.ToString();
                entSuc.Tel_envios_sucursal = gen.SetCampo(TxtTelefonoDE.Text);
                entSuc.Email_envios_sucursal = gen.SetCampo(TxtEmailContactoDE.Text);
                entSuc.Atencion_personal1_sucursal = gen.SetCampo(TxtAtenciónCobranza.Text);
                entSuc.Observaciones = gen.SetCampo(TxtObservaciones.Text);
                entSuc.E_mail = gen.SetCampo(TxtEmail.Text);
                entSuc.EmailCobranza1 = gen.SetCampo(TxtEmailCobranza.Text);
                if (ActIns == Comunes.AGREGA)
                {
                     entSuc.IdUsuarioRegistro1 = App.IdUsuario;
                }
                else
                {
                    entSuc.IdUsuarioModifico1 = App.IdUsuario;
                }

                if (ValidarRFC() == false)
                    return;

                if (ValidaDatosRFC() == false)
                    return;

                Respuesta<int> res = cliente.InsUpdSucursal(entSuc, ActIns, "A");
                if (bandera == 1)
                {
                    if (res.EsExitoso)
                    {
                        // opcion valida cuando se agrega una sucursal desde el catálogo
                        if (opcGuarda == 0)
                        {
                            //Actualizacion del Grid Generico
                            frmCatologoGenerico.AcutualizaGrid<EntSucursal>(entSuc);                            
                        }
                        Editando = false;
                        messageBox = new avisosis("Se ha " + (ActIns == Comunes.AGREGA ? " agregado " : ActIns == Comunes.CAMBIA ? " actualizado " : " eliminado ") + " correctamente la Sucursal.", this.Title, MessageBoxButton.OK, MessageBoxImage.None); messageBox.ShowDialog();
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

        public void Consulta(EntUsuario enttrM)
        {
            try
            {
                if (ActIns == Comunes.CAMBIA)
                {
                    BrConfiguracion brped = new BrConfiguracion();
                    EntUsuario EntMrM = new EntUsuario();
                    EntMrM.IdArea = enttrM.IdArea;
                    Respuesta<List<EntUsuario>> result = brped.GetConsultaUsuarios(EntMrM);
                    if (result.TotalRegistros > 0)
                    {
                        // DpFecha.Text = result.Resultado[0].Avifeci.ToString("yyyy/MM/dd");
                    }
                    //TxtAviso.IsEnabled = false;
                }
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

        private bool ValidaDatosRFC()
        {
            try
            {
                bool Valido = false;
                EntSucursal entcve = new EntSucursal();
                BrCliente cliente = new BrCliente();
                entcve.Clave_cliente = Convert.ToInt32(TxtCliente.Text);
                entcve.Rfc_sucursal = TxtRfc.Text;
                Respuesta<List<EntSucursal>> respuesta = cliente.GetValidaSucursalRFC(entcve);
                if (respuesta.EsExitoso)
                {
                    messageBox = new avisosis(respuesta.Resultado[0].Rfc_sucursal, this.Title, MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
                    Valido = false;
                }
                else
                {
                    Valido = true;
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
                    if (TxtRfc.Text.Length == 12)
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

using ADMIN2.Controls;
using ADMIN2.DAL;
using ADMIN2.Entity;
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
using System.Windows.Threading;

namespace AdminEvents
{
    /// <summary>
    /// Lógica de interacción para Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        DispatcherTimer dispa = new DispatcherTimer();
        int bandera = 0;
        string banGene = string.Empty;
        avisosis messageBox = new avisosis();
        static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();

        public Main()
        {
            InitializeComponent();
        }

        private void btnMaxiWin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (bandera == 0)
                {
                    WindowState = WindowState.Maximized;
                    btnMaxiWin.ToolTip = "Restaurar a tamaño normal";
                    bandera = 1;
                }
                else
                {
                    WindowState = WindowState.Normal;
                    btnMaxiWin.ToolTip = "Maximizar";
                    bandera = 0;
                }
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, "ADMIN 2.0", MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
            }
        }

        private void btnMinWin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WindowState = WindowState.Minimized;
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, "ADMIN 2.0", MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
            }
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, "ADMIN 2.0", MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
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
                messageBox = new avisosis(ex, "ADMIN 2.0", MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                App.Current.Shutdown();
                //if (CerrarSesion == 1)
                //{
                //    string ruta = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\ADMIN 2.0.exe";
                //    System.Diagnostics.Process.Start(ruta);
                //    System.IO.File.Delete(RutaArchivo);
                //}
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, "ADMIN 2.0", MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
            }
        }

        private void BtnMenuClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Button Boton = (Button)sender;
                //object oform;
                string ValidaNomFormulario = string.Empty;
                string NameSpace = string.Empty;
                int Acceso = 0;
       /*         switch (Boton.Name)    ESTO SE COMENTA JULIAN!!!!
                {
                    case "BtnUsuarios":
                        ValidaNomFormulario = "FrmClientes";
                        NameSpace = "ADMIN2.frmCatologoGenerico";
                        if (App.Admin == true)
                        //if (validarUsuario("FrmClientes"))
                        {
                            Acceso = 1;
                            CatalogConfigElement cat = SITAConfig.GetConfigCatalogo(Genericas.CatUsuarios);
                            frmCatologoGenerico frmCatalogo = new frmCatologoGenerico();
                            frmCatalogo.BindGrid<EntUsuario>(cat, string.Empty, 0);
                            frmCatalogo.Name = "FrmUsuario";
                            frmCatalogo.Title = "Usuarios";
                            frmCatalogo.txtTitulo.Text = "Usuarios";
                            frmCatalogo.btnBaja.Content = "Desactivar";
                            txtDireccion.Text = string.Empty;
                            txtDireccion.Text = "Configuración/" + BtnUsuarios.Content.ToString();
                            frmCatalogo.ShowDialog();
                        }
                        break;

                    case "BtnPerfiles":
                        if (App.Admin == true)
                        {
                            Acceso = 1;
                            CatalogConfigElement catP = SITAConfig.GetConfigCatalogo(Genericas.CatPerfiles);
                            frmCatologoGenerico frmCatalogoP = new frmCatologoGenerico();
                            frmCatalogoP.BindGrid<EntPerfil>(catP, string.Empty, 0);
                            frmCatalogoP.Name = "FrmPerfil";
                            frmCatalogoP.Title = "Perfiles";
                            frmCatalogoP.txtTitulo.Text = "Perfil";
                            //txtDireccion.Text = txtDireccion.Text + BtnPerfiles.Content.ToString();
                            frmCatalogoP.ShowDialog();
                        }
                        break;
                    case "BtnBitacoraCambios":
                        if (App.Admin == true)
                        {
                            Acceso = 1;
                            CatalogConfigElement catP = SITAConfig.GetConfigCatalogo(Genericas.CatBitacoraCambios);
                            frmCatologoGenerico frmCatalogoP = new frmCatologoGenerico();
                            frmCatalogoP.BindGrid<EntBitacora>(catP, string.Empty, 3);
                            frmCatalogoP.Name = "FrmBitacoraCambios";
                            frmCatalogoP.Title = "Bitácora de Cambios";
                            frmCatalogoP.txtTitulo.Text = "Bitácora de Cambios";
                            frmCatalogoP.btnCambio.Visibility = Visibility.Hidden;
                            frmCatalogoP.btnNuevo.Visibility = Visibility.Hidden;
                            frmCatalogoP.btnBaja.Content = "Exportar Excel";
                            txtDireccion.Text = string.Empty;
                            txtDireccion.Text = "Administración /" + BtnBitacoraCambios.Content.ToString();
                            frmCatalogoP.ShowDialog();
                        }
                        break;

                    case "BtnAccesoClientes":
                        ValidaNomFormulario = "FrmCliente";
                        NameSpace = "ADMIN2.frmCatologoGenerico";
                        if (validarUsuario("FrmCliente"))
                        {
                            Acceso = 1;
                            CatalogConfigElement catP = SITAConfig.GetConfigCatalogo(Genericas.CatCliente);
                            frmCatologoGenerico frmCatalogoP = new frmCatologoGenerico();
                            frmCatalogoP.BindGrid<EntCliente>(catP, string.Empty, 1);
                            frmCatalogoP.Name = "FrmCliente";
                            frmCatalogoP.Title = "Catálogo de Clientes";
                            frmCatalogoP.txtTitulo.Text = "Catálogo de Clientes";
                            frmCatalogoP.btnBaja.Visibility = Visibility.Collapsed;
                            frmCatalogoP.btnfiltroPed.Visibility = Visibility.Visible;
                            frmCatalogoP.btnfiltroPed.Content = "Ver Sucursales";
                            frmCatalogoP.btnfiltroPed.IsEnabled = false;
                            if (txtDireccion.Text != "Catálogo de Clientes")
                            {
                                txtDireccion.Text = string.Empty;
                                txtDireccion.Text = "Catálogo de Clientes";
                            }

                            frmCatalogoP.ShowDialog();
                        }
                        break;

                    case "BtnClientes":
                        ValidaNomFormulario = "FrmCliente";
                        NameSpace = "ADMIN2.frmCatologoGenerico";
                        if (validarUsuario("FrmCliente"))
                        {
                            Acceso = 1;
                            CatalogConfigElement catP = SITAConfig.GetConfigCatalogo(Genericas.CatCliente);
                            frmCatologoGenerico frmCatalogoP = new frmCatologoGenerico();
                            frmCatalogoP.BindGrid<EntCliente>(catP, string.Empty, 1);
                            frmCatalogoP.Name = "FrmCliente";
                            frmCatalogoP.Title = "Catálogo de Clientes";
                            frmCatalogoP.txtTitulo.Text = "Catálogo de Clientes";
                            frmCatalogoP.btnBaja.Visibility = Visibility.Collapsed;
                            frmCatalogoP.btnfiltroPed.Visibility = Visibility.Visible;
                            frmCatalogoP.btnfiltroPed.Content = "Ver Sucursales";
                            frmCatalogoP.btnfiltroPed.IsEnabled = false;
                            if (txtDireccion.Text != txtDireccion.Text + BtnClientes.Content.ToString())
                            {
                                txtDireccion.Text = string.Empty;
                                txtDireccion.Text = "Clientes/" + BtnClientes.Content.ToString();
                            }
                            frmCatalogoP.ShowDialog();
                        }
                        break;

                    //    case "BtnOpciones":
                    //        ValidaNomFormulario = "frmOpcionesCFDI";
                    //        NameSpace = "ADMIN 2.0.CFDI.frmOpcionesCFDI";
                    //        if (validarUsuario(ValidaNomFormulario))
                    //        {
                    //            Acceso = 1;
                    //            oform = System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(NameSpace);
                    //            ((BaseWindow)oform).ShowDialog();
                    //        }
                    //        break;

                    //    case "BtmImDirecta":
                    //        ValidaNomFormulario = "frmImpresionDirecta";
                    //        NameSpace = "ADMIN 2.0.CFDI.frmImpresionDirecta";
                    //        if (validarUsuario(ValidaNomFormulario))
                    //        {
                    //            Acceso = 1;
                    //oform = System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(NameSpace);
                    //((BaseWindow)oform).ShowDialog();
                    //        }
                    //        break;
                }  */ 
                if (Acceso.Equals(0))
                {
                    messageBox = new avisosis("Acceso restringido por el administrador del sistema, favor de contactar a su administrador", "ADMIN 2.0", MessageBoxButton.OK, MessageBoxImage.Warning); messageBox.ShowDialog();
                }
                menit.IsSubmenuOpen = false;
                //ExpCtaGatos.IsExpanded = false;
                //ExpAgendas.IsExpanded = false;
                //ExpHerramientas.IsExpanded = false;
                //ExpAyuda.IsExpanded = false;
            }
            catch (Exception ex)
            {

                messageBox = new avisosis(ex, "ADMIN 2.0",  MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
            }
        }

        private void ExpandedMenu(object sender, RoutedEventArgs e)
        {
            try
            {
                txtDireccion.Text = string.Empty;
                Expander Expander = (Expander)sender;
          /*      switch (Expander.Name)    COMENTO JULIAN !!!!
                {
                    case "ExpClientes":
                        ExpClientes.IsExpanded = true;
                        ExpProduccion.IsExpanded = false;
                        ExpAdministracion.IsExpanded = false;
                        ExpConsultoria.IsExpanded = false;
                        ExpSoporteTecnico.IsExpanded = false;
                        ExpReportes.IsExpanded = false;
                        ExpConfiguracion.IsExpanded = false;
                        ExpAyuda.IsExpanded = false;
                        txtDireccion.Text = "Clientes/";
                        break;
                    case "ExpProduccion":
                        ExpClientes.IsExpanded = false;
                        ExpProduccion.IsExpanded = true;
                        ExpAdministracion.IsExpanded = false;
                        ExpConsultoria.IsExpanded = false;
                        ExpSoporteTecnico.IsExpanded = false;
                        ExpReportes.IsExpanded = false;
                        ExpConfiguracion.IsExpanded = false;
                        ExpAyuda.IsExpanded = false;
                        txtDireccion.Text = "Producción/";
                        break;
                    case "ExpAdministracion":
                        ExpClientes.IsExpanded = false;
                        ExpProduccion.IsExpanded = false;
                        ExpAdministracion.IsExpanded = true;
                        ExpConsultoria.IsExpanded = false;
                        ExpSoporteTecnico.IsExpanded = false;
                        ExpReportes.IsExpanded = false;
                        ExpConfiguracion.IsExpanded = false;
                        ExpAyuda.IsExpanded = false;
                        txtDireccion.Text = "Administración/";
                        break;
                    case "ExpConsultoria":
                        ExpClientes.IsExpanded = false;
                        ExpProduccion.IsExpanded = false;
                        ExpAdministracion.IsExpanded = false;
                        ExpConsultoria.IsExpanded = true;
                        ExpSoporteTecnico.IsExpanded = false;
                        ExpReportes.IsExpanded = false;
                        ExpConfiguracion.IsExpanded = false;
                        ExpAyuda.IsExpanded = false;
                        txtDireccion.Text = "Consultoría/";
                        break;
                    case "ExpSoporteTecnico":
                        ExpClientes.IsExpanded = false;
                        ExpProduccion.IsExpanded = false;
                        ExpAdministracion.IsExpanded = false;
                        ExpConsultoria.IsExpanded = false;
                        ExpSoporteTecnico.IsExpanded = true;
                        ExpReportes.IsExpanded = false;
                        ExpConfiguracion.IsExpanded = false;
                        ExpAyuda.IsExpanded = false;
                        txtDireccion.Text = "Soporte Técnico/";
                        break;
                    case "ExpReportes":
                        ExpClientes.IsExpanded = false;
                        ExpProduccion.IsExpanded = false;
                        ExpAdministracion.IsExpanded = false;
                        ExpConsultoria.IsExpanded = false;
                        ExpSoporteTecnico.IsExpanded = false;
                        ExpReportes.IsExpanded = true;
                        ExpConfiguracion.IsExpanded = false;
                        ExpAyuda.IsExpanded = false;
                        txtDireccion.Text = "Reportes/";
                        break;
                    case "ExpConfiguracion":
                        ExpClientes.IsExpanded = false;
                        ExpProduccion.IsExpanded = false;
                        ExpAdministracion.IsExpanded = false;
                        ExpConsultoria.IsExpanded = false;
                        ExpSoporteTecnico.IsExpanded = false;
                        ExpReportes.IsExpanded = false;
                        ExpConfiguracion.IsExpanded = true;
                        ExpAyuda.IsExpanded = false;
                        txtDireccion.Text = "Configuración/";
                        break;
                    case "ExpAyuda":
                        ExpClientes.IsExpanded = false;
                        ExpProduccion.IsExpanded = false;
                        ExpAdministracion.IsExpanded = false;
                        ExpConsultoria.IsExpanded = false;
                        ExpSoporteTecnico.IsExpanded = false;
                        ExpReportes.IsExpanded = false;
                        ExpConfiguracion.IsExpanded = false;
                        ExpAyuda.IsExpanded = true;
                        txtDireccion.Text = "Manual de Usuario/";
                        break;
                }*/

            }    
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, "ADMIN 2.0", MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
            }
        }


        //internal void LlenaAccesosPerfil(Ent_User usuario)
        //{
        //    try
        //    {
        //        BRCatalogo cat = new BRCatalogo();
        //        Ent_Tipo_Cambio enttipcam = new Ent_Tipo_Cambio();
        //        usuarioSesion = usuario;
        //        var verADMIN 2.0 = ConfigurationManager.AppSettings["versADMIN 2.0"];

        //        enttipcam.Fecha = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        //        Respuesta<List<Ent_Tipo_Cambio>> restipoc = cat.GetTiposCambio(enttipcam);
        //        UsuarioLogeo = usuarioSesion.ST_C_US_USUARIO;
        //        PerfilLogeo = usuarioSesion.ST_C_US_PERFIL;
        //        perfil = usuarioSesion;
        //        if (restipoc.Resultado.Count > 0)
        //            lblinformacion.Text = "Usuario: " + usuarioSesion.ST_C_US_USUARIO + "   Fecha: " + DateTime.Now.ToShortDateString() + "   Tipo Cambio: " + restipoc.Resultado[0].Tip_cam + "   Versión ADMIN 2.0: " + verADMIN 2.0 + "   Patente: " + Utils.ppalcong.Patent + "   Aduana: " + Utils.ppalcong.Aduana + "     Sección: " + Utils.ppalcong.Seccion + "   Serie: " + Utils.ppalcong.Serie;
        //        else
        //            lblinformacion.Text = "Usuario: " + usuarioSesion.ST_C_US_USUARIO + "   Fecha: " + DateTime.Now.ToShortDateString() + "   Versión ADMIN 2.0: " + verADMIN 2.0 + "   Patente: " + Utils.ppalcong.Patent + "   Aduana: " + Utils.ppalcong.Aduana + "     Sección: " + Utils.ppalcong.Seccion + "   Serie: " + Utils.ppalcong.Serie;

        //    }
        //    catch (Exception ex)
        //    {
        //        messageBox = new avisosis(ex, "ADMIN 2.0", MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
        //    }
        //}

        //private void btnPedConsol_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        if (validarUsuario("frmPedPpal"))
        //        {
        //            txtDireccion.Text = "Pedimento/Pedimento/Pedimento Consolidado";

        //            Catalogos.frmCatologoGenerico frmCatalogo = new Catalogos.frmCatologoGenerico();
        //            CatalogConfigElement cat = ADMIN 2.0Config.GetConfigCatalogo(Comunes.CatPedimentosConsolidados);
        //            frmCatalogo.BindGrid<Ent_Pedimento>(cat, string.Empty, 1);
        //            frmCatalogo.rdbExport.Visibility = Visibility.Visible;
        //            frmCatalogo.rdbImport.Visibility = Visibility.Hidden;
        //            frmCatalogo.rdbImport.IsChecked = true;
        //            frmCatalogo.btnBaja.Visibility = Visibility.Collapsed;
        //            frmCatalogo.btnCambio.Visibility = Visibility.Visible;
        //            frmCatalogo.btnNuevo.Visibility = Visibility.Collapsed;
        //            frmCatalogo.banderParte = 0;
        //            frmCatalogo.Title = "Pedimento Consolidado";
        //            frmCatalogo.txtTitulo.Text = "Pedimento Consolidado";
        //            frmCatalogo.gbOpc.Header = string.Empty;
        //            SubMenuPed.IsSubmenuOpen = false;
        //            frmCatalogo.Show();
        //        }
        //        else
        //        {
        //            messageBox = new avisosis("Acceso restringido por el administrador del sistema, Favor de contactar a su administrador", "ADMIN 2.0", MessageBoxButton.OK, MessageBoxImage.Warning); messageBox.ShowDialog();
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        messageBox = new avisosis(ex, "ADMIN 2.0", MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
        //    }
        //}

        #region Metodos

        public bool validarUsuario(string formulario)
        {
            try
            {
                //actualiza lista acceso
                //BrConfiguracion brusu = new BrConfiguracion();
                //EntPerfil entp = new EntPerfil();
                //entp.IdSistema = App.IdSistema;
                //entp.IdUsuarioRegistro = App.IdUsuario;
                //Respuesta<List<EntPerfil>> resp = brusu.GetConsultaPerfileAccesoUsuario(entp);
                //if (resp.Resultado.Count > 0)
                //{
                //    App.ListaAccesoPantalla = resp.Resultado;
                //}

                if (App.ListaAccesoPantalla.Where(c => c.NombrePantalla == formulario).Count() > 0)
                {
                    //EntPerfil entP = new EntPerfil();
                    foreach (EntPerfil entP in App.ListaAccesoPantalla)
                    {
                        if (App.ListaAccesoPantalla.Where(c => c.NombrePantalla == formulario).Count() > 0)
                        {
                            App.IdPermiso = entP.IdPermiso;
                            break;
                        }
                    }
                    //usuarioSesion.PantallaEnEjecucion = usuarioSesion.LstAccxPerf.Where(c => c.ST_C_PA_FORMULARIO == formulario).FirstOrDefault();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                messageBox = new avisosis("No se ha cargado la información del usuario correctamente. . .", "ADMIN 2.0", MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
                return false;
            }
        }

        #endregion

        private void menit_Click(object sender, RoutedEventArgs e)
        {
            txtDireccion.Text = string.Empty;
        }

    }
}
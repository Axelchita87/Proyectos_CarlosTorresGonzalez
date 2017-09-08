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

namespace ADMIN2.Configuración
{
    /// <summary>
    /// Lógica de interacción para FrmUsuarios.xaml
    /// </summary>
    public partial class FrmUsuarios : BaseWindow
    {
        private frmCatologoGenerico frmCatologoGenerico;

        public FrmUsuarios()
        {
            InitializeComponent();
            btnAceptar.IsEnabled = false;
            btnCancelar.IsEnabled = false;
        }

        public FrmUsuarios(frmCatologoGenerico frmCatologoGenerico)
        {
            // TODO: Complete member initialization
            this.frmCatologoGenerico = frmCatologoGenerico;
            InitializeComponent();
            //btnAceptar.IsEnabled = false;
            //btnCancelar.IsEnabled = false;
            ConsultaPerfiles();
            ConsultaAreas();            
            if (App.IdPermiso.ToString() == "1")
            {
                inhabilitaControles(Grid1);
                inhabilitaControles(GridBotones);
            }
        }

        #region Declaraciones

        avisosis messageBox = new avisosis();
        EntPerfil perf = new EntPerfil();
        EntArea area = new EntArea();
        EntUsuario EntUser = new EntUsuario();
        EntPerfil entperfil = new EntPerfil();
        public string ActIns = string.Empty;
        public int bandera = 0;
        public int IdPerfil = 0;
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

        private void txtContrasena_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!ValidaExistPwd() && txtContrasena.Password != string.Empty)
            {
                btnAceptar.IsEnabled = true;
                btnCancelar.IsEnabled = true;
            }
            else
            {
                btnAceptar.IsEnabled = false;
                btnCancelar.IsEnabled = false;
            }
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bandera = 1;
                if (IdPerfil == 0) {
                    messageBox = new avisosis("Es necesario agregar los permisos del usuario.", this.Title, MessageBoxButton.OK, MessageBoxImage.Warning);
                    messageBox.ShowDialog();
                    return;
                }
                if (!ValidaExistPwd() && txtContrasena.Password != string.Empty)
                {
                    int LongMinPwd = 1;
                    if (txtContrasena.Password.Length >= LongMinPwd)
                    {
                        Guarda();
                    }
                    else
                    {
                        messageBox = new avisosis(String.Format("La contraseña debe de tener por lo menos {0} caracteres", LongMinPwd), this.Title, MessageBoxButton.OK, MessageBoxImage.Warning);
                        messageBox.ShowDialog();
                    }
                    
                }
                else
                {
                    messageBox = new avisosis("¡Las contraseñas no coinciden!", this.Title, MessageBoxButton.OK, MessageBoxImage.Exclamation); messageBox.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, this.Title, MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
            }
        }

        private void cmbPerfil_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (CmbPerfil.SelectedValue != null)
                {
                    perf = CmbPerfil.SelectedItem as EntPerfil;
                    ComboBox_SelectionChanged(sender, e);
                }
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, "Usuario", MessageBoxButton.OK, MessageBoxImage.Error);
                messageBox.ShowDialog();
            }
        }

        private void cmbAreaSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (CmbArea.SelectedValue != null)
                {
                    area = CmbArea.SelectedItem as EntArea;
                    ComboBox_SelectionChanged(sender, e);
                }
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex,this.Title, MessageBoxButton.OK, MessageBoxImage.Error);
                messageBox.ShowDialog();
            }
        }

        #endregion

        #region Métodos

        //guarda y actualiza
        public void Guarda()
        {
            EntUsuario entUser = new EntUsuario();
            BrConfiguracion ped = new BrConfiguracion();
            try
            {
                totRequeridos = 3;
                //contabilizaYValidaRequerido(TxtUsuario);
                contabilizaYValidaRequerido(TxtNombre);
                contabilizaYValidaRequerido(TxtCorreo);
                contabilizaYValidaRequerido(CmbArea);
                //contabilizaYValidaRequerido(CmbPerfil);
                
                if (totRequeridos > 0)
                {
                    messageBox = new avisosis(totRequeridos == 1 ? (string.Format("¡El campo {0} es obligatorio!", ControlInvalido)) : "Los campos son obligatorios", this.Title, MessageBoxButton.OK, MessageBoxImage.Warning);
                    messageBox.ShowDialog();
                    return;
                }

                //if (!ValidaBusqOpcionalConMensaje(TxtEmpOri, LblEmpresaOrigen))
                //    return;

                //enttrM.Aviavii = Convert.ToInt32(TxtAviso.Text);

                if (ActIns == Comunes.AGREGA)
                {
                    entUser.IdUsuarioRegistro = App.IdUsuario;
                    entUser.ActivoTexto = "Si";
                }
                else
                {
                    entUser.FechaModifico =Convert.ToString(DateTime.Today);
                    entUser.IdUsuarioModifico = App.IdUsuario;
                    entUser.IdUsuario = EntUser.IdUsuario;
                    entUser.ActivoTexto = EntUser.ActivoTexto;
                }
                entUser.Usuario = TxtUsuario.Text;
                entUser.Nombre = TxtNombre.Text;
                entUser.Clave = BREncripcion.encript2(txtContrasena.Password);
                entUser.Origen = area.Abreviatura;
                entUser.IdArea = area.IdArea;
                entUser.Area = area.Area;
                entUser.CorreoElectronico = TxtCorreo.Text;
                //entUser.IdPerfil = perf.IdPerfil;
                entUser.IdPerfil = IdPerfil;
                Respuesta<int> res = ped.InsUpdUsuarios(entUser, ActIns, "A");
                if (bandera == 1)
                {
                    if (res.EsExitoso)
                    {
                        //Actualizacion del Grid Generico                        
                        Editando = false;
                        messageBox = new avisosis("Se ha " + (ActIns == Comunes.AGREGA ? " agregado " : ActIns == Comunes.CAMBIA ? " actualizado " : " eliminado ") + " correctamente el usuario", this.Title, MessageBoxButton.OK, MessageBoxImage.None); messageBox.ShowDialog();
                        frmCatologoGenerico.AcutualizaGrid<EntUsuario>(entUser);                        
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

        public void Consulta(EntUsuario entUser)
        {
            try
            {
                if (ActIns == Comunes.CAMBIA)
                {
                    BrConfiguracion brped = new BrConfiguracion();                    
                    EntUser.IdUsuario = entUser.IdUsuario;
                    EntUser.ActivoTexto = entUser.ActivoTexto;
                    Respuesta<List<EntUsuario>> result = brped.GetConsultaUsuarios(EntUser);
                    if (result.TotalRegistros > 0)
                    {
                        TxtUsuario.Text = result.Resultado[0].Usuario.ToString();
                        TxtNombre.Text = result.Resultado[0].Nombre.ToString();
                        TxtCorreo.Text = result.Resultado[0].CorreoElectronico.ToString();
                        txtContrasena.Password = BREncripcion.decript2(result.Resultado[0].Clave.ToString());
                        txtConfirmacion.Password = BREncripcion.decript2(result.Resultado[0].Clave.ToString());
                        CmbArea.SelectedValue =result.Resultado[0].IdArea.ToString();
                        CmbPerfil.SelectedValue = result.Resultado[0].IdPerfil.ToString();
                        IdPerfil = result.Resultado[0].IdPerfil;
                        if (result.Resultado[0].ActivoTexto.ToString() == "Si")
                        {
                            chkDeshabilitado.IsChecked = true;
                        }
                        else
                        {
                            chkDeshabilitado.IsChecked = false;
                        }
                    }
                    TxtUsuario.IsEnabled = false;
                    chkDeshabilitado.IsEnabled = false;
                    LblActivo.Visibility = System.Windows.Visibility.Visible;
                    chkDeshabilitado.Visibility = System.Windows.Visibility.Visible;
                }
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

        private bool ValidaExistPwd()
        {
            try
            {
                bool Existe = false;
                if (txtContrasena.Password == txtConfirmacion.Password)
                {
                    ValidaPasswordBox(ref txtConfirmacion, ref txtConfirmacion, TValida.Ninguno, TFormato.Ninguno, "");
                    Existe = false;
                }
                else
                {
                    ValidaPasswordBox(ref txtContrasena, ref txtContrasena, TValida.Ninguno, TFormato.Ninguno, "");
                    Existe = !ValidaPasswordBox(ref txtConfirmacion, ref txtConfirmacion, TValida.Mostrar, TFormato.Ninguno, "¡Las contraseñas no coinciden!");
                }

                return Existe;
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, this.Title, MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
                return false;
            }
        }

        private void ConsultaPerfiles()
        {
            try
            {
                EntPerfil entp = new EntPerfil();
                BrConfiguracion confp = new BrConfiguracion();
                entp.IdSistema = 2;
                Respuesta<List<EntPerfil>> res = confp.GetConsultaPerfiles(entp);
                if (res.EsExitoso)
                {
                    if (res.Resultado.Count > 0)
                    {
                        CmbPerfil.DataContext = res.Resultado;
                    }
                }
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, this.Title, MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
            }
        }

        private void ConsultaAreas()
        {
            try
            {
                EntArea entp = new EntArea();
                BrConfiguracion confp = new BrConfiguracion();
                Respuesta<List<EntArea>> res = confp.GetConsultaAreas(entp);
                if (res.EsExitoso)
                {
                    if (res.Resultado.Count > 0)
                    {
                        CmbArea.DataContext = res.Resultado;
                    }
                }
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, this.Title, MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
            }
        }

        #endregion

        private void btnAceptar_Copy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FrmPerfiles frmUC = new FrmPerfiles(this);
                entperfil.IdPerfil = Convert.ToInt32(CmbPerfil.SelectedValue);
                entperfil.Perfil = TxtNombre.Text;
                if (entperfil == null || entperfil.IdPerfil >0 )
                {
                                    
                    frmUC.ActIns = Comunes.CAMBIA;
                    frmUC.Consulta(entperfil);
                }
                else
                {
                    frmUC.ActIns = Comunes.AGREGA;
                    frmUC.ConsultaNombrePerfil(entperfil);

                }
                frmUC.ShowDialog();
                IdPerfil = frmUC.IdPerfil;
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex,this.Title, MessageBoxButton.OK, MessageBoxImage.Error);
                messageBox.ShowDialog();
            }
        }        
    }
}


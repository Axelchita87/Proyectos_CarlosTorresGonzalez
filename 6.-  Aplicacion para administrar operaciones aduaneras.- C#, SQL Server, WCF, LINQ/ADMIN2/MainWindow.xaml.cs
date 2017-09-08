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
using ADMIN2.DAL;
using ADMIN2.Entity;
using ADMIN2.BR;

namespace ADMIN2
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        avisosis messageBox = new avisosis();
        public MainWindow()
        {
            InitializeComponent();           
        }
        #region Variables        
        #endregion

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                App.Current.Shutdown();
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, "Acceso al Sistema", MessageBoxButton.OK, MessageBoxImage.Error);
                messageBox.ShowDialog();
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ValidaUsuario();
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, "Acceso al Sistema", MessageBoxButton.OK, MessageBoxImage.Error);
                messageBox.ShowDialog();
            }
        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnLogin_Click(null, null);
            }
        }

        private void txtUsuario_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Encript wnd = new Encript();
            wnd.Show();
        }

        #region Metodos

        private void ValidaUsuario()
        {
            try
            {
                BrConfiguracion brusu = new BrConfiguracion();
                EntUsuario enusu = new EntUsuario();
                enusu.IdSistema = 2;
                enusu.Usuario = txtUsuario.Text;
                enusu.Clave = BREncripcion.encript2(txtPassword.Password);
                Respuesta<List<EntUsuario>> respob = brusu.GetValidaUsuario(enusu);
                if(respob.Resultado.Count > 0)
                {
                    if (respob.Resultado[0].ValidaUsuario != 0)
                    {
                        messageBox = new avisosis(respob.Resultado[0].Mensaje, "Acceso al Sistema", MessageBoxButton.OK, MessageBoxImage.Information);
                        messageBox.ShowDialog(); 
                    }
                    else
                    {
                        //carga datos usuario
                        respob = new Respuesta<List<EntUsuario>>();
                        respob = brusu.GetConsultaUsuario(enusu);
                        if (respob.Resultado.Count > 0)
                        {
                            App.IdUsuario = respob.Resultado[0].IdUsuario;
                            App.NombreUsuario = respob.Resultado[0].Nombre;
                            App.Admin = respob.Resultado[0].Admin;
                            App.IdArea = respob.Resultado[0].IdArea;
                            App.CorreoElectronico = respob.Resultado[0].CorreoElectronico;
                            App.IdPerfil = respob.Resultado[0].IdPerfil;
                            App.IdSistema = respob.Resultado[0].IdSistema;
                        }
                        //agrega lista acceso
                        EntPerfil entp = new EntPerfil();
                        entp.IdSistema = App.IdSistema;
                        entp.IdUsuarioRegistro = App.IdUsuario;
                        Respuesta<List<EntPerfil>> resp = brusu.GetConsultaPerfileAccesoUsuario(entp);
                        if ( resp.Resultado.Count > 0)
                        {
                            App.ListaAccesoPantalla = resp.Resultado;
                        }
                        Close();
                        Main m = new Main();
                        m.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, "Acceso al Sistema", MessageBoxButton.OK, MessageBoxImage.Error);
                messageBox.ShowDialog();
            }

        }
        #endregion

    }
}

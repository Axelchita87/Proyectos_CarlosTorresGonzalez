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


namespace ADMIN2.Clientes
{
    /// <summary>
    /// Lógica de interacción para FrmEntidades.xaml
    /// </summary>
    public partial class FrmEntidades : BaseWindow
    {
        public FrmEntidades()
        {
            InitializeComponent();
            IdPermiso = App.IdPermiso.ToString();

            if (App.IdPermiso.ToString() == "1")
            {
                inhabilitaControles(GridBotones);
                inhabilitaControles(GridBotones2);
            }            
            BtnMunicipio.Visibility = Visibility.Hidden;
            BtnColinia.Visibility = Visibility.Hidden;
            ConsultaEntidades();
        }

        #region Declaraciones

        avisosis messageBox = new avisosis();
        public string ActIns = string.Empty;
        public int bandera = 0;
        public bool ValidaDir = false;
        public int idEstado = 0;
        public bool aplicaCopia = false;
        private Respuesta<List<EntEntidades>> EstadosRep;
        private Respuesta<List<EntEntidades>> MunicipioResp;
        private Respuesta<List<EntEntidades>> ColoniaResp;
        EntEntidades Resent = new EntEntidades();
        EntEntidades MunicipioResent = new EntEntidades();
        EntEntidades ColoniaResent = new EntEntidades();
        public int MuestraOpcion = 0;
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
            ValidaDir = false;
            LimpiaTextBox(this);           
            Close();
          
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bandera = 1;
                if (ChbAplica.IsChecked == true)
                {
                    aplicaCopia = true;
                }
                this.Close();
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, this.Title, MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
            }
        }

        private void BtnEntidad(object sender, RoutedEventArgs e)
        {
            frmCatologoGenerico frmCatalogo = new frmCatologoGenerico();
            object Resp = frmCatalogo.AbrirAgendaGenerica<EntEntidades>(Genericas.CatEntidades, "Entidades Federativas", false, false, false, "", 1);
            Resent = Resp as EntEntidades;
            if (Resent != null)
            {
                TxtEstado.Text = Resent.D_estado;
                BtnMunicipio.Visibility = Visibility.Visible;
                BtnMunicipio_Click(null, null);
            }
            else
                BtnMunicipio.Visibility = Visibility.Hidden;

        }

        private void BtnMunicipio_Click(object sender, RoutedEventArgs e)
        {
            frmCatologoGenerico frmCatalogo = new frmCatologoGenerico();
            ConsultaMunicipios();
            object Resp = frmCatalogo.AbrirAgendaGenerica<EntEntidades>(MunicipioResp.Resultado, Genericas.CatMunicipios, "Municipios", false, false, false);
            MunicipioResent = Resp as EntEntidades;
            if (Resent != null)
            {
                TxtMunicipio.Text = MunicipioResent.D_mnpio;
                BtnColinia.Visibility = Visibility.Visible;
                BtnColinia_Click(null, null);
            }
            else
                BtnColinia.Visibility = Visibility.Hidden;
        }

        private void BtnColinia_Click(object sender, RoutedEventArgs e)
        {
            frmCatologoGenerico frmCatalogo = new frmCatologoGenerico();
            ConsultaColonias();
            object Resp = frmCatalogo.AbrirAgendaGenerica<EntEntidades>(ColoniaResp.Resultado, Genericas.CatColonias, "Colonia", false, false, false);
            ColoniaResent = Resp as EntEntidades;
            if (Resent != null)
            {
                ValidaDir = true;
                TxtColonia.Text = ColoniaResent.D_asenta;
                TxtCP.Text = ColoniaResent.IdCodigo.ToString();                
            }

        }

        #endregion

        #region Métodos
      
        private void ConsultaEntidades()
        {
            try
            {
                BrCliente cliente = new BrCliente();
                EntEntidades ent = new EntEntidades();
                EstadosRep = cliente.GetConsultaEntidades(ent);                
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, this.Title, MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
            }
        }

        private void ConsultaMunicipios()
        {
            try
            {
                BrCliente cliente = new BrCliente();
                EntEntidades ent = new EntEntidades();                
                ent.IdEstado = Resent.IdEstado;
                idEstado = ent.IdEstado;
                MunicipioResp = cliente.GetConsultaMunicipios(ent);
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, this.Title, MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
            }
        }

        private void ConsultaColonias()
        {
            try
            {
                BrCliente cliente = new BrCliente();
                EntEntidades ent = new EntEntidades();
                ent.IdMunicipio = MunicipioResent.IdMunicipio;
                ColoniaResp = cliente.GetConsultaColonias(ent);
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, this.Title, MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
            }
        }

        public void MuestaOpcion()
        {
            if (MuestraOpcion == 1)
            {
                LblAplica.Visibility = Visibility.Visible;
                ChbAplica.Visibility = Visibility.Visible;
            }
            else
            {
                LblAplica.Visibility = Visibility.Hidden;
                ChbAplica.Visibility = Visibility.Hidden;
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

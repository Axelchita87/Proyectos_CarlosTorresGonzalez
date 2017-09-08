using ADMIN2.WindowSist;
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

namespace ADMIN2
{
    /// <summary>
    /// Lógica de interacción para UserControl1.xaml
    /// </summary>
    public partial class avisosis : Window
    {
        public MessageBoxImage messageBoxImage;
        private Exception Ex;
        private string p;
        public bool Cancelar;
        private CNLValidaExcepciones errorDesc;
        public MessageBoxButton messageBoxButton { get; set; }

        public avisosis()
        {
            InitializeComponent();
        }

        public avisosis(string messageBoxText, string caption)
        {
            InitializeComponent();


            txtMsg.Text = messageBoxText;
            lblTitulo.Content = caption;

            this.messageBoxButton = MessageBoxButton.OK;
            this.messageBoxImage = MessageBoxImage.Information;

        }

        public avisosis(string messageBoxText, string caption, MessageBoxButton messageBoxButton, MessageBoxImage messageBoxImage)
        {
            InitializeComponent();


            txtMsg.Text = messageBoxText;
            lblTitulo.Content = caption;



            this.messageBoxButton = messageBoxButton;
            this.messageBoxImage = messageBoxImage;

        }

        public avisosis(Exception ex, string caption, MessageBoxButton messageBoxButton1, MessageBoxImage messageBoxImage)
        {
            InitializeComponent();

            Ex = ex;
            errorDesc = new WindowSist.CNLValidaExcepciones(ex);
            txtMsg.Text = errorDesc.Texto + "\n" + errorDesc.TextoDetalle;
            lblTitulo.Content = caption;

            if (messageBoxImage == MessageBoxImage.Error)
            {
                btnCopiarError.Visibility = Visibility.Visible;
                txtMsg.IsEnabled = true;
            }

            this.messageBoxButton = messageBoxButton;
            this.messageBoxImage = messageBoxImage;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.DragMove();
        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Cancelar = true;
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Thickness th0 = new Thickness();
            th0.Left = 0;
            th0.Top = 0;
            th0.Right = 237;
            th0.Bottom = 15;

            Thickness th = new Thickness();
            th.Left = 0;
            th.Top = 0;
            th.Right = 125;
            th.Bottom = 15;


            Thickness th2 = new Thickness();
            th2.Left = 0;
            th2.Top = 0;
            th2.Right = 16;
            th2.Bottom = 15;



            switch (messageBoxButton)
            {
                case MessageBoxButton.OK:
                    btnYes.Visibility = Visibility.Visible;
                    btnYes.Content = "Aceptar";
                    btnYes.Margin = th2;
                    btnNo.Visibility = Visibility.Hidden;
                    break;
                case MessageBoxButton.OKCancel:
                    btnYes.Visibility = Visibility.Visible;
                    btnYes.Content = "Aceptar";
                    btnYes.Margin = th;
                    btnNo.Visibility = Visibility.Visible;
                    btnNo.Content = "Cancelar";
                    btnNo.Margin = th2;
                    break;
                case MessageBoxButton.YesNo:
                    btnYes.Visibility = Visibility.Visible;
                    btnYes.Content = "Si";
                    btnYes.Margin = th;
                    btnNo.Visibility = Visibility.Visible;
                    btnNo.Content = "No";
                    btnNo.Margin = th2;
                    break;
                case MessageBoxButton.YesNoCancel:
                    btnYes.Visibility = Visibility.Visible;
                    btnYes.Content = "Si";
                    btnYes.Margin = th0;
                    btnNo.Visibility = Visibility.Visible;
                    btnNo.Content = "No";
                    btnNo.Margin = th;
                    btnCancel.Visibility = Visibility.Visible;
                    btnCancel.Content = "Cancelar";
                    btnCancel.Margin = th2;
                    break;
            }

            string img = string.Empty;
            switch (Convert.ToInt32(messageBoxImage))
            {
                case 16:
                    img = "/images/error.png";
                    break;
                case 64:
                    img = "/images/info.png";
                    break;
                case 0:
                    img = "/images/check_blue.png";
                    break;
                case 32:
                    img = "/images/question.png";
                    break;
                case 48:
                    img = "/images/warning.png";
                    break;
            }

            Uri uriImagen = new Uri(img, UriKind.Relative);
            BitmapImage objBi = new BitmapImage(uriImagen);
            lblImage.Source = objBi;
        }

        private void btnCopiarError_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(errorDesc.Texto + "\n" + errorDesc.TextoDetalle);
        }
    }
}

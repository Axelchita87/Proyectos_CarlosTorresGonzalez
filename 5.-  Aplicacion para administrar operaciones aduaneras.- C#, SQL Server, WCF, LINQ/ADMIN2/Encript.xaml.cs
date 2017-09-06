using ADMIN2.BR;
using ADMIN2.DAL;
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
    /// Lógica de interacción para Encript.xaml
    /// </summary>
    public partial class Encript : Window
    {
        public Encript()
        {
            InitializeComponent();
        }

        private void btnEncript_Click(object sender, RoutedEventArgs e)
        {
            txtDesenc.Text = BREncripcion.encript2(txtEncriptar.Text);
        }

        private void btnDeEncript_Click(object sender, RoutedEventArgs e)
        {
            txtDesenc.Text = BREncripcion.decript2(txtEncriptar.Text);
        }
    }
}

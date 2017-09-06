using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using System.Text.RegularExpressions;

namespace ADMIN2.Controls
{
    public class DecimalTextBox : TextBox
    {
        private string noDecimales = "2";
        public string NoDecimales 
        {
            set { noDecimales = value; }
            get 
            {
                return noDecimales; 
            } 
        }
        private string noEnteros = "9";
        public string NoEnteros
        {
            set { noEnteros = value; }
            get
            {
                return noEnteros;
            }
        }
        private string formato = "N";
        public string Formato
        {
            get { return formato; }
            set { formato = value; }
        }
        protected override void OnLostFocus(RoutedEventArgs e)
        {
            this.Text = Convert.ToDecimal(this.Text == string.Empty ? "0" : this.Text).ToString(Formato + NoDecimales);
            base.OnLostFocus(e);
        }

        protected override void OnGotFocus(RoutedEventArgs e)
        {
            this.SelectionLength = this.Text.Length;
            base.OnGotFocus(e);
        }

        protected override void OnPreviewTextInput(System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"^([0-9]+([.]\d{0," + NoDecimales + "})?|0+([.]\\d{0," + NoDecimales + "}))?$");            
            e.Handled = !regex.IsMatch(this.Text.Insert(this.SelectionStart, e.Text));
            base.OnPreviewTextInput(e);
        }

        protected override void OnPreviewKeyDown(System.Windows.Input.KeyEventArgs e)
        {
            if (this.SelectionLength != this.Text.Length || this.Text.Length == 0)
            {
                if (e.Key == Key.Space)
                    e.Handled = true;
            }
       
            base.OnPreviewKeyDown(e);
        }

        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            //int zero = 0;
            //if (this.Text.Trim() != string.Empty)
            //{
            //    if (Convert.ToDecimal(this.Text) == 0)
            //        this.Text = "0." + zero.ToString("D" + NoDecimales);
            //}
            //else
            //{
            //    this.Text = "0." + zero.ToString("D" + NoDecimales);
            //}
            base.OnTextChanged(e);
            
        }   
     
    }
}

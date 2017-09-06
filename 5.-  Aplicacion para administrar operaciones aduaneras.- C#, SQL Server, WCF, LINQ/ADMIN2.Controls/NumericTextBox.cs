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
    public class NumericTextBox : TextBox
    {
        protected override void OnLostFocus(RoutedEventArgs e)
        {
            //this.Text = Convert.ToDecimal(this.Text).ToString("N");
            base.OnLostFocus(e);
        }

        protected override void OnGotFocus(RoutedEventArgs e)
        {
            this.SelectionLength = this.Text.Length;
            base.OnGotFocus(e);
        }

        protected override void OnPreviewTextInput(System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"^[0-9]\d*$");
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
            if (this.Text.Trim() == string.Empty)
            {
                this.Text = string.Empty;
            }
            base.OnTextChanged(e);
        }
    }
}

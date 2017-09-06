using MyCTS.Entities;
using MyCTS.Presentation.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace MyCTS.Presentation.Reservations.Profiles
{
    /// <summary>
    /// Interaction logic for UsrCtrlCCardsFirstLevel.xaml
    /// </summary>
    public partial class UsrCtrlCCardsFirstLevel : UserControl
    {
        private List<Dynamic> lst;

        public UsrCtrlCCardsFirstLevel(List<Dynamic> lst)
        {
            InitializeComponent();
            this.lst = lst;
            FillFileds();
        }

        public UsrCtrlCCardsFirstLevel()
        {
            InitializeComponent();
        }

        void Expander_Expanded(object sender, System.Windows.RoutedEventArgs e)
        {
            foreach (var item in this.AirlinesGroup.Children)
            {
                if (item is Expander & item != sender)
                    ((Expander)item).IsExpanded = false;
            }
        }

        private void FillFileds()
        {
            try
            {
                int i = 0;
                do
                {
                    List<object> j = new List<object>() { null, 2, 3, 4, 5 };
                    var a = lst.SingleOrDefault(x => x.FieldName == "CreditCard" + j[i]);
                    if (a != null)
                    {
                        var q = a.GetType().GetProperty(a.FieldName).GetValue(a, null).ToString().Split('*');
                        ((TextBox)this.FindName("CCCode" + j[i])).Text = q.FirstOrDefault();
                        ((PasswordBox)this.FindName("CC" + j[i])).Password = q.LastOrDefault();
                    }
                    var d = lst.SingleOrDefault(x => x.FieldName == "ExpirationDate" + j[i]);
                    if (d != null)
                    {
                        var b = d.GetType().GetProperty(d.FieldName).GetValue(d, null).ToString().Split(new String[] { "/" }, 5,
                                                                                      StringSplitOptions.RemoveEmptyEntries);
                        ((PasswordBox)this.FindName("MM" + j[i])).Password = b.FirstOrDefault();
                        ((Label)this.FindName("lblMM" + j[i])).Visibility = (string.IsNullOrEmpty(((PasswordBox)this.FindName("MM" + j[i])).Password) ? System.Windows.Visibility.Visible : System.Windows.Visibility.Hidden);
                        ((PasswordBox)this.FindName("YY" + j[i])).Password = b.LastOrDefault();
                        ((Label)this.FindName("lblYY" + j[i])).Visibility = (string.IsNullOrEmpty(((PasswordBox)this.FindName("YY" + j[i])).Password) ? System.Windows.Visibility.Visible : System.Windows.Visibility.Hidden);
                        
                    }
                    var l = lst.SingleOrDefault(x => x.FieldName == "CVV" + ((j[i] == null) ? 1 : int.Parse(j[i].ToString())));
                    if (l != null)
                    {
                        var c = new string(Common.toDecrypt(l.GetType().GetProperty(l.FieldName).GetValue(l, null).ToString()).Where(char.IsDigit).ToArray());
                        ((PasswordBox)this.FindName("Code" + j[i])).Password = (!string.IsNullOrEmpty(c)) ? c : string.Empty;
                        ((Label)this.FindName("lblCode" + j[i])).Visibility = (string.IsNullOrEmpty(c)) ? System.Windows.Visibility.Visible : System.Windows.Visibility.Hidden;
                    }

                    var t = lst.SingleOrDefault(x => x.FieldName == "TypeOfService" + ((j[i] == null) ? 1 : int.Parse(j[i].ToString())));
                    if (t != null)
                    {
                        var q = t.GetType().GetProperty(t.FieldName).GetValue(t, null).ToString().Split('*');
                        if (q.Length >= 4)
                        {
                            ((CheckBox)this.FindName("chkAir" + j[i])).IsChecked = (q.FirstOrDefault() == "Y") ? true : false;
                            ((CheckBox)this.FindName("chkCar" + j[i])).IsChecked = (q[1] == "Y") ? true : false;
                            ((CheckBox)this.FindName("chkHtl" + j[i])).IsChecked = (q[2] == "Y") ? true : false;
                            ((TextBox)this.FindName("txtSpecificUse" + j[i])).Text = q.LastOrDefault().Replace('¨', ' ');
                        }
                    }
                    
                    ((Expander)this.FindName("Expander" + j[i])).Expanded += Expander_Expanded;
                    ((TextBox)this.FindName("txtSpecificUse" + j[i])).TextChanged += header_TextChanged;
                    ((TextBox)this.FindName("CCCode" + j[i])).CharacterCasing = CharacterCasing.Upper;
                    ((TextBox)this.FindName("CCCode" + j[i])).TextChanged += header_TextChanged;
                    ((Label)this.FindName("lblCode" + j[i])).MouseLeftButtonUp += UsrCtrlCCardsFirstLevel_MouseLeftButtonUp;
                    ((PasswordBox)this.FindName("CC" + j[i])).PasswordChanged += UsrCtrlCCardsFirstLevel_PasswordChanged;
                    ((Label)this.FindName("lblMM" + j[i])).MouseLeftButtonUp += UsrCtrlCCardsFirstLevel_MouseLeftButtonUp;
                    ((Label)this.FindName("lblYY" + j[i])).MouseLeftButtonUp += UsrCtrlCCardsFirstLevel_MouseLeftButtonUp;
                    ((CheckBox)this.FindName("chkAir" + j[i])).Click += chk_Checked;
                    ((CheckBox)this.FindName("chkCar" + j[i])).Click += chk_Checked;
                    ((CheckBox)this.FindName("chkHtl" + j[i])).Click += chk_Checked;
                    ((TextBox)this.FindName("txtSpecificUse" + j[i])).CharacterCasing = CharacterCasing.Upper;
                    ((PasswordBox)this.FindName("MM" + j[i])).GotFocus += UsrCtrlCCardsFirstLevel_GotFocus;
                    ((PasswordBox)this.FindName("YY" + j[i])).GotFocus += UsrCtrlCCardsFirstLevel_GotFocus;
                    ((PasswordBox)this.FindName("Code" + j[i])).GotFocus += UsrCtrlCCardsFirstLevel_GotFocus;
                    Expander e = (Expander)this.FindName("Expander" + j[i]);
                    if (e != null & ((PasswordBox)this.FindName("CC" + j[i])).Password.Length >= 5)
                        e.Header = ((TextBox)this.FindName("CCCode" + j[i])).Text + "           " + "***********" + ((PasswordBox)this.FindName("CC" + j[i])).Password.Substring(((PasswordBox)this.FindName("CC" + j[i])).Password.Length - 4, 4)
                            + "           "
                            + (((CheckBox)this.FindName("chkAir" + j[i])).IsChecked == true ? "AIR" : "    ")
                            + "    " + (((CheckBox)this.FindName("chkCar" + j[i])).IsChecked == true ? "CAR" : "    ")
                            + "    " + (((CheckBox)this.FindName("chkHtl" + j[i])).IsChecked == true ? "HTL" : "    ")
                            + "           " + ((TextBox)this.FindName("txtSpecificUse" + j[i])).Text.Replace('¨', ' ');
                    ++i;
                } while (i < 5);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in FillFields Profiles: " + ex.Message);
            }
        }

        void UsrCtrlCCardsFirstLevel_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            ((Label)this.FindName("lbl" + ((PasswordBox)sender).Name)).Visibility = System.Windows.Visibility.Hidden;
        }

        void UsrCtrlCCardsFirstLevel_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ((Label)sender).Visibility = System.Windows.Visibility.Hidden;
        }

        private void PrintHeader()
        {
            try
            {
                int i = 0;
                do
                {
                    List<object> j = new List<object>() { null, 2, 3, 4, 5 };
                    Expander ex = null;
                    ex = (Expander)this.FindName("Expander" + j[i]);
                    if (ex != null & ((PasswordBox)this.FindName("CC" + j[i])).Password.Length >= 5)
                        ex.Header = ((TextBox)this.FindName("CCCode" + j[i])).Text + "           " + "***********" + ((PasswordBox)this.FindName("CC" + j[i])).Password.Substring(((PasswordBox)this.FindName("CC" + j[i])).Password.Length - 4, 4)
                            + "           "
                            + (((CheckBox)this.FindName("chkAir" + j[i])).IsChecked == true ? "AIR" : "   ")
                            + "    " + (((CheckBox)this.FindName("chkCar" + j[i])).IsChecked == true ? "CAR" : "   ")
                            + "    " + (((CheckBox)this.FindName("chkHtl" + j[i])).IsChecked == true ? "HTL" : "   ")
                            + "           " + ((TextBox)this.FindName("txtSpecificUse" + j[i])).Text.Replace('¨', ' ');
                    ++i;
                } while (i < 5);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void header_TextChanged(object sender, TextChangedEventArgs e)
        {
            PrintHeader();
        }

        void UsrCtrlCCardsFirstLevel_PasswordChanged(object sender, System.Windows.RoutedEventArgs e)
        {
            PrintHeader();
        }

        private void chk_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            PrintHeader();
        }
    }
}

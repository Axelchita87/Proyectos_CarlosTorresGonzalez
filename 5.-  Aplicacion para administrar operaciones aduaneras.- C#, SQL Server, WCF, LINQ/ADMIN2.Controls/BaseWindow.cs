using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Text.RegularExpressions;
using System.Windows.Media;
using System.Windows.Controls.Primitives;
using ADMIN2.BR;
using ADMIN2.Entity;
using ADMIN2.DAL;
using Ionic.Zip;
using System.IO;

//clr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.Toolkit
namespace ADMIN2.Controls
{
    public enum TValida
    {
        Ninguno = -1,
        Mostrar = 0,
        Vacio = 1,
        Longitud = 2,
        Formato = 3,
        Comparacion = 4,
        Quitar = 5
    }

    public enum TFormato
    {
        Ninguno = -1,
        Email = 0,
        Rfc = 1,
        Rfc1012y13 = 4,
        Curp = 2,
        Telefono=3
    }

    public class BaseWindow : Window
    {
        public bool Editando = false;
        public bool guardar = false;
        public bool cerrando = false;
        public bool ClaveVacia = false;
        public int totRequeridos = 0;
        public bool valExistente = false;
        public int totFormato = 0;
        public string tituloVentana = string.Empty;
        public string IdPermiso = string.Empty;
        avisosis messageBox = new avisosis();
        public string ControlInvalido;
        public bool SinTipoCambioSita;
        public string TipoCambioConsultado;
        //private Respuesta<List<Ent_CodigosPost>> EstadosRep;
        //private Respuesta<List<Ent_Paises>> Paises;
        private DateTime fechaAgregadoExpDig = DateTime.MinValue;
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
            if (Editando)
            {
                messageBox = new avisosis("¿Desea guardar los cambios efecutados?", tituloVentana!=string.Empty?tituloVentana:this.Title, MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
                bool? res = messageBox.ShowDialog();
                if (res == true)
                {
                    guardar = true;
                    Editando = false;
                }
                else if (res == false)
                {
                    if (messageBox.Cancelar)
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        guardar = false;
                        Editando = false;
                    }
                }
            }
        }

        protected override void OnInitialized(EventArgs e)
        {
            this.ResizeMode = ResizeMode.NoResize;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            base.OnInitialized(e);
        }

        #region Marcadores de validaciones al guardar registro

        public void txtValidaVacio(object sender, RoutedEventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                if (txt.IsFocused != true)
                {
                    ValidaTextBox(ref txt, TValida.Vacio, TFormato.Ninguno, String.Format("¡El campo {0} es obligatorio!", txt.Tag));
                }
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, this.Title, MessageBoxButton.OK, MessageBoxImage.Error);
                messageBox.ShowDialog();
            }
        }
        /// <summary>
        /// Método para validar antes de guardar en las ventanas de captura y edición
        /// </summary>
        /// <param name="txt">nombre del control de tipo TextBox</param>
        /// <param name="tipo">Ninguno, Mostrar, Vacio, Longitud, Formato, Comparacion, Quitar</param>
        /// <param name="format">Ninguno, Email, Rfc, Curp</param>
        /// <param name="msg">Mensaje de error que se mostrará</param>
        /// <param name="valor">se utiliza en caso de que tipo sea Longitud</param>
        /// <returns></returns>
        public bool ValidaTextBox(ref TextBox txt, TValida tipo, TFormato format, string msg, int valor = 0)
        {
            bool respuesta = false;
            switch (tipo)
            {
                case TValida.Longitud:
                    if (txt.Text.Length < valor)
                        MarcaErrorText(txt, msg, 1);
                    else
                    {
                        MarcaErrorText(txt, null, 0);
                        respuesta = true;
                    }
                    break;
                case TValida.Vacio:
                    if (txt.Text.Trim() == string.Empty)
                    {
                        MarcaErrorText(txt, msg, 1);
                    }
                    else
                    {
                        MarcaErrorText(txt, null, 0);
                        respuesta = true;
                    }
                    break;
                case TValida.Mostrar:
                    MarcaErrorText(txt, msg, 1);
                    break;
                case TValida.Quitar:
                    MarcaErrorText(txt, null, 0);
                    respuesta = true;
                    break;
                case TValida.Ninguno:
                    MarcaErrorText(txt, null, 0);
                    respuesta = true;
                    break;
                case TValida.Formato:
                    switch (format)
                    {
                        case TFormato.Rfc1012y13:
                            if (!isRFC1012y13(txt.Text))
                                MarcaErrorText(txt, msg, 1);
                            else
                            {
                                MarcaErrorText(txt, null, 0);
                                respuesta = true;
                            }
                            break;
                        case TFormato.Rfc:
                            if (!isRFC(txt.Text))
                                MarcaErrorText(txt, msg, 1);
                            else
                            {
                                MarcaErrorText(txt, null, 0);
                                respuesta = true;
                            }
                            break;
                        case TFormato.Email:
                            if (!isEMail(txt.Text))
                                MarcaErrorText(txt, msg, 1);
                            else
                            {
                                MarcaErrorText(txt, null, 0);
                                respuesta = true;
                            }
                            break;
                        case TFormato.Curp:
                            if (!isCURP(txt.Text))
                                MarcaErrorText(txt, msg, 1);
                            else
                            {
                                MarcaErrorText(txt, null, 0);
                                respuesta = true;
                            }
                            break;
                        case TFormato.Telefono:
                            if (!isTelefono(txt.Text))
                                MarcaErrorText(txt, msg, 1);
                            else
                            {
                                MarcaErrorText(txt, null, 0);
                                respuesta = true;
                            }
                            break;
                    }
                    break;
            }
            return respuesta;
        }

        public void contabilizaYValidaRequerido(TextBox txtControl)
        {
            if (ValidaTextBox(ref txtControl, TValida.Vacio, TFormato.Ninguno, string.Format("¡El campo {0} es obligatorio!", txtControl.Tag.ToString())))
                totRequeridos--;
            else
                ControlInvalido = txtControl.Tag.ToString();
        }

        public void contabilizaYValidaRequerido(ADMIN2.Controls.DecimalTextBox txtControl)
        {
            if (ValidaTextBox(ref txtControl, TValida.Vacio, string.Format("¡El campo {0} es obligatorio!", TFormato.Ninguno, txtControl.Tag.ToString())))
                totRequeridos--;
            else
                ControlInvalido = txtControl.Tag.ToString();
        }

        public void contabilizaYValidaRequerido(DatePicker DtControl)
        {
            if (ValidaDatePicker(ref DtControl, TValida.Vacio, string.Format("¡El campo {0} es obligatorio!", DtControl.Tag.ToString())))
                totRequeridos--;
            else
                ControlInvalido = DtControl.Tag.ToString();
        }

        public void contabilizaYValidaRequerido(ComboBox cmbControl)
        {
            if (ValidaComboBox(ref cmbControl, TValida.Vacio, string.Format("¡El campo {0} es obligatorio!", cmbControl.Tag.ToString())))
                totRequeridos--;
            else
                ControlInvalido = cmbControl.Tag.ToString();
        }

        public void contabilizaYValidaRequerido(MaskedTextBox txtControl)
        {
            if (ValidaTextBox(ref txtControl, TValida.Vacio, string.Format("¡El campo {0} es obligatorio!", txtControl.Tag.ToString())))
                totRequeridos--;
            else
                ControlInvalido = txtControl.Tag.ToString();
        }

        /// <summary>
        /// Valida cualquier control de búsqueda que se haya seleccionado una opcion válida
        /// </summary>
        /// <param name="txtControl">nombre del control</param>
        /// <param name="lblControl">nombre de la etiqueta Descripcion</param>
        /// <returns></returns>
        public bool ValidaBusqObligatoriaConMensaje(TextBox txtControl, TextBlock lblControl)
        {
            if (txtControl.Text == string.Empty || lblControl.Text == "No existe en catálogo")
            {
                ValidaTextBox(ref txtControl, TValida.Mostrar, TFormato.Ninguno, string.Format("¡El campo {0} debe ser válido!", txtControl.Tag));
                messageBox = new avisosis(string.Format("¡El campo {0} debe ser válido!", txtControl.Tag), this.Title, MessageBoxButton.OK, MessageBoxImage.Warning);
                messageBox.ShowDialog();
                return false;
            }
            else
            {
                ValidaTextBox(ref txtControl, TValida.Quitar, TFormato.Ninguno, "");
                return true;
            }
        }

        /// <summary>
        /// Valida cualquier control de búsqueda que se haya seleccionado una opcion válida en caso que el control tenga texto
        /// </summary>
        /// <param name="txtControl">nombre del control</param>
        /// <param name="lblControl">nombre de la etiqueta Descripcion</param>
        /// <returns></returns>
        public bool ValidaBusqOpcionalConMensaje(TextBox txtControl, TextBlock lblControl)
        {
            if (txtControl.Text != string.Empty && lblControl.Text == "No existe en catálogo")
            {
                ValidaTextBox(ref txtControl, TValida.Mostrar, TFormato.Ninguno, string.Format("¡El campo {0} debe ser válido!", txtControl.Tag));
                messageBox = new avisosis(string.Format("¡El campo {0} debe ser válido!", txtControl.Tag), this.Title, MessageBoxButton.OK, MessageBoxImage.Warning);
                messageBox.ShowDialog();
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool ValidaTextBox(ref ADMIN2.Controls.TelefonoTextBox txt, TValida tipo, TFormato format, string msg, int valor = 0)
        {
            bool respuesta = false;
            switch (tipo)
            {
                case TValida.Longitud:
                    if (txt.Text.Length < valor)
                        MarcaErrorText(txt, msg, 1);
                    else
                    {
                        MarcaErrorText(txt, null, 0);
                        respuesta = true;
                    }
                    break;
                case TValida.Vacio:
                    if (txt.Text.Trim() == string.Empty)
                    {
                        MarcaErrorText(txt, msg, 1);
                    }
                    else
                    {
                        MarcaErrorText(txt, null, 0);
                        respuesta = true;
                    }
                    break;
                case TValida.Mostrar:
                    MarcaErrorText(txt, msg, 1);
                    break;
                case TValida.Quitar:
                    MarcaErrorText(txt, null, 0);
                    respuesta = true;
                    break;
                case TValida.Ninguno:
                    MarcaErrorText(txt, null, 0);
                    respuesta = true;
                    break;
                case TValida.Formato:
                    switch (format)
                    {
                        case TFormato.Rfc:
                            if (!isRFC(txt.Text))
                                MarcaErrorText(txt, msg, 1);
                            else
                            {
                                MarcaErrorText(txt, null, 0);
                                respuesta = true;
                            }
                            break;
                        case TFormato.Email:
                            if (!isEMail(txt.Text))
                                MarcaErrorText(txt, msg, 1);
                            else
                            {
                                MarcaErrorText(txt, null, 0);
                                respuesta = true;
                            }
                            break;
                        case TFormato.Curp:
                            if (!isCURP(txt.Text))
                                MarcaErrorText(txt, msg, 1);
                            else
                            {
                                MarcaErrorText(txt, null, 0);
                                respuesta = true;
                            }
                            break;
                        case TFormato.Telefono:
                            if (!isTelefono(txt.Text))
                                MarcaErrorText(txt, msg, 1);
                            else
                            {
                                MarcaErrorText(txt, null, 0);
                                respuesta = true;
                            }
                            break;
                    }
                    break;
            }
            return respuesta;
        }

        public bool ValidaTextBox(ref ADMIN2.Controls.NumericTextBox txt, TValida tipo, TFormato format, string msg, int valor = 0)
        {
            bool respuesta = false;
            switch (tipo)
            {
                case TValida.Longitud:
                    if (txt.Text.Length < valor)
                        MarcaErrorText(txt, msg, 1);
                    else
                    {
                        MarcaErrorText(txt, null, 0);
                        respuesta = true;
                    }
                    break;
                case TValida.Vacio:
                    if (txt.Text.Trim() == string.Empty)
                    {
                        MarcaErrorText(txt, msg, 1);
                    }
                    else
                    {
                        MarcaErrorText(txt, null, 0);
                        respuesta = true;
                    }
                    break;
                case TValida.Mostrar:
                    MarcaErrorText(txt, msg, 1);
                    break;
                case TValida.Quitar:
                    MarcaErrorText(txt, null, 0);
                    break;
                case TValida.Ninguno:
                    MarcaErrorText(txt, null, 0);
                    respuesta = true;
                    break;
            }
            return respuesta;
        }

        public bool ValidaTextBox(ref ADMIN2.Controls.DecimalTextBox txt, TValida tipo, string msg, TFormato format = TFormato.Ninguno, int valor = 0)
        {
            bool respuesta = false;
            switch (tipo)
            {
                case TValida.Longitud:
                    if (txt.Text.Length < valor)
                        MarcaErrorText(txt, msg, 1);
                    else
                    {
                        MarcaErrorText(txt, null, 0);
                        respuesta = true;
                    }
                    break;
                case TValida.Vacio:
                    if (Convert.ToDecimal(txt.Text == string.Empty ? 0 : Convert.ToDecimal(txt.Text)) == 0)
                    {
                        MarcaErrorText(txt, msg, 1);
                    }
                    else
                    {
                        MarcaErrorText(txt, null, 0);
                        respuesta = true;
                    }
                    break;
                case TValida.Mostrar:
                    MarcaErrorText(txt, msg, 1);
                    break;
                case TValida.Quitar:
                    MarcaErrorText(txt, null, 0);
                    break;
                case TValida.Ninguno:
                    MarcaErrorText(txt, null, 0);
                    respuesta = true;
                    break;
            }
            return respuesta;
        }

        public bool ValidaComboBox(ref ComboBox cmb, TValida tipo, string msg)
        {
            bool respuesta = false;
            switch (tipo)
            {
                case TValida.Vacio:
                    if (cmb.SelectedItem == null)
                    {
                        MarcaErrorCombo(cmb, msg, 1);
                    }
                    else
                    {
                        MarcaErrorCombo(cmb, msg, 0);
                        respuesta = true;
                    }
                    break;
                case TValida.Mostrar:
                    MarcaErrorCombo(cmb, msg, 1);
                    break;
                case TValida.Quitar:
                    MarcaErrorCombo(cmb, msg, 0);
                    respuesta = true;
                    break;
                case TValida.Longitud:
                    MarcaErrorCombo(cmb, msg, 1);
                    break;
            }
            return respuesta;
        }

        public bool ValidaDatePicker(ref DatePicker dtpk, TValida tipo, string msg)
        {
            bool respuesta = false;
            switch (tipo)
            {
                case TValida.Vacio:
                    if (dtpk.Text == string.Empty)
                    {
                        MarcaErrorDatePik(dtpk, msg, 1);
                    }
                    else
                    {
                        if (dtpk.SelectedDate.HasValue)
                        {
                            MarcaErrorDatePik(dtpk, msg, 0);
                            respuesta = true;
                        }
                    }
                    break;
                case TValida.Mostrar:
                    MarcaErrorDatePik(dtpk, msg, 1);
                    break;
                case TValida.Quitar:
                    MarcaErrorDatePik(dtpk, msg, 0);
                    respuesta = true;
                    break;
            }
            return respuesta;
        }
       
        public bool ValidaCheck(ref RadioButton check, TValida tipo, string msg)
        {
            bool respuesta = false;
            switch (tipo)
            {
                case TValida.Vacio:
                    if (check.IsChecked == false)
                    {
                        MarcaErrorCheck(check, msg, 1);
                    }
                    else
                    {

                        MarcaErrorCheck(check, msg, 0);
                        respuesta = true;
                    }
                    break;
                case TValida.Mostrar:
                    MarcaErrorCheck(check, msg, 1);
                    break;
                case TValida.Quitar:
                    MarcaErrorCheck(check, msg, 0);
                    respuesta = true;
                    break;
            }
            return respuesta;
        }

        public bool ValidaPasswordBox(ref PasswordBox txt, ref PasswordBox txtConfirm, TValida tipo, TFormato format, string msg)
        {
            bool respuesta = false;
            switch (tipo)
            {
                case TValida.Vacio:
                    if (txt.Password.Trim() == string.Empty)
                    {
                        MarcaErrorPassword(txt, msg, 1);
                    }
                    else
                    {
                        MarcaErrorPassword(txt, null, 0);
                        respuesta = true;
                    }
                    break;
                case TValida.Mostrar:
                    MarcaErrorPassword(txt, msg, 1);
                    MarcaErrorPassword(txtConfirm, msg, 1);
                    break;
                case TValida.Quitar:
                    MarcaErrorPassword(txt, null, 0);
                    MarcaErrorPassword(txtConfirm, null, 0);
                    break;
                case TValida.Comparacion:
                    if (txt.Password != txtConfirm.Password)
                    {
                        MarcaErrorPassword(txt, msg, 1);
                        MarcaErrorPassword(txtConfirm, msg, 1);
                    }
                    else
                    {
                        MarcaErrorPassword(txt, null, 0);
                        MarcaErrorPassword(txtConfirm, null, 0);
                        respuesta = true;
                    }
                    break;
                case TValida.Ninguno:
                    MarcaErrorPassword(txt, null, 0);
                    respuesta = true;
                    break;
            }
            return respuesta;
        }

        public bool ValidaTextBox(ref ADMIN2.Controls.MaskedTextBox txt, TValida tipo, string msg, TFormato format = TFormato.Ninguno, int valor = 0)
        {
            bool respuesta = false;
            switch (tipo)
            {
                case TValida.Longitud:
                    if (txt.Text.Length < valor)
                        MarcaErrorText(txt, msg, 1);
                    else
                    {
                        MarcaErrorText(txt, null, 0);
                        respuesta = true;
                    }
                    break;
                case TValida.Vacio:
                    if (Convert.ToDecimal(txt.Text == "__.____" ? 0 : Convert.ToDecimal(txt.Text.Replace("_","0"))) == 0)
                    {
                        MarcaErrorText(txt, msg, 1);
                    }
                    else
                    {
                        MarcaErrorText(txt, null, 0);
                        respuesta = true;
                    }
                    break;
                case TValida.Mostrar:
                    MarcaErrorText(txt, msg, 1);
                    break;
                case TValida.Quitar:
                    MarcaErrorText(txt, null, 0);
                    break;
                case TValida.Ninguno:
                    MarcaErrorText(txt, null, 0);
                    respuesta = true;
                    break;
            }
            return respuesta;
        }
        
        private void MarcaErrorPassword(PasswordBox txt, string msg, int p)
        {
            txt.ToolTip = msg;
            txt.Style = p == 1 ? (Style)this.FindResource("NotEqual") : (Style)null;
        }

        private void MarcaErrorText(TextBox txt, string msg, int p)
        {
            txt.ToolTip = msg;
            txt.Template = p == 1 ? (ControlTemplate)this.FindResource("segundo_estilo") : (ControlTemplate)this.FindResource("TextBoxBaseControlTemplate");
        }

        private void MarcaErrorCombo(ComboBox cmb, string msg, int p)
        {
            if(p==1)
            cmb.ToolTip = msg;
            cmb.Style = p == 1 ? (Style)this.FindResource("NotSelect") : (Style)null;
        }
        private void MarcaErrorDatePik(DatePicker dtp, string msg, int p)
        {
            dtp.ToolTip = msg;
           // dtp.Style = p == 1 ? (Style)this.FindResource("Date") : (Style)this.FindResource("DatePickerStyle1");
          
        }
        private void MarcaErrorCheck(RadioButton chck, string msg, int p)
        {
            chck.ToolTip = msg;
            chck.Style = p == 1 ? (Style)this.FindResource("Check") : (Style)this.FindResource("Check3");
        }

        private void MarcaErrorAuto(AutoCompleteBox autxt, string msg, int p)
        {
            autxt.ToolTip = msg;
            autxt.Style = p == 1 ? (Style)this.FindResource("AutBox") : (Style)this.FindResource("stilo");
        }
        #endregion

        #region Activar botones al editar
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            VerificaBotones(this);
        }

        public void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            VerificaBotones(this);
        }

        public void Password_Changed(object sender, RoutedEventArgs e)
        {
            VerificaBotones(this);
        }

        public void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            VerificaBotones(this);
        }
        public void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            VerificaBotones(this);
        }

        public void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            VerificaBotones(this);
        }

        public void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            VerificaBotones(this);
        }

        public void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            VerificaBotones(this);
        }
       
        public void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Editando = false;
            Button btnAceptar = FindChild<Button>(this, "btnAceptar");
            btnAceptar.IsEnabled = false;
            Button btnCancelar = FindChild<Button>(this, "btnCancelar");
            btnCancelar.IsEnabled = false;
        }

        public void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, this.Title, MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
            }
        }

        public void btnMinWin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WindowState = WindowState.Minimized;
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, this.Title, MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
            }
        }
        /// <summary>
        /// Método que hábilita los botones de Aceptar y Cancelar en las ventanas de captura y edición.
        /// </summary>
        /// <param name="w"></param>
        public void VerificaBotones(Window w)
        {
            Button btnAceptar = FindChild<Button>(w, "btnAceptar");
            Button btnCancelar = FindChild<Button>(w, "btnCancelar");
            if (!ClaveVacia && !Editando)
            {
                if (btnAceptar != null)
                {
                    if (IdPermiso == "2")
                    {
                        btnAceptar.IsEnabled = true;
                        Editando = true;
                    }                    
                }
                if (btnCancelar != null)
                {
                    if (IdPermiso == "2")
                    {
                        btnCancelar.IsEnabled = true;
                        Editando = true;
                    }
                }
            }
            else if (ClaveVacia)
            {
                if (btnAceptar != null)
                {
                    btnAceptar.IsEnabled = false;
                    Editando = false;
                }
                if (btnCancelar != null)
                {
                    btnCancelar.IsEnabled = false;
                    Editando = false;
                }
            }
            else if (Editando)
            {
                if (btnAceptar != null)
                {
                    if (IdPermiso == "2")
                    {
                        btnAceptar.IsEnabled = true;
                        Editando = true;
                    }
                }
                if (btnCancelar != null)
                {
                    if (IdPermiso == "2")
                    {
                        btnCancelar.IsEnabled = true;
                        Editando = true;
                    }
                }
            }
        }

        /// <summary>
        /// Método que inhabilita un DecimalTextBox cuando se llena otro
        /// </summary>
        /// <param name="txt1">DecimalTextBox que se está capturando</param>
        /// <param name="cmb">ComboBox a inhabilitar </param>
        /// <param name="txt2">DecimalTextBox a inhabilitar</param>
      
        public void EnableDisableTextboxCombo(DecimalTextBox txt1, ComboBox cmb ,DecimalTextBox txt2)
        {
            if (Convert.ToDecimal(txt1.Text == string.Empty ? "0.00" : txt1.Text) == 0)
            {
                if (txt2 != null)
                {
                    txt2.IsEnabled = false;
                    cmb.IsEnabled = false;
                    txt2.Text ="0.00";
                    cmb.SelectedIndex = -1;
                }
            }
            else
            {
                txt2.IsEnabled = true;
                cmb.IsEnabled = true;
            }
        }
        /// <summary>
        /// Método que inhabilita un DecimalTextBox cuando se llena otro
        /// </summary>
        /// <param name="txt1">DecimalTextBox que se está capturando</param>
        /// <param name="txt2">DecimalTextBox a inhabilitar</param>
        public void EnableDisableTextbox(DecimalTextBox txt1, DecimalTextBox txt2)
        {
            if (Convert.ToDecimal(txt1.Text == string.Empty ? "0" : txt1.Text) == 0)
            {
                if (txt2 != null)
                    txt2.IsEnabled = true;
            }
            else
            {
                txt2.IsEnabled = false;
            }
        }
        /// <summary>
        /// Método que inhabilita un CombotBox cuando se llena un DecimalTextBox
        /// </summary>
        /// <param name="txt1">DecimalTextBox que se está capturando</param>
        /// <param name="txt2">CombotBox a inhabilitar</param>
        public void EnableDisableComboBox(DecimalTextBox txt1, ComboBox cmb)
        {
            if (Convert.ToDecimal(txt1.Text == string.Empty ? "0" : txt1.Text)  ==0)
            {
                if (cmb != null)
                    cmb.IsEnabled = false;
            }
            else
            {
                cmb.IsEnabled = true;
            }
        }
        public void FillComboCveName(ref ComboBox cmb1, ref ComboBox cmb2, ComboFilter exp)
        {
            cmb1.SelectedValuePath = exp.ValueCombo1;
            cmb2.SelectedValuePath = exp.ValueCombo2;
            TextSearch.SetTextPath(cmb1, exp.TextSearchCombo1);
            TextSearch.SetTextPath(cmb2, exp.TextSearchCombo2);

            cmb1.DataContext = exp.Collection;
            cmb2.DataContext = exp.Collection;
            
        }
        public void FillComboCveName(ref ComboBox cmb1 ,ComboFilter exp)
        {
            cmb1.SelectedValuePath = exp.ValueCombo1;
           
            TextSearch.SetTextPath(cmb1, exp.TextSearchCombo1);
         
            cmb1.DataContext = exp.Collection;
        }
        public void FillComboCveName(ref ComboBox cmb1, ref ComboBox cmb2, ref ComboBox cmb3, ComboFilter exp)
        {
            cmb1.SelectedValuePath = exp.ValueCombo1;
            cmb2.SelectedValuePath = exp.ValueCombo2;
            cmb3.SelectedValuePath = exp.ValueCombo3;
            TextSearch.SetTextPath(cmb1, exp.TextSearchCombo1);
            TextSearch.SetTextPath(cmb2, exp.TextSearchCombo2);
            TextSearch.SetTextPath(cmb3, exp.TextSearchCombo3);
            cmb1.DataContext = exp.Collection;
            cmb2.DataContext = exp.Collection;
            cmb3.DataContext = exp.Collection;
        }
        /// <summary>
        /// Método que inhabilita un DecimalTextBox cuando se llena otro
        /// </summary>
        /// <param name="txt1">DecimalTextBox que se está capturando</param>
        /// <param name="txt2">DecimalTextBox a inhabilitar</param>
        public void EnableDisableTextbox2(DecimalTextBox txt1, TextBox txt2, Button btn1)
        {
            if (Convert.ToDecimal(txt1.Text == string.Empty ? "0.0000" : txt1.Text) == 0)
            {
                if (txt2 != null)
                    txt2.IsEnabled = false;
                if (btn1 != null)
                    btn1.IsEnabled = false;
            }
            else
            {
                txt2.IsEnabled = true;
                btn1.IsEnabled = true;
            }
        }
        #endregion

        #region Validaciones tipo control

        public void TextBoxDecimal_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //if (e.)
            Regex regex = new Regex(@"^([0-9]+([.]\d{0,2})?|0+([.]\d{0,2}))?$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }

        public void TextBoxNumeric_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox txtAux = sender as TextBox;
            Regex regex = new Regex(@"^[0-9]\d*$");
            e.Handled = !regex.IsMatch(txtAux.Text.Insert(txtAux.SelectionStart, e.Text.Trim()));
        }

        public void TextBoxNumeric_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            TextBox txtAux = sender as TextBox;
            if (txtAux.SelectionLength != txtAux.Text.Length)
            {
                if (e.Key == Key.Space)
                    e.Handled = true;
            }
        }

        public void TextBoxTelefono_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //if (e.)
            Regex regex = new Regex(@"^[0-9]\d*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }

        public void TextBoxTelefono_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            TextBox txtAux = sender as TextBox;
            if (txtAux.SelectionLength != txtAux.Text.Length)
            {
                if (e.Key == Key.Space)
                    e.Handled = true;
            }
        }
        #endregion

        #region Busqueda de controles en la ventana activa

        /// <summary>
        /// Encuentra un control dentro de una ventana.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parent"></param>
        /// <param name="childName"></param>
        /// <returns></returns>
        public static T FindChild<T>(DependencyObject parent, string childName = "") where T : DependencyObject
        {
            // Confirm parent and childName are valid. 
            if (parent == null) return null;

            T foundChild = null;

            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                // If the child is not of the request child type child
                T childType = child as T;
                if (childType == null)
                {
                    // recursively drill down the tree
                    foundChild = FindChild<T>(child, childName);

                    // If the child is found, break so we do not overwrite the found child. 
                    if (foundChild != null) break;
                }
                else if (!string.IsNullOrEmpty(childName))
                {
                    var frameworkElement = child as FrameworkElement;
                    // If the child's name is set for search
                    if (frameworkElement != null && frameworkElement.Name == childName)
                    {
                        // if the child's name is of the request name
                        foundChild = (T)child;
                        break;
                    }
                }
                else
                {
                    // child element found.
                    foundChild = (T)child;
                    break;
                }
            }

            return foundChild;
        }

        /// <summary>
        /// Cambia el texto default "Seleccione una fecha" en un DatePicker.
        /// </summary>
        /// <param name="sender">el control Datepicker</param>
        /// <param name="newText">Nuevo Texto</param>
        public static void CambiaTextoDatePicker(object sender, string newText)
        {
            var dp = sender as DatePicker;
            if (dp == null) return;

            var tb = FindChild<DatePickerTextBox>(dp);
            if (tb == null) return;

            //var wm = tb.Template.FindName("PART_Watermark", tb) as ContentControl;
           // if (wm == null) return;

           // wm.Content = newText;
        }

        public void DatePicker_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                CambiaTextoDatePicker(sender, string.Empty);
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex.Message, this.Title, MessageBoxButton.OK, MessageBoxImage.Error);
                messageBox.ShowDialog();
            }
        }

        #endregion

        #region Validación formatos

        #region RFC

        /// <summary>
        /// Función que valida el formato de tipo RFC 12 ó 13 caracteres
        /// </summary>
        /// <param name="strRfc"></param>
        /// <returns></returns>
        private static bool isRFC(string strRfc)
        {
            string lsPatron = @"^([a-zA-ZñÑ&]{3,4})(\d{2})((01|03|05|07|08|10|12)(0[1-9]|[12]\d|3[01])|02(0[1-9]|[12]\d)|(04|06|09|11)(0[1-9]|[12]\d|30))([a-zA-Z,0-9][a-zA-Z,0-9][0-9A])$";
            Regex loRE = new Regex(lsPatron);
            if (loRE.IsMatch(strRfc))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Función que valida el formato de tipo RFC 12 ó 13 y 10 caracteres
        /// </summary>
        /// <param name="strRfc"></param>
        /// <returns></returns>
        private static bool isRFC1012y13(string strRfc)
        {
            string lsPatron = strRfc.Length == 10 ? @"^[A-Z,Ñ,&]{4}[0-9]{2}[0-1][0-9][0-3][0-9]?" : @"^([a-zA-ZñÑ&]{3,4})(\d{2})((01|03|05|07|08|10|12)(0[1-9]|[12]\d|3[01])|02(0[1-9]|[12]\d)|(04|06|09|11)(0[1-9]|[12]\d|30))([a-zA-Z,0-9][a-zA-Z,0-9][0-9A])$";
            Regex loRE = new Regex(lsPatron);
            if (loRE.IsMatch(strRfc))
                return true;
            else
                return false;
        }

        #endregion

        #region CURP

        /// <summary>
        /// Valida el formato CURP
        /// </summary>
        /// <param name="strCurp"></param>
        /// <returns></returns>
        private static bool isCURP(string strCurp)
        {
            string lsPatron = @"^([a-zA-ZñÑ][aeiouxAEIOUX][a-zA-Z]{2})(\d{2})((01|03|05|07|08|10|12)(0[1-9]|[12]\d|3[01])|02(0[1-9]|[12]\d)|(04|06|09|11)(0[1-9]|[12]\d|30))([M,H])(AS|BC|BS|CC|CS|CH|CL|CM|DF|DG|GT|GR|HG|JC|MC|MN|MS|NT|NL|OC|PL|QT|QR|SP|SL|SR|TC|TS|TL|VZ|YN|ZS|NE)([B,C,D,F,G,H,J,K,L,M,N,Ñ,P,Q,R,S,T,V,W,X,Y,Z]{3})([0-9,A-Z][0-9])$";
            Regex loRE = new Regex(lsPatron);
            if (loRE.IsMatch(strCurp))
                return true;
            else
                return false;
        }

        #endregion

        #region Email

        /// <summary>
        /// Valida el formato EMail
        /// </summary>
        /// <param name="direccion"></param>
        /// <returns></returns>
        private bool isEMail(string direccion)
        {
            string expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(direccion, expresion))
            {
                if (Regex.Replace(direccion, expresion, string.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region tele

        /// <summary>
        /// Valida el formato Telefono
        /// </summary>
        /// <param name="Telefono"></param>
        /// <returns></returns>
        private bool isTelefono(string Telefono)
        {
            string expresion = "^+?d{1,3}?[- .]?(?(?:d{2,3}))?[- .]?ddd[- .]?dddd$ ";
            //string expresion = "\\[0-9]+([-+.']\\w+)*$";
            //"^[0-9]{3}$";
            //"^[+-]?\d+(\.\d+)?$";
            //"/^\d{9}$/";//@"^\d-\d{3}$";// @"^[^-][0-9]$";//"[-]?\d(\.\d)?$";// @"[0-9'-'+'.',']*/";
            if (Regex.IsMatch(Telefono, expresion))
            {
                if (Regex.Replace(Telefono, expresion, string.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        #endregion
        #endregion

        #region Metodos Auxiliares
        //public string ConsultaTipoCambio(TextBox TXTTipoCambio, DateTime FechaConsulta, string PerfilUsuario, bool ConexionDia)
        //{
        //    try
        //    {
        //        BRCatalogo cat = new BRCatalogo();
        //        Ent_Tipo_Cambio tip = new Ent_Tipo_Cambio();
        //        tip.Fecha = FechaConsulta;
        //        Respuesta<List<Ent_Tipo_Cambio>> restipocmb = cat.GetTiposCambio(tip);
        //        TipoCambioConsultado = string.Empty;
        //        double TipoCambDec = 0, TipoCamSita = 0;

        //        if (restipocmb.Resultado.Count > 0)
        //        {
        //            TipoCambioConsultado = restipocmb.Resultado[0].Tip_cam.ToString();
        //            TipoCamSita = Convert.ToDouble(TipoCambioConsultado);

        //            if (TipoCamSita > 0)
        //            {
        //                TipoCambioConsultado = TipoCamSita.ToString("00.0000");
        //                SinTipoCambioSita = false;

        //                if (ConexionDia)
        //                {
        //                    TXTTipoCambio.IsEnabled = false;
        //                }
        //                else if (PerfilUsuario != "Administrador")
        //                {
        //                    TXTTipoCambio.IsEnabled = false;
        //                }
        //            }
        //            else
        //            {
        //                if (IsLoaded)
        //                {
        //                    messageBox = new avisosis("No se encontró un Tipo de Cambio para esta Fecha", this.Title, MessageBoxButton.OK, MessageBoxImage.Warning);
        //                    messageBox.ShowDialog();
        //                    SinTipoCambioSita = true;
        //                }
        //                TipoCambioConsultado = TipoCambDec.ToString("00.0000");
        //                TXTTipoCambio.IsEnabled = true;
        //            }
        //        }
        //        else
        //        {
        //            if (IsLoaded)
        //            {
        //                messageBox = new avisosis("No se encontró un Tipo de Cambio para esta Fecha", this.Title, MessageBoxButton.OK, MessageBoxImage.Warning);
        //                messageBox.ShowDialog();
        //                SinTipoCambioSita = true;
        //            }
        //            TipoCambioConsultado = TipoCambDec.ToString("00.0000");
        //            TXTTipoCambio.IsEnabled = true;
        //        }

        //        return TipoCambioConsultado;
        //    }
        //    catch (Exception ex)
        //    {
        //        messageBox = new avisosis(ex, this.Title, MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
        //        return string.Empty;
        //    }
        //}

        //public void GuardarTipoDeCambio(decimal txttipocamb, DateTime dpEntr, string InsUPD, string UsuarioLogeo)
        //{
        //    try
        //    {
        //        Ent_Tipo_Cambio entalm = new Ent_Tipo_Cambio();
        //        Respuesta<int> res = new Respuesta<int>();
        //        BRCatalogo cat = new BRCatalogo();

        //        entalm.Tip_cam = txttipocamb;
        //        entalm.Fecha = dpEntr;

        //        entalm.Usumod = UsuarioLogeo;

        //        //si el tipo de cambio es diferente de 0.0000 lo guarda
        //        if (entalm.Tip_cam != 0)
        //        {
        //            res = cat.InsUpDelTipoCambio(entalm, InsUPD);

        //            if (res.EsExitoso)
        //            {
        //                messageBox = new avisosis("Se guardó este Tipo de Cambio para esta Fecha en Tipos de Cambio del Sistema", this.Title, MessageBoxButton.OK, MessageBoxImage.None);
        //                messageBox.ShowDialog();
        //            }
        //            else
        //            {
        //                messageBox = new avisosis("No se guardó este Tipo de Cambio en Tipos de Cambio del Sistema: " + res.Error, this.Title, MessageBoxButton.OK, MessageBoxImage.Error);
        //                messageBox.ShowDialog();
        //            }

        //            SinTipoCambioSita = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        messageBox = new avisosis(ex, this.Title, MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
        //    }
        //}
        //#region Obtiene consecutivo de pedimento
        //public string ObtieneConsecutivoPedimentoImp(string TipoOperacion)
        //{
        //    try
        //    {
        //        string NoPedimento = string.Empty;
        //        BRConfiguraciones conf = new BRConfiguraciones();
        //        Ent_Opciones_SAAI entopcsaai = new Ent_Opciones_SAAI();

        //        entopcsaai.Encabeza = Comunes.ENCABEZAGRID;
        //        entopcsaai.Elemento = OpcionesSAAI.CKCONSIMPEXP;
        //        //saai.Valor = string.Empty;
        //        Respuesta<List<Ent_Opciones_SAAI>> resaai = new Respuesta<List<Ent_Opciones_SAAI>>();
        //        resaai = conf.GetOpcSAAI(entopcsaai);

        //        if (resaai.EsExitoso && resaai.Resultado.Count > 0 && resaai.Resultado[0].Valor == "N")
        //        {
        //            entopcsaai.Encabeza = Comunes.ENCABEZAGRID;
        //            entopcsaai.Elemento = TipoOperacion == "1" ? OpcionesSAAI.TXTPEDIMP : OpcionesSAAI.TXTPEDEXP;
        //        }
        //        else
        //        {
        //            entopcsaai.Encabeza = Comunes.ENCABEZAGRID;
        //            entopcsaai.Elemento = OpcionesSAAI.TXTPEDIMP;
        //        }
        //        //if (resaai.Resultado[i].Elemento == OpcionesSAAI.CKCONSIMPEXP && resaai.Resultado[i].Valor != "N") ckConsImpExp.IsChecked = true;

        //        Respuesta<List<Ent_Opciones_SAAI>> respu3 = conf.GetOpcSAAI(entopcsaai);
        //        NoPedimento = respu3.Resultado[0].Valor;

        //        return NoPedimento;
        //    }
        //    catch (Exception ex)
        //    {
        //        messageBox = new avisosis(ex, this.Title, MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
        //        return string.Empty;
        //    }
        //}
        //#endregion

        //#region Actualiza consecutivo de pedimento
        //public void ActualizaConsecutivoPedimentoImp(string TipoOperacion, string NoPedimento)
        //{
        //    try
        //    {
        //      new Respuesta<int>();
        //        BRConfiguraciones conf = new BRConfiguraciones();
        //        Ent_Opciones_SAAI entopcsaai = new Ent_Opciones_SAAI();

        //        entopcsaai.Encabeza = Comunes.ENCABEZAGRID;
        //        entopcsaai.Elemento = OpcionesSAAI.CKCONSIMPEXP;
        //        //saai.Valor = string.Empty;
        //        Respuesta<List<Ent_Opciones_SAAI>> resaai = new Respuesta<List<Ent_Opciones_SAAI>>();
        //        resaai = conf.GetOpcSAAI(entopcsaai);

        //        entopcsaai.Encabeza = Comunes.ENCABEZAGRID;
        //        //Cuando sea el mismo consecutivo para ambos
        //        if (resaai.EsExitoso && resaai.Resultado.Count > 0 && resaai.Resultado[0].Valor == "N")
        //        {
        //            entopcsaai.Elemento = TipoOperacion == "1" ? OpcionesSAAI.TXTPEDIMP : OpcionesSAAI.TXTPEDEXP;
        //            entopcsaai.Valor = (Convert.ToInt32(NoPedimento) + 1).ToString();
        //            Respuesta<int> resSaai = conf.InsUpdDelOpcSAAI(entopcsaai, Comunes.CAMBIA);
        //        }
        //        else
        //        {
        //            entopcsaai.Elemento = OpcionesSAAI.TXTPEDIMP;
        //            entopcsaai.Valor = (Convert.ToInt32(NoPedimento) + 1).ToString();
        //            Respuesta<int> resSaai = conf.InsUpdDelOpcSAAI(entopcsaai, Comunes.CAMBIA);

        //            entopcsaai.Elemento = OpcionesSAAI.TXTPEDEXP;
        //            entopcsaai.Valor = (Convert.ToInt32(NoPedimento) + 1).ToString();
        //            resSaai = conf.InsUpdDelOpcSAAI(entopcsaai, Comunes.CAMBIA);
        //        }
                
        //    }
        //    catch (Exception ex)
        //    {
        //        messageBox = new avisosis(ex, this.Title, MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
        //    }
        //}
        //#endregion

        public void inhabilitaControles(Grid GRD, bool InhaDataGrid = true)
        {
            try
            {
                List<TextBox> controls = new List<TextBox>();
                controls = (List<TextBox>)Helper.GetChildObjects<TextBox>(GRD, "");

                foreach (TextBox item1 in controls)
                {
                    item1.IsEnabled = false;
                }


                List<NumericTextBox> numtxt = new List<NumericTextBox>();
                numtxt = (List<NumericTextBox>)Helper.GetChildObjects<NumericTextBox>(GRD, "");

                foreach (NumericTextBox item1 in numtxt)
                {
                    item1.IsEnabled = false;
                }

                List<DatePicker> dtpk = new List<DatePicker>();
                dtpk = (List<DatePicker>)Helper.GetChildObjects<DatePicker>(GRD, "");

                foreach (DatePicker item1 in dtpk)
                {
                    item1.IsEnabled = false;
                }

                List<DecimalTextBox> txdecs = new List<DecimalTextBox>();
                txdecs = (List<DecimalTextBox>)Helper.GetChildObjects<DecimalTextBox>(GRD, "");

                foreach (DecimalTextBox item1 in txdecs)
                {
                    item1.IsEnabled = false;
                }

                List<ADMIN2.Controls.MaskedTextBox> txtmasc = new List<ADMIN2.Controls.MaskedTextBox>();
                txtmasc = (List<ADMIN2.Controls.MaskedTextBox>)Helper.GetChildObjects<ADMIN2.Controls.MaskedTextBox>(GRD, "");

                foreach (ADMIN2.Controls.MaskedTextBox item1 in txtmasc)
                {
                    item1.IsEnabled = false;
                }

                List<Button> btns = new List<Button>();
                btns = (List<Button>)Helper.GetChildObjects<Button>(GRD, "");

                foreach (Button item2 in btns)
                {
                    item2.IsEnabled = false;
                }

                if (InhaDataGrid)
                {
                    List<DataGrid> grv = new List<DataGrid>();
                    grv = (List<DataGrid>)Helper.GetChildObjects<DataGrid>(GRD, "");

                    foreach (DataGrid item3 in grv)
                    {
                        item3.IsEnabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, this.Title, MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
            }
        }

        //public string ObtieneEstado(string Direntfed)
        //{
        //    try
        //    {
        //        if (EstadosRep == null)
        //        {
        //            BRCatalogo ct = new BRCatalogo();
        //            Ent_CodigosPost codPost = new Ent_CodigosPost();
        //            codPost.Opc = Comunes.ESTADOS;
        //            EstadosRep = ct.NGetCodigosPost(codPost);
        //        }

        //        var rfclst = EstadosRep.Resultado.Where(x => x.EDOCVE == Direntfed).ToList();

        //        if (rfclst.Count > 0)
        //        {
        //            return rfclst.FirstOrDefault().D_estado;
        //        }
        //        else
        //        {
        //            return "-";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        messageBox = new avisosis(ex, this.Title, MessageBoxButton.OK, MessageBoxImage.Error);
        //        messageBox.ShowDialog();
        //        return "-";
        //    }
        //}

        //public string ObtienePais(string Cvepais)
        //{
        //    try
        //    {
        //        if (Paises == null)
        //        {
        //            Ent_Paises Entpais = new Ent_Paises();
        //            BRCatalogo ct = new BRCatalogo();
        //            Paises = ct.NGetPaises(Entpais);
        //        }

        //        var rfclst = Paises.Resultado.Where(x => x.Cve_pais == Cvepais).ToList();

        //        if (rfclst.Count > 0)
        //        {
        //            return rfclst.FirstOrDefault().Pais;
        //        }
        //        else
        //        {
        //            return "-";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        messageBox = new avisosis(ex, this.Title, MessageBoxButton.OK, MessageBoxImage.Error);
        //        messageBox.ShowDialog();
        //        return "-";
        //    }
        //}

        //public void generarBitacora(string llave, string concepto, string IdUsusario)
        //{
        //    try
        //    {
        //        BRCatalogo ct = new BRCatalogo();
        //        Ent_Bitacora_Sis bitacora = new Ent_Bitacora_Sis();
        //        bitacora.llave = llave;
        //        bitacora.concepto = concepto;
        //        bitacora.usuariored = Environment.MachineName;
        //        bitacora.hora = DateTime.Today.Hour + ":" + DateTime.Today.Minute + ":" + DateTime.Today.Second;
        //        bitacora.usuariosis = IdUsusario;
        //        ct.InsUpDelBitacoraSis(bitacora);

        //    }
        //    catch (Exception ex)
        //    {
        //        messageBox = new avisosis(ex, this.Title, MessageBoxButton.OK, MessageBoxImage.Error);
        //        messageBox.ShowDialog();
        //    }
        //}
        public void llenarFechaAgregadoExpD(DateTime fecha)
        {
            fechaAgregadoExpDig = fecha;
        }

        public void agregarArchivoExpDig(string ruta, string archivo, string refe, int sub, string ped, string tipo, string ext,string cve_imp)
        {
            string nomArch = "";
            string path = System.Windows.Forms.Application.StartupPath;
            System.Uri resourceLocater = new System.Uri(path, System.UriKind.Relative);
            if (!File.Exists(resourceLocater + "/ExpedienteDigital.zip"))
            {
                Directory.CreateDirectory(resourceLocater+"/Expediente");
                using (ZipFile zip2 = new ZipFile())
                {
                    zip2.AddDirectory(resourceLocater + "/Expediente");
                    zip2.Save(resourceLocater + "/ExpedienteDigital.zip");
                    Directory.Delete(resourceLocater + "/Expediente",true);
                }                

            }
                       
            ZipFile zip = ZipFile.Read(resourceLocater + "/ExpedienteDigital.zip");
            try
            {
                
                if (fechaAgregadoExpDig == DateTime.MinValue)
                {
                    fechaAgregadoExpDig = DateTime.Now;
                }
                
                    if (!ext.ToLower().Contains(".txt") && !ext.ToLower().Contains(".pdf") && !ext.ToLower().Contains(".xls") &&
                        !ext.ToLower().Contains(".xlsx") && !ext.ToLower().Contains(".doc") && !ext.ToLower().Contains(".docx")
                        && !ext.ToLower().Contains(".png") && !ext.ToLower().Contains(".jpg") && !ext.ToLower().Contains(".jpeg")
                        && !ext.ToLower().Contains(".gif") && ext != "" && ext != ".otro")
                    {
                        ext = ".txt";
                    }
                    string numref = "";
                    if (refe.Contains("_") || refe.Contains("-"))
                    {
                        numref = refe.Replace("_", "");
                        numref = numref.Replace("-", "");
                    }
                    else
                    {
                        numref = refe;
                    }
                    if (ext == ".otro")
                    {
                        nomArch = tipo;
                    }
                    else
                    {
                        nomArch = numref + "_" + sub + "_" + ped + tipo + ext;
                    }
                    
                    if (File.Exists(ruta + archivo))
                    {
                        File.Copy(ruta + archivo, resourceLocater + "/" + nomArch);
                    }

                    int rompe2 = 0;
                    foreach (ZipEntry fi in zip)
                    {
                       
                        if (fi.FileName == cve_imp + "/" + fechaAgregadoExpDig.Year + "/" + fechaAgregadoExpDig.Month + "/" + refe + "/" + nomArch)
                        {
                            rompe2 = 1;
                        }
                        else
                        {
                            rompe2 = 2;
                       }
                        if(rompe2==1)
                        {
                           
                            fi.Extract(resourceLocater+"/", ExtractExistingFileAction.OverwriteSilently);                                                     
                            break;
                        }

                    }
                    if (rompe2 == 2)
                    {
                        Directory.CreateDirectory(resourceLocater + "/" + cve_imp);
                       
                        
                    }
                    if (rompe2 ==0)
                    {
                        Directory.CreateDirectory(resourceLocater + "/" + cve_imp);

                    }
                    if (File.Exists(resourceLocater + "/"+cve_imp + "/" + fechaAgregadoExpDig.Year + "/" + fechaAgregadoExpDig.Month + "/" + refe + "/" + nomArch))
                    {                        
                        File.Copy(resourceLocater + "/"+nomArch, resourceLocater + "/" + cve_imp + "/"+ fechaAgregadoExpDig.Year + "/" + fechaAgregadoExpDig.Month + "/" + refe + "/" + nomArch,true);
                        zip.RemoveEntry(cve_imp + "/" + fechaAgregadoExpDig.Year + "/" + fechaAgregadoExpDig.Month + "/" + refe + "/" + nomArch);
                        zip.AddFile(cve_imp + "/" + fechaAgregadoExpDig.Year + "/" + fechaAgregadoExpDig.Month + "/" + refe + "/" + nomArch, cve_imp + "/" + fechaAgregadoExpDig.Year + "/" + fechaAgregadoExpDig.Month + "/" + refe + "/");
                        zip.Save();
                        zip.Dispose();
                       // File.Delete(resourceLocater + "/" + cve_imp + "/" + nomArch);
                        File.Delete(resourceLocater + "/" + nomArch);
                        Directory.Delete(resourceLocater + "/" + cve_imp, true);                       
                    }
                    else 
                    {
                        zip.AddFile(resourceLocater + "/" + nomArch, cve_imp + "/" + fechaAgregadoExpDig.Year + "/" + fechaAgregadoExpDig.Month + "/" + refe + "/");
                        zip.Save();
                        zip.Dispose();
                        File.Delete(resourceLocater + "/" + nomArch);
                        Directory.Delete(resourceLocater + "/" + cve_imp, true);                                              
                    }
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, "Expediente Digital", MessageBoxButton.OK, MessageBoxImage.Error);
                messageBox.ShowDialog();
                File.Delete(resourceLocater + "/" + nomArch);
                Directory.Delete(resourceLocater + "/" + cve_imp, true);
            }
        }
        #endregion
    }

    public class ComboFilter
    {
        public string ValueCombo1 { get; set; }
        public string ValueCombo2 { get; set; }
        public string ValueCombo3 { get; set; }
        public string TextSearchCombo1 { get; set; }
        public string TextSearchCombo2 { get; set; }
        public string TextSearchCombo3 { get; set; }
        public object Collection { get; set; }
    }
}
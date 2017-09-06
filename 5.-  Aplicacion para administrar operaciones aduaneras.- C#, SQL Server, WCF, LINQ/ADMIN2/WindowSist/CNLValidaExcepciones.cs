using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ADMIN2.WindowSist
{
    public class CNLValidaExcepciones
    {
        private string _Texto;
        private string _TextoDetalle;

        public CNLValidaExcepciones()
        {
            try
            {
                _Texto = "";
                _TextoDetalle = "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CNLValidaExcepciones(Exception _Excepcion)
        {
            try
            {
                _Texto = "Ha ocurrido un error inesperado: " + _Excepcion.Message;
                _TextoDetalle = _Excepcion.Message.ToString() + "\n" +
                                _Excepcion.Source.ToString() + "\n" +
                                _Excepcion.TargetSite.DeclaringType.FullName.ToString() + "\n" +
                                _Excepcion.TargetSite.DeclaringType.FullName.ToString() + _Excepcion.StackTrace.ToString() + "\n" +
                                _Excepcion.TargetSite.ToString() + "\n" +
                                _Excepcion.TargetSite.Module.ToString() + " -> "
                                                                        + _Excepcion.Source.ToString()
                                                                        + " -> "
                                                                        + _Excepcion.TargetSite.DeclaringType.FullName.ToString()
                                                                        + " -> "
                                                                        + _Excepcion.TargetSite.Name.ToString()
                                                                        + " -> "
                                                                        + _Excepcion.TargetSite.ReflectedType.FullName.ToString()
                                                                        + " ";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public MessageBoxResult ShowMessageGral(string _Texto, MessageBoxImage _Imagen)
        {
            try
            {
                string sCaption =
                    _Imagen.Equals(MessageBoxImage.Question) ? "Confirmación" :
                    _Imagen.Equals(MessageBoxImage.Error) ? "Error" :
                    _Imagen.Equals(MessageBoxImage.Information) ? "Información" : "Validación";
                MessageBoxButton msgBut =
                    _Imagen.Equals(MessageBoxImage.Question) ? MessageBoxButton.YesNo : MessageBoxButton.OK;
                if (_Imagen.Equals(MessageBoxImage.Error)) _Texto = "Ha ocurrido un error inesperado " + _Texto;
                return MessageBox.Show(_Texto, sCaption, msgBut, _Imagen);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string Texto
        {
            set { _Texto = value; }
            get { return _Texto; }
        }
        public string TextoDetalle
        {
            set { _TextoDetalle = value; }
            get { return _TextoDetalle; }
        }
    }
}

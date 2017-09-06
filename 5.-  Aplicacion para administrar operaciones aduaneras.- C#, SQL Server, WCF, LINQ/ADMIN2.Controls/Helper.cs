using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ADMIN2.Controls
{
    public static class Helper
    {

        #region [metodos extensores]

        /// <summary>
        /// Metodo extensor para obtener una lista de hijos en el arbol visual del objeto especificado.
        /// </summary>
        /// <typeparam name="T">Tipo de control que quiere obtenerse</typeparam>
        /// <param name="_obj">objeto de dependencia en el cual se buscara</param>
        /// <param name="_name">nombre del control/controles a buscar</param>
        /// <returns>
        /// lista del tipo de control a buscar con todos los controles coincidentes con el nombre y tipo. 
        /// null en caso de no encontrar ninguno
        /// </returns>
        public static List<T> GetChildObjects<T>(this DependencyObject _obj, string _name)
        {
            var retVal = new List<T>();
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(_obj); i++)
            {
                object c = VisualTreeHelper.GetChild(_obj, i);
                if (c.GetType().FullName == typeof(T).FullName && (String.IsNullOrEmpty(_name) || ((FrameworkElement)c).Name == _name))
                {
                    retVal.Add((T)c);
                }
                var gc = ((DependencyObject)c).GetChildObjects<T>(_name);
                if (gc != null)
                    retVal.AddRange(gc);
            }

            return retVal;
        }

        /// <summary>
        /// Metodo extensor para obtener un hijo en el arbol visual del objeto especificado.
        /// </summary>
        /// <typeparam name="T">Tipo de control que quiere obtenerse</typeparam>
        /// <param name="_obj">objeto de dependencia en el cual se buscara</param>
        /// <param name="_name">nombre del control a buscar</param>
        /// <returns>control coincidentes con el nombre y tipo. null en caso de no encontrarlo</returns>
        public static T GetChildObject<T>(this DependencyObject _obj, string _name) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(_obj); i++)
            {
                object c = VisualTreeHelper.GetChild(_obj, i);
                if (c.GetType().FullName == typeof(T).FullName && (String.IsNullOrEmpty(_name) || ((FrameworkElement)c).Name == _name))
                {
                    return (T)c;
                }
                object gc = ((DependencyObject)c).GetChildObject<T>(_name);
                if (gc != null)
                    return (T)gc;
            }

            return null;
        }

        #endregion [metodos extensores]
    }
}

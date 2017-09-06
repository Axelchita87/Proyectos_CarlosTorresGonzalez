using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Presentation.Base
{
    /// <summary>
    /// 
    /// </summary>
    public static class EntitieFactory
    {

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Create<T>() where T : new()
        {
            return new T();
        }

    }
}

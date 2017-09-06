using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace MyCTS.Presentation
{
    public class firstValidations
    {
        
        static private string[] availability;
        static public string[] Availability
        {
            get { return availability; }
            set { availability = value; }
        }

        private void clear()
        {
            
        }
    }
}

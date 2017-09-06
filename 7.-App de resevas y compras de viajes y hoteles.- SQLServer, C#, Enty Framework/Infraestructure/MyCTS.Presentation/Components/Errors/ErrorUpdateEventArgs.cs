using System;
using System.Collections.Generic;
using System.Text;
using MyCTS.Components;
using System.Windows.Forms;




namespace MyCTS.Presentation.Components
{
    public class ErrorUpdateEventArgs
    {
        public delegate void txtErrorHandler(string errorValue);
        static public txtErrorHandler ErrorAssign;
    }

    


}

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MyCTS.Presentation.Components
{
    public class ResizeSplitUpdateEventArgs
    {
        public delegate void ResizeSplittHandler(int size); 
        static public ResizeSplittHandler DoResize;

      
       
       


       

        //Modulo Activo
        static private string moduleActive;
        static public string ModuleActive
        {
            get { return moduleActive; }
            set { moduleActive = value; }
        }

        //Nombre de UserControl
        static private string ucname;
        static public string UcName
        {
            get { return ucname; }
            set { ucname = value; }
        }

        static private string ucactivated;
        static public string UcActivated
        {
            get { return ucactivated; }
            set { ucactivated = value; }
        }




        // indica si el esplit sera restaurado
        static private string restore;
        static public string Restore
        {
            get { return restore; }
            set { restore = value; }
        }


        // indica si sera maximizado el esplit
        static private string maximize;
        static public string Maximize
        {
            get { return maximize; }
            set { maximize = value; }
        }

        
      
        
    }
}

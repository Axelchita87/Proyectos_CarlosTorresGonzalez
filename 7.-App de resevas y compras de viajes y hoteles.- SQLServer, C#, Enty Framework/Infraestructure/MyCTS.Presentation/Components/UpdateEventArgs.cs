using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Presentation.Components
{
    public class UpdateEventArgs: EventArgs
    {
        private string[] objets;
        //constructor
        public UpdateEventArgs(params string[] obj)
        {
            int len = obj.Length;
            this.objets = new string[len];

            for (int i = 0; i < len; i++)
                this.objets[i] = obj[i];

        }
        public string[] Objets
        {
            get { return this.objets; }
 
        }

    }
}

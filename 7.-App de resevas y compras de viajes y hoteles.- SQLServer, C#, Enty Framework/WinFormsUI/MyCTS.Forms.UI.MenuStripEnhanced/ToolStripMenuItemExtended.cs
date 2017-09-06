using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace MyCTS.Forms.UI
{
    public class ToolStripMenuItemExtended : ToolStripMenuItem
    {

        private string m_value;
        public string Value
        {
            get { return m_value; }
            set { m_value = value; }
        }

        private void InitializeComponent()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.ErrorRecovery
{
    public partial class ucVolarisErrorRecovery : UserControl
    {
        public ucVolarisErrorRecovery()
        {
            InitializeComponent();

        }

        /// <summary>
        /// 
        /// </summary>
        private string _error;

        /// <summary>
        /// Gets or sets the error.
        /// </summary>
        /// <value>
        /// The error.
        /// </value>
        public string Error
        {
            get
            {
                return _error;

            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _error = value;
                    this.label2.Text = _error;

                }
            }
        }


        public event EventHandler Retry;
        private void optionOne_Click(object sender, EventArgs e)
        {
            if (Retry != null)
            {
                Retry(this, e);
            }
        }
        public event EventHandler Cancel;
        private void option_Click(object sender, EventArgs e)
        {
            if (Cancel != null)
            {
                Cancel(this, e);
            }
        }




    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Components;
using System.Windows.Forms;

namespace MyCTS.Presentation.Reservations.Availability.InterJet.Handlers
{
    public class InterJetUserControlHandler
    {

        /// <summary>
        /// Gets or sets the user control.
        /// </summary>
        /// <value>
        /// The user control.
        /// </value>
        public CustomUserControl UserControl
        {
            get;
            set;
        }

        public ToolTip _toolTiper;

        public ToolTip ToolTiper
        {
            get
            {
                return _toolTiper ?? (_toolTiper = new ToolTip
                                                       {

                                                           InitialDelay = 0
                                                       });
            }
        }


        public ErrorProvider _errorProvider;

        public ErrorProvider ErrorProvider
        {
            get
            {

                return _errorProvider ?? (_errorProvider = new ErrorProvider
                                                                 {



                                                                 });
            }
        }

        /// <summary>
        /// Gets the name of the label by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public Label GetLabelByName(string name)
        {
            return this.GetControlByName(name) as Label;
        }



        /// <summary>
        /// Gets the name of the combo box by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public ComboBox GetComboBoxByName(string name)
        {

            return this.GetControlByName(name) as ComboBox;
        }

        /// <summary>
        /// Gets the name of the text box by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public TextBox GetTextBoxByName(string name)
        {
            return this.GetControlByName(name) as TextBox;
        }

        /// <summary>
        /// Gets the name of the check box by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public CheckBox GetCheckBoxByName(string name)
        {

            return this.GetControlByName(name) as CheckBox;
        }
        /// <summary>
        /// Gets the name of the panel by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public Panel GetPanelByName(string name)
        {
            return this.GetControlByName(name) as Panel;
        }


        /// <summary>
        /// Gets the name of the group box by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public GroupBox GetGroupBoxByName(string name)
        {
            return this.GetControlByName(name) as GroupBox;
        }
        /// <summary>
        /// Gets the name of the control by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public Control GetControlByName(string name)
        {

            Control theControl = this.UserControl.Controls.Find(name, true).FirstOrDefault() as Control;

            if (theControl != null)
            {
                return theControl;
            }
            return new Control();

        }
    }
}

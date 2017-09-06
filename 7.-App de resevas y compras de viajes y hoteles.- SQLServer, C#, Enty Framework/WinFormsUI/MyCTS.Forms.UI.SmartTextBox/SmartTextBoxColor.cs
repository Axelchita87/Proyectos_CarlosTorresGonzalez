using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MyCTS.Forms.UI
{
    public class SmartTextBoxColor : ISmartTextBox
    {
        private SmartTextBox m_mySmartTextBox;
        public SmartTextBox MySmartTextBox
        {
            get { return m_mySmartTextBox; }
            set { m_mySmartTextBox = value; }
        }

        public SmartTextBoxColor() { }

        public SmartTextBoxColor(SmartTextBox mySmartTextBox, Color enterColor, Color leaveColor)
        {
            this.MySmartTextBox = mySmartTextBox;
            this.EnterColor = enterColor;
            this.LeaveColor = leaveColor;            
        }
        public SmartTextBoxColor(SmartTextBox objTextBox, Color enterColor)
        {
            this.MySmartTextBox = objTextBox;
            this.EnterColor = enterColor;
            this.LeaveColor = Color.White;
        }      


        #region ISmartTextBox Members
        private Color m_leaveColor;
        public Color LeaveColor
        {
            get
            {
                return m_leaveColor;
            }
            set
            {
                m_leaveColor = value;
            }
        }

        private Color m_enterColor;
        public Color EnterColor
        {
            get
            {
                return m_enterColor;
            }
            set
            {
                m_enterColor = value;
            }
        }

        #endregion
    }
}

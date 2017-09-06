using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;

namespace MyCTS.Forms.UI
{
    public class SmartTextBox : TextBox, ISmartTextBox
    {
        public enum CriteriaFields
        {
            AnyCharacter = 0,
            OnlyLetters = 1,
            OnlyNumbers = 2,
            NumbersOrLetters = 3,
            Custom = 4
        }
        private string m_customExpression;
        private bool m_allowBlankSpaces = true;
        private char[] m_charsIncluded;
        private char[] m_charsNoIncluded;
        private Control m_nextControl;
        private Dictionary<string, Regex> CurrentCriteriaExpression;
        private CriteriaFields m_currentCriteria;

        private bool m_TextPasted = false;
        private bool m_TextCopied = false;

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

        [Description("Indica cual es el control siguiente en caso de que sea automático"),
      Category("Custom"), DefaultValue("True")]
        public bool AllowBlankSpaces
        {
            get { return m_allowBlankSpaces; }
            set { m_allowBlankSpaces = value; }
        }

        [Description("Indica cual es el control siguiente en caso de que sea automático"),
        Category("Custom"), DefaultValue(null)]
        public Control NextControl
        {
            get { return m_nextControl; }
            set { m_nextControl = value; }
        }

        [Description("Tipo de Texto valido para el Campo"),
        Category("Custom"), DefaultValue("AnyCharacter")]
        public CriteriaFields CurrentCriteria
        {
            get { return m_currentCriteria; }
            set { m_currentCriteria = value; }
        }

        [Description("Define caracteres permitidos (independiente del criterio seleccionado)"),
        Category("Custom"), DefaultValue(null),]
        public char[] CharsIncluded
        {
            get { return m_charsIncluded; }
            set { m_charsIncluded = value; }

        }

        [Description("Define caracteres no permitidos (independiente del criterio seleccionado)"),
        Category("Custom"), DefaultValue(null),]
        public char[] CharsNoIncluded
        {
            get { return m_charsNoIncluded; }
            set { m_charsNoIncluded = value; }

        }
        [Description("Define expresion regular personalizada por el usuario"),
        Category("Custom"), DefaultValue(null),]
        public string CustomExpression
        {
            get { return m_customExpression; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    m_customExpression = value;
                    if (!string.IsNullOrEmpty(m_customExpression))
                    {
                        CurrentCriteriaExpression["MyExpression"] = new Regex(m_customExpression);
                    }
                }
            }
        }

        public SmartTextBox()
        {
            m_customExpression = ".*";
            CurrentCriteriaExpression = new Dictionary<string, Regex>();
            //CurrentCriteriaExpression.Add("AnyCharacter", new Regex(@"^\s*$"));
            CurrentCriteriaExpression.Add("AnyCharacter", new Regex(@"^(\W*$)|(\w*$)"));
            CurrentCriteriaExpression.Add("OnlyNumbers", new Regex(@"^-?\d\d*$"));
            CurrentCriteriaExpression.Add("OnlyLetters", new Regex(@"^([A-Za-z])*$"));
            CurrentCriteriaExpression.Add("NumbersOrLetters", new Regex(@"^([0-9a-zA-Z])*$"));
            CurrentCriteriaExpression.Add("Custom", new Regex(m_customExpression));
            this.CharacterCasing = CharacterCasing.Upper;
        }

        private bool IsCharAllowed(char keyChar)
        {
            if ((m_charsIncluded == null) || (!(m_charsIncluded.Length > 0)))
                return false;

            foreach (char c in m_charsIncluded)
            {
                if (c.ToString().ToUpper().Equals(keyChar.ToString().ToUpper()))
                    return true;
            }

            return false;

        }

        private bool IsCharNotAllowed(char keyChar)
        {
            if ((m_charsNoIncluded == null) || (!(m_charsNoIncluded.Length > 0)))
                return false;

            foreach (char c in m_charsNoIncluded)
            {
                if (c.ToString().ToUpper().Equals(keyChar.ToString().ToUpper()))
                    return true;
            }

            return false;
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (m_TextPasted)
            {
                string valueText = this.Text;
                if (!CurrentCriteriaExpression[m_currentCriteria.ToString()].IsMatch(valueText))
                {
                    this.Text = string.Empty;
                    MessageBox.Show("El formato de texto a pegar es inválido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                m_TextPasted = false;
            }

            if (m_TextCopied)
                m_TextCopied = false;

            base.OnKeyUp(e);

        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.V))
                m_TextPasted = true;
            if ((e.KeyData == (Keys.Control | Keys.C)) | (e.KeyData == (Keys.Control | Keys.X)))
                m_TextCopied = true;
            base.OnKeyDown(e);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if ((m_TextPasted) | (m_TextCopied))
                return;  

            int keyCode = (int)e.KeyChar;

            if ((!(AllowBlankSpaces)) && (keyCode == 32))
            {
                e.Handled = true;
                return;
            }

            if (keyCode == 8 | keyCode == 13 || keyCode == 32 || (m_currentCriteria.ToString() == "AnyCharacter"))
            {
                base.OnKeyPress(e);
                return;
            }

            if ((keyCode == 241) | (keyCode == 209))
            {
                e.Handled = true;
                return;
            }

            char currentKeyChar = char.Parse(e.KeyChar.ToString().ToUpper());

            if (IsCharAllowed(currentKeyChar))
                return;

            if (IsCharNotAllowed(currentKeyChar))
            {
                e.Handled = true;
                return;
            }

            //string valueText = this.Text.Replace("\r", string.Empty).Replace("\n", string.Empty) + e.KeyChar.ToString();
            string valueText = currentKeyChar.ToString();
            if (!CurrentCriteriaExpression[m_currentCriteria.ToString()].IsMatch(valueText))
            {
                e.Handled = true;
                return;
            }



        }
    }
}
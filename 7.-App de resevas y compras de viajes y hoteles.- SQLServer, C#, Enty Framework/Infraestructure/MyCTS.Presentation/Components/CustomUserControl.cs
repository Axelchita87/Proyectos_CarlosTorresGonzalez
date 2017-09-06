using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;
using MyCTS.Forms.UI;
using MyCTS.Business;

namespace MyCTS.Presentation.Components
{
    public class CustomUserControl : UserControl
    {
        private string[] m_parameters;
        /// <summary>
        /// Propiedad para el paso de parámetros entre User Controls
        /// </summary>
        public string[] Parameters
        {
            get { return m_parameters; }
            set { m_parameters = value; }
        }

        public object Parameter
        {
            set;
            get;
        }

        public object Data { get; set; }



        #region Asignación de colores al obtener y perder el foco


        private bool m_lightingTextBox = true;
        /// <summary>
        /// Propiedad para controlar si se aplica la asignación de colores al obtener y perder
        /// el foco en todos los textbox del User Control actual 
        /// </summary>
        public bool LightingTextBox
        {

            get { return m_lightingTextBox; }
            set { m_lightingTextBox = value; }
        }

        /// <summary>
        /// Asigna a un conjunto de objetos TextBox la funcionalidad
        /// de color al perder o tener el foco
        /// </summary>
        /// <param name="items">Lista de elementos TextBox</param>
        public void SetCustomTextBoxColors(List<SmartTextBoxColor> items)
        {
            foreach (SmartTextBoxColor item in items)
            {
                SmartTextBox txt = item.MySmartTextBox;
                if (txt == null) return;
                txt = this.Controls.Find(txt.Name, true)[0] as SmartTextBox;
                txt.EnterColor = item.EnterColor;
                txt.Enter += new EventHandler(txt_Enter);
                txt.LeaveColor = item.LeaveColor;
                txt.BackColor = item.LeaveColor;
                txt.Leave += new EventHandler(txt_Leave);
            }
        }
        /// <summary>
        /// Asigna a un objeto textbox la funcionalidad
        /// de color al perder o tener el foco
        /// </summary>
        /// <param name="item">Elemento TextBox de tipo SmartTextboxColor</param>
        public void SetCustomTextBoxColors(SmartTextBoxColor item)
        {
            SmartTextBox txt = item.MySmartTextBox;
            if (txt == null) return;
            txt = this.Controls.Find(txt.Name, true)[0] as SmartTextBox;
            txt.EnterColor = item.EnterColor;
            txt.Enter += new EventHandler(txt_Enter);
            txt.LeaveColor = item.LeaveColor;
            txt.BackColor = item.LeaveColor;
            txt.Leave += new EventHandler(txt_Leave);
        }

        private void SetColorTextBox(Control ctls)
        {
            foreach (Control c in ctls.Controls)
            {
                if (c is SmartTextBox)
                {
                    SmartTextBox txt = c as SmartTextBox;
                    if (txt == null) continue;
                    txt.EnterColor = Color.FromName(Resources.Constants.TEXTBOX_ENTER_COLOR);
                    txt.Enter += new EventHandler(txt_Enter);
                    txt.LeaveColor = Color.FromName(Resources.Constants.TEXTBOX_LEAVE_COLOR);
                    txt.BackColor = txt.LeaveColor;
                    txt.Leave += new EventHandler(txt_Leave);
                }
                if (c.HasChildren)
                    SetColorTextBox(c);
            }
        }

        private void txt_Enter(object sender, EventArgs e)
        {
            SmartTextBox txtBoxLocal = sender as SmartTextBox;
            txtBoxLocal.BackColor = txtBoxLocal.EnterColor;
        }
        private void txt_Leave(object sender, EventArgs e)
        {
            SmartTextBox txtBoxLeave = sender as SmartTextBox;
            txtBoxLeave.BackColor = txtBoxLeave.LeaveColor;
        }
        #endregion

        #region Control de tabulador
        private Control m_initialcontrolfocus;
        public Control InitialControlFocus
        {
            get { return m_initialcontrolfocus; }
            set { m_initialcontrolfocus = value; }
        }

        private Control m_lastcontrolfocus;
        public Control LastControlFocus
        {
            get { return m_lastcontrolfocus; }
            set { m_lastcontrolfocus = value; }
        }

        protected override bool ProcessTabKey(bool forward)
            {

            if (m_initialcontrolfocus != null && m_lastcontrolfocus != null)
            {
                Type initialControlType = m_initialcontrolfocus.GetType();
                Type lastControlType = m_lastcontrolfocus.GetType();

                if (this.ActiveControl.GetType() == lastControlType)
                {
                    Control c = this.ActiveControl;
                    if (c.Name == m_lastcontrolfocus.Name)
                    {
                        c = m_initialcontrolfocus;
                        c.Select();
                        //TextBox txtTemp = m_initialcontrolfocus as TextBox;
                        //txtTemp.Select();
                        return forward;
                    }

                }
            }
            return base.ProcessTabKey(forward);
        }
        #endregion

        /// <summary>
        /// Sobre carga del Evento Load para configuración de controls
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            if (m_lightingTextBox)
                SetColorTextBox(this);

            SetListBox(this);
            SetEnterEventTextBox(this);
            
            try
            {
                Common.LogApplicationItem.UserControlName = this.Name;
                base.OnLoad(e);                
            }
            catch (Exception ex)
            {
                try
                {
                    Common.LogApplicationItem.ErrorDescription = "Error al cargar User Control " + ex.ToString();
                    Common.LogApplicationItem.StackTrace = ex.StackTrace;
                    LogsApplicationBL.AddLogApplication(Common.LogApplicationItem);
                }
                catch { }
            }
        }

        public Color GetCalendarColor
        {
            get 
            {
                return Color.FromArgb(Int32.Parse(Resources.Constants.CALENDAR_RED),
                    Int32.Parse(Resources.Constants.CALENDAR_GREEN),
                    Int32.Parse(Resources.Constants.CALENDAR_BLUE));
            }
        }

        #region Esconde listbox de textos predictivos

        private List<ListBox> lbCollection = new List<ListBox>();
        /// <summary>
        /// Busca todos los ListBox dentro del Usercontrol
        /// Si la propiedad Tag contiene algo no se validará para los predictivos
        /// </summary>
        /// <param name="ctls"></param>
        private void SetListBox(Control ctls)
        {
            foreach (Control c in ctls.Controls)
            {
                if (c is ListBox)
                {
                    ListBox lb = c as ListBox;
                    if (lb.Tag != null)
                        if (!(string.IsNullOrEmpty(lb.Tag.ToString())))
                            continue;
                    lbCollection.Add(lb);
                }
                if (c.HasChildren)
                    SetListBox(c);
            }
        }

        /// <summary>
        /// Asigna el evento "Enter" a los controles para esconder los listbox 
        /// que hayan sido marcados como predictivos
        /// </summary>
        /// <param name="ctls"></param>
        private void SetEnterEventTextBox(Control ctls)
        {
            foreach (Control c in ctls.Controls)
            {
                if (c is ListBox)
                {
                    ListBox lb = c as ListBox;
                    if (lb.Tag != null)
                        if (!(string.IsNullOrEmpty(lb.Tag.ToString())))
                        c.Enter += new EventHandler(c_Enter);
                    else
                    {
                        lb.BringToFront();
                    }

                }
                else
                {
                    c.Enter += new EventHandler(c_Enter);
                    if (c.HasChildren)
                        SetListBox(c);
                }

            }
        }

        void c_Enter(object sender, EventArgs e)
        {
            if (lbCollection.Count > 0)
            {
                foreach (ListBox lb in lbCollection)
                    lb.Visible = false;
            }
        }
        #endregion

        protected override void Dispose(bool disposing)
        {
            MyCTS.Business.ObjectsBL.ClearObjects();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // CustomUserControl
            // 
            this.Name = "CustomUserControl";
            this.Load += new System.EventHandler(this.CustomUserControl_Load);
            this.ResumeLayout(false);

        }

        private void CustomUserControl_Load(object sender, EventArgs e)
        {

        }


    }
}

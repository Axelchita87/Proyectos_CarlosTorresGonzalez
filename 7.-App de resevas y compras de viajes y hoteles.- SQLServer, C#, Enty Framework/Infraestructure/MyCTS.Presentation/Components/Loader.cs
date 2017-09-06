using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace MyCTS.Presentation.Components
{
    public class Loader
    {
        public static string NAMESPACEDEFAULT = "MyCTS.Presentation.";

        public static Form GetReferenceForm(string formName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            formName = NAMESPACEDEFAULT + formName;

            return assembly.CreateInstance(formName) as Form;
        }

        public static CustomUserControl GetReferenceUserControl(string userControlName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            userControlName = NAMESPACEDEFAULT + userControlName;


            return assembly.CreateInstance(userControlName) as CustomUserControl;

        }

        public enum Zone
        {
            Left,
            Middle,
            Right
        }

        public static void AddToPanelWithParameters(Zone zone, CustomUserControl uc, string userControlName, params string[] parameters)
        {
            Form frm = uc.ParentForm;
            AddToPanelWithParameters(zone, frm, userControlName, null, parameters);
        }

        public static void AddToPanelWithParameters(Zone zone, CustomUserControl uc, string userControlName, object parameter, params string[] parameters)
        {
            Form frm = uc.ParentForm;
            AddToPanelWithParameters(zone, frm, userControlName, parameter, parameters);
        }

        /// <summary>
        /// Cambio para cambios bajo costo
        /// </summary>
        /// <param name="zone"></param>
        /// <param name="uc"></param>
        /// <param name="userControlName"></param>
        /// <param name="parameter"></param>
        /// <param name="parameters"></param>
        public static void AddToPanelWithParameters(Zone zone, CustomUserControl uc, string userControlName, object parameter, object extraData, params string[] parameters)
        {
            Form frm = uc.ParentForm;
            AddToPanelWithParameters(zone, frm, userControlName, parameter, extraData, parameters);
        }

        public static void AddToPanelWithParameters(Zone zone, Form frm, string userControlName, object parameter, params string[] parameters)
        {
            string panelName = string.Empty;

            switch (zone)
            {
                case Zone.Left:
                    panelName = "pnlLeft";
                    break;
                case Zone.Middle:
                    panelName = "pnlMiddle";
                    break;
                case Zone.Right:
                    panelName = "pnlRight";
                    break;
            }

            panelName = panelName.ToLower();

            Control[] controls = frm.Controls.Find(panelName, true);
            if (controls[0].Controls.Count > 0)
            {
                if (controls[0].Controls[0] is CustomUserControl)
                    ((CustomUserControl)controls[0].Controls[0]).Dispose();
            }

            //controls[0].Controls.Clear();
            //frm.PerformLayout();
            //GC.Collect();

            CustomUserControl cu = (CustomUserControl)Loader.GetReferenceUserControl(userControlName);
            cu.Parameters = parameters;
            cu.Parameter = parameter;
            controls[0].Controls.Add(cu);

        }

        /// <summary>
        /// Cambios Bajo costo
        /// </summary>
        /// <param name="zone"></param>
        /// <param name="frm"></param>
        /// <param name="userControlName"></param>
        /// <param name="parameter"></param>
        /// <param name="parameters"></param>
        public static void AddToPanelWithParameters(Zone zone, Form frm, string userControlName, object parameter, object extraData, params string[] parameters)
        {
            string panelName = string.Empty;

            switch (zone)
            {
                case Zone.Left:
                    panelName = "pnlLeft";
                    break;
                case Zone.Middle:
                    panelName = "pnlMiddle";
                    break;
                case Zone.Right:
                    panelName = "pnlRight";
                    break;
            }

            panelName = panelName.ToLower();

            Control[] controls = frm.Controls.Find(panelName, true);
            if (controls[0].Controls.Count > 0)
            {
                if (controls[0].Controls[0] is CustomUserControl)
                    ((CustomUserControl)controls[0].Controls[0]).Dispose();
            }

            //controls[0].Controls.Clear();
            //frm.PerformLayout();
            //GC.Collect();

            CustomUserControl cu = (CustomUserControl)Loader.GetReferenceUserControl(userControlName);
            cu.Parameters = parameters;
            cu.Data = extraData;
            cu.Parameter = parameter;
            controls[0].Controls.Add(cu);

        }







        public static void AddToPanel(Zone zone, CustomUserControl uc, string userControlName)
        {
            Form frm = uc.ParentForm;
            AddToPanel(zone, frm, userControlName);
        }

        public static void AddToPanel(Zone zone, Form frm, string userControlName)
        {

            string panelName = string.Empty;

            switch (zone)
            {
                case Zone.Left:
                    panelName = "pnlLeft";
                    break;
                case Zone.Middle:
                    panelName = "pnlMiddle";
                    break;
                case Zone.Right:
                    panelName = "pnlRight";
                    break;
            }

            panelName = panelName.ToLower();
                        
            try
            {
                Control[] controls = frm.Controls.Find(panelName, true);

                if (controls[0].Controls.Count > 0)
                {
                    if (controls[0].Controls[0] is CustomUserControl)
                        ((CustomUserControl)controls[0].Controls[0]).Dispose();
                }
                controls[0].Controls.Add(Loader.GetReferenceUserControl(userControlName));
            }
            catch (Exception ex)
            {
                String sError = ex.Message;
            }

        }

    }
}

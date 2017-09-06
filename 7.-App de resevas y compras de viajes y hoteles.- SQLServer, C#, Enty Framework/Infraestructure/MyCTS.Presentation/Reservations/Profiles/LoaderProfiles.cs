using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation
{
    class LoaderProfiles
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
            Right,
            Modal_Profile
        }

        public static void AddToPanelWithParameters(Zone zone, CustomUserControl uc, string userControlName, params string[] parameters)
        {
            Form frm = uc.ParentForm;
            AddToPanelWithParameters(zone, frm, userControlName, parameters);
        }

        public static void AddToPanelWithParameters(Zone zone, Form frm, string userControlName, params string[] parameters)
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
                case Zone.Modal_Profile:
                    panelName = "pnlProfiles";
                    break;
            }

            panelName = panelName.ToLower();

            Control[] controls = frm.Controls.Find(panelName, true);
            if (controls[0].Controls.Count > 0)
            {
                if (controls[0].Controls[0] is CustomUserControl)
                    ((CustomUserControl)controls[0].Controls[0]).Dispose();
            }

            CustomUserControl cu = (CustomUserControl)Loader.GetReferenceUserControl(userControlName);
            cu.Parameters = parameters;
            controls[0].Controls.Add(cu);

        }

        public static void AddToPanel(Zone zone, CustomUserControl uc, string userControlName)
        {
            Form frm = uc.ParentForm;
            AddToPanel(zone, frm, userControlName);
        }

        public static void AddToPanel(Zone zone, string userControlName)
        {

            MyCTS.Presentation.Reservations.Profiles.UcSecondLevelProfiles.ListObjStar2Dcpsl.Clear();
            frmProfiles frmProfiles = new frmProfiles();
            Form frm = frmProfiles;
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
                case Zone.Modal_Profile:
                    panelName = "pnlProfiles";
                    break;
            }

            panelName = panelName.ToLower();

                            Control[] controls = frm.Controls.Find(panelName, true);
                            if (controls != null)
                            {
                                if (controls.Length > 0)
                                {
                                    if (controls[0].Controls.Count > 0)
                                    {
                                        if (controls[0].Controls[0] is CustomUserControl)
                                            ((CustomUserControl)controls[0].Controls[0]).Dispose();
                                    } controls[0].Controls.Add(Loader.GetReferenceUserControl(userControlName));
                                }
                            }

        }

    }
}

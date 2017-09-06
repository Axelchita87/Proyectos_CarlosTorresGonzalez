using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Xml;
using MyCTS.Forms.UI.Entities;
using MyCTS.Forms.UI.DataAccess;
using System.Web.Security;
using MyCTS.Business;
using MyCTS.Entities;

//using MyImages = global::MyCTS.Forms.UI.Resources;

namespace MyCTS.Forms.UI
{
    public partial class MenuStripEnhanced : MenuStrip
    {
        public MenuStripEnhanced()
        {
            InitializeComponent();
        }

        private object m_form;
        [ToolboxItem( "Extended" ), Category( "Extended" ), Description("The Form that the MenuStrip is attached to.")]
        public object Form
        {
            get { return m_form; }
            set { m_form = value; }
        }

        private static global::System.Resources.ResourceManager resourceMan;
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        private static global::System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MyCTS.Forms.UI.Resources.ImagesResource", typeof(MyCTS.Forms.UI.Resources.ImagesResource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        private Image GetImageFromResource(string imagename)
        {
            if (ResourceManager.GetObject(imagename) != null)
                return (Image)ResourceManager.GetObject(imagename);
            else
                return null;
        }


        string[] roles = null;

        public void LoadDynamicMenu(string username, string PCC)
        {
            List<Rol> rolList = RolesBL.GetRolesByUser(username, PCC);
            roles = Array.ConvertAll<Rol, string>(rolList.ToArray(), delegate(Rol from) { return from.RoleName.ToString(); });
            //roles = Roles.GetRolesForUser(username);
            //roles = new string[] { "admin", "" };
            List<ApplicationObjects> applicationObjects = MyCTS.Forms.UI.DataAccess.Security.GetMenuData();
            List<ApplicationObjects> parentObjects = GetParents(applicationObjects);
            
            foreach (ApplicationObjects item in parentObjects)
            {
                ToolStripMenuItemExtended menu = new ToolStripMenuItemExtended();
                
                menu.Name = item.Name;
                menu.Text = item.Text;
                menu.Value = item.ID.ToString();
                menu.Width = 55;
                menu.AutoSize = false;
                this.Items.Add(menu);
                AddChild(applicationObjects, (ToolStripMenuItemExtended)this.Items[this.Items.Count - 1]);
            }
        }
        private void AddChild(List<ApplicationObjects> applicationObjects, ToolStripMenuItemExtended menuItem)
        {
            List<ApplicationObjects> childObjects = GetChilds(applicationObjects, menuItem.Value);
            ToolStripSeparator separator = null;

            foreach (ApplicationObjects objects in childObjects)
            {
                ToolStripMenuItemExtended item = new ToolStripMenuItemExtended();
                if (objects.Text.Equals("-"))
                {
                    separator = new ToolStripSeparator();
                    menuItem.DropDownItems.Add(separator);
                }
                else
                {
                   if (roles != null && !string.IsNullOrEmpty(objects.Roles))
                        if (!IsAllowed(objects.Roles)) continue;

                    item.Name = objects.Name;
                    item.Text = objects.Text;
                    item.Value = objects.ID.ToString();

                    if (objects.Checked)
                    {
                        item.Checked = true;
                        item.CheckOnClick = true; 
                    }
                    try
                    {
                        if (!string.IsNullOrEmpty(objects.ImageName))
                        {
                            Image img = GetImageFromResource(objects.ImageName.ToLower());
                            if (img != null)
                                item.Image = img;
                        }
                    }
                    catch{}

                    string[] arrKeys = objects.ShortCut.Split(new char[] { ',' });
                    if (arrKeys.Length == 1)
                    {
                        if (!(string.IsNullOrEmpty(arrKeys[0])))
                        {
                            TypeConverter conv = TypeDescriptor.GetConverter(typeof(Keys));
                            Keys key = (Keys)conv.ConvertFromString(arrKeys[0]);
                            item.ShortcutKeys = key;
                        }                        
                    }
                    else
                    {
                        TypeConverter conv = TypeDescriptor.GetConverter(typeof(Keys));
                        //if (arrKeys[1].ToUpper().Trim().Equals("SUPR"))
                        //    arrKeys[1] = "Delete";

                        Keys key = (Keys)conv.ConvertFromString(arrKeys[0]) | (Keys)conv.ConvertFromString(arrKeys[1]);
                        item.ShortcutKeys = key;
                    }
                    
                    menuItem.DropDownItems.Add(item);

                    if (!string.IsNullOrEmpty(objects.EventName))
                        FindEventsByName(item, this.Form, true, "MenuItemOn", objects.EventName);

                    AddChild(applicationObjects, (ToolStripMenuItemExtended)menuItem.DropDownItems[menuItem.DropDownItems.Count - 1]);
                }
            }

        }
        private List<ApplicationObjects> GetChilds(List<ApplicationObjects> applicationObjects, string parentID)
        {
            return applicationObjects.FindAll(delegate(ApplicationObjects a)
                                            { return a.ParentID == Int32.Parse(parentID); });
        }
        private List<ApplicationObjects> GetParents(List<ApplicationObjects> applicationObjects)
        {
            return applicationObjects.FindAll(delegate(ApplicationObjects a) 
                                            { return a.ParentID == 0; });
        }

        private bool IsAllowed(string rolesAllowed)
        {
            if (rolesAllowed.Contains("*")) return true;

            rolesAllowed = rolesAllowed.ToLower();
            foreach (string r in roles)
                if (rolesAllowed.Contains(r.ToLower())) return true;

            return false;
        }

        private void FindEventsByName( object sender, object receiver, bool bind, string handlerPrefix, string handlerSuffix )
        {
            System.Reflection.EventInfo[] SenderEvent = sender.GetType().GetEvents();
            Type ReceiverType = receiver.GetType();
            System.Reflection.MethodInfo method;

            foreach ( System.Reflection.EventInfo e in SenderEvent )
            {
                method = ReceiverType.GetMethod( string.Format( "{0}{1}{2}", handlerPrefix, e.Name, handlerSuffix ), System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic );
                
                if ( method != null )
                {

                    System.Delegate d = System.Delegate.CreateDelegate( e.EventHandlerType, receiver, method.Name );

                    if ( bind )
                        e.AddEventHandler( sender, d );
                    else
                        e.RemoveEventHandler( sender, d );
                }
            }
        }

        public void clearMenuStripItems()
        {
            this.Items.Clear();
        }
    }
}
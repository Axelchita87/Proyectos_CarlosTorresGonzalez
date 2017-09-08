using ADMIN2.BR;
using ADMIN2.Controls;
using ADMIN2.DAL;
using ADMIN2.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AdminEvents.Configuracion
{
    /// <summary>
    /// Lógica de interacción para FrmPerfiles.xaml
    /// </summary>
    public partial class FrmPerfiles : BaseWindow
    {
        public FrmPerfiles()
        {
            InitializeComponent();
            btnAceptar.IsEnabled = false;
            btnCancelar.IsEnabled = false;

            BrConfiguracion catalogos = new BrConfiguracion();
            EntPerfil perfilAcceso = new EntPerfil();
            Respuesta<List<EntPerfil>> repuesta = new Respuesta<List<EntPerfil>>();
        }

        public FrmPerfiles(frmCatologoGenerico frmCatologoGenerico)
        {
            // TODO: Complete member initialization
            this.frmCatologoGenerico = frmCatologoGenerico;

            InitializeComponent();
            //btnAceptar.IsEnabled = false;
            //btnCancelar.IsEnabled = false;

            BrConfiguracion catalogos = new BrConfiguracion();
            EntPerfil perfilAcceso = new EntPerfil();
            Respuesta<List<EntPerfil>> repuesta = new Respuesta<List<EntPerfil>>();

            ////pasar metodo a la principal
            //perfilAcceso.IdSistema = 2;
            //perfilAcceso.IdPerfil = 1;
            //repuesta = catalogos.GetConsultaPerfileAcceso(perfilAcceso, "B");
            //lstAccesosXPerfil = repuesta.Resultado;
        }

        public FrmPerfiles(FrmUsuarios frmUsuarios)
        {
            // TODO: Complete member initialization
            this.frmUsuarios = frmUsuarios;
            InitializeComponent();
            //btnAceptar.IsEnabled = false;
            //btnCancelar.IsEnabled = false;

            BrConfiguracion catalogos = new BrConfiguracion();
            EntPerfil perfilAcceso = new EntPerfil();
            Respuesta<List<EntPerfil>> repuesta = new Respuesta<List<EntPerfil>>();

            ////pasar metodo a la principal
            //perfilAcceso.IdSistema = 2;
            //perfilAcceso.IdPerfil = 1;
            //repuesta = catalogos.GetConsultaPerfileAcceso(perfilAcceso, "B");
            //lstAccesosXPerfil = repuesta.Resultado;
        }

        #region Declaraciones

        avisosis messageBox = new avisosis();
        public List<EntPantalla> ListPantallas;
        public List<EntPerfil> lstAccesosXPerfil = new List<EntPerfil>();
        EntPerfil Perfil = new EntPerfil();

        public string ActIns = string.Empty;
        public int bandera = 0;
        private frmCatologoGenerico frmCatologoGenerico;
        private FrmUsuarios frmUsuarios;
        public string NombrePerfil = string.Empty;
        public int IdPerfil = 0;

        #endregion

        #region Eventos

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            try
            {
                base.DragMove();
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, this.Title, MessageBoxButton.OK, MessageBoxImage.Error);
                messageBox.ShowDialog();
            }
        }

        private void BtnCerrarClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, this.Title, MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
            }
        }

        private void BtnBusquedaClick(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    frmCatologoGenerico frmCatalogo = new frmCatologoGenerico();
            //    object Resp = frmCatalogo.AbrirAgendaGenerica<EntCgRecExp>(DAL.Comunes.CatCGRECEXPReferencia, "Recepción Expedientes", false, false, false, string.Empty, 5);
            //    EntCgRecExp EntCgRecExp = Resp as EntCgRecExp;

            //    if (EntCgRecExp != null)
            //    {
            //        txtreferencia.Text = EntCgRecExp.NumReferencia;
            //        TxtSub.Text = EntCgRecExp.ISub.ToString();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    messageBox = new avisosis(ex, this.Title, MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
            //}
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                base.OnClosing(e);
                if (guardar)
                {
                    cerrando = true;
                    btnAceptar_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, this.Title, MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
            }
        }

        private void btnCancelClick(object sender, RoutedEventArgs e)
        {
            if (ActIns == Comunes.AGREGA)
            {
                LimpiaTextBox(this);
            }
            else
            {
                Close();
            }
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bandera = 1;
                Guarda();
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, this.Title, MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
            }
        }

        private void TreeView_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                // ... Get TreeView reference
                var tree = sender as TreeView;

                //OBTENER EL CATALOGO DE PANTALLAS
                BrConfiguracion catalogos = new BrConfiguracion();
                EntPantalla pantalla = new EntPantalla();
                Respuesta<List<EntPantalla>> repuesta = new Respuesta<List<EntPantalla>>();
                ListPantallas = new List<EntPantalla>();

                List<TreeViewItem> TreViewMenus = new List<TreeViewItem>();
                List<CheckBox> chbPantallas = new List<CheckBox>();
                CheckBox chbxitem = new CheckBox();

                //Obteniendo todas las pantallas
                pantalla.IdSistema = 2;
                repuesta = catalogos.GetConsultaPantallas(pantalla, "A");
                ListPantallas = repuesta.Resultado;

                //Obteniendo los modulos
                var modulos = ListPantallas.GroupBy(x => x.Modulo).Select(grupo => grupo.First());

                //agregando los modulos
                foreach (EntPantalla itemp in modulos)
                {
                    TreeViewItem itemModulo = new TreeViewItem();
                    chbxitem = new CheckBox();
                    chbxitem.Click += cb_Checked;
                    chbxitem.Content = itemp.Modulo;
                    //chbxitem.Name = "mo_" + itemp.MENU.Replace(" ", "");
                    chbxitem.Name = "mo_" + itemp.IdPantalla;
                    chbxitem.IsChecked = ConsultarEnPerfil(itemp.IdPantalla);

                    itemModulo.Header = chbxitem;

                    //Obteniendo los menús
                    var menus = (from m in ListPantallas
                                 where m.Modulo == itemp.Modulo
                                 select m).GroupBy(x => x.SubMenu).Select(grupo => grupo.First());

                    //Agregando los menus
                    TreViewMenus = new List<TreeViewItem>();
                    foreach (EntPantalla itemmenu in menus)
                    {
                        if (itemmenu.SubMenu != string.Empty && itemmenu.SubMenu != null)
                        {
                            TreeViewItem itemMenu = new TreeViewItem();
                            chbxitem = new CheckBox();
                            chbxitem.Click += cb_Checked;
                            chbxitem.Content = itemmenu.SubMenu;
                            //chbxitem.Name = "me_" + itemmenu.SUBMENU.Replace(" ", "");
                            chbxitem.Name = "me_" + itemmenu.IdPantalla;
                            chbxitem.IsChecked = ConsultarEnPerfil(itemmenu.IdPantalla);

                            itemMenu.Header = chbxitem;

                            //Obteniendo las pantallas
                            var pantallas = (from m in ListPantallas
                                             where m.SubMenu == itemmenu.SubMenu && m.Modulo == itemp.Modulo
                                             select m).ToList();

                            //Agregando las pantallas
                            chbPantallas = new List<CheckBox>();
                            foreach (EntPantalla itemP in pantallas)
                            {
                                if (itemP.Pantalla != string.Empty && itemP.Pantalla != null)
                                {
                                    TreeViewItem itemPantallas = new TreeViewItem();
                                    chbxitem = new CheckBox();
                                    chbxitem.Click += cb_Checked;
                                    chbxitem.Content = itemP.Pantalla;
                                    chbxitem.Name = "pa_" + itemP.IdPantalla.ToString();
                                    chbxitem.IsChecked = ConsultarEnPerfil(itemP.IdPantalla);
                                    chbPantallas.Add(chbxitem);
                                }
                            }
                            itemMenu.ItemsSource = chbPantallas;
                            TreViewMenus.Add(itemMenu);
                        }
                        else
                        {
                            /////////////77
                            //TreeViewItem itemMenu2 = new TreeViewItem();
                            //Obteniendo las pantallas
                            var pantallas2 = (from m in ListPantallas
                                              where m.Modulo == itemp.Modulo
                                              select m).ToList();

                            //Agregando las pantallas
                            //chbPantallas = new List<CheckBox>();
                            TreeViewItem itemPantallas = new TreeViewItem();
                            foreach (EntPantalla itemP in pantallas2)
                            {
                                if (itemP.SubMenu == string.Empty || itemP.SubMenu == null)
                                {
                                    itemPantallas = new TreeViewItem();
                                    chbxitem = new CheckBox();
                                    chbxitem.Click += cb_Checked;
                                    chbxitem.Content = itemP.Pantalla;
                                    chbxitem.Name = "pa_" + itemP.IdPantalla.ToString();
                                    chbxitem.IsChecked = ConsultarEnPerfil(itemP.IdPantalla);
                                    itemPantallas.Header = chbxitem;
                                    //chbPantallas.Add(chbxitem);  
                                    TreViewMenus.Add(itemPantallas);
                                }
                            }
                            //itemMenu2.ItemsSource = chbPantallas;

                            ////////////
                        }
                    }


                    itemModulo.ItemsSource = TreViewMenus;
                    // add both items.
                    tree.Items.Add(itemModulo);
                }


            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void chbxSeleccionaTodos_Click(object sender, RoutedEventArgs e)
        {
            chbxSeleccionaTodosCotrolTotal.IsChecked = chbxSeleccionaTodos.IsChecked == true ? false : true;
            bool NuevoVal = chbxSeleccionaTodos.IsChecked == true ? true : false;

            //Se valida que si el perfil es administrador no permita cambiar permisos de pantallas
            lstAccesosXPerfil.Select(c => { c.ST_C_AP_LEER = NuevoVal; return c; }).Select(c => { c.ST_C_AP_LEERYESCRIBIR = !NuevoVal; return c; }).ToList();

            dgrPermisos.ItemsSource = null;
            dgrPermisos.ItemsSource = lstAccesosXPerfil;

        }

        private void chbxSeleccionaTodosCotrolTotal_Click(object sender, RoutedEventArgs e)
        {
            chbxSeleccionaTodos.IsChecked = chbxSeleccionaTodosCotrolTotal.IsChecked == true ? false : true;
            bool NuevoVal = chbxSeleccionaTodosCotrolTotal.IsChecked == true ? true : false;

            //Se valida que si el perfil es administrador y quiere hacer cambios sobre la pantalla de perfiles  a Solo lectura, no permita cambiarlo, de lo contrario ya no podria asignar permisos de pantallas
            lstAccesosXPerfil.Select(c => { c.ST_C_AP_LEER = !NuevoVal; return c; }).Select(c => { c.ST_C_AP_LEERYESCRIBIR = NuevoVal; return c; }).ToList();

            dgrPermisos.ItemsSource = null;
            dgrPermisos.ItemsSource = lstAccesosXPerfil;
        }

        private void dgrPermisos_CurrentCellChanged(object sender, EventArgs e)
        {
            //Validamos que exista una columna que see este seleccionando, es necesario de lo contrario manda error en algunos casos
            if (dgrPermisos.CurrentCell.Column != null)
            {
                //Obtenemos el checkbox en cuestion
                CheckBox mycheckbox = dgrPermisos.CurrentCell.Column.GetCellContent(dgrPermisos.CurrentItem) as CheckBox;
                EntPerfil Acceso = (EntPerfil)dgrPermisos.CurrentItem;

                if (mycheckbox != null)
                {
                    //Obtenemos el id de la pantalla de la actual fila del grid
                    int Id = Acceso.IdPantalla;

                    //el cambio de valor del chek se hace manualmente ya que se probo con la respuesta normal del evento CurrentCellChanged y cuando el metodo es invocado el check aun no cambia su estatus
                    bool NuevoVal = mycheckbox.IsChecked == true ? false : true;
                    switch (dgrPermisos.CurrentColumn.Header.ToString())
                    {
                        case "Solo lectura":
                            //Se cambia los valores en el listado de pantallas
                            //Se valida que si el perfil es administrador y quiere hacer cambios sobre la pantalla de perfiles  a Solo lectura, no permita cambiarlo, de lo contrario ya no podria asignar permisos de pantallas
                            lstAccesosXPerfil.Where(c => c.IdPantalla == Id).Select(c => { c.ST_C_AP_LEER = NuevoVal; return c; }).Select(c => { c.ST_C_AP_LEERYESCRIBIR = false; return c; }).ToList();
                            break;
                        case "Control total":
                            // lstAccesosXPerfil.Where(c => c.ST_C_AP_PANTALLA == Id).Select(c => { c.ST_C_AP_LEERYESCRIBIR = NuevoVal; return c; }).Select(c => { c.ST_C_AP_LEER = !NuevoVal; return c; }).ToList();
                            lstAccesosXPerfil.Where(c => c.IdPantalla == Id).Select(c => { c.ST_C_AP_LEERYESCRIBIR = NuevoVal; return c; }).Select(c => { c.ST_C_AP_LEER = false; return c; }).ToList();
                            break;
                    }


                    dgrPermisos.ItemsSource = null;
                    dgrPermisos.ItemsSource = lstAccesosXPerfil;

                    if (lstAccesosXPerfil.Count > 0)
                    {
                        chbxSeleccionaTodos.Visibility = Visibility.Visible;
                        chbxSeleccionaTodosCotrolTotal.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        chbxSeleccionaTodos.Visibility = Visibility.Hidden;
                        chbxSeleccionaTodosCotrolTotal.Visibility = Visibility.Hidden;
                    }
                }
            }
        }

        #endregion

        #region Métodos

        void cb_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox tree = sender as CheckBox;
            string[] namchk = tree.Name.Split('_');
            //Obteniendo el estado del chekbox
            bool estado = tree.IsChecked == true ? true : false;
            //bool EsPerfilAdministrador = ValidarEsPerfilAdministrador();

            //if (!EsPerfilAdministrador || (EsPerfilAdministrador && estado))
            //{
            //Obteniendo el tipo de chek seleccionado: modulo 'mo' o menu 'me' o pantalla 'pa'
            if (namchk[0] == "mo")
            {
                TreeViewItem treeModulo = (TreeViewItem)tree.Parent;
                foreach (TreeViewItem treeMenu in treeModulo.Items)
                {
                    CheckBox chkMenu = (CheckBox)treeMenu.Header;
                    chkMenu.IsChecked = estado;

                    foreach (CheckBox chkPantalla in treeMenu.Items)
                    {
                        chkPantalla.IsChecked = estado;
                        AgregarPermisoAGrid(chkPantalla.Name, tree.Content + "/" + chkMenu.Content + "/" + chkPantalla.Content.ToString(), estado);
                    }

                    var pant = (from m in ListPantallas
                                where m.IdPantalla == Convert.ToInt32(namchk[1])
                                select m).FirstOrDefault();

                    AgregarPermisoAGrid(chkMenu.Name, pant.Modulo + "/" + chkMenu.Content.ToString(), estado);
                }
            }
            else if (namchk[0] == "me")
            {
                TreeViewItem treeMenu = (TreeViewItem)tree.Parent;
                CheckBox chkMenu = (CheckBox)treeMenu.Header;
                string MenuString = string.Empty;


                foreach (CheckBox chkPantalla in treeMenu.Items)
                {
                    if (MenuString == string.Empty)
                    {
                        string[] nm = chkPantalla.Name.Split('_');
                        var pant = (from m in ListPantallas
                                    where m.IdPantalla == Convert.ToInt32(nm[1])
                                    select m).FirstOrDefault();

                        MenuString = pant.Modulo;
                    }
                    chkPantalla.IsChecked = estado;
                    AgregarPermisoAGrid(chkPantalla.Name, MenuString + "/" + chkMenu.Content + "/" + chkPantalla.Content.ToString(), estado);
                }
            }
            else if (namchk[0] == "pa")
            {
                var pant = (from m in ListPantallas
                            where m.IdPantalla == Convert.ToInt32(namchk[1])
                            select m).FirstOrDefault();

                AgregarPermisoAGrid(tree.Name, pant.Modulo + "/" + pant.SubMenu + "/" + tree.Content.ToString(), estado);
            }
            //}
            //else
            //{
            //    tree.IsChecked = true;
            //}
        }

        private void AgregarPermisoAGrid(string NombreControl, string NombrePantalla, bool IsChecked)
        {
            EntPerfil pantalla = new EntPerfil();
            string[] namPant = NombreControl.Split('_');
            pantalla.IdPantalla = Convert.ToInt32(namPant[1]);
            pantalla.RutaPantalla = NombrePantalla;

            if (IsChecked)
            {
                var lstAccesos = from acss in lstAccesosXPerfil
                                 where acss.IdPantalla == pantalla.IdPantalla
                                 select acss;

                //Se valida que el permiso no se encuentre ya en el listado
                if (lstAccesos.Count() == 0)
                {
                    lstAccesosXPerfil.Add(pantalla);
                }
            }
            else
            {
                var lstAccesos = from acs in lstAccesosXPerfil
                                 where acs.IdPantalla != pantalla.IdPantalla
                                 select acs;

                lstAccesosXPerfil = lstAccesos.ToList();
            }

            dgrPermisos.ItemsSource = null;
            dgrPermisos.ItemsSource = lstAccesosXPerfil;

            if (lstAccesosXPerfil.Count > 0)
            {
                chbxSeleccionaTodos.Visibility = Visibility.Visible;
                chbxSeleccionaTodosCotrolTotal.Visibility = Visibility.Visible;
            }
            else
            {
                chbxSeleccionaTodos.Visibility = Visibility.Hidden;
                chbxSeleccionaTodosCotrolTotal.Visibility = Visibility.Hidden;
            }
        }

        private bool ConsultarEnPerfil(int IdPantalla)
        {
            if (lstAccesosXPerfil != null)
            {
                EntPerfil search = lstAccesosXPerfil.Find(m => m.IdPantalla == IdPantalla);
                if (search != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }

        //guarda y actualiza

        public void Guarda()
        {
            EntPerfil enttrM = new EntPerfil();
            BrConfiguracion ped = new BrConfiguracion();
            try
            {
                //totRequeridos = 1;
                //contabilizaYValidaRequerido(TxtPerfil);
                //if (totRequeridos > 0)
                //{
                //    messageBox = new avisosis(totRequeridos == 1 ? (string.Format("¡El campo {0} es obligatorio!", ControlInvalido)) : "Los campos son obligatorios", this.Title, MessageBoxButton.OK, MessageBoxImage.Warning);
                //    messageBox.ShowDialog();
                //    return;
                //}

                if (ActIns == Comunes.AGREGA)
                {
                    enttrM.IdUsuarioRegistro = App.IdUsuario;
                }
                else
                {
                    enttrM.IdPerfil = Perfil.IdPerfil;
                    enttrM.IdUsuarioModifico = App.IdUsuario;
                }
                enttrM.IdSistema = App.IdSistema;
                //enttrM.Perfil = TxtPerfil.Text;
                enttrM.Perfil = NombrePerfil;
                Respuesta<int> res = ped.InsUpdPerfiles(enttrM, ActIns, "A");
                if (bandera == 1)
                {
                    if (res.EsExitoso)
                    {
                        if (Perfil.IdPerfil != 0)
                        {
                            //elimina registros
                            res = ped.InsUpdPerfiles(enttrM, Comunes.BORRAR, "");
                        }
                        else
                        {
                            //inserta nuevo registro
                            Perfil.IdPerfil = res.Resultado;
                        }

                        //registra perfil acceso, todas las pantallas
                        foreach (EntPerfil entPerAcceso in lstAccesosXPerfil)
                        {
                            entPerAcceso.IdSistema = 2;
                            entPerAcceso.IdPerfil = Perfil.IdPerfil;
                            entPerAcceso.IdUsuarioRegistro = 1;
                            bool SinSeleccion = false;
                            if (!SinSeleccion)
                            {
                                res = ped.InsUpdPerfiles(entPerAcceso, "A", "B");
                                if (!res.EsExitoso)
                                {
                                    //Sale del Foreach y del método GuardaRegistro
                                    messageBox = new avisosis(res.MensajeUsuario + ". Error al " + (ActIns == Comunes.AGREGA ? "Insertar" : "Actualizar"), this.Title, MessageBoxButton.OK, MessageBoxImage.Error);
                                    messageBox.ShowDialog();
                                    break;
                                }
                            }
                        }
                        if (res.EsExitoso)
                        {
                            Editando = false;
                            messageBox = new avisosis("Se ha " + (ActIns == Comunes.AGREGA ? "agregado" : "actualizado") + " el perfil correctamente.", this.Title, MessageBoxButton.OK, MessageBoxImage.None);
                            messageBox.ShowDialog();
                            if (!cerrando)
                                this.Close();
                        }

                        //Actualizacion del Grid Generico
                        //frmCatologoGenerico.AcutualizaGrid<EntPerfil>(enttrM);

                        //asigna valor para que se puede guardar desde la pantalla de usuario
                        IdPerfil = Perfil.IdPerfil;

                    }
                    else
                    {
                        messageBox = new avisosis("Error al " + (ActIns == Comunes.AGREGA ? " agregar " : ActIns == Comunes.CAMBIA ? " actualizar " : " eliminar ") + res.Error, this.Title, MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
                    }
                }

            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, this.Title, MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
            }
        }

        public void Consulta(EntPerfil EntPerfilAcceso)
        {
            try
            {
                if (ActIns == Comunes.CAMBIA)
                {
                    BrConfiguracion catalogos = new BrConfiguracion();
                    Perfil.IdSistema = 2;
                    Perfil.IdPerfil = EntPerfilAcceso.IdPerfil;
                    NombrePerfil = EntPerfilAcceso.Perfil;
                    Respuesta<List<EntPerfil>> resultP = catalogos.GetConsultaPerfiles(Perfil);
                    if (resultP.TotalRegistros > 0)
                    {
                        TxtPerfil.Text = resultP.Resultado[0].Perfil;

                        Respuesta<List<EntPerfil>> result = catalogos.GetConsultaPerfileAcceso(Perfil, "B");
                        if (result.TotalRegistros > 0)
                        {
                            lstAccesosXPerfil = result.Resultado;
                            EntPerfil entpAc = new EntPerfil();
                            dgrPermisos.ItemsSource = lstAccesosXPerfil;

                            if (lstAccesosXPerfil.Count > 0)
                            {
                                chbxSeleccionaTodos.Visibility = Visibility.Visible;
                                chbxSeleccionaTodosCotrolTotal.Visibility = Visibility.Visible;
                            }
                            else
                            {
                                chbxSeleccionaTodos.Visibility = Visibility.Hidden;
                                chbxSeleccionaTodosCotrolTotal.Visibility = Visibility.Hidden;
                            }
                        }
                    }
                    TxtPerfil.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, this.Title, MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
            }
        }


        public void ConsultaNombrePerfil(EntPerfil EntPerfilAcceso)
        {
            try
            {
                NombrePerfil = EntPerfilAcceso.Perfil;
            }
            catch (Exception ex)
            {
                messageBox = new avisosis(ex, this.Title, MessageBoxButton.OK, MessageBoxImage.Error); messageBox.ShowDialog();
            }
        }
        //Limpia Texbox
        static public void LimpiaTextBox(Visual myMainWindow)
        {
            int childrenCount = VisualTreeHelper.GetChildrenCount(myMainWindow);
            for (int i = 0; i < childrenCount; i++)
            {
                var visualChild = (Visual)VisualTreeHelper.GetChild(myMainWindow, i);
                if (visualChild is TextBox)
                {
                    TextBox tb = (TextBox)visualChild;
                    tb.Clear();
                }
                LimpiaTextBox(visualChild);
            }
        }

        #endregion
    }
}

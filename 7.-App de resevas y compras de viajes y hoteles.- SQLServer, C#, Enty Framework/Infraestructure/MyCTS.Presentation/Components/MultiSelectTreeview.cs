using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace MyCTS.Forms.UI
{
    public class MultiSelectTreeview : TreeView
    {
        #region Selected Node(s) Properties

        private List<TreeNode> m_SelectedNodes = null;
        /// <summary>
        /// Obtiene o establece los nodos seleccionados
        /// </summary>
        public List<TreeNode> SelectedNodes
        {
            get
            {
                return m_SelectedNodes;
            }
            set
            {
                ClearSelectedNodes();
                if (value != null)
                {
                    foreach (TreeNode node in value)
                    {
                        ToggleNode(node, true);
                    }
                }
            }
        }

        private TreeNode m_SelectedNode;
        /// <summary>
        /// Obtiene o establece el nodo seleccionado
        /// </summary>
        public new TreeNode SelectedNode
        {
            get { return m_SelectedNode; }
            set
            {
                ClearSelectedNodes();
                if (value != null)
                {
                    SelectNode(value);
                }
            }
        }

        private int m_ImageIndexSelected = 3;
        /// <summary>
        /// Obtiene o establece el índice de la imágen que se utilizará como default
        /// cuando un elemento está seleccionado
        /// </summary>
        public int ImageIndexDefault
        {
            get
            {
                return m_ImageIndexSelected;
            }
            set
            {
                m_ImageIndexSelected = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el índice de la imágen que se utilizará como default
        /// cuando un elemento es de tipo opcional y está seleccionado
        /// </summary>
        private int m_ImageIndexSelectedOptional = 4;
        public int ImageIndexSelectedOptional
        {
            get
            {
                return m_ImageIndexSelectedOptional;
            }
            set
            {
                m_ImageIndexSelectedOptional = value;
            }
        }

        #endregion

        /// <summary>
        /// Constructor que crea la lista de objetos de tipo SmartTreeNode
        /// </summary>
        public MultiSelectTreeview()
        {
            m_SelectedNodes = new List<TreeNode>();
            base.SelectedNode = null;
        }

        #region Overridden Events

        /// <summary>
        /// Asegura que al menos un nodo está seleccionado cuando se utiliza 
        /// la tecla ctrl para seleccion múltiple
        /// </summary>
        /// <param name="e">Los eventos lanzados por el control.</param>
        protected override void OnGotFocus(EventArgs e)
        {
            try
            {
                if (m_SelectedNode == null && this.TopNode != null)
                {
                    ToggleNode(this.TopNode, true);
                }

                base.OnGotFocus(e);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        /// <summary>
        /// Si el usuario da clic sobre un nodo que no se ha seleccionado lo selecciona
        /// </summary>
        /// <param name="e">Los eventos lanzados por el control.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            try
            {
                base.SelectedNode = null;

                TreeNode node = this.GetNodeAt(e.Location);
                if (node != null)
                {
                    int leftBound = node.Bounds.X; // - 20; // Permite al usuario hacer clic sobre la imágen y se use como selección
                    int rightBound = node.Bounds.Right + 10; // Permite dar un rango extra de selección 
                    if (e.Location.X > leftBound && e.Location.X < rightBound)
                    {
                        if (ModifierKeys == Keys.None && (m_SelectedNodes.Contains(node)))
                        {
                        }
                        else
                        {
                            SelectNode(node);
                        }
                    }
                }

                base.OnMouseDown(e);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        /// <summary>
        /// Si el nodo ha sido seleccionado previamente no lo vuelve a seleccionar
        /// </summary>
        /// <param name="e">Los eventos lanzados por el control.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            try
            {
                // Verifica si se ha dado clic sobre alguno de los nodos
                TreeNode node = this.GetNodeAt(e.Location);
                if (node != null)
                {
                    if (ModifierKeys == Keys.None && m_SelectedNodes.Contains(node))
                    {
                        int leftBound = node.Bounds.X; // -20; // // Permite al usuario hacer clic sobre la imágen y se use como selección
                        int rightBound = node.Bounds.Right + 10; // Permite dar un rango extra de selección 
                        if (e.Location.X > leftBound && e.Location.X < rightBound)
                        {

                            SelectNode(node);
                        }
                    }
                }

                base.OnMouseUp(e);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        protected override void OnItemDrag(ItemDragEventArgs e)
        {
            try
            {
                TreeNode node = e.Item as TreeNode;

                if (node != null)
                {
                    if (!m_SelectedNodes.Contains(node))
                    {
                        SelectSingleNode(node);
                        ToggleNode(node, true);
                    }
                }

                base.OnItemDrag(e);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        /// <summary>
        /// Evento para evitar que se utilice SelectedNode del objeto base
        /// </summary>
        /// <param name="e">Los eventos lanzados por el control.</param>
        protected override void OnBeforeSelect(TreeViewCancelEventArgs e)
        {
            try
            {
                base.SelectedNode = null;
                e.Cancel = true;

                base.OnBeforeSelect(e);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        /// <summary>
        /// Evento para evitar que se utilice SelectedNode del objeto base
        /// </summary>
        /// <param name="e">Los eventos lanzados por el control.</param>
        protected override void OnAfterSelect(TreeViewEventArgs e)
        {
            try
            {
                base.OnAfterSelect(e);
                base.SelectedNode = null;
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {

            base.OnKeyDown(e);

            if (e.KeyCode == Keys.ShiftKey) return;

            bool bShift = (ModifierKeys == Keys.Shift);

            try
            {
                // Si no hay selección, seleccionar el nodo inicial como default para evitar error
                if (m_SelectedNode == null && this.TopNode != null)
                {
                    ToggleNode(this.TopNode, true);
                }

                if (m_SelectedNode == null) return;

                if (e.KeyCode == Keys.Left)
                {
                    if (m_SelectedNode.IsExpanded && m_SelectedNode.Nodes.Count > 0)
                    {
                        m_SelectedNode.Collapse();
                    }
                    else if (m_SelectedNode.Parent != null)
                    {
                        SelectSingleNode(m_SelectedNode.Parent);
                    }
                }
                else if (e.KeyCode == Keys.Right)
                {
                    if (!m_SelectedNode.IsExpanded)
                    {
                        m_SelectedNode.Expand();
                    }
                    else
                    {
                        SelectSingleNode(m_SelectedNode.FirstNode);
                    }
                }
                else if (e.KeyCode == Keys.Up)
                {
                    // Selecciona el nodo anterior
                    if (m_SelectedNode.PrevVisibleNode != null)
                    {
                        SelectNode(m_SelectedNode.PrevVisibleNode);
                    }
                }
                else if (e.KeyCode == Keys.Down)
                {
                    // Selecciona el siguiente nodo
                    if (m_SelectedNode.NextVisibleNode != null)
                    {
                        SelectNode(m_SelectedNode.NextVisibleNode);
                    }
                }
                else if (e.KeyCode == Keys.Home)
                {
                    if (bShift)
                    {
                        if (m_SelectedNode.Parent == null)
                        {
                            // Selecciona todos los nodos desde el que está seleccionado hasta al primero
                            if (this.Nodes.Count > 0)
                            {
                                SelectNode(this.Nodes[0]);
                            }
                        }
                        else
                        {
                            SelectNode(m_SelectedNode.Parent.FirstNode);
                        }
                    }
                    else
                    {
                        // Select this first node in the tree
                        if (this.Nodes.Count > 0)
                        {
                            SelectSingleNode(this.Nodes[0]);
                        }
                    }
                }
                else if (e.KeyCode == Keys.End)
                {
                    if (bShift)
                    {
                        if (m_SelectedNode.Parent == null)
                        {
                            if (this.Nodes.Count > 0)
                            {
                                SelectNode(this.Nodes[this.Nodes.Count - 1]);
                            }
                        }
                        else
                        {
                            SelectNode(m_SelectedNode.Parent.LastNode);
                        }
                    }
                    else
                    {
                        if (this.Nodes.Count > 0)
                        {
                            TreeNode ndLast = this.Nodes[0].LastNode;
                            while (ndLast.IsExpanded && (ndLast.LastNode != null))
                            {
                                ndLast = ndLast.LastNode;
                            }
                            SelectSingleNode(ndLast);
                        }
                    }
                }
                else if (e.KeyCode == Keys.PageUp)
                {
                    int nCount = this.VisibleCount;
                    TreeNode ndCurrent = m_SelectedNode;
                    while ((nCount) > 0 && (ndCurrent.PrevVisibleNode != null))
                    {
                        ndCurrent = ndCurrent.PrevVisibleNode;
                        nCount--;
                    }
                    SelectSingleNode(ndCurrent);
                }
                else if (e.KeyCode == Keys.PageDown)
                {
                    int nCount = this.VisibleCount;
                    TreeNode ndCurrent = m_SelectedNode;
                    while ((nCount) > 0 && (ndCurrent.NextVisibleNode != null))
                    {
                        ndCurrent = ndCurrent.NextVisibleNode;
                        nCount--;
                    }
                    SelectSingleNode(ndCurrent);
                }
                else
                {
                    string sSearch = ((char)e.KeyValue).ToString();

                    TreeNode ndCurrent = m_SelectedNode;
                    while ((ndCurrent.NextVisibleNode != null))
                    {
                        ndCurrent = ndCurrent.NextVisibleNode;
                        if (ndCurrent.Text.StartsWith(sSearch))
                        {
                            SelectSingleNode(ndCurrent);
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
            finally
            {
                this.EndUpdate();
            }
        }

        #endregion

        #region Helper Methods

        private void SelectNode(TreeNode node)
        {
            try
            {
                this.BeginUpdate();

                if (m_SelectedNode == null || ModifierKeys == Keys.Control)
                {
                    // Ctrl+Click selecciona y deselecciona el nodo
                    bool bIsSelected = m_SelectedNodes.Contains(node);
                    ToggleNode(node, !bIsSelected);
                }
                else if (ModifierKeys == Keys.Shift)
                {
                    // Shift+Click selecciona los nodos entre el nodo seleccionado y hasta el último seleccionado
                    TreeNode ndStart = m_SelectedNode;
                    TreeNode ndEnd = node;

                    if (ndStart.Parent == ndEnd.Parent)
                    {
                        if (ndStart.Index < ndEnd.Index)
                        {
                            while (ndStart != ndEnd)
                            {
                                ndStart = ndStart.NextVisibleNode;
                                if (ndStart == null) break;
                                ToggleNode(ndStart, true);
                            }
                        }
                        else if (ndStart.Index == ndEnd.Index)
                        {

                        }
                        else
                        {
                            while (ndStart != ndEnd)
                            {
                                ndStart = ndStart.PrevVisibleNode;
                                if (ndStart == null) break;
                                ToggleNode(ndStart, true);
                            }
                        }
                    }
                    else
                    {

                        TreeNode ndStartP = ndStart;
                        TreeNode ndEndP = ndEnd;
                        int startDepth = Math.Min(ndStartP.Level, ndEndP.Level);

                        while (ndStartP.Level > startDepth)
                        {
                            ndStartP = ndStartP.Parent;
                        }

                        while (ndEndP.Level > startDepth)
                        {
                            ndEndP = ndEndP.Parent;
                        }

                        while (ndStartP.Parent != ndEndP.Parent)
                        {
                            ndStartP = ndStartP.Parent;
                            ndEndP = ndEndP.Parent;
                        }

                        if (ndStartP.Index < ndEndP.Index)
                        {
                            while (ndStart != ndEnd)
                            {
                                ndStart = ndStart.NextVisibleNode;
                                if (ndStart == null) break;
                                ToggleNode(ndStart, true);
                            }
                        }
                        else if (ndStartP.Index == ndEndP.Index)
                        {
                            if (ndStart.Level < ndEnd.Level)
                            {
                                while (ndStart != ndEnd)
                                {
                                    ndStart = ndStart.NextVisibleNode;
                                    if (ndStart == null) break;
                                    ToggleNode(ndStart, true);
                                }
                            }
                            else
                            {
                                while (ndStart != ndEnd)
                                {
                                    ndStart = ndStart.PrevVisibleNode;
                                    if (ndStart == null) break;
                                    ToggleNode(ndStart, true);
                                }
                            }
                        }
                        else
                        {
                            while (ndStart != ndEnd)
                            {
                                ndStart = ndStart.PrevVisibleNode;
                                if (ndStart == null) break;
                                ToggleNode(ndStart, true);
                            }
                        }
                    }
                }
                else
                {
                    SelectSingleNode(node);
                }

                OnAfterSelect(new TreeViewEventArgs(m_SelectedNode));
            }
            finally
            {
                this.EndUpdate();
            }
        }

        /// <summary>
        /// Limpia los nodoso seleccionos
        /// </summary>
        private void ClearSelectedNodes()
        {
            try
            {
                foreach (TreeNode node in m_SelectedNodes)
                {
                    node.BackColor = this.BackColor;
                    node.ForeColor = this.ForeColor;
                    node.ImageIndex = this.ImageIndexDefault;
                }
            }
            finally
            {
                m_SelectedNodes.Clear();
                m_SelectedNode = null;
            }
        }

        private void SelectSingleNode(TreeNode node)
        {
            if (node == null)
            {
                return;
            }

            ClearSelectedNodes();
            ToggleNode(node, true);
            node.EnsureVisible();
        }

        private void ToggleNode(TreeNode node, bool bSelectNode)
        {
            if (bSelectNode)
            {
                string group = node.Text.Split(new char[] { '-' })[0].Trim();
               
                if (group.Equals("O"))
                {
                    m_SelectedNode = node;
                    if (!m_SelectedNodes.Contains(node))
                    {
                        m_SelectedNodes.Add(node);
                    }

                    node.BackColor = SystemColors.Highlight;
                    node.ForeColor = SystemColors.HighlightText;
                    node.ImageIndex = this.ImageIndexSelectedOptional;
                }
            }
            else
            {
                m_SelectedNodes.Remove(node);
                node.ImageIndex = this.ImageIndexDefault;
                node.BackColor = this.BackColor;
                node.ForeColor = this.ForeColor;
            }
        }

        /// <summary>
        /// Manejador de error
        /// </summary>
        /// <param name="ex"></param>
        private void HandleException(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

        #endregion
    }
}

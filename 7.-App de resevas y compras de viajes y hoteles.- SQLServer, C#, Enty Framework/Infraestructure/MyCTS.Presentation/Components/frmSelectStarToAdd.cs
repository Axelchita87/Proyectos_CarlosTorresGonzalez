using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MyCTS.Entities;

namespace MyCTS.Presentation
{
    public partial class frmSelectStarToAdd : Form
    {
        public List<CatAllStars> Stars = new List<CatAllStars>();
        public List<int> starIndex = new List<int>();
        public frmSelectStarToAdd()
        {
            InitializeComponent();
        }

        private void frmSelectStarToAdd_Load(object sender, EventArgs e)
        {
            if (Stars.Count > 0)
            {
                foreach (CatAllStars item in Stars)
                {
                    TreeNode node = new TreeNode();
                    node.Name = item.StarName;
                    node.Text = item.StarName;
                    treeViewStars.Nodes.Add(node);
                }
                treeViewStars.ExpandAll();
                treeViewStars.Focus();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            foreach (TreeNode node in treeViewStars.Nodes)
            {
                if (node.Checked)
                    starIndex.Add(node.Index);
            }
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (TreeNode node in treeViewStars.Nodes)
                node.Checked = ((CheckBox)sender).Checked;
        }

    }
}
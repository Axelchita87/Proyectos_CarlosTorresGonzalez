using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyCTS.Presentation.Components
{
    public partial class ucMultiLineSmartText : UserControl
    {
        public ucMultiLineSmartText()
        {
            InitializeComponent();
        }

        private int lastCtrlLocation = 62+29;
       

        private void button1_Click(object sender, EventArgs e)
        {
            LineSmartText lineSmart =new LineSmartText();
            Panel pnl1 = (Panel)this.Controls.Find("panel1", false)[0];
            lineSmart.Location = new System.Drawing.Point(1, lastCtrlLocation);
            lineSmart.Focus();
            panel1.Controls.Add(lineSmart);

            //lastCtrlLocation += 29;

            //foreach (Control c in pnl1.Controls)
            //{
            //    Panel pnlChild = (Panel)c;
            //    TextBox txt = (TextBox)c.Controls[1];
            //    ComboBox cmb = (ComboBox)c.Controls[0];

            //    b = string.EmptC:\Users\imartinez\Desktop\Emmanuel\SolutionMyCTSV2\Infraestructure\MyCTS.Presentation\Components\ucMultiLineSmartText.csy;
            //    a = txt.Text;
            //    if (cmb.SelectedItem != null)
            //        b = cmb.SelectedItem.ToString();

            //    MessageBox.Show(a + b);
            }
        }

       
    }


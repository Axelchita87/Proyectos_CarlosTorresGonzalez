using MyCTS.Business;
using MyCTS.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyCTS.Presentation.Reservations.Tickets.TicketsEmission
{
    public partial class frmCreateOrDiscartProfile : Form
    {
        public static List<int> ChkedRow;
        public static List<int> ChkedRowN;
        public static bool isSelect = false;
        bool closeUser;
        public frmCreateOrDiscartProfile()
        {
            InitializeComponent();
        }


        private void frmCreateOrDiscartProfile_Load(object sender, EventArgs e)
        {
            List<NewPassengerProfile> exist = ucServicesFeePayApply.exist;
            List<NewPassengerProfile> notExist = ucServicesFeePayApply.notExist;
            closeUser = true;
            if (exist.Count != 0)
            {
                dataGridView1.ColumnCount = 2;
                dataGridView1.Columns[0].Name = "Nombre";
                dataGridView1.Columns[1].Name = "Email";

                dataGridView1.Columns[0].Width = 200;
                dataGridView1.Columns[1].Width = 200;
                string[] row;

                foreach (NewPassengerProfile item in exist)
                {
                    row = new string[] { item.Name + " " + item.LastName, item.Email };
                    dataGridView1.Rows.Add(row);
                }

                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                dataGridView1.Columns.Add(chk);
                chk.HeaderText = "Seleccione";
                chk.Name = "chk";
            }
            else
            {
                dataGridView1.Visible=false;
                label1.Visible = false ;
            }
            if (notExist.Count != 0)
            {
                dataGridView2.ColumnCount = 2;
                dataGridView2.Columns[0].Name = "Nombre";
                dataGridView2.Columns[1].Name = "Email";

                dataGridView2.Columns[0].Width = 200;
                dataGridView2.Columns[1].Width = 200;


                string[] row;
                foreach (NewPassengerProfile item in notExist)
                {
                    row = new string[] { item.Name + " " + item.LastName, item.Email };
                    dataGridView2.Rows.Add(row);
                }


                DataGridViewCheckBoxColumn chkNew = new DataGridViewCheckBoxColumn();
                dataGridView2.Columns.Add(chkNew);
                chkNew.HeaderText = "Seleccione";
                chkNew.Name = "chkNew";
            }
            else
            {
                dataGridView2.Visible = false;
                label2.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           ChkedRow = new List<int>();
           ChkedRowN = new List<int>();
            DataRow dr;

            for (int i = 0; i <= dataGridView1.RowCount - 1; i++)
            {
                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells["chk"].Value) == true)
                {
                    isSelect = true;
                    ChkedRow.Add(i);
                }

            }
            for (int i = 0; i <= dataGridView2.RowCount - 1; i++)
            {
                if (Convert.ToBoolean(dataGridView2.Rows[i].Cells["chkNew"].Value) == true)
                {
                    isSelect = true;
                    ChkedRowN.Add(i);
                }


            }
            closeUser = false;
            this.Close();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("El perfil no se puede editar ya que 
            //int co = e.ColumnIndex;
            //int ro = e.RowIndex;
            //if (co == -1 || co == 2)
            //    return;

            //string value = dataGridView1[co, ro].Value.ToString();
            //if (co == 0)
            //    ucServicesFeePayApply.exist[ro].Name = value;
            //else if (co == 1)
            //    ucServicesFeePayApply.exist[ro].Email = value;
        }

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int co = e.ColumnIndex;
            int ro = e.RowIndex;
            if (co == -1 || co == 2)
                return;
            string value = dataGridView2[co, ro].Value.ToString();
            if (co == 0)
                ucServicesFeePayApply.notExist[ro].Name = value;
            else if (co == 1)
                ucServicesFeePayApply.notExist[ro].Email = value;
        }

        private void frmCreateOrDiscartProfile_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(closeUser)
                isSelect = false;
        }
    }
}

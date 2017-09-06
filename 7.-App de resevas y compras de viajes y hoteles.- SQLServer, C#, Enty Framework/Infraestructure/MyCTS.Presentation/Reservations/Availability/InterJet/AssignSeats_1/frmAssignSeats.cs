using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
namespace MyCTS.Presentation
{
    public partial class frmAssignSeats : Form
    {
        public frmAssignSeats(List<MyCTS.Services.APIInterJet.GetSeatAvailabilityResponse> listResponse, Entities.InterJetTicket ticket)
        {
            InitializeComponent();

            booking = listResponse;
            tickets = ticket;
        }

        private List<MyCTS.Services.APIInterJet.GetSeatAvailabilityResponse> booking;
        private Entities.InterJetTicket tickets;
        private interjetSeats interjetSeats;

        private int rowSelect = -1;
        private int numPas = 0;
        private int numP = 1;
        private bool onclick = true;
        private List<interjetSeats> listInterjetSeats = new List<interjetSeats>();

        public static List<interjetSeats> listInterjetSeatsReturn = new List<interjetSeats>();

        private void Form1_Load(object sender, EventArgs e)
        {
            assignAsets();
            listInterjetSeatsReturn = new List<interjetSeats>();
        }


        string airPlane;
        string airPlaneName;
        string arrivalStation;
        string departureStation;
        int segments = 0;
        int dispo = 0;

        public void assignAsets()
        {
            try
            {
                numP = 1;
                numPas = 0;
                airPlaneName = booking[segments].SeatAvailabilityResponse.EquipmentInfos[0].Name;
                airPlane = booking[segments].SeatAvailabilityResponse.EquipmentInfos[0].EquipmentType;
                arrivalStation = booking[segments].SeatAvailabilityResponse.EquipmentInfos[0].ArrivalStation;
                departureStation = booking[segments].SeatAvailabilityResponse.EquipmentInfos[0].DepartureStation;

                lblAirPlane.Text = airPlaneName;
                List<MyCTS.Services.APIInterJet.SeatInfo> listSeats = booking[segments].SeatAvailabilityResponse.EquipmentInfos[0].Compartments[0].Seats;
                panel1.Controls.Clear();
                if (airPlane == "320")
                {
                    ucInterjetAirPlane1 panel = new ucInterjetAirPlane1();
                    panel1.Controls.Add(panel);
                }
                else
                {
                    ucInterjetAirPlane2 panel = new ucInterjetAirPlane2();
                    panel1.Controls.Add(panel);
                }
                onclick = true;
                for (int i = 0; i < listSeats.Count; i++)
                {
                    string seatAvailability = listSeats[i].SeatAvailability.ToString();
                    string seatDesignator = listSeats[i].SeatDesignator;

                    if (!seatDesignator.Contains('$'))
                    {
                        findControl(seatDesignator, seatAvailability);
                    }
                }
                if (dispo == 0)
                {
                    segments++;
                    MessageBox.Show("No hay asientos disponibles para el segmento " + departureStation + "-" + arrivalStation + " ", "MyCTS");
                    assignAsets();
                }
                else
                {

                    onclick = false;
                    List<Entities.InterJetPassanger> pass = tickets.Passangers.GetAll();

                    listInterjetSeats.Clear();
                    for (int i = 0; i < pass.Count; i++)
                    {
                        if(!pass[i].ToString().Contains("Menor"))
                        {
                            interjetSeats = new interjetSeats();
                            interjetSeats.Id = pass[i].ID;
                            interjetSeats.Name = pass[i].FullName;
                            interjetSeats.Seat = "";
                            listInterjetSeats.Add(interjetSeats);
                            numPas++;
                        }
                    }
                    setGrid();
                }
            }
            catch (Exception err)
            {
            }
        }

        private void findControl(string name, string avalability)
        {
            Control[] tbxs;

            if (airPlane == "320")
                tbxs = this.Controls.Find("txt" + name, true);
            else
                tbxs = this.Controls.Find("txt" + name + name.Substring(name.Length - 1), true);

            if (tbxs != null && tbxs.Length > 0)
            {
                TextBox txtbox = (TextBox)tbxs[0];
                txtbox.Text = name;
                if (onclick)
                {
                    txtbox.Click += new System.EventHandler(this.txt1A_Click);
                    txtbox.MouseLeave += new System.EventHandler(this.txt1FF_MouseLeave);
                    txtbox.MouseHover += new System.EventHandler(this.txt1FF_MouseHover);
                }
                txtbox.ReadOnly = true;

                switch (avalability)
                {
                    case "Unknown":
                        tbxs[0].BackColor = Color.Silver;
                        tbxs[0].Enabled = false;
                        break;
                    case "Reserved":
                        tbxs[0].BackColor = Color.Silver;
                        tbxs[0].Enabled = false;
                        break;
                    case "Restricted":
                        tbxs[0].BackColor = Color.Silver;
                        tbxs[0].Enabled = false;
                        break;
                    case "Open":
                        tbxs[0].BackColor = Color.YellowGreen;
                        dispo++;
                        break;
                    default:
                        tbxs[0].BackColor = Color.Silver;
                        tbxs[0].Enabled = false;
                        break;

                }
            }
        }

        public void setGrid()
        {
            try
            {
                dataGridView1.Rows.Clear();

                for (int i = 0; i < listInterjetSeats.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["ID"].Value = listInterjetSeats[i].Id;
                    dataGridView1.Rows[i].Cells["Asiento"].Value = listInterjetSeats[i].Seat == string.Empty ? "Sin Asignar." : listInterjetSeats[i].Seat;
                    dataGridView1.Rows[i].Cells["Pasajero"].Value = listInterjetSeats[i].Name;
                    dataGridView1.Rows[i].Cells["Segmento"].Value = departureStation + " - " + arrivalStation;
                    Icon updateimg = Resources.Resources.editar;
                    dataGridView1.Rows[i].Cells["Selecciona"].Value = updateimg;
                }
            }
            catch (Exception err)
            {
            }
        }

        private void txt1A_Click(object sender, EventArgs e)
        {
            try
            {
                int column = -1;

                if (rowSelect != -1)
                    column = rowSelect;
                else if (numP <= numPas)
                    column = numP -1;
                else
                    return;

                TextBox txt = (TextBox)sender;

                if (txt.BackColor == Color.Yellow)
                {
                    MessageBox.Show("El asiento esta ocupado, por favor seleccione otro.", "MYCTS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (column != -1)
                {
                    if (listInterjetSeats[column].Seat != string.Empty)
                    {
                        findControl(listInterjetSeats[column].Seat, "Open");
                    }

                    listInterjetSeats[column].Seat = txt.Text;

                    txt.BackColor = Color.Yellow;
                    setGrid();
                    lblAlerta.Text = "El asiento " + txt.Text + " se asigno al pasajero \n" + listInterjetSeats[column].Name;
                    rowSelect = -1;

                    numP++;
                }
                else
                {
                    lblAlerta.Text = "Seleccione el pasajero que desea modificar.";
                }
            }
            catch (Exception err)
            {
                throw new Exception();
            }
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int col = e.ColumnIndex;
            int row = e.RowIndex;
            onclick = true;
            if (col == 3 && row != -1)
            {
                rowSelect = row;
                lblAlerta.Text = "Selecciona un asiento disponible para el pasajero \n" + listInterjetSeats[rowSelect].Name;
            }
        }

        private void txt1FF_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void txt1FF_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int numV = booking.Count / 2;
                string vuelo = string.Empty;

                if (segments <= numV)
                {
                    vuelo = "Ida";
                }
                else
                {
                    vuelo = "Vuelta";
                }

                segments++;
                lblAlerta.Text = "";

                //listInterjetSeatsReturn = null;
                //listInterjetSeatsReturn = new List<interjetSeats>();

                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    if (dataGridView1.Rows[j].Cells["Asiento"].Value.ToString() != "Sin Asignar.")
                    {
                        interjetSeats = new interjetSeats();
                        interjetSeats.Id = dataGridView1.Rows[j].Cells["ID"].Value.ToString();
                        interjetSeats.Name = dataGridView1.Rows[j].Cells["Pasajero"].Value.ToString();
                        interjetSeats.Segment = departureStation + " - " + arrivalStation;
                        interjetSeats.Seat = dataGridView1.Rows[j].Cells["Asiento"].Value.ToString();
                        interjetSeats.IsSelect = true;
                        interjetSeats.typeSegment = vuelo;
                        listInterjetSeatsReturn.Add(interjetSeats);
                    }
                    //else
                    //{
                    //    MessageBox.Show("Seleccione asiento para el pasajero ." + dataGridView1.Rows[j].Cells["Pasajero"].Value.ToString(), "MYCTS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    return;
                    //}
                }

                if (segments != booking.Count)
                {
                    MessageBox.Show("Se asignaron correctamente los asientos para el segmento " + departureStation + " - " + arrivalStation + "\nContinuara con el siguiente segmento.", "MYCTS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    assignAsets();
                }
                else
                {
                    MessageBox.Show("Se asignaron correctamente los asientos para el segmento " + departureStation + " - " + arrivalStation, "MYCTS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }

            }
            catch (Exception err)
            {
                throw new Exception();
            }
        }
    }

    public class interjetSeats
    {
        private string id;
        private string name;
        private string seat;
        private string segment;
        private string tipeSegment;
        private bool select;
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Seat
        {
            get { return seat; }
            set { seat = value; }
        }
        public string Segment
        {
            get { return segment; }
            set { segment = value; }
        }
        public bool IsSelect
        {
            get { return select; }
            set { select = value; }
        }
        public string typeSegment
        {
            get { return tipeSegment; }
            set { tipeSegment = value; }
        }
    }

    public class paxSeats
    {
        public string Name
        {
            get;
            set;
        }
        public string Seat
        {
            get;
            set;
        }
        public string Segment
        {
            get;
            set;
        }
    }
}

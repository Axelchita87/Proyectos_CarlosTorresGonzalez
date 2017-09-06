using MyCTS.Entities;
using MyCTS.Forms.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MyCTS.Presentation.Components
{
    public partial class frmProfilesCreditCards : Form
    {

        private List<string> listCreditCardsFirstLevel = new List<string>();
        public static List<string> listCreditCardsSecondLevel = new List<string>();
        private List<string> listCreditCardsFirstLevelHide = new List<string>();
        private List<string> listCreditCardsSecondLevelHide = new List<string>();
        private int indexSelector = 0;
        Control.ControlCollection ucControls;
        public static List<string> creditCardNameCVV;
        public static bool flag = false;
        public frmProfilesCreditCards(List<string> listCreditCardsFirstL, List<string> listCreditCardsSecondL, Control.ControlCollection controls, int ucIndexCollector)
        {
            InitializeComponent();
            listCreditCardsFirstLevel = listCreditCardsFirstL;
            listCreditCardsSecondLevel = listCreditCardsSecondL;
            ucControls = controls;
            indexSelector = ucIndexCollector;
            firstLevelCombo.Focus();
        }

        public frmProfilesCreditCards(List<Entities.InterJetProfileCreditCard> lstFirst, Entities.InterJetProfile secondLevel)
        {
            InitializeComponent();
            foreach (var element in lstFirst)
                listCreditCardsFirstLevel.Add(element.CreditCardNumberProtected);
            foreach (var element in secondLevel.CreditCards.GetCards())
            {
                listCreditCardsSecondLevel.Add(element.CreditCardNumberProtected);
            }
        }

        private string selectedCrediCard;
        public static string selectCreditCard ;
        public string SelectedCrediCard
        {
            get { return selectedCrediCard; }
        }

       

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (ValidateBussinesRules)
            {
                if (firstLevelCheckBox.Checked)
                {
                    int selectedindex = firstLevelCombo.SelectedIndex;
                    selectedCrediCard = listCreditCardsFirstLevel[selectedindex-1];
                    Close();
                }
                else if (secondLevelCheckBox.Checked)
                {
                    int selectedindex = secondLevelCombo.SelectedIndex;
                    selectedCrediCard = listCreditCardsSecondLevel[selectedindex-1];

                    Close();
                }
            }
            else
                selectedCrediCard = string.Empty;
        }

        public bool ValidateBussinesRules
        {
            get 
            {
                bool isValid= true;
                if (firstLevelCombo.Enabled && secondLevelCombo.Enabled)
                {
                    if ((firstLevelCheckBox.Checked && firstLevelCombo.SelectedItem.ToString() == "Seleccione una opción:") && (!secondLevelCheckBox.Checked && secondLevelCombo.SelectedItem.ToString() == "Seleccione una opción:"))
                    {
                        MessageBox.Show("Debes seleccionar de la lista, la tarjeta que deseas utilizar");
                        isValid = false;
                    }
                    else if ((!firstLevelCheckBox.Checked && firstLevelCombo.SelectedItem.ToString() != "Seleccione una opción:") && (!secondLevelCheckBox.Checked && secondLevelCombo.SelectedItem.ToString() == "Seleccione una opción:"))
                    {
                        MessageBox.Show("Debes seleccionar una casilla para utilizar la tarjeta seleccionada");
                        isValid = false;
                    }
                    else if ((secondLevelCheckBox.Checked && secondLevelCombo.SelectedItem.ToString() == "Seleccione una opción:") && (!firstLevelCheckBox.Checked && firstLevelCombo.SelectedItem.ToString() == "Seleccione una opción:"))
                    {
                        MessageBox.Show("Debes seleccionar de la lista, la tarjeta que deseas utilizar");
                        isValid = false;
                    }
                    else if ((!secondLevelCheckBox.Checked && secondLevelCombo.SelectedItem.ToString() != "Seleccione una opción:") && (!firstLevelCheckBox.Checked && firstLevelCombo.SelectedItem.ToString() == "Seleccione una opción:"))
                    {
                        MessageBox.Show("Debes seleccionar una casilla para utilizar la tarjeta seleccionada");
                        isValid = false;
                    }
                    if (firstLevelCheckBox.Checked && secondLevelCombo.SelectedItem.ToString() != "Seleccione una opción:" && firstLevelCombo.SelectedItem.ToString() == "Seleccione una opción:")
                    {
                        MessageBox.Show("Debes seleccionar una casilla y una tarjeta del mismo nivel");
                        isValid = false;
                    }
                    else if (secondLevelCheckBox.Checked && firstLevelCombo.SelectedItem.ToString() != "Seleccione una opción:" && secondLevelCombo.SelectedItem.ToString() == "Seleccione una opción:")
                    {
                        MessageBox.Show("Debes seleccionar una casilla y una tarjeta del mismo nivel");
                        isValid = false;
                    }
                    else if ((!secondLevelCheckBox.Checked && secondLevelCombo.SelectedItem.ToString() == "Seleccione una opción:") && (firstLevelCheckBox.Checked && firstLevelCombo.SelectedItem.ToString() == "Seleccione una opción:"))
                    {
                        MessageBox.Show("Debes seleccionar una casilla y una tarjeta del mismo nivel");
                        isValid = false;
                    }
                }
                else if (!firstLevelCombo.Enabled)
                {
                    if (secondLevelCheckBox.Checked && secondLevelCombo.SelectedItem.ToString() == "Seleccione una opción:")
                    {
                        MessageBox.Show("Debes seleccionar de la lista, la tarjeta que deseas utilizar");
                        isValid = false;
                    }
                    else if (!secondLevelCheckBox.Checked && secondLevelCombo.SelectedItem.ToString() != "Seleccione una opción:")
                    {
                        MessageBox.Show("Debes seleccionar una casilla para utilizar la tarjeta seleccionada");
                        isValid = false;
                    }
                    else if (!secondLevelCheckBox.Checked && secondLevelCombo.SelectedItem.ToString() == "Seleccione una opción:")
                    {
                        MessageBox.Show("Debes seleccionar la casilla y una tarjeta");
                        isValid = false;
                    }
                }
                else if (!secondLevelCombo.Enabled)
                {
                    if (firstLevelCheckBox.Checked && firstLevelCombo.SelectedItem.ToString() == "Seleccione una opción:")
                    {
                        MessageBox.Show("Debes seleccionar de la lista, la tarjeta que deseas utilizar");
                        isValid = false;
                    }
                    else if (!firstLevelCheckBox.Checked && firstLevelCombo.SelectedItem.ToString() != "Seleccione una opción:")
                    {
                        MessageBox.Show("Debes seleccionar una casilla para utilizar la tarjeta seleccionada");
                        isValid = false;
                    }
                    else if (!firstLevelCheckBox.Checked && firstLevelCombo.SelectedItem.ToString() == "Seleccione una opción:")
                    {
                        MessageBox.Show("Debes seleccionar la casilla y una tarjeta");
                        isValid = false;
                    }
                }



                return isValid;
            }
        }

        private void btnDeny_Click(object sender, EventArgs e)
        {
            selectedCrediCard = string.Empty;
            Close();
        }

        private void frmProfilesCreditCards_Load(object sender, EventArgs e)
        {
            selectedCrediCard = string.Empty;
            if (listCreditCardsFirstLevel.Count > 0)
            {
                firstLevelCombo.Enabled = true;
                firstLevelCheckBox.Enabled = true;
                listCreditCardsFirstLevelHide.Add("Seleccione una opción:");
                for (int y = 0; y <= listCreditCardsFirstLevel.Count - 1; y++)
                {
                    string creditcardHide = string.Empty;
                    string[] parts = listCreditCardsFirstLevel[y].Split(' ');
                    string code = parts[0].Split('-')[0];
                    string number = parts[0].Split('-')[1];
                    string hideNumber = string.Empty;


                    for (int x = 0; x <= number.Length - 4; x++)
                        hideNumber = hideNumber + "X";

                    hideNumber = hideNumber + number.Substring(number.Length - 4, 4);
                    var typeServ = parts[2].Split('^');
                    creditcardHide = string.Concat(code, "-", hideNumber, "  ", typeServ[0] + " " + typeServ[1] + " " + typeServ[2] + " " + typeServ[3].Replace('¨', ' '));
                    listCreditCardsFirstLevelHide.Add(creditcardHide);
                }
                firstLevelCombo.Items.Clear();
                foreach (string creditCard in listCreditCardsFirstLevelHide)
                {
                    firstLevelCombo.Items.Add(creditCard);
                }
                firstLevelCombo.SelectedIndex = 0;
            }
            else
            {
                firstLevelCombo.Enabled = false;
                firstLevelCheckBox.Enabled = false;
            }

            if (listCreditCardsSecondLevel.Count > 0)
            {
                secondLevelCombo.Enabled = true;
                secondLevelCheckBox.Enabled = true;
                listCreditCardsSecondLevelHide.Add("Seleccione una opción:");
                creditCardNameCVV = new List<string>();
                for (int y = 0; y <= listCreditCardsSecondLevel.Count - 1; y++)
                {
                    string creditcardHide = string.Empty;
                    string[] parts = listCreditCardsSecondLevel[y].Split(' ');
                    string[] inf = listCreditCardsSecondLevel[y].Split('^');
                    string code = parts[0].Split('-')[0];
                    string number = parts[0].Split('-')[1];
                    string cvv = (inf.Length >= 2)? inf[1] : " ";
                    string nameClient = (inf.Length >= 3)? inf[2] : " ";
                    string hideNumber = string.Empty;
                    creditCardNameCVV.Add(nameClient);
                    creditCardNameCVV.Add(cvv);

                    for (int x = 0; x <= number.Length - 4; x++)
                        hideNumber = hideNumber + "X";

                    hideNumber = hideNumber + number.Substring(number.Length - 4, 4);
                    creditcardHide = string.Concat(code, "-", hideNumber);
                    listCreditCardsSecondLevelHide.Add(creditcardHide);
                }


                secondLevelCombo.Items.Clear();
                foreach (string creditCard in listCreditCardsSecondLevelHide)
                {
                    secondLevelCombo.Items.Add(creditCard);
                }
                secondLevelCombo.SelectedIndex = 0;
            }
            else
            {
                secondLevelCombo.Enabled = false;
                secondLevelCheckBox.Enabled = false;
            }
        }

        private void secondLevelCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            firstLevelCheckBox.Checked = false;
            //secondLevelCheckBox.Checked = true;
        }

        private void firstLevelCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            secondLevelCheckBox.Checked = false;
            //firstLevelCheckBox.Checked = true;
        }

        private void frmProfilesCreditCards_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedCrediCard))
            {
                string[] creditcardParts = selectedCrediCard.Split(' ');
                selectCreditCard = selectedCrediCard;
                string code = creditcardParts[0].Split('-')[0];
                string number = creditcardParts[0].Split('-')[1];
                string month = creditcardParts[1].Split('/')[0];
                string year = creditcardParts[1].Split('/')[1].Substring(0,2);
                string[] inf = creditcardParts[1].Split('^');
                string cvv = (inf.Length > 1) ? inf[1] : string.Empty;
                
                //listCreditCardsSecondLevel
                
                if (indexSelector.Equals(0))
                {
                    SmartTextBox ctrl = (SmartTextBox)ucControls.Find("txtTypeCard", true)[0];
                    ctrl.Text = code;

                    ctrl = (SmartTextBox)ucControls.Find("txtSecurityCode", true)[0];
                    ctrl.Text = new string( Common.toDecrypt(cvv).Where(char.IsDigit).ToArray()); 
                    ctrl = (SmartTextBox)ucControls.Find("txtNumberCard", true)[0];
                    ctrl.Text = number;

                    ctrl = (SmartTextBox)ucControls.Find("txtMonth", true)[0];
                    ctrl.Text = month;

                    ctrl = (SmartTextBox)ucControls.Find("txtYear", true)[0];
                    ctrl.Text = year;

                    Button btn = (Button)ucControls.Find("btnShow", true)[0];
                    btn.Visible = true;
                }
                else
                {
                    //SmartTextBox ctrl = (SmartTextBox)ucControls.Find("txtTypeCardCTS", true)[0];
                    //string codeCTS = string.Empty;
                    //switch (code)
                    //{
                    //    case "AX":
                    //        codeCTS = "CCAC";
                    //        break;
                    //    case "CA":
                    //        codeCTS = "CCPV";
                    //        break;
                    //    case "VI":
                    //        codeCTS = "CCPV";
                    //        break;
                    //    case "TP":
                    //        codeCTS = "CCTC";
                    //        break;
                    //    default:
                    //        codeCTS = code;
                    //        break;

                    //}
                    //ctrl.Text = codeCTS;
                    ComboBox ctrlCmb = (ComboBox)ucControls.Find("CmbTypeCard", true)[0];
                    for (int i = 1; i < ctrlCmb.Items.Count; i++)
                    {

                        if (((ListItem)ctrlCmb.Items[i]).Value.Equals(code))
                        {
                            ctrlCmb.SelectedIndex = i;
                            break;
                        }
                    }   

                    SmartTextBox ctrl = (SmartTextBox)ucControls.Find("txtNumberCardCTS", true)[0];
                    ctrl.Text = number;

                    Button btn = (Button)ucControls.Find("btnShowCTS", true)[0];
                    btn.Visible = true;
                }
            }           
        }
    }
}

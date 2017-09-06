using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Business;
using MyCTS.Entities;
using MyCTS.Services.ValidateDKsAndCreditCards;
using System.Linq;
using System.Text;
using System.Configuration;
using DevExpress.Utils.OAuth.Provider;

namespace MyCTS.Presentation
{
    public partial class ucCorporateCRUD : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Permite realizar el CRUD a la informacion de ToolsOnlineRules
        /// Creación:   12/06/13 , Modificación:*
        /// Cambio:      *    , Solicito *
        /// Autor:       Jessica Gutierrez 
        /// </summary>

        #region ========Declaration of variables=========
        private string optionSelected;
        string attribute1 = string.Empty;
        string consultan1 = string.Empty;
        List<CorporativeCRUDConsulta> list = new List<CorporativeCRUDConsulta>();
        StatusFamilyName usuario = new StatusFamilyName();
        #endregion

        public ucCorporateCRUD()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
               ControlStyles.UserPaint |
               ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtDKPrincipal;
            this.LastControlFocus = btnAccept;
        }

        //Carga de elementos 
        private void ucCorporateCRUD_Load(object sender, EventArgs e)
        {
            if (this.Parameters[0].ToString() == Resources.Constants.CORPORATE_CRUD_HIGH)
            {
                rdoBuscar.Visible = false;
                rdoModificar.Visible = false;
                FillClassOfService();
                optionSelected = Resources.Constants.CORPORATE_CRUD_HIGH;
            }
            else if (this.Parameters[0].ToString() == Resources.Constants.CORPORAT_CRUD_DROP)
            {
                lblTitle.Text = lblTitle.Text.Replace(Resources.Constants.CORPORATE_CRUD_HIGH, Resources.Constants.CORPORAT_CRUD_DROP);
                rdoModificar.Text = Resources.Constants.ELIMINAR;
                rdoBuscar.Checked = true;
                #region======= deactive controls======
                txtPCC.Enabled = false;
                txtSupervisor.Enabled = false;
                txtConsultan1.Enabled = false;
                txtConsultant2.Enabled = false;
                txtConsultant3.Enabled = false;
                txtConsultant4.Enabled = false;
                txtConsultant5.Enabled = false;
                txtPCC1.Enabled = false;
                txtPCC2.Enabled = false;
                txtPCC3.Enabled = false;
                txtPCC4.Enabled = false;
                txtPCC5.Enabled = false;
                txtFirmConsultant1.Enabled = false;
                txtFirmConsultant2.Enabled = false;
                txtFirmConsultant3.Enabled = false;
                txtFirmConsultant4.Enabled = false;
                txtFirmConsultant5.Enabled = false;
                txtCorporate.Enabled = false;
                cmbTools.Enabled = false;
                txtFirmSupervisor.Enabled = false;
                chkAvailable.Enabled = false;
                chkAvailable1.Enabled = false;
                chkAvailable2.Enabled = false;
                chkAvailable3.Enabled = false;
                chkAvailable4.Enabled = false;
                chkAvailable5.Enabled = false;
                #endregion
                optionSelected = Resources.Constants.CORPORAT_CRUD_DROP;
            }
            else if (this.Parameters[0].ToString() == Resources.Constants.CORPORATE_CRUD_MODIFICATION)
            {
                lblTitle.Text = lblTitle.Text.Replace(Resources.Constants.CORPORATE_CRUD_HIGH +" de", Resources.Constants.CORPORATE_CRUD_MODIFICATION);
                optionSelected = Resources.Constants.CORPORATE_CRUD_MODIFICATION;
                FillClassOfService();
                rdoBuscar.Checked = true;
            }
            else if(this.Parameters[0].ToString()==Resources.Constants.CORPORATE_CONSULTA_CAMBIOS_ASIGNADO)
            {
                lblTitle.Text = lblTitle.Text.Replace(Resources.Constants.CORPORATE_CRUD_HIGH + " de", Resources.Constants.ADMINISTRACION_CONSULTORES);
                optionSelected = Resources.Constants.CORPORATE_CONSULTA_CAMBIOS_ASIGNADO;
                #region======= deactive controls======
                rdoBuscar.Visible = false;
                rdoModificar.Visible = false;
                txtPCC.Enabled = false;
                txtSupervisor.Enabled = false;
                chkAvailable.Enabled = false;
                txtCorporate.Enabled = false;
                cmbTools.Enabled = false;
                txtFirmSupervisor.Enabled = false;
                txtConsultan1.Enabled = false;
                txtConsultant2.Enabled = false;
                txtConsultant3.Enabled = false;
                txtConsultant4.Enabled = false;
                txtConsultant5.Enabled = false;
                btnAplicarCambios.Visible = true;
                btnAccept.Text = "Cancelar";
                #endregion
            }
            txtDKPrincipal.Focus();
        }

        //Dentro del evento se mandan a llamar las validaciones y las acciones.
        private void btnAccept_Click(object sender, System.EventArgs e)
        {
            if (optionSelected == Resources.Constants.CORPORATE_CRUD_HIGH)
            {
                if (IsValidateBusinessRules)
                {
                        Commands();
                }
            }
            else if (optionSelected == Resources.Constants.CORPORATE_CRUD_MODIFICATION)
            {
                Commands();
            }
            else if (optionSelected == Resources.Constants.CORPORAT_CRUD_DROP)
            {
                Commands();
            }
            else if (optionSelected == Resources.Constants.CORPORATE_CONSULTA_CAMBIOS_ASIGNADO)
            {
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
        }

        #region ===== methodsClass =====

        //Validación de reglas de negocio
        private bool IsValidateBusinessRules
        {
            get
            {
                bool valor = false;

                if (optionSelected == Resources.Constants.CORPORATE_CRUD_HIGH || rdoModificar.Checked || optionSelected == Resources.Constants.CORPORATE_CONSULTA_CAMBIOS_ASIGNADO)
                {
                    if (string.IsNullOrEmpty(txtDKPrincipal.Text))
                    {
                        MessageBox.Show(Resources.Constants.INGRESE_DK_CORPORATIVO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtDKPrincipal.Focus();
                    }
                    else if (string.IsNullOrEmpty(txtCorporate.Text))
                    {
                        MessageBox.Show(Resources.Constants.INGRESE_CORPORATIVO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCorporate.Focus();
                    }
                    else if (string.IsNullOrEmpty(cmbTools.Text))
                    {
                        MessageBox.Show(Resources.Constants.INGRESE_HERRAMIENTA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbTools.Focus();
                    }
                    else if(string.IsNullOrEmpty(txtPCC.Text))
                    {
                        MessageBox.Show(Resources.Constants.INGRESA_PCC, Resources.Constants.MYCTS,MessageBoxButtons.OK,MessageBoxIcon.Information);
                        txtPCC.Focus();
                    }
                    else if (string.IsNullOrEmpty(txtFirmSupervisor.Text))
                    {
                        MessageBox.Show(Resources.Constants.INGRESE_SUPERVISOR, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtFirmSupervisor.Focus();
                    }
                    else if (string.IsNullOrEmpty(txtSupervisor.Text))
                    {
                        MessageBox.Show(Resources.Constants.INGRESE_DATOS_SUPERVISOR, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtSupervisor.Focus();
                    }
                    else if (!chkAvailable.Checked)
                    {
                        MessageBox.Show(Resources.Constants.ACTIVE_AGENTE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        chkAvailable.Focus();
                    }
                    else if (string.IsNullOrEmpty(txtFirmConsultant1.Text) && !string.IsNullOrEmpty(txtConsultan1.Text))
                    {
                        MessageBox.Show(Resources.Constants.INGRESA_CODIGO_CONSULTOR, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtFirmConsultant1.Focus();
                    }
                    else if (string.IsNullOrEmpty(txtFirmConsultant1.Text) && !string.IsNullOrEmpty(txtConsultan1.Text) && chkAvailable1.Checked == true)
                    {
                        MessageBox.Show(Resources.Constants.INGRESA_CODIGO_CONSULTOR, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtFirmConsultant1.Focus();
                    }
                    else if (!string.IsNullOrEmpty(txtFirmConsultant1.Text) && string.IsNullOrEmpty(txtPCC1.Text))
                    {
                        MessageBox.Show(Resources.Constants.INGRESA_PCC, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPCC1.Focus();
                    }
                    else if (!string.IsNullOrEmpty(txtFirmConsultant1.Text) && string.IsNullOrEmpty(txtConsultan1.Text) && chkAvailable1.Checked == true)
                    {
                        MessageBox.Show(Resources.Constants.REQUIERE_INGRESE_NOMBRE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtConsultan1.Focus();
                    }
                    else if (string.IsNullOrEmpty(txtFirmConsultant2.Text) && !string.IsNullOrEmpty(txtConsultant2.Text))
                    {
                        MessageBox.Show(Resources.Constants.INGRESA_CODIGO_CONSULTOR, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtFirmConsultant2.Focus();
                    }
                    else if (!string.IsNullOrEmpty(txtFirmConsultant2.Text) && string.IsNullOrEmpty(txtConsultant2.Text) && chkAvailable2.Checked == true)
                    {
                        MessageBox.Show(Resources.Constants.REQUIERE_INGRESE_NOMBRE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtConsultant2.Focus();
                    }
                    else if (!string.IsNullOrEmpty(txtFirmConsultant2.Text) && string.IsNullOrEmpty(txtPCC2.Text))
                    {
                        MessageBox.Show(Resources.Constants.INGRESA_PCC, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPCC2.Focus();
                    }
                    else if (string.IsNullOrEmpty(txtFirmConsultant2.Text) && !string.IsNullOrEmpty(txtConsultant2.Text) && chkAvailable2.Checked == true)
                    {
                        MessageBox.Show(Resources.Constants.INGRESA_CODIGO_CONSULTOR, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtFirmConsultant2.Focus();
                    }
                    else if (string.IsNullOrEmpty(txtFirmConsultant3.Text) && !string.IsNullOrEmpty(txtConsultant3.Text))
                    {
                        MessageBox.Show(Resources.Constants.INGRESA_CODIGO_CONSULTOR, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtFirmConsultant3.Focus();
                    }
                    else if (!string.IsNullOrEmpty(txtFirmConsultant3.Text) && string.IsNullOrEmpty(txtPCC3.Text))
                    {
                        MessageBox.Show(Resources.Constants.INGRESA_PCC, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPCC3.Focus();
                    }
                    else if (!string.IsNullOrEmpty(txtFirmConsultant3.Text) && string.IsNullOrEmpty(txtConsultant3.Text) && chkAvailable3.Checked == true)
                    {
                        MessageBox.Show(Resources.Constants.REQUIERE_INGRESE_NOMBRE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtConsultant3.Focus();
                    }
                    else if (string.IsNullOrEmpty(txtFirmConsultant3.Text) && !string.IsNullOrEmpty(txtConsultant3.Text) && chkAvailable3.Checked == true)
                    {
                        MessageBox.Show(Resources.Constants.INGRESA_CODIGO_CONSULTOR, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtFirmConsultant3.Focus();
                    }
                    else if (string.IsNullOrEmpty(txtFirmConsultant4.Text) && !string.IsNullOrEmpty(txtConsultant4.Text))
                    {
                        MessageBox.Show(Resources.Constants.INGRESA_CODIGO_CONSULTOR, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtFirmConsultant4.Focus();
                    }
                    else if (!string.IsNullOrEmpty(txtFirmConsultant4.Text) && string.IsNullOrEmpty(txtPCC4.Text))
                    {
                        MessageBox.Show(Resources.Constants.INGRESA_PCC, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPCC4.Focus();
                    }
                    else if (!string.IsNullOrEmpty(txtFirmConsultant4.Text) && string.IsNullOrEmpty(txtConsultant4.Text) && chkAvailable4.Checked == true)
                    {
                        MessageBox.Show(Resources.Constants.REQUIERE_INGRESE_NOMBRE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtConsultant4.Focus();
                    }
                    else if (string.IsNullOrEmpty(txtFirmConsultant4.Text) && !string.IsNullOrEmpty(txtConsultant4.Text) && chkAvailable4.Checked == true)
                    {
                        MessageBox.Show(Resources.Constants.INGRESA_CODIGO_CONSULTOR, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtFirmConsultant4.Focus();
                    }
                    else if (string.IsNullOrEmpty(txtFirmConsultant5.Text) && !string.IsNullOrEmpty(txtConsultant5.Text))
                    {
                        MessageBox.Show(Resources.Constants.INGRESA_CODIGO_CONSULTOR, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtFirmConsultant5.Focus();
                    }
                    else if (!string.IsNullOrEmpty(txtFirmConsultant5.Text) && string.IsNullOrEmpty(txtConsultant5.Text) && chkAvailable5.Checked == true)
                    {
                        MessageBox.Show(Resources.Constants.REQUIERE_INGRESE_NOMBRE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtConsultant5.Focus();
                    }
                    else if (!string.IsNullOrEmpty(txtFirmConsultant5.Text) && string.IsNullOrEmpty(txtPCC5.Text))
                    {
                        MessageBox.Show(Resources.Constants.INGRESA_PCC, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPCC5.Focus();
                    }
                    else if (string.IsNullOrEmpty(txtFirmConsultant5.Text) && !string.IsNullOrEmpty(txtConsultant5.Text) && chkAvailable5.Checked == true)
                    {
                        MessageBox.Show(Resources.Constants.INGRESA_CODIGO_CONSULTOR, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtFirmConsultant5.Focus();
                    }
                    else
                    {
                        valor = true;
                    }
                    return valor;
                }
                else if (optionSelected == Resources.Constants.CORPORAT_CRUD_DROP)
                {
                    if (string.IsNullOrEmpty(txtDKPrincipal.Text))
                    {
                        MessageBox.Show(Resources.Constants.INGRESE_DK_CORPORATIVO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        valor = true;
                    }
                }
                else
                {
                    valor = true;
                }
                    return valor;
            }

        }

        //Validación de DK
        private bool IsValidateDK
        {
            get
            {
               bool statusDK = false;
               try
               {
                   attribute1 = OnlyAttribute1BL.GetOnlyAttribute1(txtDKPrincipal.Text);
                   if (!string.IsNullOrEmpty(attribute1))
                   {
                       statusDK = true;
                   }
               }
               catch (Exception ex)
               {
                   throw ex;
               }
                #region validationDK extraerAttribute1
               /*
                WsMyCTS wsServ = new WsMyCTS();
                MyCTS.Services.ValidateDKsAndCreditCards.GetAttribute1 integraAttribute = null;
                MyCTS.Services.ValidateDKsAndCreditCards.GetAttribute1 integraAttribute1 = null;

                try
                {
                    try
                    {
                        integraAttribute = wsServ.GetAttribute(txtDKPrincipal.Text, Login.OrgId);
                    }
                    catch
                    {
                        integraAttribute = wsServ.GetAttribute(txtDKPrincipal.Text, Login.OrgId);
                    }
                }
                catch
                {
                    MyCTS.Services.ValidateDKsAndCreditCards.GetAttribute1 AttributeBackup = wsServ.GetAttribute(txtDKPrincipal.Text, Login.OrgId);
                    if (AttributeBackup != null)
                    {
                        if (!string.IsNullOrEmpty(AttributeBackup.Attribute1.ToString()) &&
                           (AttributeBackup.Attribute1.Contains(Resources.Reservations.MESSAGE_NO)))
                            statusDK = false;
                        else if (!string.IsNullOrEmpty(AttributeBackup.Attribute1.ToString()) &&
                                AttributeBackup.Attribute1.Contains(Resources.Reservations.MESSAGE_INACTIVO))
                            statusDK = false;
                    }
                }
                if (integraAttribute != null)
                {
                    if (!string.IsNullOrEmpty(integraAttribute.Attribute1) && integraAttribute.Status.Contains("NO EXISTE LOCATION") || integraAttribute.Status_Site.Contains("NO EXISTE LOCATION"))
                        statusDK = false;
                    else if (!string.IsNullOrEmpty(integraAttribute.Attribute1) &&
                            integraAttribute.Status.Contains("INACTIVO") || integraAttribute.Status_Site.Contains("INACTIVO"))
                        statusDK = false;
                    else
                    {
                        MyCTS.Services.ValidateDKsAndCreditCards.SetQCByAttribute1 tempAttribute = new MyCTS.Services.ValidateDKsAndCreditCards.SetQCByAttribute1();
                        tempAttribute = wsServ.SetQCGetAttribute(integraAttribute.Attribute1, integraAttribute.Status, integraAttribute.Status_Site);
                        attribute1 = tempAttribute.Attribute1;
                        statusDK = true;
                    }
                }
                else if (integraAttribute1 != null)
                {
                    if (!string.IsNullOrEmpty(integraAttribute1.Attribute1) &&
                       (integraAttribute1.Status.Contains(Resources.Reservations.MESSAGE_NO)) || (integraAttribute1.Status_Site.Contains(Resources.Reservations.MESSAGE_NO)))
                        statusDK = false;
                    else if (!string.IsNullOrEmpty(integraAttribute1.Attribute1) &&
                            integraAttribute1.Status.Contains("INACTIVO") || integraAttribute1.Status_Site.Contains("INACTIVO"))
                        statusDK = false;
                    else
                    {
                        MyCTS.Services.ValidateDKsAndCreditCards.SetQCByAttribute1 tempAttribute = new MyCTS.Services.ValidateDKsAndCreditCards.SetQCByAttribute1();
                        tempAttribute = wsServ.SetQCGetAttribute(integraAttribute1.Attribute1, integraAttribute1.Status, integraAttribute1.Status_Site);
                        attribute1 = tempAttribute.Attribute1;
                        statusDK = true;
                    }
                }*/
                #endregion
                return statusDK;
            }
        }

        //Validar si existe DK y extraer información
        private bool IsValidateExistDK
        {
            get
            {
               bool validation = false;
               attribute1 = txtDKPrincipal.Text;
               list= CorporativeCRUDConsultaBL.ReportCorporateConsulting(attribute1);
               if (list.Count > 0)
               {
                   validation = true;
               }
               return validation;
            }
        }
        
        //Realizar cada una de las reglas en especifico
        private void Commands()
        {
            if (optionSelected == Resources.Constants.CORPORATE_CRUD_HIGH)
            {
                if (IsValidateExistDK)
                {
                    MessageBox.Show(Resources.Constants.YA_EXISTE_DK, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDKPrincipal.Focus();
                }
                else if (!IsValidateExistDK)
                {
                    try
                    {
                        AddCorporateCRUD corporateCRUD= FillCorporateCRUD();
                        AddCorporateCRUDBL.AddCorporateCRUD(corporateCRUD);
                        MessageBox.Show(Resources.Constants.CORPORATIVO_REGISTRADO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearControls();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(Resources.Constants.HUBO_UN_ERROR_AL_INGRESAR_DATOS, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else if (optionSelected == Resources.Constants.CORPORATE_CRUD_MODIFICATION)
            {
                if (rdoBuscar.Checked)
                {
                    if (IsValidateExistDK)
                    {
                        SeeInformation();
                        txtDKPrincipal.Focus();
                    }
                }
                else if (rdoModificar.Checked)
                {
                    if (IsValidateBusinessRules)
                    {
                        try
                        {
                            UpdateCorporateCRUD updateCRUD = FillUpdateCorporate();
                            UpdateCoporateCRUDBL.UpdateCorporateCRUD(updateCRUD);
                            MessageBox.Show(Resources.Constants.CAMBIOS_SOLICITADOS_SATISFACTORIOS, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearControls();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(Resources.Constants.HA_OCURRIDO_ERROR_MODIFICA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            else if (optionSelected == Resources.Constants.CORPORAT_CRUD_DROP)
            {
                if (rdoBuscar.Checked)
                {
                    if (IsValidateExistDK)
                    {
                        SeeInformation();
                    }
                }
                else if (rdoModificar.Checked)
                {
                  DialogResult result= MessageBox.Show(Resources.Constants.MENSAJE_EMILINACION, Resources.Constants.MYCTS, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                  if (result == DialogResult.Yes)
                  {
                      try
                      {
                          AddToolOnlineRulesDelete deleteRules = FillDeleteCorporate();
                          AddToolOnlineRulesDeleteBL.AddCorporateDelete(deleteRules);
                          DeleteToolOnlineRulesBL.DeleteToolOnlineRules(attribute1);
                          MessageBox.Show(Resources.Constants.ELIMINACION_SOLICITADA_SATISFACTORIA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                          ClearControls();
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(Resources.Constants.HA_CORRUDIO_UN_ERRO_ELIMINAR, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                      }
                  }
                }
            }
        }

        //Llenado de la lista de CorporateCRUD
        private AddCorporateCRUD FillCorporateCRUD()
        {
            AddCorporateCRUD corporateCRUD = new AddCorporateCRUD
            {
                Corporative = txtCorporate.Text,
                ToolOnline = cmbTools.Text,
                Attribute1= txtDKPrincipal.Text,
                PCC=txtPCC.Text,
                Supervisor= txtSupervisor.Text,
                SupAgente= Convert.ToInt32(txtFirmSupervisor.Text),
                 SupStatus= chkAvailable.Checked.ToString(),
                Consultores = new List<ConsultorCRUD>
                {
                 new ConsultorCRUD(txtConsultan1.Text, CadenaAEnteroONulo(txtFirmConsultant1.Text), txtPCC1.Text, chkAvailable1.Checked.ToString()),
                 new ConsultorCRUD(txtConsultant2.Text, CadenaAEnteroONulo(txtFirmConsultant2.Text) ,txtPCC2.Text, chkAvailable2.Checked.ToString()),
                 new ConsultorCRUD(txtConsultant3.Text, CadenaAEnteroONulo(txtFirmConsultant3.Text),txtPCC3.Text, chkAvailable3.Checked.ToString()),
                 new ConsultorCRUD(txtConsultant4.Text, CadenaAEnteroONulo(txtFirmConsultant4.Text), txtPCC4.Text, chkAvailable4.Checked.ToString()),
                 new ConsultorCRUD(txtConsultant5.Text, CadenaAEnteroONulo(txtFirmConsultant5.Text), txtPCC5.Text, chkAvailable5.Checked.ToString())  
                },
                FechaInsert= DateTime.Now,
                InsertBy = Convert.ToInt32(ConfigurationManager.AppSettings["DatosContacto"].Split('|')[1]),
                FechaUpdate= CadenaODateTime(null),
                UpdateBy = Convert.ToInt32(null)
       
            };
            return corporateCRUD;
        }

        //Cambio de cadena a entero con valores null
        private int? CadenaAEnteroONulo(string valor)
        {
            int? valorNulo = null;
            if(!string.IsNullOrEmpty(valor))
        {
                valorNulo =Convert.ToInt32(valor);
            }
            return valorNulo;
        }

        //Cambio de entero a cadena
        private string EnteroACadena(string valor)
        {
            string nuevoValor = string.Empty;
            if (valor != "0" && valor!="-1")
            {
                nuevoValor = valor;
            }
            return nuevoValor;
        }

        //Cambio de cadena a dateTime con valores null
        private DateTime CadenaODateTime(string valor)
        {
            DateTime date =Convert.ToDateTime("01/01/1753");
            return date;
        }

        //Asignar los valores extraidos a los controles
        private void SeeInformation()
        {
            txtCorporate.Text = list[0].Corporative;
            cmbTools.Text = list[0].ToolOnline;
            txtSupervisor.Text = list[0].Supervisor;
            txtFirmSupervisor.Text = list[0].SupAgente.ToString();
            chkAvailable.Checked = Convert.ToBoolean(list[0].SupStatus);
            txtPCC.Text = list[0].PCC;
            txtConsultan1.Text = EnteroACadena(list[0].Consultor1);
            txtFirmConsultant1.Text = EnteroACadena(list[0].ConAgent1.ToString());
            txtPCC1.Text = list[0].PCC1;
            chkAvailable1.Checked = CadenaBoolean(list[0].ConStatus1);
            txtConsultant2.Text =EnteroACadena(list[0].Consultor2);
            txtFirmConsultant2.Text = EnteroACadena(list[0].ConAgent2.ToString());
            txtPCC2.Text = list[0].PCC2;
            chkAvailable2.Checked = CadenaBoolean(list[0].ConStatus2);
            txtConsultant3.Text = EnteroACadena(list[0].Consultor3);
            txtFirmConsultant3.Text = EnteroACadena(list[0].ConAgent3.ToString());
            txtPCC3.Text = list[0].PCC3;
            chkAvailable3.Checked = CadenaBoolean(list[0].ConStatus3);
            txtConsultant4.Text = EnteroACadena(list[0].Consultor4);
            txtFirmConsultant4.Text = EnteroACadena(list[0].ConAgent4.ToString());
            txtPCC4.Text = list[0].PCC4;
            chkAvailable4.Checked = CadenaBoolean(list[0].ConStatus4);
            txtConsultant5.Text = EnteroACadena(list[0].Consultor5);
            txtFirmConsultant5.Text = EnteroACadena(list[0].ConAgent5.ToString());
            txtPCC5.Text = list[0].PCC5;
            chkAvailable5.Checked = CadenaBoolean(list[0].ConStatus5);
        }

        //Llenado de lista de Actulizacion de CorporateCRUD
        private UpdateCorporateCRUD FillUpdateCorporate()
        {
            UpdateCorporateCRUD updateCorporate = new UpdateCorporateCRUD
            {
                Corporative = txtCorporate.Text,
                ToolOnline = cmbTools.Text,
                Attribute1 = attribute1,
                PCC=txtPCC.Text,
                Supervisor = txtSupervisor.Text,
                SupAgente = Convert.ToInt32(txtFirmSupervisor.Text),
                SupStatus = chkAvailable.Checked.ToString(),
                Consultores = new List<ConsultorCRUD>
                {
                 new ConsultorCRUD(txtConsultan1.Text, CadenaAEnteroONulo(txtFirmConsultant1.Text), txtPCC1.Text, chkAvailable1.Checked.ToString()),
                 new ConsultorCRUD(txtConsultant2.Text, CadenaAEnteroONulo(txtFirmConsultant2.Text) ,txtPCC2.Text, chkAvailable2.Checked.ToString()),
                 new ConsultorCRUD(txtConsultant3.Text, CadenaAEnteroONulo(txtFirmConsultant3.Text),txtPCC3.Text, chkAvailable3.Checked.ToString()),
                 new ConsultorCRUD(txtConsultant4.Text, CadenaAEnteroONulo(txtFirmConsultant4.Text), txtPCC4.Text, chkAvailable4.Checked.ToString()),
                 new ConsultorCRUD(txtConsultant5.Text, CadenaAEnteroONulo(txtFirmConsultant5.Text), txtPCC5.Text, chkAvailable5.Checked.ToString())  
                },
                FechaInsert=list[0].FechaInsert,
                InsertBy=list[0].InsertBy,
                FechaUpdate = DateTime.Now,
                UpdateBy = Convert.ToInt32(ConfigurationManager.AppSettings["DatosContacto"].Split('|')[1])
            };
            return updateCorporate;
        }

        //Llenado de lista para la tabla de ToolOnlineRulesDelete
        private AddToolOnlineRulesDelete FillDeleteCorporate()
        {
            AddToolOnlineRulesDelete deleteCorporate = new AddToolOnlineRulesDelete
            {
                Corporative = txtCorporate.Text,
                ToolOnline = cmbTools.Text,
                Attribute1 = txtDKPrincipal.Text,
                Supervisor = txtSupervisor.Text,
                SupAgente = Convert.ToInt32(txtFirmSupervisor.Text),
                SupStatus = chkAvailable.Checked.ToString(),
                Consultores = new List<ConsultorCRUD>
                {
                 new ConsultorCRUD(txtConsultan1.Text, CadenaAEnteroONulo(txtFirmConsultant1.Text), txtPCC1.Text, chkAvailable1.Checked.ToString()),
                 new ConsultorCRUD(txtConsultant2.Text, CadenaAEnteroONulo(txtFirmConsultant2.Text) ,txtPCC2.Text, chkAvailable2.Checked.ToString()),
                 new ConsultorCRUD(txtConsultant3.Text, CadenaAEnteroONulo(txtFirmConsultant3.Text),txtPCC3.Text, chkAvailable3.Checked.ToString()),
                 new ConsultorCRUD(txtConsultant4.Text, CadenaAEnteroONulo(txtFirmConsultant4.Text), txtPCC4.Text, chkAvailable4.Checked.ToString()),
                 new ConsultorCRUD(txtConsultant5.Text, CadenaAEnteroONulo(txtFirmConsultant5.Text), txtPCC5.Text, chkAvailable5.Checked.ToString())  
                },
                FechaInsert = list[0].FechaInsert,
                InsertBy = list[0].InsertBy,
                FechaUpdate=list[0].FechaUpdate,
                UpdateBy=list[0].UpdateBy,
                FechaDelete = DateTime.Now,
                DeleteBy = Convert.ToInt32(ConfigurationManager.AppSettings["DatosContacto"].Split('|')[1])
            };
            return deleteCorporate;
        }

        /// <summary>
        /// Llenado del combobox de Herramientas Online
        /// con datos provenientes de la base de datos
        /// </summary>
        private void FillClassOfService()
        {
            List<GetOnlineTools> listOnlineTools = GetOnlineToolsBL.GetOnlineTools();
            bindingSource1.DataSource = listOnlineTools;

            foreach (GetOnlineTools onlineToolsItem in listOnlineTools)
            {
                ListItem litem = new ListItem();
                litem.Text = string.Format("{0}",
                    onlineToolsItem.ToolName);
                litem.Value = onlineToolsItem.ToolName;
                cmbTools.Items.Add(litem);
            }
        }

        //Exrae Status y FamilyName del usuario
        private void FirmInformation(string firm, string PCC)
        {
            usuario = null;
            usuario = StatusFamilyNameBL.StautsFamilyName(firm, PCC);
        }

        //Extraer la Información de ToolOnlineRules
        private List<CorporativeCRUDConsulta> ConsultaAsignado(int firm, string attribute1)
        {
            List<CorporativeCRUDConsulta> consulta = new List<CorporativeCRUDConsulta>();
            try
            {
                consulta = CorporativeCRUDConsultaBL.ReportCorporateConsulting(firm, attribute1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return consulta;
        }

        private bool CadenaBoolean(string valor)
        {
            bool nuevoValor = false;
            if (valor == string.Empty)
            {
                nuevoValor = false;
            }
            else
            {
                nuevoValor = Convert.ToBoolean(valor);
            }
            return nuevoValor;
        }
        //Limpiar los valores de los controles
        private void ClearControls()
        {
            txtConsultan1.Text = string.Empty;
            txtConsultant2.Text = string.Empty;
            txtConsultant3.Text = string.Empty;
            txtConsultant4.Text = string.Empty;
            txtConsultant5.Text = string.Empty;
            txtCorporate.Text = string.Empty;
            txtDKPrincipal.Text = string.Empty;
            txtFirmConsultant1.Text = string.Empty;
            txtFirmConsultant2.Text = string.Empty;
            txtFirmConsultant3.Text = string.Empty;
            txtFirmConsultant4.Text = string.Empty;
            txtFirmConsultant5.Text = string.Empty;
            txtFirmSupervisor.Text = string.Empty;
            txtSupervisor.Text = string.Empty;
            txtPCC.Text = string.Empty;
            txtPCC1.Text = string.Empty;
            txtPCC2.Text = string.Empty;
            txtPCC3.Text = string.Empty;
            txtPCC4.Text = string.Empty;
            txtPCC5.Text = string.Empty;
            rdoBuscar.Checked = true;
            chkAvailable.Checked = false;
            chkAvailable1.Checked = false;
            chkAvailable2.Checked = false;
            chkAvailable3.Checked = false;
            chkAvailable4.Checked = false;
            chkAvailable5.Checked = false;
            cmbTools.Text = string.Empty;
            txtDKPrincipal.Focus();
        }

        #endregion

        #region ===== Events====
        //Realizar la validación del DK
        private void txtDKPrincipal_TextChanged(object sender, EventArgs e)
        {
            if (txtDKPrincipal.Text.Length == 6 && optionSelected == Resources.Constants.CORPORATE_CRUD_HIGH)
            {
                if (!IsValidateDK)
                {
                    MessageBox.Show(Resources.Constants.DK_INGRESADO_NO_CORRESPONDE_CORPORATIVO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDKPrincipal.Focus();
                }
            }
            else if (txtDKPrincipal.Text.Length == 6 && (optionSelected == Resources.Constants.CORPORATE_CRUD_MODIFICATION ||
                    optionSelected == Resources.Constants.CORPORAT_CRUD_DROP))
            {
                if (!IsValidateExistDK)
                {
                    MessageBox.Show(Resources.Constants.CORPORATIVO_INGRESADO_NO_HA_SIDO_DADO_DE_ALTA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (txtDKPrincipal.Text.Length == 6 && optionSelected == Resources.Constants.CORPORATE_CONSULTA_CAMBIOS_ASIGNADO)
            {
                if (IsValidateDK)
                {
                    if (IsValidateExistDK)
                    {
                   list = null;
                        list = ConsultaAsignado(Convert.ToInt32(ConfigurationManager.AppSettings["DatosContacto"].Split('|')[1]), attribute1);
                        if (list.Count > 0)
                        {
                   SeeInformation();
                            txtFirmConsultant1.Focus();
                }
                        else
                        {
                            MessageBox.Show(Resources.Constants.CORPORATIVO_INGRESADO_NO_ENCONTRADO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearControls();
                            txtDKPrincipal.Focus();
            }
        }
                    else
                    {
                        MessageBox.Show(Resources.Constants.CORPORATIVO_INGRESADO_NO_HA_SIDO_DADO_DE_ALTA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearControls();
                        txtDKPrincipal.Focus();
                    }
                }
                else
                {
                    MessageBox.Show(Resources.Constants.EL_DK_INGRESADO_NO_EXISTE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDKPrincipal.Focus();
                }
            }
        }
        //Realiza la validacion y guarda cambios 
        private void btnAplicarCambios_Click(object sender, EventArgs e)
        {
            if (IsValidateBusinessRules)
            {
                try
                {
                    UpdateCorporateCRUD updateCRUD = FillUpdateCorporate();
                    UpdateCoporateCRUDBL.UpdateCorporateCRUD(updateCRUD);
                    MessageBox.Show(Resources.Constants.CAMBIOS_SOLICITADOS_SATISFACTORIOS, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearControls();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Resources.Constants.HA_OCURRIDO_ERROR_MODIFICA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        //KeyDown
        /// <summary>
        /// Este se usa para todos los controles en general si se oprime 
        /// Esc se manda a el User control de Welcome
        /// Enter se manda la accion de botón de Aceptar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);

            if (e.KeyData == Keys.Enter)
                btnAccept_Click(sender, e);
        }
        //Valida el estatus de la firma y asigna el familyName al campo
        private void txtPCC_TextChanged(object sender, EventArgs e)
       {
            if (txtPCC.Text.Length == 4)
            {
                FirmInformation(txtFirmSupervisor.Text, txtPCC.Text);
                if (usuario.StatusFirm == "A")
                {
                    txtSupervisor.Text = usuario.FamilyName;
                    txtSupervisor.Focus();
                }
                else if (usuario.StatusFirm == "I")
                {
                    MessageBox.Show(Resources.Constants.LA_FIRMA_INGRESADA_ENCUENTRA_INACTIVA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (string.IsNullOrEmpty(usuario.StatusFirm))
                {
                    MessageBox.Show(Resources.Constants.LA_FIRMA_INGRESADA_NO_EXISTE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        }
        //Valida el estatus de la firma y asigna el familyName al campo
        private void txtPCC1_TextChanged(object sender, EventArgs e)
        {
            if (txtPCC1.Text.Length == 4)
            {
                FirmInformation(txtFirmConsultant1.Text, txtPCC1.Text);
                if (usuario.StatusFirm == "A")
                {
                    txtConsultan1.Text = usuario.FamilyName;
                    txtConsultan1.Focus();
                }
                else if (usuario.StatusFirm == "I")
                {
                    MessageBox.Show(Resources.Constants.LA_FIRMA_INGRESADA_ENCUENTRA_INACTIVA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
                else if (string.IsNullOrEmpty(usuario.StatusFirm))
                {
                    MessageBox.Show(Resources.Constants.LA_FIRMA_INGRESADA_NO_EXISTE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
            }

        }
        //Valida el estatus de la firma y asigna el familyName al campo
        private void txtPCC2_TextChanged(object sender, EventArgs e)
        {
            if (txtPCC2.Text.Length == 4)
            {
                FirmInformation(txtFirmConsultant2.Text, txtPCC2.Text);
                if (usuario.StatusFirm == "A")
                {
                    txtConsultant2.Text = usuario.FamilyName;
                    txtConsultant2.Focus();
                }
                else if (usuario.StatusFirm == "I")
                {
                    MessageBox.Show(Resources.Constants.LA_FIRMA_INGRESADA_ENCUENTRA_INACTIVA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (string.IsNullOrEmpty(usuario.StatusFirm))
                {
                    MessageBox.Show(Resources.Constants.LA_FIRMA_INGRESADA_NO_EXISTE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        //Valida el estatus de la firma y asigna el familyName al campo
        private void txtPCC3_TextChanged(object sender, EventArgs e)
        {
            if (txtPCC3.Text.Length == 4)
            {
                FirmInformation(txtFirmConsultant3.Text, txtPCC3.Text);
                if (usuario.StatusFirm == "A")
                {
                    txtConsultant3.Text = usuario.FamilyName;
                    txtConsultant3.Focus();
                }
                else if (usuario.StatusFirm == "I")
                {
                    MessageBox.Show(Resources.Constants.LA_FIRMA_INGRESADA_ENCUENTRA_INACTIVA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (string.IsNullOrEmpty(usuario.StatusFirm))
                {
                    MessageBox.Show(Resources.Constants.LA_FIRMA_INGRESADA_NO_EXISTE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        //Valida el estatus de la firma y asigna el familyName al campo
        private void txtPCC4_TextChanged(object sender, EventArgs e)
        {
            if (txtPCC4.Text.Length == 4)
            {
                FirmInformation(txtFirmConsultant4.Text, txtPCC4.Text);
                if (usuario.StatusFirm == "A")
                {
                    txtConsultant4.Text = usuario.FamilyName;
                    txtConsultant4.Focus();
                }
                else if (usuario.StatusFirm == "I")
                {
                    MessageBox.Show(Resources.Constants.LA_FIRMA_INGRESADA_ENCUENTRA_INACTIVA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
                else if (string.IsNullOrEmpty(usuario.StatusFirm))
                {
                    MessageBox.Show(Resources.Constants.LA_FIRMA_INGRESADA_NO_EXISTE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
            }
        }
        //Valida el estatus de la firma y asigna el familyName al campo
        private void txtPCC5_TextChanged(object sender, EventArgs e)
        {
            if (txtPCC5.Text.Length == 4)
            {
                FirmInformation(txtFirmConsultant5.Text, txtPCC5.Text);
                if (usuario.StatusFirm == "A")
                {
                    txtConsultant5.Text = usuario.FamilyName;
                    txtConsultant5.Focus();
                }
                else if (usuario.StatusFirm == "I")
                {
                    MessageBox.Show(Resources.Constants.LA_FIRMA_INGRESADA_ENCUENTRA_INACTIVA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (string.IsNullOrEmpty(usuario.StatusFirm))
                {
                    MessageBox.Show(Resources.Constants.LA_FIRMA_INGRESADA_NO_EXISTE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        #endregion
    }
}

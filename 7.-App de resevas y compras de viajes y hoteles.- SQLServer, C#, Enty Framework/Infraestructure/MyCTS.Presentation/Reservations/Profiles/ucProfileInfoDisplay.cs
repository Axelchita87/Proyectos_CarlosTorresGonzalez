using Microsoft.Office.Interop.Outlook;
using MyCTS.Business;
using MyCTS.Entities;
using MyCTS.Presentation.Components;
using MyCTS.Presentation.Reservations.Profiles;
using MyCTS.Services.ValidateDKsAndCreditCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MyCTS.Presentation
{
    public partial class ucProfileInfoDisplay : CustomUserControl
    {
        /// <summary>
        /// Descripción: User control que despliega la informacion del perfil seleccionado
        /// Creación:    03 febrero 2010, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Marcos Q. Ramírez
        /// </summary>

        private TreeNode mySelectedNode = new TreeNode();
        private string pcc = string.Empty;
        private string firstStarName = string.Empty;
        private string secondStarName = string.Empty;
        private string lineType = string.Empty;
        private string tempLineType = string.Empty;
        private string name = string.Empty;
        private string lastName = string.Empty;
        public string[] Parametersreceived;
        string[] parameters = new string[4];
        private List<Dynamic> listFields;

        public static Star1Details ObjStar1Dpid;
        public static Star2Details ObjStar2Dpid;

        private List<List<Star2ndLevelInfo>> container = new List<List<Star2ndLevelInfo>>();
        //private MyCTS.Services.MyCTSOracleConnection.Cat1stStarInfoByLocation star1InfoByLocation = new MyCTS.Services.MyCTSOracleConnection.Cat1stStarInfoByLocation();
        //private MyCTS.Services.MyCTSOracleConnectionDev.Cat1stStarInfoByLocation star1InfoByLocation1 = new MyCTS.Services.MyCTSOracleConnectionDev.Cat1stStarInfoByLocation();
        private MyCTS.Services.ValidateDKsAndCreditCards.Cat1stStarInfoByLocation star1InfoByLocation = new MyCTS.Services.ValidateDKsAndCreditCards.Cat1stStarInfoByLocation();
        private MyCTS.Services.ValidateDKsAndCreditCards.Cat1stStarInfoByLocation star1InfoByLocation1 = new MyCTS.Services.ValidateDKsAndCreditCards.Cat1stStarInfoByLocation();
        private MyCTS.Services.ValidateDKsAndCreditCards.Cat1stStarInfoByLocation star1InfoByLocationBackup = new MyCTS.Services.ValidateDKsAndCreditCards.Cat1stStarInfoByLocation();
        List<CatAllStars> Star2List = new List<CatAllStars>();

        public ucProfileInfoDisplay()
        {
            InitializeComponent();
        }

        //Evento Load
        private void ucProfileInfoDisplay_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            Star2List.Clear();
            ObjStar1Dpid = ucProfileSearch.ObjStar1Details;
            ObjStar2Dpid = ucProfileSearch.ObjStar2Details;
            ucProfileSearch.ObjStar1Details = null;
            ucProfileSearch.ObjStar2Details = null;

            btnRenameProfile.Visible = false;

            if (ucProfileSearch.newFormat)
            {
                splitContainerStarinfo.Panel1Collapsed = true;
                this.Height = 720;
            }

            ucProfileSearch.newFormat = false;

            if (frmProfiles.IsReservationFlow)
            {
                btnDeleteProfile.Enabled = false;
                btnRenameProfile.Enabled = false;
                this.Height = 545;
            }
            else
            {
                string activeProfiles = ParameterBL.GetParameterValue(Resources.Profiles.Constants.ACTIVE_PROFILES).Values;
                if (Convert.ToBoolean(activeProfiles))
                {
                    btnDeleteProfile.Enabled = true;
                    btnRenameProfile.Enabled = true;
                    contextMenuStripChild.Enabled = true;
                }
                else
                {
                    btnDeleteProfile.Enabled = false;
                    btnRenameProfile.Enabled = false;
                    contextMenuStripChild.Enabled = false;
                }
            }

            SetProfileTreeView(ucProfileSearch.star1Info);
        }

        #region===== MethodsClass =====

        /// <summary>
        /// Carga la informacion del perfil en el arbol principal
        /// </summary>
        private void SetProfileTreeView(List<MyCTS.Entities.Star1stLevelInfo> linesInfo)
        {
            string location = string.Empty;
            foreach (MyCTS.Entities.Star1stLevelInfo lines in linesInfo)
            {
                if (lines.Text.Contains(Resources.Profiles.Constants.COMMAND_DK))
                {
                    try
                    {
                        if (lines.Text.IndexOf(Resources.Profiles.Constants.COMMAND_DK) == 0)
                        {
                            location = lines.Text.Substring(lines.Text.IndexOf(Resources.Profiles.Constants.COMMAND_DK) + 2, 6);
                        }
                    }
                    catch { }
                }
            }

            pcc = ucProfileSearch.star1Info[0].Pccid;
            firstStarName = ucProfileSearch.star1Info[0].Level1;

            treeViewProfile.SelectedImageIndex = 4;
            treeViewProfile.ImageList = imageProfileList;

            if (!ucProfileSearch.star1Info.Count.Equals(0) &&
                !ucProfileSearch.star2Info.Count.Equals(0))
            {
                secondStarName = ucProfileSearch.star2Info[0].Level2;
                treeViewProfile.BeginUpdate();
                treeViewProfile.Nodes.Add(Resources.Profiles.Constants.NODE_PROFILES_NAME, string.Concat(Resources.Profiles.Constants.NODE_PROFILES_TEXT, " ", ucProfileSearch.star2Info[0].Level2, " ", ucProfileSearch.star1Info[0].Pccid), 0);
                treeViewProfile.Nodes[0].Nodes.Add(Resources.Profiles.Constants.NODE_STAR1_NAME, string.Concat(Resources.Profiles.Constants.NODE_STAR1_TEXT, " ", ucProfileSearch.star1Info[0].Level1, " ", Resources.Profiles.Constants.NODE_STAR1_TEXT2), 1);
                treeViewProfile.Nodes[0].Nodes.Add(Resources.Profiles.Constants.NODE_STAR1_INTEGRA, string.Format("DATOS DK {0} EN INTEGRA", location), 6);
                //treeViewProfile.Nodes[0].Nodes.Add(Resources.Profiles.Constants.NODE_STAR2_NAME, string.Concat(Resources.Profiles.Constants.NODE_STAR2_TEXT, " ", ucProfileSearch.star2Info[0].Level2), 2);

                TreeNode nodeS2 = new TreeNode();
                
                nodeS2.Text = string.Concat(Resources.Profiles.Constants.NODE_STAR2_TEXT, " ", ucProfileSearch.star2Info[0].Level2);
                nodeS2.ImageIndex = 2;
                if (!ucProfileSearch.isMessageUpdateShow)
                    nodeS2.ContextMenuStrip = contextMenuStripChild;
                treeViewProfile.Nodes[0].Nodes.Add(nodeS2);
                treeViewProfile.Nodes[0].SelectedImageIndex = 4;

                foreach (MyCTS.Entities.Star1stLevelInfo info1 in ucProfileSearch.star1Info)
                {
                    TreeNode node = new TreeNode();
                    node.Name = info1.Line.ToString();
                    node.Text = string.Concat(info1.Type, " ", Resources.Profiles.Constants.INDENT, " ", info1.Text);
                    node.ImageIndex = 3;
                    if (info1.Type.Equals(Resources.Profiles.Constants.LINE_TYPE_O))
                        node.ToolTipText = Resources.Profiles.Constants.NODE_OPTIONAL_TOOLTIP_TEXT;


                    treeViewProfile.Nodes[0].Nodes[0].Nodes.Add(node);
                }

                try
                {
                    LoadIntegraProfileValues(location);
                }
                catch
                {
                    LoadIntegraProfileBackup(location);
                }

                foreach (Star2ndLevelInfo info2 in ucProfileSearch.star2Info)
                {
                    TreeNode node = new TreeNode();
                    node.Name = info2.Line.ToString();
                    node.Text = string.Concat(info2.Type, " - ", info2.Text);
                    node.ImageIndex = 3;
                    if (ucProfileSearch.isMessageUpdateShow)
                        node.ContextMenuStrip = contextCopyMenuStrip;

                    if (info2.Type.Equals(Resources.Profiles.Constants.LINE_TYPE_O))
                        node.ToolTipText = Resources.Profiles.Constants.NODE_OPTIONAL_TOOLTIP_TEXT;
                    else
                        node.ToolTipText = node.ToolTipText = Resources.Profiles.Constants.NODE_TOOLTIP_TEXT;
                    treeViewProfile.Nodes[0].Nodes[2].Nodes.Add(node);
                }


                var i = DocsSecondLevelBL.getImageByProfileId(int.Parse(ObjStar2Dpid.Id));
                int p = 1;
                foreach (var item in i)
                {
                    TreeNode n = new TreeNode()
                    {
                        Name = item.ImageId.ToString(),
                        Text = "N - Imagen " + p + ": "+ item.NameDocument,
                        ImageIndex = 3,
                    };
                    p = p + 1;
                    treeViewProfile.Nodes[0].Nodes[2].Nodes.Add(n);
                }
                    
                treeViewProfile.EndUpdate();
            }
            else if (!ucProfileSearch.star1Info.Count.Equals(0))
            {
                treeViewProfile.BeginUpdate();
                treeViewProfile.Nodes.Add(Resources.Profiles.Constants.NODE_PROFILES_NAME, string.Concat(Resources.Profiles.Constants.NODE_PROFILES_TEXT, " ", ucProfileSearch.star1Info[0].Level1, " ", ucProfileSearch.star1Info[0].Pccid), 0);
                //treeViewProfile.Nodes[0].Nodes[0].ContextMenuStrip = contextMenuStripChild;


                var nodeS1 = new TreeNode();
                nodeS1.Text = string.Concat(Resources.Profiles.Constants.NODE_STAR1_TEXT, " ", ucProfileSearch.star1Info[0].Level1, " ", Resources.Profiles.Constants.NODE_STAR1_TEXT2);
                nodeS1.ImageIndex = 1;
                if (!ucProfileSearch.isMessageUpdateShow)
                    nodeS1.ContextMenuStrip = contextMenuStripChild;
                treeViewProfile.Nodes[0].Nodes.Add(nodeS1);

                treeViewProfile.Nodes[0].Nodes.Add(Resources.Profiles.Constants.NODE_STAR1_INTEGRA, string.Format("DATOS DK {0} EN INTEGRA", location), 6);
                treeViewProfile.Nodes[0].SelectedImageIndex = 4;

                foreach (MyCTS.Entities.Star1stLevelInfo info in ucProfileSearch.star1Info)
                {
                    var node = new TreeNode();
                    node.Name = info.Line.ToString();
                    node.Text = string.Concat(info.Type, " ", Resources.Profiles.Constants.INDENT, " ", info.Text);
                    node.ImageIndex = 3;
                    if (ucProfileSearch.isMessageUpdateShow)
                        node.ContextMenuStrip = contextCopyMenuStrip;

                    if (info.Type.Equals(Resources.Profiles.Constants.LINE_TYPE_O))
                        node.ToolTipText = Resources.Profiles.Constants.NODE_OPTIONAL_TOOLTIP_TEXT;
                    else
                        node.ToolTipText = node.ToolTipText = Resources.Profiles.Constants.NODE_TOOLTIP_TEXT;
                    treeViewProfile.Nodes[0].Nodes[0].Nodes.Add(node);
                }

                Star2List = CatAllStarsBL.GetAll2ndStarDetailed_Profile(ucProfileSearch.star1Info[0].Pccid, ucProfileSearch.star1Info[0].Level1, Login.OrgId);

                if (!string.IsNullOrEmpty(ucProfileSearch.star1Info.FirstOrDefault().Id))
                {
                    var pr = DocsFirstLevelBL.getImageByProfileId(ucProfileSearch.star1Info.FirstOrDefault().Id);
                    int p = 1;
                    foreach (var item in pr)
                    {
                        TreeNode n = new TreeNode()
                        {
                            Name = item.ImageId.ToString(),
                            Text = "N - Imagen " + p + ": " + item.NameDocument,
                            ImageIndex = 3,
                        };
                        p = p + 1;
                        treeViewProfile.Nodes[0].Nodes[0].Nodes.Add(n);
                    }
                }

                if (!Star2List.Count.Equals(0))
                {

                    //TreeNode treeNode2Level = new TreeNode();
                    //treeNode2Level.ImageIndex = 5;
                    //treeNode2Level.Text = Resources.Profiles.Constants.NODE_STAR2LIST_TEXT;
                    //treeNode2Level.Tag = "Header2Level";
                    treeViewProfile.Nodes[0].Nodes[0].Nodes.Add(Resources.Profiles.Constants.NODE_STAR2LIST_NAME, Resources.Profiles.Constants.NODE_STAR2LIST_TEXT, 5);
                    //treeViewProfile.Nodes[0].Nodes[0].Nodes.Add(treeNode2Level);

                    for (int i = 0; i < Star2List.Count; i++)
                    {
                        TreeNode treeNodeChild = new TreeNode();
                        treeNodeChild.ImageIndex = 2;
                        treeNodeChild.Text = Star2List[i].StarName;
                        treeNodeChild.Tag = "child" + Guid.NewGuid().ToString();
                        treeViewProfile.Nodes[0].Nodes[0].Nodes[treeViewProfile.Nodes[0].Nodes[0].Nodes.Count - 1].Nodes.Add(treeNodeChild);
                        //treeViewProfile.Nodes[0].Nodes[0].Nodes[treeViewProfile.Nodes[0].Nodes[0].Nodes.Count - 1].Nodes.Add(Resources.Profiles.Constants.NODE_STAR2_NAME, Star2List[i].StarName, 2);
                        
                        //if (!Star2List[i].IsNew)
                        //{
                        //    List<Star2ndLevelInfo> star2InfoList = Star2ndLevelInfoBL.GetStar2ndLevelInfo(Star2List[i].PccId, Star2List[i].Star1Ref, Star2List[i].StarName);
                        //    foreach (Star2ndLevelInfo star2Info in star2InfoList)
                        //    {

                        //        treeViewProfile.Nodes[0].Nodes[0].Nodes[treeViewProfile.Nodes[0].Nodes[0].Nodes.Count - 1].Nodes[i].Nodes.Add(Resources.Profiles.Constants.NODE_STAR2INFO_NAME, string.Concat(star2Info.Type, " ", Resources.Profiles.Constants.INDENT, " ", star2Info.Text), 3);

                        //    }
                        //    container.Add(star2InfoList);
                        //}
                        //else
                        //{
                        //    ProfilesMethods objProfileMethods = new ProfilesMethods();
                        //    Star2Details _objStar2Details = Getprofile2Level(Star2List[i].PccId, Star2List[i].Star1Ref, Star2List[i].StarName);
                        //    List<Star2ndLevelInfo> star2Info = objProfileMethods.FormatSabreProfile2L(_objStar2Details);
                        //    foreach (Star2ndLevelInfo starInfo in star2Info)
                        //    {

                        //        treeViewProfile.Nodes[0].Nodes[0].Nodes[treeViewProfile.Nodes[0].Nodes[0].Nodes.Count - 1].Nodes[i].Nodes.Add(Resources.Profiles.Constants.NODE_STAR2INFO_NAME, string.Concat(starInfo.Type, " ", Resources.Profiles.Constants.INDENT, " ", starInfo.Text), 3);

                        //    }
                        //    container.Add(star2Info);
 
                        //}
                    }
                }

                try
                {
                    LoadIntegraProfileValues(location);
                }
                catch
                {
                    LoadIntegraProfileBackup(location);
                }

                treeViewProfile.EndUpdate();
            }
        }

        /// <summary>
        /// Agrega información del perfil al record
        /// </summary>
        private void AddProfileToRecord()
        {
            string send = string.Empty;
            if (!ucProfileSearch.star1Info.Count.Equals(0) &&
                ucProfileSearch.star2Info.Count.Equals(0))
            {
                foreach (MyCTS.Entities.Star1stLevelInfo Star1Line in ucProfileSearch.star1Info)
                {
                    if (Star1Line.Type.Equals(Resources.Profiles.Constants.LINE_TYPE_A))
                    {
                        string temp = string.Concat(Star1Line.Text,
                            "Σ");
                        int totalLenght = send.Length + temp.Length;
                        if (totalLenght > 950)
                        {
                            ProfileSendRemarks(send);
                            send = temp;
                        }
                        else
                        {
                            send = string.Concat(send,
                                Star1Line.Text,
                                "Σ");
                        }
                    }
                }

                if (treeViewProfile.SelectedNodes.Count > 0)
                {
                    foreach (TreeNode node in treeViewProfile.SelectedNodes)
                    {
                      
                        string temp = string.Concat(ucProfileSearch.star1Info[node.Index].Text,
                        "Σ");
                        int totalLenght = send.Length + temp.Length;
                        if (totalLenght > 950)
                        {
                            ProfileSendRemarks(send);
                            send = temp;
                        }
                        else
                        {
                            send = string.Concat(send,
                            ucProfileSearch.star1Info[node.Index].Text,
                            "Σ");
                        }

                    }
                }
                if (!string.IsNullOrEmpty(send))
                {
                    ProfileSendRemarks(send);
                }

                //send = string.Empty;
                //if (mySelectedNode != null)
                //{
                //    if (mySelectedNode.Parent != null)
                //    {
                //        if (mySelectedNode.Parent.Name.Contains(Resources.Profiles.Constants.NODE_STAR2LIST_NAME))
                //        {
                //            int index = mySelectedNode.Index;
                //            if (container.Count > 0)
                //            {
                //                foreach (Star2ndLevelInfo Star2Line in container[index])
                //                {
                //                    if (Star2Line.Type.Equals(Resources.Profiles.Constants.LINE_TYPE_A))
                //                    {
                //                        string temp = string.Concat(Star2Line.Text,
                //                            "Σ");
                //                        int totalLenght = send.Length + temp.Length;
                //                        if (totalLenght > 950)
                //                        {
                //                            ProfileSendRemarks(send);
                //                            send = temp;
                //                        }
                //                        else
                //                        {
                //                            send = string.Concat(send,
                //                                Star2Line.Text,
                //                                "Σ");
                //                        }
                //                    }

                //                }

                //                if (treeViewProfile.SelectedNodes.Count > 0)
                //                {
                //                    foreach (TreeNode node in treeViewProfile.SelectedNodes)
                //                    {
                //                        if (node.Parent.Name.Equals(Resources.Profiles.Constants.NODE_STAR2_NAME))
                //                        {
                //                            string temp = string.Concat(container[index][node.Index].Text,
                //                                "Σ");
                //                            int totalLenght = send.Length + temp.Length;
                //                            if (totalLenght > 950)
                //                            {
                //                                ProfileSendRemarks(send);
                //                                send = temp;
                //                            }
                //                            else
                //                            {
                //                                send = string.Concat(send,
                //                                    container[index][node.Index].Text,
                //                                    "Σ");
                //                            }
                //                        }
                //                    }
                //                }
                //                if (!string.IsNullOrEmpty(send))
                //                {
                //                    ProfileSendRemarks(send);
                //                }
                //            }
                //        }

                //        else if (mySelectedNode.Parent.Name.Contains(Resources.Profiles.Constants.NODE_STAR2_NAME))
                //        {
                //            int index = mySelectedNode.Parent.Index;
                //            if (container.Count > 0)
                //            {
                //                foreach (Star2ndLevelInfo Star2Line in container[index])
                //                {
                //                    if (Star2Line.Type.Equals(Resources.Profiles.Constants.LINE_TYPE_A))
                //                    {
                //                        string temp = string.Concat(Star2Line.Text,
                //                                "Σ");
                //                        int totalLenght = send.Length + temp.Length;
                //                        if (totalLenght > 950)
                //                        {
                //                            ProfileSendRemarks(send);
                //                            send = temp;
                //                        }
                //                        else
                //                        {
                //                            send = string.Concat(send,
                //                                Star2Line.Text,
                //                                "Σ");
                //                        }
                //                    }
                //                }

                //                if (treeViewProfile.SelectedNodes.Count > 0)
                //                {
                //                    foreach (TreeNode node in treeViewProfile.SelectedNodes)
                //                    {
                //                        if (node.Parent.Name.Equals(Resources.Profiles.Constants.NODE_STAR2_NAME))
                //                        {
                //                            string temp = string.Concat(container[node.Parent.Index][node.Index].Text,
                //                                "Σ");
                //                            int totalLenght = send.Length + temp.Length;
                //                            if (totalLenght > 950)
                //                            {
                //                                ProfileSendRemarks(send);
                //                                send = temp;
                //                            }
                //                            else
                //                            {
                //                                send = string.Concat(send,
                //                                    container[node.Parent.Index][node.Index].Text,
                //                                    "Σ");
                //                            }
                //                        }
                //                    }
                //                }
                //                if (!string.IsNullOrEmpty(send))
                //                {
                //                    ProfileSendRemarks(send);
                //                }
                //            }
                //        }

                //    }
                //}
            }
            else if (!ucProfileSearch.star1Info.Count.Equals(0) &&
                !ucProfileSearch.star2Info.Count.Equals(0))
            {
                send = string.Empty;
                foreach (MyCTS.Entities.Star1stLevelInfo Star1Line in ucProfileSearch.star1Info)
                {
                    if (Star1Line.Type.Equals(Resources.Profiles.Constants.LINE_TYPE_A))
                    {
                        string temp = string.Concat(Star1Line.Text,
                                                "Σ");
                        int totalLenght = send.Length + temp.Length;
                        if (totalLenght > 950)
                        {
                            ProfileSendRemarks(send);
                            send = temp;
                        }
                        else
                        {
                            send = string.Concat(send,
                                Star1Line.Text,
                                "Σ");
                        }
                    }
                }

                if (treeViewProfile.SelectedNodes.Count > 0)
                {
                    foreach (TreeNode node in treeViewProfile.SelectedNodes)
                    {
                        if (!string.IsNullOrEmpty(firstStarName) && string.IsNullOrEmpty(secondStarName))
                        {
                            string temp = string.Concat(ucProfileSearch.star1Info[node.Index].Text,
                                                "Σ");
                            int totalLenght = send.Length + temp.Length;
                            if (totalLenght > 950)
                            {
                                ProfileSendRemarks(send);
                                send = temp;
                            }
                            else
                            {
                                send = string.Concat(send,
                                    ucProfileSearch.star1Info[node.Index].Text,
                                    "Σ");
                            }
                        }
                    }
                }
                if (!string.IsNullOrEmpty(send))
                {
                    ProfileSendRemarks(send);
                }


                send = string.Empty;
                foreach (Star2ndLevelInfo Star2Line in ucProfileSearch.star2Info)
                {
                    if (Star2Line.Type.Equals(Resources.Profiles.Constants.LINE_TYPE_A))
                    {
                        send = string.Concat(send,
                            Star2Line.Text.StartsWith("PE‡") ? string.Concat(Star2Line.Text, "-1.1") : Star2Line.Text,
                            "Σ");
                    }
                }

                if (treeViewProfile.SelectedNodes.Count > 0)
                {
                    foreach (TreeNode node in treeViewProfile.SelectedNodes)
                    {
                        if (!string.IsNullOrEmpty(firstStarName) && !string.IsNullOrEmpty(secondStarName))
                        {
                            string temp = string.Concat(ucProfileSearch.star2Info[node.Index].Text,
                                    "Σ");
                            int totalLenght = send.Length + temp.Length;
                            if (totalLenght > 950)
                            {
                                ProfileSendRemarks(send);
                                send = temp;
                            }
                            else
                            {
                                send = string.Concat(send,
                                    ucProfileSearch.star2Info[node.Index].Text,
                                    "Σ");
                            }
                        }
                    }
                }
                if (!string.IsNullOrEmpty(send))
                {
                    ProfileSendRemarks(send);
                }

            }


            if (frmProfiles.IsReservationFlow)
                this.ParentForm.Close();
            else
                LoaderProfiles.AddToPanel(LoaderProfiles.Zone.Modal_Profile, this, Resources.Profiles.Constants.UC_WELCOME_PROFILES);

        }

        private void ProfileSendRemarks(string send)
        {
            if (!string.IsNullOrEmpty(send))
            {
                send = send.TrimEnd(new char[] { 'Σ' });
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    objCommand.SendReceiveProfile(send);
                }
            }

        }

        private void LoadIntegraProfileValues(string location)
        {
            WsMyCTS wsServ = new WsMyCTS();
            try
            {
                star1InfoByLocation = wsServ.GetProfileInfo(location);
            }
            catch
            {
                star1InfoByLocation1 = wsServ.GetProfileInfo(location);
            }

            if (star1InfoByLocation.CustomerName != null)
            {
                if (!string.IsNullOrEmpty(star1InfoByLocation.Attribute1))
                    SetIntegraProfileNodes(Resources.Profiles.Constants.INTEGRA_FIELD_ATTRIBUTE1,
                        star1InfoByLocation.Attribute1,
                        Resources.Profiles.Constants.NODE_INTEGRA_TOOLTIP_TEXT_ATTRIBUTE1,
                        7);
                if (!string.IsNullOrEmpty(star1InfoByLocation.CustomerName))
                    SetIntegraProfileNodes(Resources.Profiles.Constants.INTEGRA_FIELD_CUSTOMER_NAME,
                        star1InfoByLocation.CustomerName,
                        Resources.Profiles.Constants.NODE_INTEGRA_TOOLTIP_TEXT_SOCIAL_REASON,
                        8);

                if (!string.IsNullOrEmpty(star1InfoByLocation.Address))
                    SetIntegraProfileNodes(Resources.Profiles.Constants.INTEGRA_FIELD_ADDRESS,
                        star1InfoByLocation.Address,
                        Resources.Profiles.Constants.NODE_INTEGRA_TOOLTIP_TEXT_STREET_AND_NUMBER,
                        9);
                if (!string.IsNullOrEmpty(star1InfoByLocation.City))
                    SetIntegraProfileNodes(Resources.Profiles.Constants.INTEGRA_FIELD_CITY,
                        star1InfoByLocation.City,
                        Resources.Profiles.Constants.NODE_INTEGRA_TOOLTIP_TEXT_CITY,
                        9);
                if (!string.IsNullOrEmpty(star1InfoByLocation.PostalCode))
                    SetIntegraProfileNodes(Resources.Profiles.Constants.INTEGRA_FIELD_POSTAL_CODE,
                        star1InfoByLocation.PostalCode,
                        Resources.Profiles.Constants.NODE_INTEGRA_TOOLTIP_TEXT_POSTAL_CODE,
                        9);
                if (!string.IsNullOrEmpty(star1InfoByLocation.Municipality))
                    SetIntegraProfileNodes(Resources.Profiles.Constants.INTEGRA_FIELD_MUNICIPALITY,
                        star1InfoByLocation.Municipality,
                        Resources.Profiles.Constants.NODE_INTEGRA_TOOLTIP_TEXT_MUNICIPALITY,
                        9);
                if (!string.IsNullOrEmpty(star1InfoByLocation.State))
                    SetIntegraProfileNodes(Resources.Profiles.Constants.INTEGRA_FIELD_STATE,
                        star1InfoByLocation.State,
                        Resources.Profiles.Constants.NODE_INTEGRA_TOOLTIP_TEXT_STATE,
                        9);

                if (!string.IsNullOrEmpty(star1InfoByLocation.RFC))
                    SetIntegraProfileNodes(Resources.Profiles.Constants.INTEGRA_FIELD_RFC,
                        star1InfoByLocation.RFC,
                        Resources.Profiles.Constants.NODE_INTEGRA_TOOLTIP_TEXT_RFC,
                        10);
            }
            else if (star1InfoByLocation1.CustomerName != null)
            {
                if (!string.IsNullOrEmpty(star1InfoByLocation1.Attribute1))
                    SetIntegraProfileNodes(Resources.Profiles.Constants.INTEGRA_FIELD_ATTRIBUTE1,
                        star1InfoByLocation1.Attribute1,
                        Resources.Profiles.Constants.NODE_INTEGRA_TOOLTIP_TEXT_ATTRIBUTE1,
                        7);
                if (!string.IsNullOrEmpty(star1InfoByLocation1.CustomerName))
                    SetIntegraProfileNodes(Resources.Profiles.Constants.INTEGRA_FIELD_CUSTOMER_NAME,
                        star1InfoByLocation1.CustomerName,
                        Resources.Profiles.Constants.NODE_INTEGRA_TOOLTIP_TEXT_SOCIAL_REASON,
                        8);

                if (!string.IsNullOrEmpty(star1InfoByLocation1.Address))
                    SetIntegraProfileNodes(Resources.Profiles.Constants.INTEGRA_FIELD_ADDRESS,
                        star1InfoByLocation1.Address,
                        Resources.Profiles.Constants.NODE_INTEGRA_TOOLTIP_TEXT_STREET_AND_NUMBER,
                        9);
                if (!string.IsNullOrEmpty(star1InfoByLocation1.City))
                    SetIntegraProfileNodes(Resources.Profiles.Constants.INTEGRA_FIELD_CITY,
                        star1InfoByLocation1.City,
                        Resources.Profiles.Constants.NODE_INTEGRA_TOOLTIP_TEXT_CITY,
                        9);
                if (!string.IsNullOrEmpty(star1InfoByLocation1.PostalCode))
                    SetIntegraProfileNodes(Resources.Profiles.Constants.INTEGRA_FIELD_POSTAL_CODE,
                        star1InfoByLocation1.PostalCode,
                        Resources.Profiles.Constants.NODE_INTEGRA_TOOLTIP_TEXT_POSTAL_CODE,
                        9);
                if (!string.IsNullOrEmpty(star1InfoByLocation1.Municipality))
                    SetIntegraProfileNodes(Resources.Profiles.Constants.INTEGRA_FIELD_MUNICIPALITY,
                        star1InfoByLocation1.Municipality,
                        Resources.Profiles.Constants.NODE_INTEGRA_TOOLTIP_TEXT_MUNICIPALITY,
                        9);
                if (!string.IsNullOrEmpty(star1InfoByLocation1.State))
                    SetIntegraProfileNodes(Resources.Profiles.Constants.INTEGRA_FIELD_STATE,
                        star1InfoByLocation1.State,
                        Resources.Profiles.Constants.NODE_INTEGRA_TOOLTIP_TEXT_STATE,
                        9);

                if (!string.IsNullOrEmpty(star1InfoByLocation1.RFC))
                    SetIntegraProfileNodes(Resources.Profiles.Constants.INTEGRA_FIELD_RFC,
                        star1InfoByLocation1.RFC,
                        Resources.Profiles.Constants.NODE_INTEGRA_TOOLTIP_TEXT_RFC,
                        10);
            }
            else
            {
                treeViewProfile.Nodes[0].Nodes[1].Nodes.Add(Resources.Profiles.Constants.NODE_NO_DATA_NAME, Resources.Profiles.Constants.NODE_NO_DATA_TEXT, 3);
            }
        }


        private void LoadIntegraProfileBackup(string location)
        {
            WsMyCTS wsServ = new WsMyCTS();
            star1InfoByLocationBackup = wsServ.Get1stStarInfoByLocation(location);
            //star1InfoByLocationBackup = Cat1stStarInfoByLocationBL.Get1stStarInfoByLocation(location);
            if (star1InfoByLocationBackup != null)
            {
                if (!string.IsNullOrEmpty(star1InfoByLocationBackup.Attribute1))
                    SetIntegraProfileNodes(Resources.Profiles.Constants.INTEGRA_FIELD_ATTRIBUTE1,
                        star1InfoByLocationBackup.Attribute1,
                        Resources.Profiles.Constants.NODE_INTEGRA_TOOLTIP_TEXT_ATTRIBUTE1,
                        7);
                if (!string.IsNullOrEmpty(star1InfoByLocationBackup.CustomerName))
                    SetIntegraProfileNodes(Resources.Profiles.Constants.INTEGRA_FIELD_CUSTOMER_NAME,
                        star1InfoByLocationBackup.CustomerName,
                        Resources.Profiles.Constants.NODE_INTEGRA_TOOLTIP_TEXT_SOCIAL_REASON,
                        8);

                if (!string.IsNullOrEmpty(star1InfoByLocationBackup.Address))
                    SetIntegraProfileNodes(Resources.Profiles.Constants.INTEGRA_FIELD_ADDRESS,
                        star1InfoByLocationBackup.Address,
                        Resources.Profiles.Constants.NODE_INTEGRA_TOOLTIP_TEXT_STREET_AND_NUMBER,
                        9);
                if (!string.IsNullOrEmpty(star1InfoByLocationBackup.City))
                    SetIntegraProfileNodes(Resources.Profiles.Constants.INTEGRA_FIELD_CITY,
                        star1InfoByLocationBackup.City,
                        Resources.Profiles.Constants.NODE_INTEGRA_TOOLTIP_TEXT_CITY,
                        9);
                if (!string.IsNullOrEmpty(star1InfoByLocationBackup.PostalCode))
                    SetIntegraProfileNodes(Resources.Profiles.Constants.INTEGRA_FIELD_POSTAL_CODE,
                        star1InfoByLocationBackup.PostalCode,
                        Resources.Profiles.Constants.NODE_INTEGRA_TOOLTIP_TEXT_POSTAL_CODE,
                        9);
                if (!string.IsNullOrEmpty(star1InfoByLocationBackup.Municipality))
                    SetIntegraProfileNodes(Resources.Profiles.Constants.INTEGRA_FIELD_MUNICIPALITY,
                        star1InfoByLocationBackup.Municipality,
                        Resources.Profiles.Constants.NODE_INTEGRA_TOOLTIP_TEXT_MUNICIPALITY,
                        9);
                if (!string.IsNullOrEmpty(star1InfoByLocationBackup.State))
                    SetIntegraProfileNodes(Resources.Profiles.Constants.INTEGRA_FIELD_STATE,
                        star1InfoByLocationBackup.State,
                        Resources.Profiles.Constants.NODE_INTEGRA_TOOLTIP_TEXT_STATE,
                        9);

                if (!string.IsNullOrEmpty(star1InfoByLocationBackup.RFC))
                    SetIntegraProfileNodes(Resources.Profiles.Constants.INTEGRA_FIELD_RFC,
                        star1InfoByLocationBackup.RFC,
                        Resources.Profiles.Constants.NODE_INTEGRA_TOOLTIP_TEXT_RFC,
                        10);
            }
            else
            {
                treeViewProfile.Nodes[0].Nodes[1].Nodes.Add(Resources.Profiles.Constants.NODE_NO_DATA_NAME, Resources.Profiles.Constants.NODE_NO_DATA_TEXT, 3);
            }
        }

        private void SetIntegraProfileNodes(string nodeName, string nodeText, string tooltipText, int imageIndex)
        {
            TreeNode node = new TreeNode();
            node.Name = nodeName;
            node.Text = nodeText;
            node.ImageIndex = imageIndex;
            node.ToolTipText = tooltipText;
            treeViewProfile.Nodes[0].Nodes[1].Nodes.Add(node);
        }

        /// <summary>
        /// Arma el texto que sera ingresado en el cuerpo del archivo de contacto de OutLook
        /// </summary>
        /// <returns></returns>
        private string ProfileBodyToSend()
        {
            string OutLookBody = string.Empty;
            string starFirstLevelInfo = string.Empty;
            string starSecondLevelInfo = string.Empty;
            if (!ucProfileSearch.star1Info.Count.Equals(0) &&
                ucProfileSearch.star2Info.Count.Equals(0))
            {
                if (Star2List.Count > 0)
                {
                    DialogResult yesNo = MessageBox.Show("¿DESEAS INGRESAR INFORMACIÓN DE ESTRELLAS DE SEGUNDO NIVEL?", Resources.Constants.MYCTS, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (yesNo.Equals(DialogResult.Yes))
                    {
                        frmSelectStarToAdd frmSelect = new frmSelectStarToAdd();
                        frmSelect.Stars = Star2List;
                        frmSelect.ShowDialog();
                        if (frmSelect.starIndex.Count > 0)
                        {
                            starFirstLevelInfo = SetFirstLevelBody();
                            starSecondLevelInfo = SetChooseStars(ref frmSelect.starIndex);
                        }
                        else
                        {
                            starFirstLevelInfo = SetFirstLevelBody();
                        }
                    }
                    else
                    {
                        starFirstLevelInfo = SetFirstLevelBody();
                    }
                }
                else
                {
                    starFirstLevelInfo = SetFirstLevelBody();
                }
            }
            else if (!ucProfileSearch.star1Info.Count.Equals(0) &&
                !ucProfileSearch.star2Info.Count.Equals(0))
            {
                starFirstLevelInfo = SetFirstLevelBody();
                starSecondLevelInfo = SetSecondLevelBody();
                OutLookBody = string.Concat(starFirstLevelInfo,
                    "\n",
                    starSecondLevelInfo);
            }
            OutLookBody = string.Concat(starFirstLevelInfo,
                "\n",
                starSecondLevelInfo);
            return OutLookBody;
        }

        /// <summary>
        /// Crea el archivo OutLook y lo agrega a la carpeta de contactos por default
        /// </summary>
        //private void ProfileSendToOutlook()
        //{
        //    string starBody = string.Empty;
        //    _Application outlookObj = new Microsoft.Office.Interop.Outlook.Application();
        //    MAPIFolder fldContacts = (MAPIFolder)outlookObj.Session.GetDefaultFolder(OlDefaultFolders.olFolderContacts);
        //    ContactItem newContact = (ContactItem)fldContacts.Items.Add(OlItemType.olContactItem);
        //    string temp = string.Concat(name,
        //            " ",
        //            lastName);
        //    temp = temp.TrimEnd();
        //    foreach (object obj in fldContacts.Items)
        //    {
        //        ContactItem item = obj as ContactItem;
        //        if (item.FullName != null)
        //        {
        //            if (item.FullName.Equals(temp))
        //            {
        //                DialogResult yesNo = MessageBox.Show("EL CONTACTO CON EL CONTENIDO DE LA ESTRELLA  \n QUE INTENTAS EXPORTAR YA EXISTE. ¿DESEAS REEMPLAZARLO?", Resources.Constants.MYCTS, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        //                if (yesNo.Equals(DialogResult.Yes))
        //                {
        //                    item.Delete();
        //                    break;
        //                }
        //                else
        //                {
        //                    return;
        //                }
        //            }

        //        }
        //    }
        //    starBody = ProfileBodyToSend();
        //    newContact.FirstName = name;
        //    newContact.LastName = lastName;
        //    newContact.Body = starBody;
        //    if (star1InfoByLocation != null)
        //    {
        //        newContact.CompanyName = star1InfoByLocation.CustomerName;
        //        newContact.BusinessTelephoneNumber = star1InfoByLocation.MainPhone;
        //        newContact.BusinessAddressStreet = star1InfoByLocation.Address;
        //        newContact.BusinessAddressState = star1InfoByLocation.State;
        //        newContact.BusinessAddressCity = star1InfoByLocation.City;
        //        newContact.BusinessAddressPostalCode = star1InfoByLocation.PostalCode;
        //    }
        //    if (star1InfoByLocation1 != null)
        //    {
        //        newContact.CompanyName = star1InfoByLocation1.CustomerName;
        //        newContact.BusinessTelephoneNumber = star1InfoByLocation1.MainPhone;
        //        newContact.BusinessAddressStreet = star1InfoByLocation1.Address;
        //        newContact.BusinessAddressState = star1InfoByLocation1.State;
        //        newContact.BusinessAddressCity = star1InfoByLocation1.City;
        //        newContact.BusinessAddressPostalCode = star1InfoByLocation1.PostalCode;
        //    }
        //    else if (star1InfoByLocationBackup != null)
        //    {
        //        newContact.CompanyName = star1InfoByLocationBackup.CustomerName;
        //        newContact.BusinessTelephoneNumber = star1InfoByLocationBackup.MainPhone;
        //        newContact.BusinessAddressStreet = star1InfoByLocationBackup.Address;
        //        newContact.BusinessAddressState = star1InfoByLocationBackup.State;
        //        newContact.BusinessAddressCity = star1InfoByLocationBackup.City;
        //        newContact.BusinessAddressPostalCode = star1InfoByLocationBackup.PostalCode;
        //        newContact.Body = starBody;

        //    }
        //    newContact.Save();
        //    MessageBox.Show("ENVIO DE ESTRELLA CONCLUIDO CORRECTAMENTE", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    Dispose(ref outlookObj, ref fldContacts, ref newContact);
        //}

        /// <summary>
        /// Elimina los objetos creados de la API de OutLook
        /// </summary>
        /// <param name="outlookObj">Objeto de la API de OutLook</param>
        /// <param name="fldContacts">Folder de contactos de OutLook</param>
        /// <param name="newContact">Archivo de contacto de OutLook</param>
        private void Dispose(ref _Application outlookObj, ref MAPIFolder fldContacts, ref ContactItem newContact)
        {
            if (outlookObj != null) Marshal.ReleaseComObject(outlookObj);
            if (fldContacts != null) Marshal.ReleaseComObject(fldContacts);
            if (newContact != null) Marshal.ReleaseComObject(newContact);
            outlookObj = null;
            fldContacts = null;
            newContact = null;
            GC.Collect();
        }

        /// <summary>
        /// Carga la informacion de la estrella de primer nivel al cuerpo del contacto a crear
        /// </summary>
        /// <returns></returns>
        private string SetFirstLevelBody()
        {
            string starFirstLevelInfo = string.Concat("INFORMACIÓN DE LA ESTRELLA DE PRIMER NIVEL ",
                        firstStarName,
                        "\n",
                        "\n");

            foreach (MyCTS.Entities.Star1stLevelInfo value in ucProfileSearch.star1Info)
            {
                starFirstLevelInfo = string.Concat(starFirstLevelInfo,
                    value.Text,
                    "\n");
                if (value.Type.Equals(Resources.Profiles.Constants.LINE_TYPE_S))
                {
                    name = value.Text;
                    lastName = string.Empty;
                }
            }
            return starFirstLevelInfo;
        }

        /// <summary>
        /// Carga la informacion de la estrella de segundo nivel al cuerpo del contacto a crear
        /// </summary>
        /// <returns></returns>
        private string SetSecondLevelBody()
        {
            string starSecondLevelInfo = string.Concat("INFORMACIÓN DE LA ESTRELLA DE SEGUNDO NIVEL ",
                   secondStarName,
                   "\n",
                   "\n");

            foreach (Star2ndLevelInfo value in ucProfileSearch.star2Info)
            {
                starSecondLevelInfo = string.Concat(starSecondLevelInfo,
                    value.Text,
                    "\n");
                if (value.Type.Equals(Resources.Profiles.Constants.LINE_TYPE_S))
                {
                    string[] temp = value.Text.Split(new char[] { ' ' });
                    if (temp.Length > 1)
                    {
                        name = temp[0];
                        lastName = temp[1];
                    }
                    else
                    {
                        name = temp[0];
                    }
                }
            }
            return starSecondLevelInfo;
        }

        /// <summary>
        /// Ingresa las estrellas de segundo nivel dependientes de la estrella de primer nivel al cuerpo
        /// del contacto de OutLoook a crear
        /// </summary>
        /// <param name="index">Lista de indices de las estrellas de segundo nivel a cargar al cuerpo
        /// del nuevo contacto</param>
        /// <returns></returns>
        private string SetChooseStars(ref List<int> index)
        {
            string allContent = string.Empty;
            if (index.Count > 0)
            {
                foreach (int i in index)
                {
                    string starSecondLevelInfo = string.Empty;
                    starSecondLevelInfo = string.Concat("INFORMACIÓN DE LA ESTRELLA DE SEGUNDO NIVEL ",
                       Star2List[i].StarName,
                       "\n",
                       "\n");

                    foreach (Star2ndLevelInfo value in container[i])
                    {
                        starSecondLevelInfo = string.Concat(starSecondLevelInfo,
                            value.Text,
                            "\n");
                    }
                    allContent = string.Concat(allContent,
                        starSecondLevelInfo,
                        "\n");
                }
            }
            return allContent;
        }

        /// <summary>
        /// Edita el valor de las lineas contenidas en los perfiles
        /// </summary>
        /// <param name="newValue">Nuevo valor de línea</param>
        //private void ChangeLineValue(string newValue)
        //{
        //    if (mySelectedNode.Parent.Name.Contains(Resources.Profiles.Constants.NODE_STAR1_NAME))
        //    {
        //        lineType = ucProfileSearch.star1Info[mySelectedNode.Index].Type;
        //        Text = ucProfileSearch.star1Info[mySelectedNode.Index].Text;
        //        Update1stLevelInfoBL.Update1stLevel1Info(pcc, firstStarName, lineType, Text, newValue);
        //        SetProfileChangesBL.SetProfile(Login.PCC, Login.Agent, firstStarName, string.Empty, DateTime.Now);
        //        mySelectedNode.Text = string.Concat(lineType, " ", Resources.Profiles.Constants.INDENT, " ", newValue);
        //        ucProfileSearch.star1Info[mySelectedNode.Index].Text = newValue;

        //    }
        //    else if (mySelectedNode.Parent.Name.Contains(Resources.Profiles.Constants.NODE_STAR2_NAME))
        //    {
        //        lineType = ucProfileSearch.star2Info[mySelectedNode.Index].Type;
        //        Text = ucProfileSearch.star2Info[mySelectedNode.Index].Text;
        //        Update2ndLevelInfoBL.Update2ndLevelInfo(pcc, firstStarName, secondStarName, lineType, Text, newValue);
        //        SetProfileChangesBL.SetProfile(Login.PCC, Login.Agent, firstStarName, secondStarName, DateTime.Now);
        //        mySelectedNode.Text = string.Concat(lineType, " ", Resources.Profiles.Constants.INDENT, " ", newValue);
        //        ucProfileSearch.star2Info[mySelectedNode.Index].Text = newValue;
        //    }
        //}



        private Star1Details Getprofile1Level(String pcc, string level1)
        {
            var s1 = new Star1Details();
            var fd = new FieldsDynamicsBL();
            listFields = fd.GetStar1Details(pcc, level1);

            s1.ProfileName = GetDynamicProperties("ProfileName");
            s1.Pcc = GetDynamicProperties("PCC");
            s1.CustomerDk = GetDynamicProperties("CustomerDK");
            s1.CompanyName = GetDynamicProperties("CompanyName");
            s1.Phone = GetDynamicProperties("Telephone");
            s1.Ext = GetDynamicProperties("Ext");
            s1.TravelPolicies = GetDynamicProperties("TravelPolicies");
            s1.SocialReason = GetDynamicProperties("SocialReason");
            s1.Street = GetDynamicProperties("Street");
            s1.OutsideNumber = GetDynamicProperties("OutsideNumber");
            s1.InternalNumber = GetDynamicProperties("InternalNumber");
            s1.Colony = GetDynamicProperties("Colony");
            s1.Municipality = GetDynamicProperties("Municipality");
            s1.PostalCode = GetDynamicProperties("PostalCode");
            s1.City = GetDynamicProperties("City");
            s1.State = GetDynamicProperties("State");
            s1.Rfc = GetDynamicProperties("RFC");
            s1.CreditCard = GetDynamicProperties("CreditCard");
            s1.ExpirationDate = GetDynamicProperties("ExpirationDate");
            s1.ContactCompany = GetDynamicProperties("ContactCompany"); ;
            s1.Email = GetDynamicProperties("Email"); ;
            s1.Comments = GetDynamicProperties("Comments"); ;
            s1.CreatedBy = GetDynamicProperties("CreatedBy");
            s1.Password = GetDynamicProperties("Password");
            s1.Id = GetDynamicProperties("Id");
            s1.Osi = GetDynamicProperties("Osi");
            s1.Remarks = GetDynamicProperties("Remarks");
            s1.AlternativeEmail = GetDynamicProperties("AlternativeEmail");
            s1.CreditCard2 = GetDynamicProperties("CreditCard2");
            s1.ExpirationDate2 = GetDynamicProperties("ExpirationDate2");
            s1.CreditCard3 = GetDynamicProperties("CreditCard3");
            s1.ExpirationDate3 = GetDynamicProperties("ExpirationDate3");
            s1.CreditCard4 = GetDynamicProperties("CreditCard4");
            s1.ExpirationDate4 = GetDynamicProperties("ExpirationDate4");
            s1.CreditCard5 = GetDynamicProperties("CreditCard5");
            s1.ExpirationDate5 = GetDynamicProperties("ExpirationDate5");
            return s1;
        }

        private Star2Details Getprofile2Level(string email)
        {
            var s2 = new Star2Details();
            listFields = FieldsDynamicsBL.GetStar2Details(email);
            s2.Id = GetDynamicProperties("Id");
            s2.Pcc = GetDynamicProperties("Pcc");
            s2.Level1 = GetDynamicProperties("Level1");
            s2.Level2 = GetDynamicProperties("Level2");
            s2.Name = GetDynamicProperties("Name");
            s2.LastName = GetDynamicProperties("LastName");
            s2.OfficePhone = GetDynamicProperties("OfficePhone");
            s2.Ext = GetDynamicProperties("Ext");
            s2.OfficePhoneCode = GetDynamicProperties("OfficePhoneCode");
            s2.DirectPhone = GetDynamicProperties("DirectPhone");
            s2.DirectPhoneCode = GetDynamicProperties("DirectPhoneCode");
            s2.Email = GetDynamicProperties("Email");
            s2.FrequentFlyer1 = GetDynamicProperties("FrequentFlyer1");
            s2.FrequentFlyer2 = GetDynamicProperties("FrequentFlyer2");
            s2.FrequentFlyer3 = GetDynamicProperties("FrequentFlyer3");
            s2.FrequentFlyer4 = GetDynamicProperties("FrequentFlyer4");
            s2.FrequentFlyer5 = GetDynamicProperties("FrequentFlyer5");
            s2.Passport = GetDynamicProperties("Passport");
            s2.Passport2 = GetDynamicProperties("Passport2");
            s2.Passport3 = GetDynamicProperties("Passport3");

            s2.Birthday = GetDynamicProperties("Birthday");
            s2.Visa = GetDynamicProperties("Visa");
            s2.ImmigrationForm = GetDynamicProperties("ImmigrationForm");
            s2.Rfc = GetDynamicProperties("RFC");
            s2.CreditCar = GetDynamicProperties("CreditCar");
            s2.PersonalCar = GetDynamicProperties("PersonalCar");
            s2.StreetAndNumber = GetDynamicProperties("StreetAndNumber");
            s2.Colony = GetDynamicProperties("Colony");
            s2.PostalCode = GetDynamicProperties("PostalCode");
            s2.Estate = GetDynamicProperties("Estate");
            s2.City = GetDynamicProperties("City");
            s2.Name2 = GetDynamicProperties("Name2");
            s2.LastName2 = GetDynamicProperties("LastName2");
            s2.Paternal = GetDynamicProperties("Paternal");
            s2.Maternal = GetDynamicProperties("Maternal");
            s2.Occupation = GetDynamicProperties("Occupation");
            s2.Seat = GetDynamicProperties("Seat");
            s2.Family1 = GetDynamicProperties("Family1");
            s2.Family2 = GetDynamicProperties("Family2");
            s2.Family3 = GetDynamicProperties("Family3");
            s2.Family4 = GetDynamicProperties("Family4");
            s2.Family5 = GetDynamicProperties("Family5");
            s2.Family6 = GetDynamicProperties("Family6");
            s2.Comments = GetDynamicProperties("Comments");
            s2.HotelCreditCar = GetDynamicProperties("HotelCreditCar");
            s2.CadHotel1 = GetDynamicProperties("CadHotel1");
            s2.CadHotel2 = GetDynamicProperties("CadHotel2");
            s2.Leasing1 = GetDynamicProperties("Leasing1");
            s2.Leasing2 = GetDynamicProperties("Leasing2");
            s2.Osi = GetDynamicProperties("Osi");
            s2.Remarks = GetDynamicProperties("Remarks");
            s2.AlternativeEmail = GetDynamicProperties("AlternativeEmail");
            s2.CreditCard2 = GetDynamicProperties("CreditCard2");
            s2.CreditCard3 = GetDynamicProperties("CreditCard3");
            //nuevos campos
            s2.MonthPreferences = GetDynamicProperties("MonthPreferences");
            s2.PlacePreferences = GetDynamicProperties("PlacePreferences");
            s2.WantInformation = GetDynamicProperties("WantInformation");

            s2.MiddleName = GetDynamicProperties("MiddleName");
            s2.EmployeeID = GetDynamicProperties("EmployeeID");
            s2.TravelClass = GetDynamicProperties("TravelClass");
            s2.Division = GetDynamicProperties("Division");
            s2.CostCenter = GetDynamicProperties("CostCenter");
            s2.ManagerLoginID = GetDynamicProperties("ManagerLoginID");
            s2.Position_Title = GetDynamicProperties("Position_Title");
            s2.CustomerField1 = GetDynamicProperties("CustomerField1");
            s2.CustomerField2 = GetDynamicProperties("CustomerField2");
            s2.CustomerField3 = GetDynamicProperties("CustomerField3");
            s2.Gender = GetDynamicProperties("Gender");



            return s2;
        }

        private Star2Details Getprofile2Level(String pcc, string level1, string level2)
        {
            var s2 = new Star2Details();
            listFields = FieldsDynamicsBL.GetStar2Details(pcc, level1, level2);
            s2.Id = GetDynamicProperties("Id");
            s2.Pcc = GetDynamicProperties("Pcc");
            s2.Level1 = GetDynamicProperties("Level1");
            s2.Level2 = GetDynamicProperties("Level2");
            s2.Name = GetDynamicProperties("Name");
            s2.LastName = GetDynamicProperties("LastName");
            s2.OfficePhone = GetDynamicProperties("OfficePhone");
            s2.Ext = GetDynamicProperties("Ext");
            s2.OfficePhoneCode = GetDynamicProperties("OfficePhoneCode");
            s2.DirectPhone = GetDynamicProperties("DirectPhone");
            s2.DirectPhoneCode = GetDynamicProperties("DirectPhoneCode");
            s2.Email = GetDynamicProperties("Email");
            s2.FrequentFlyer1 = GetDynamicProperties("FrequentFlyer1");
            s2.FrequentFlyer2 = GetDynamicProperties("FrequentFlyer2");
            s2.FrequentFlyer3 = GetDynamicProperties("FrequentFlyer3");
            s2.FrequentFlyer4 = GetDynamicProperties("FrequentFlyer4");
            s2.FrequentFlyer5 = GetDynamicProperties("FrequentFlyer5");
            s2.Passport = GetDynamicProperties("Passport");
            s2.Passport2 = GetDynamicProperties("Passport2");
            s2.Passport3 = GetDynamicProperties("Passport3");

            s2.Birthday = GetDynamicProperties("Birthday");
            s2.Visa = GetDynamicProperties("Visa");
            s2.ImmigrationForm = GetDynamicProperties("ImmigrationForm");
            s2.Rfc = GetDynamicProperties("RFC");
            s2.CreditCar = GetDynamicProperties("CreditCar");
            s2.PersonalCar = GetDynamicProperties("PersonalCar");
            s2.StreetAndNumber = GetDynamicProperties("StreetAndNumber");
            s2.Colony = GetDynamicProperties("Colony");
            s2.PostalCode = GetDynamicProperties("PostalCode");
            s2.Estate = GetDynamicProperties("Estate");
            s2.City = GetDynamicProperties("City");
            s2.Name2 = GetDynamicProperties("Name2");
            s2.LastName2 = GetDynamicProperties("LastName2");
            s2.Paternal = GetDynamicProperties("Paternal");
            s2.Maternal = GetDynamicProperties("Maternal");
            s2.Occupation = GetDynamicProperties("Occupation");
            s2.Seat = GetDynamicProperties("Seat");
            s2.Family1 = GetDynamicProperties("Family1");
            s2.Family2 = GetDynamicProperties("Family2");
            s2.Family3 = GetDynamicProperties("Family3");
            s2.Family4 = GetDynamicProperties("Family4");
            s2.Family5 = GetDynamicProperties("Family5");
            s2.Family6 = GetDynamicProperties("Family6");
            s2.Comments = GetDynamicProperties("Comments");
            s2.HotelCreditCar = GetDynamicProperties("HotelCreditCar");
            s2.CadHotel1 = GetDynamicProperties("CadHotel1");
            s2.CadHotel2 = GetDynamicProperties("CadHotel2");
            s2.Leasing1 = GetDynamicProperties("Leasing1");
            s2.Leasing2 = GetDynamicProperties("Leasing2");
            s2.Osi = GetDynamicProperties("Osi");
            s2.Remarks = GetDynamicProperties("Remarks");
            s2.AlternativeEmail = GetDynamicProperties("AlternativeEmail");
            s2.CreditCard2 = GetDynamicProperties("CreditCard2");
            s2.CreditCard3 = GetDynamicProperties("CreditCard3");
            //nuevos campos
            s2.MonthPreferences = GetDynamicProperties("MonthPreferences");
            s2.PlacePreferences = GetDynamicProperties("PlacePreferences");
            s2.WantInformation = GetDynamicProperties("WantInformation");

            s2.MiddleName = GetDynamicProperties("MiddleName");
            s2.EmployeeID= GetDynamicProperties("EmployeeID");
            s2.TravelClass = GetDynamicProperties("TravelClass");
            s2.Division = GetDynamicProperties("Division");
            s2.CostCenter = GetDynamicProperties("CostCenter");
            s2.ManagerLoginID = GetDynamicProperties("ManagerLoginID");
            s2.Position_Title = GetDynamicProperties("Position_Title");
            s2.CustomerField1 = GetDynamicProperties("CustomerField1");
            s2.CustomerField2 = GetDynamicProperties("CustomerField2");
            s2.CustomerField3 = GetDynamicProperties("CustomerField3");
            s2.Gender = GetDynamicProperties("Gender");



            return s2;
        }

        private String GetDynamicProperties(string propName)
        {
            string x = "";
            var item = new Dynamic();

            var prop = from p in listFields
                       where p.FieldName.ToLower() == propName.ToLower()
                       select p;

            item = (prop.Count() > 0) ? prop.First<Dynamic>() : null;
            if (item != null)

                x = item.GetType().GetProperty(item.FieldName).GetValue(item, null).ToString();
            return x;
        }

        #endregion//End MethodsClass


        #region===== treeViewProfile Events =====

        //treeViewProfile_MouseClick
        private void treeViewProfile_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                TreeViewHitTestInfo info = treeViewProfile.HitTest(e.X, e.Y);
                if (info != null)
                {
                    treeViewProfile.SelectedNode = info.Node;
                    //todo:ESA changes

                    TreeNode t = treeViewProfile.SelectedNode;
                }
            }
        }


        //TreeViewProfiles_MouseDown
        private void TreeViewProfiles_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            mySelectedNode = treeViewProfile.GetNodeAt(e.X, e.Y);
        }


        //Evento treeView1_AfterLabelEdit
        private void treeView1_AfterLabelEdit(object sender, System.Windows.Forms.NodeLabelEditEventArgs e)
        {
            if (e.Label != null)
            {
                if (e.Label.Length > 0)
                {
                    if (!e.Label.Equals(mySelectedNode.Text))
                    {
                        if (e.Label.IndexOfAny(new char[] { 'ñ', 'Ñ', '|', '´', '+', '!', '¡' }) == -1)
                        {
                            DialogResult result = MessageBox.Show(Resources.Profiles.Constants.SAVE_CHANGES, Resources.Constants.MYCTS, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (result.Equals(DialogResult.Yes))
                            {
                                if (mySelectedNode.Parent.Name.Contains(Resources.Profiles.Constants.NODE_STAR1_NAME))
                                {
                                    lineType = ucProfileSearch.star1Info[mySelectedNode.Index].Type;
                                    Text = mySelectedNode.Text;
                                    Update1stLevelInfoBL.Update1stLevel1Info(pcc, firstStarName, lineType, Text, e.Label.ToUpper());
                                    SetProfileChangesBL.SetProfile(Login.PCC, Login.Agent, firstStarName, string.Empty, DateTime.Now);
                                    ucProfileSearch.star1Info[mySelectedNode.Index].Text = e.Label.ToUpper();

                                }
                                else if (mySelectedNode.Parent.Name.Contains(Resources.Profiles.Constants.NODE_STAR2_NAME))
                                {
                                    lineType = ucProfileSearch.star2Info[mySelectedNode.Index].Type;
                                    Text = mySelectedNode.Text;
                                    Update2ndLevelInfoBL.Update2ndLevelInfo(pcc, firstStarName, secondStarName, lineType, Text, e.Label.ToUpper());
                                    SetProfileChangesBL.SetProfile(Login.PCC, Login.Agent, firstStarName, secondStarName, DateTime.Now);
                                    ucProfileSearch.star2Info[mySelectedNode.Index].Text = e.Label.ToUpper();
                                }

                                e.CancelEdit = true;
                                e.Node.Text = string.Concat(lineType, " ", Resources.Profiles.Constants.INDENT, " ", e.Label.ToUpper());
                                treeViewProfile.LabelEdit = false;

                            }
                            else
                            {
                                e.CancelEdit = true;
                                e.Node.EndEdit(true);
                            }


                        }
                        else
                        {
                            e.CancelEdit = true;
                            MessageBox.Show(Resources.Profiles.Constants.NO_VALID_CHARACTERS_IN_LINE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            e.Node.BeginEdit();
                        }
                    }
                    else
                    {
                        e.CancelEdit = true;
                    }
                }
                else
                {

                    /* Cancel the label edit action, inform the user, and 
                       place the node in edit mode again. */
                    e.CancelEdit = true;
                    MessageBox.Show(Resources.Profiles.Constants.NO_EMPTY_INFORMATION, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Node.BeginEdit();
                }



            }
            else
            {
                lineType = ucProfileSearch.star1Info[mySelectedNode.Index].Type;
                e.CancelEdit = true;
                e.Node.Text = string.Concat(lineType, " ", Resources.Profiles.Constants.INDENT, " ", e.Node.Text);
                treeViewProfile.LabelEdit = false;
            }
        }

        #endregion//End treeViewProfile Events


        #region===== ToolsTripProfiles Info Button Events =====


        //Evento btnAddToRecord_Click
        private void btnAddToRecord_Click(object sender, EventArgs e)
        {
            AddProfileToRecord();
        }

        //Evento btnRenameProfile_Click
        private void btnRenameProfile_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(firstStarName) && string.IsNullOrEmpty(secondStarName))
            {
                LoaderProfiles.AddToPanelWithParameters(LoaderProfiles.Zone.Modal_Profile, this, Resources.Profiles.Constants.UC_RENAME_PROFILE, new string[] { pcc, firstStarName });
            }
            else if (!string.IsNullOrEmpty(firstStarName) && !string.IsNullOrEmpty(secondStarName))
            {
                LoaderProfiles.AddToPanelWithParameters(LoaderProfiles.Zone.Modal_Profile, this, Resources.Profiles.Constants.UC_RENAME_PROFILE, new string[] { pcc, firstStarName, secondStarName });
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = string.Empty;
            text = mySelectedNode.Text.Substring(4, mySelectedNode.Text.Length - 4);
            if (text.StartsWith("DK"))
                text = text.Substring(2, 6);
            if (text.StartsWith("5‡"))
                text = text.Substring(2, text.Length - 2);
            if (text.StartsWith("5."))
                text = text.Substring(2, text.Length - 2);
            if (text.StartsWith("3OSI"))
                text = text.Substring(5, text.Length - 5);
            if (text.StartsWith("5H-"))
                text = text.Substring(3, text.Length - 3);
            if (text.StartsWith("5"))
                text = text.Substring(1, text.Length - 1);
            if (text.Contains(','))
                text = text.Replace(',', ' ');
            else if (text.StartsWith("PE‡"))
            {
                string[] lines;
                lines = text.Split('‡');
                text = lines[1];
            }
            Clipboard.SetDataObject(text);
        }

        //Evento btnDeleteProfile_Click
        private void btnDeleteProfile_Click(object sender, EventArgs e)
        {
            Components.InputBoxDialogPassword Input = new Components.InputBoxDialogPassword();
            Input.firstStarName = firstStarName;
            Input.secondStarName = secondStarName;
            Input.pcc = pcc;
            Input.FormCaption = "Password";
            Input.FormPrompt = "Escriba la contraseña:";
            Input.BringToFront();
            Input.Show();
        }

        //Evento btnSendToOutlook_Click
        private void btnSendToOutlook_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    ProfileSendToOutlook();
            //}
            //catch
            //{ }
        }

        #endregion//End ToolsTripProfiles Info Button Events


        #region===== ContextMenu Button Click Events =====


        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ucProfileSearch _ucProfileSearch = null;

            var frm = this.ParentForm as frmProfiles;
            frm.Width = 510;
            frm.Height = 720;
            frm.CenterForm();




            if (mySelectedNode != null)
            {
                if (!string.IsNullOrEmpty(firstStarName) && !string.IsNullOrEmpty(secondStarName))
                {
                    parameters[0] = ucProfileSearch.star2Info[0].Pccid;
                    parameters[1] = ucProfileSearch.star2Info[0].Level1;
                    parameters[2] = ucProfileSearch.star2Info[0].Level2;
                    parameters[3] = "Update";
                    LoaderProfiles.AddToPanelWithParameters(LoaderProfiles.Zone.Modal_Profile, this, Resources.Profiles.Constants.UC_SECOND_LEVEL_PROFILES, parameters);
                }

                else if (!string.IsNullOrEmpty(firstStarName) && string.IsNullOrEmpty(secondStarName))
                {
                    //(mySelectedNode.Parent.Name.Contains(Resources.Profiles.Constants.NODE_STAR1_NAME))
                    parameters[0] = ucProfileSearch.star1Info[0].Pccid;
                    parameters[1] = ucProfileSearch.star1Info[0].Level1;
                    parameters[2] = null;
                    parameters[3] = "Update";
                    LoaderProfiles.AddToPanelWithParameters(LoaderProfiles.Zone.Modal_Profile, this, Resources.Profiles.Constants.UC_FIRST_LEVEL_PROFILES, parameters);
                }
            }
        }
        #endregion

        private void treeViewProfile_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var texts = new String[4];
            if (e.Button.ToString().ToLower() == "right" && e.Node.Nodes.Count==0)
            {
                if (e.Node.Text.Contains("XXXXXXXXXXXX"))
                {
                    try
                    {
                        if (ObjStar2Dpid.CreditCar.Contains(e.Node.Text.Substring(e.Node.Text.IndexOf("XXXXXXXXXXXX") + 12, 4)))
                        {
                            texts = ObjStar2Dpid.CreditCar.Split(new String[] { "*#*" }, 4, StringSplitOptions.None);
                            Clipboard.SetText(texts[1]);
                        }
                        else if (ObjStar2Dpid.CreditCard2.Contains(e.Node.Text.Substring(e.Node.Text.IndexOf("XXXXXXXXXXXX") + 12, 4)))
                        {
                            texts = ObjStar2Dpid.CreditCard2.Split(new String[] { "*#*" }, 4, StringSplitOptions.None);
                            Clipboard.SetText(texts[1]);
                        }
                        else if (ObjStar2Dpid.CreditCard3.Contains(e.Node.Text.Substring(e.Node.Text.IndexOf("XXXXXXXXXXXX") + 12, 4)))
                        {
                            texts = ObjStar2Dpid.CreditCard3.Split(new String[] { "*#*" }, 4, StringSplitOptions.None);
                            Clipboard.SetText(texts[1]);
                        }
                    }
                    catch (System.Exception exx)
                    {
                    }
                }
                else
                {
                    Clipboard.SetText(e.Node.Text);
                }
                MessageBox.Show("Se ha copiado el texto del nodo al portapapeles.","Texto copiado");
            }
            TreeNode treeNode = e.Node;
            if (treeNode.Parent != null &&
                    treeNode.Parent.Text == Resources.Profiles.Constants.NODE_STAR2LIST_TEXT &&
                    treeNode.Tag != null)
            {
                if (!treeNode.Tag.ToString().StartsWith("child"))
                    return;
                CatAllStars item = Star2List[treeNode.Index];
                int i = 0;
                string nodeInfo = string.Empty;

                if (!item.IsNew)
                {
                    List<Star2ndLevelInfo> star2InfoList = Star2ndLevelInfoBL.GetStar2ndLevelInfo(item.PccId, item.Star1Ref, item.StarName);
                    foreach (Star2ndLevelInfo star2Info in star2InfoList)
                    {

                        //treeViewProfile.Nodes[0].Nodes[0].Nodes[treeViewProfile.Nodes[0].Nodes[0].Nodes.Count - 1].Nodes[i].Nodes.Add(Resources.Profiles.Constants.NODE_STAR2INFO_NAME, 
                        //    string.Concat(star2Info.Type, " ", Resources.Profiles.Constants.INDENT, " ", star2Info.Text),
                        //    3);
                        nodeInfo += string.Concat(star2Info.Type, " ", Resources.Profiles.Constants.INDENT, " ", star2Info.Text) + "\n";
                    }
                    //container.Add(star2InfoList);
                }
                else
                {
                    ProfilesMethods objProfileMethods = new ProfilesMethods();
                    Star2Details _objStar2Details = Getprofile2Level(item.PccId, item.Star1Ref, item.StarName);
                    List<Star2ndLevelInfo> star2Info = objProfileMethods.FormatSabreProfile2L(_objStar2Details);
                    foreach (Star2ndLevelInfo starInfo in star2Info)
                    {

                        //treeViewProfile.Nodes[0].Nodes[0].Nodes[treeViewProfile.Nodes[0].Nodes[0].Nodes.Count - 1].Nodes[i].Nodes.Add(Resources.Profiles.Constants.NODE_STAR2INFO_NAME,
                        //    string.Concat(starInfo.Type, " ", Resources.Profiles.Constants.INDENT, " ", starInfo.Text),
                        //    3);
                        nodeInfo += string.Concat(starInfo.Type, " ", Resources.Profiles.Constants.INDENT, " ", starInfo.Text) + "\n";

                    }
                    //container.Add(star2Info);
                }

                MessageBox.Show(nodeInfo);
            }

        }

        private void treeViewProfile_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {

                TreeViewHitTestInfo info = treeViewProfile.HitTest(e.X, e.Y);
                if (info != null)
                {
                    string id = info.Node.Name;
                    int result = 0;
                    if (!int.TryParse(id, out result))
                        return;
                    if (result == 0)
                        return;

                    frmShowDocument show = new frmShowDocument(result);
                    show.ShowDialog();
                }
            }
            catch (System.Exception err)
            {
            }
        }

        private void treeViewProfile_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {

                TreeViewHitTestInfo info = treeViewProfile.HitTest(e.X, e.Y);
                if (info != null)
                {
                    string id = info.Node.Name;
                    int result = 0;
                    if (!int.TryParse(id, out result))
                        return;
                    if (result == 0)
                        return;

                    frmShowDocument show = new frmShowDocument(result);
                    show.ShowDialog();
                }
            }
            catch (System.Exception err)
            {
            }
        }


    }
}

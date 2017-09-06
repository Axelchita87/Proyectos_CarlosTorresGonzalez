using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Business;
using MyCTS.Entities;

namespace MyCTS.Presentation.Reservations.Profiles
{
    class ProfilesMethods
    {
        /// <summary>
        /// Asigna valores de linea del perfil a la lista contenedora
        /// </summary>
        /// <param name="value">Valor del elemento</param>
        /// <param name="text">Texto del elemento</param>
        /// <param name="profileList">Referencia de lista</param>
        private void SetCategoryValue(string value, string text, ref List<ListItem> profileList)
        {
            if (!string.IsNullOrEmpty(text))
            {
                ListItem item = new ListItem();
                item.Value = value;
                item.Text = text;
                profileList.Add(item);
            }
        }

        /// <summary>
        /// Remplaza el caracter "_" por los caracteres "=="
        /// </summary>
        /// <returns></returns>
        private string remplace_(string text)
        {
            text = text.Replace('_', ' ');
            text = text.Replace(" ", "==");
            return text;
        }

        /// <summary>
        /// Formatea los datos del perfil de primer nivel en formato Sabre
        /// </summary>
        public List<Star1stLevelInfo> FormatSabreProfile1L(Star1Details s1Profile)
        {
            var profileList = new List<ListItem>();
            var listProfile = new List<Star1stLevelInfo>();
            string textValue = string.Empty;
            try
            {
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_S, s1Profile.CompanyName, ref profileList);
                var sd = s1Profile.TravelPolicies.Split(new String[] { "*#*" }, 100, StringSplitOptions.RemoveEmptyEntries);

                foreach (String s in sd)
                    SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_P, s, ref profileList);

                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_A, string.Concat(Resources.Profiles.Constants.COMMAND_NINE, s1Profile.Phone, (!string.IsNullOrEmpty(s1Profile.Ext)) ? string.Concat(Resources.Profiles.Constants.COMMAND_X, s1Profile.Ext) : string.Empty), ref profileList);
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_A, string.Concat(Resources.Profiles.Constants.COMMAND_DK, s1Profile.CustomerDk), ref profileList);

                if (s1Profile.CustomerDk.Substring(3, 3).Equals("990"))
                {
                    SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_A, string.Concat(Resources.Profiles.Constants.COMMAND_FIVE_SLASH, s1Profile.SocialReason), ref profileList);
                    textValue = string.Format("5/{0}{1}{2},{3}", s1Profile.Street, string.Concat(Resources.Profiles.Constants.AST, s1Profile.OutsideNumber), (!string.IsNullOrEmpty(s1Profile.InternalNumber)) ? string.Concat(Resources.Profiles.Constants.AST, s1Profile.InternalNumber) : string.Empty, s1Profile.Colony);
                    SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_A, textValue, ref profileList);
                    textValue = string.Format("5/{0}, {1}, {2}", s1Profile.Municipality, s1Profile.City, s1Profile.State); SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_A, textValue, ref profileList);
                    SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_A, string.Concat(Resources.Profiles.Constants.COMMAND_FIVE_SLASH, s1Profile.PostalCode), ref profileList);
                    try
                    {
                        sd = s1Profile.Rfc.Split(new String[] { "/" }, 5, StringSplitOptions.RemoveEmptyEntries);
                        SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_A, "5/" + sd[0] + sd[1] + sd[2], ref profileList);
                        //SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_A, "5/RFC" + sd[0] + sd[1] + sd[2], ref profileList);
                    }
                    catch (Exception e)
                    {
                    }
                }
                else
                {
                    SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, string.Concat(Resources.Profiles.Constants.COMMAND_FIVE_SLASH, s1Profile.SocialReason), ref profileList);
                    textValue = string.Format("5/{0}{1}{2},{3}", s1Profile.Street, string.Concat(Resources.Profiles.Constants.AST, s1Profile.OutsideNumber), (!string.IsNullOrEmpty(s1Profile.InternalNumber)) ? string.Concat(Resources.Profiles.Constants.AST, s1Profile.InternalNumber) : string.Empty, s1Profile.Colony);
                    SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, textValue, ref profileList);
                    textValue = string.Format("5/{0}, {1}, {2}", s1Profile.Municipality, s1Profile.City, s1Profile.State);
                    SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, textValue, ref profileList);
                    SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, string.Concat(Resources.Profiles.Constants.COMMAND_FIVE_SLASH, s1Profile.PostalCode), ref profileList);
                    try
                    {
                        sd = s1Profile.Rfc.Split(new String[] { "/" }, 5, StringSplitOptions.RemoveEmptyEntries);
                        SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, "5/" + sd[0] + sd[1] + sd[2], ref profileList);
                        //SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, "5/RFC" + sd[0] + sd[1] + sd[2], ref profileList);
                    }
                    catch (Exception e)
                    {
                    }
                }

                FormatCreditCard(s1Profile.CreditCard, s1Profile.ExpirationDate, ref textValue, ref profileList, ref sd);
                FormatCreditCard(s1Profile.CreditCard2, s1Profile.ExpirationDate2, ref textValue, ref profileList, ref sd);
                FormatCreditCard(s1Profile.CreditCard3, s1Profile.ExpirationDate3, ref textValue, ref profileList, ref sd);
                FormatCreditCard(s1Profile.CreditCard4, s1Profile.ExpirationDate4, ref textValue, ref profileList, ref sd);
                FormatCreditCard(s1Profile.CreditCard5, s1Profile.ExpirationDate5, ref textValue, ref profileList, ref sd);

                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, string.Concat("CONTACTO EMPRESA:", " ", s1Profile.ContactCompany), ref profileList);
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, string.Concat("EMAIL CONTACTO:", " ", s1Profile.Email), ref profileList);
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, string.Concat("SINCRONIZACIÓN:", " ", (s1Profile.SyncStatus=="1")?"SI":"NO"), ref profileList);

                if (!string.IsNullOrEmpty(s1Profile.Comments))
                {
                    sd = s1Profile.Comments.Split(new String[] { "*#*" }, 100, StringSplitOptions.RemoveEmptyEntries);
                    foreach (String s in sd)
                        SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, s, ref profileList);
                }
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, string.Concat(Resources.Profiles.Constants.LABEL_PROFILE_CREATED_BY, " ", s1Profile.CreatedBy), ref profileList);

                if (!string.IsNullOrEmpty(s1Profile.Password))
                    SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N,
                                     string.Concat(Resources.Profiles.Constants.LABEL_PASSWORD, s1Profile.Password), ref profileList);

                if (!string.IsNullOrEmpty(s1Profile.Osi))
                {
                    string[] linesOsi = s1Profile.Osi.Split('#');
                    string[] textAndTypeLine;

                    if (linesOsi.Length > 4 || linesOsi.Length == 4)
                    {
                        for (int i = 3 - 1; i >= 0; i--)
                        {
                            textAndTypeLine = linesOsi[i].Split(',');
                            if (!string.IsNullOrEmpty(textAndTypeLine[0]))
                                SetCategoryValue(textAndTypeLine[1], "3OSI " + textAndTypeLine[0], ref profileList);
                        }

                        for (int i = 3; i < linesOsi.Length - 1; i++)
                        {
                            textAndTypeLine = linesOsi[i].Split(',');
                            if (!string.IsNullOrEmpty(textAndTypeLine[0]))
                                SetCategoryValue(textAndTypeLine[1], "3OSI " + textAndTypeLine[0], ref profileList);
                        }
                    }
                    else if (linesOsi.Length == 3)
                    {
                        for (int i = 2 - 1; i >= 0; i--)
                        {
                            if (!string.IsNullOrEmpty(linesOsi[i]))
                            {
                                textAndTypeLine = linesOsi[i].Split(',');
                                if (!string.IsNullOrEmpty(textAndTypeLine[0]))
                                    SetCategoryValue(textAndTypeLine[1], "3OSI " + textAndTypeLine[0], ref profileList);
                            }
                        }
                    }
                    else if (linesOsi.Length == 2)
                    {
                        for (int i = 1 - 1; i >= 0; i--)
                        {
                            if (!string.IsNullOrEmpty(linesOsi[i]))
                            {
                                textAndTypeLine = linesOsi[i].Split(',');
                                if (!string.IsNullOrEmpty(textAndTypeLine[0]))
                                    SetCategoryValue(textAndTypeLine[1], "3OSI " + textAndTypeLine[0], ref profileList);
                            }
                        }
                    }
                }

                if (!string.IsNullOrEmpty(s1Profile.Remarks))
                {
                    string[] linesRemarks = s1Profile.Remarks.Split('#');
                    string[] textAndTypeLine;

                    if (linesRemarks.Length > 4 || linesRemarks.Length == 4)
                    {
                        for (int i = 3 - 1; i >= 0; i--)
                        {
                            textAndTypeLine = linesRemarks[i].Split(',');
                            if (!string.IsNullOrEmpty(textAndTypeLine[0]))
                                SetCategoryValue(textAndTypeLine[1], "5" + textAndTypeLine[2] + textAndTypeLine[0], ref profileList);
                        }
                        for (int i = 3; i < linesRemarks.Length - 1; i++)
                        {
                            textAndTypeLine = linesRemarks[i].Split(',');
                            if (!string.IsNullOrEmpty(textAndTypeLine[0]))
                                SetCategoryValue(textAndTypeLine[1], "5" + textAndTypeLine[2] + textAndTypeLine[0], ref profileList);
                        }
                    }
                    else if (linesRemarks.Length == 3)
                    {
                        for (int i = 2 - 1; i >= 0; i--)
                        {
                            textAndTypeLine = linesRemarks[i].Split(',');
                            if (!string.IsNullOrEmpty(textAndTypeLine[0]))
                                SetCategoryValue(textAndTypeLine[1], "5" + textAndTypeLine[2] + textAndTypeLine[0], ref profileList);
                        }
                    }
                    else if (linesRemarks.Length == 2)
                    {
                        for (int i = 1 - 1; i >= 0; i--)
                        {
                            textAndTypeLine = linesRemarks[i].Split(',');
                            if (!string.IsNullOrEmpty(textAndTypeLine[0]))
                                SetCategoryValue(textAndTypeLine[1], "5" + textAndTypeLine[2] + textAndTypeLine[0], ref profileList);
                        }
                    }
                }

                if (!string.IsNullOrEmpty(s1Profile.AlternativeEmail))
                {
                    string[] linesAlternativeEmail = s1Profile.AlternativeEmail.Split('#');
                    string[] textAndTypeLine;

                    if (linesAlternativeEmail.Length > 4 || linesAlternativeEmail.Length == 4)
                    {
                        for (int i = 3 - 1; i >= 0; i--)
                        {
                            textAndTypeLine = linesAlternativeEmail[i].Split(',');
                            if (!string.IsNullOrEmpty(textAndTypeLine[0]))
                                SetCategoryValue(textAndTypeLine[1], "PE‡" + textAndTypeLine[0] + "‡", ref profileList);
                        }

                        for (int i = 3; i < linesAlternativeEmail.Length - 1; i++)
                        {
                            textAndTypeLine = linesAlternativeEmail[i].Split(',');
                            if (!string.IsNullOrEmpty(textAndTypeLine[0]))
                                SetCategoryValue(textAndTypeLine[1], "PE‡" + textAndTypeLine[0] + "‡", ref profileList);
                        }
                    }
                    else if (linesAlternativeEmail.Length == 3)
                    {
                        for (int i = 2 - 1; i >= 0; i--)
                        {
                            textAndTypeLine = linesAlternativeEmail[i].Split(',');
                            if (!string.IsNullOrEmpty(textAndTypeLine[0]))
                                SetCategoryValue(textAndTypeLine[1], "PE‡" + textAndTypeLine[0] + "‡", ref profileList);
                        }
                    }
                    else if (linesAlternativeEmail.Length == 2)
                    {
                        for (int i = 1 - 1; i >= 0; i--)
                        {
                            textAndTypeLine = linesAlternativeEmail[i].Split(',');
                            if (!string.IsNullOrEmpty(textAndTypeLine[0]))
                                SetCategoryValue(textAndTypeLine[1], "PE‡" + textAndTypeLine[0] + "‡", ref profileList);
                        }
                    }
                }

                if (!string.IsNullOrEmpty(s1Profile.SabreFormats))
                {
                    string[] linesSabreFormats = s1Profile.SabreFormats.Split('#');
                    string[] textAndTypeLine;

                    if (linesSabreFormats.Length > 4 || linesSabreFormats.Length == 4)
                    {
                        for (int i = 3 - 1; i >= 0; i--)
                        {
                            textAndTypeLine = linesSabreFormats[i].Split(',');
                            if (!string.IsNullOrEmpty(textAndTypeLine[0]))
                                SetCategoryValue(textAndTypeLine[1], textAndTypeLine[0], ref profileList);
                        }

                        for (int i = 3; i < linesSabreFormats.Length - 1; i++)
                        {
                            textAndTypeLine = linesSabreFormats[i].Split(',');
                            if (!string.IsNullOrEmpty(textAndTypeLine[0]))
                                SetCategoryValue(textAndTypeLine[1], textAndTypeLine[0], ref profileList);
                        }
                    }
                    else if (linesSabreFormats.Length == 3)
                    {
                        for (int i = 2 - 1; i >= 0; i--)
                        {
                            textAndTypeLine = linesSabreFormats[i].Split(',');
                            if (!string.IsNullOrEmpty(textAndTypeLine[0]))
                                SetCategoryValue(textAndTypeLine[1], textAndTypeLine[0], ref profileList);
                        }
                    }
                    else if (linesSabreFormats.Length == 2)
                    {
                        for (int i = 1 - 1; i >= 0; i--)
                        {
                            textAndTypeLine = linesSabreFormats[i].Split(',');
                            if (!string.IsNullOrEmpty(textAndTypeLine[0]))
                                SetCategoryValue(textAndTypeLine[1], textAndTypeLine[0], ref profileList);
                        }
                    }
                }
            }
            catch { }

            foreach (ListItem content in profileList)
            {
                var profile = new Star1stLevelInfo
                {
                    Id = s1Profile.Id,
                    Pccid = s1Profile.Pcc,
                    Level1 = s1Profile.ProfileName,
                    Type = content.Value,
                    Text = content.Text,
                    Purged = false
                };
                listProfile.Add(profile);
            }
            return listProfile;
        }

        /// <summary>
        /// Formatea los datos del perfil de segundo nivel en formato Sabre
        /// </summary>
        public List<Star2ndLevelInfo> FormatSabreProfile2L(Star2Details s2Profile)
        {
            var profileList = new List<ListItem>();
            var texts = new String[4];
            var listProfile = new List<Star2ndLevelInfo>();

            string textValue = string.Empty;
            string familiarLastName = string.Empty;

            if(!string.IsNullOrEmpty(s2Profile.MiddleName))
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_A, string.Concat(Resources.Constants.INDENT, s2Profile.LastName.TrimEnd(), Resources.Constants.SLASH, s2Profile.Name.TrimEnd()," ", s2Profile.MiddleName.TrimEnd()), ref profileList);
            else
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_A, string.Concat(Resources.Constants.INDENT, s2Profile.LastName.TrimEnd(), Resources.Constants.SLASH, s2Profile.Name.TrimEnd()), ref profileList);
            SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_A, string.Concat(Resources.Profiles.Constants.COMMAND_NINE, s2Profile.OfficePhone, (!string.IsNullOrEmpty(s2Profile.Ext)) ? string.Concat(Resources.Profiles.Constants.COMMAND_X, s2Profile.Ext) :
                string.Empty, (!String.IsNullOrEmpty(s2Profile.OfficePhoneCode)) ? string.Concat(Resources.Constants.INDENT, s2Profile.OfficePhoneCode.Substring(0, 1)) : string.Empty), ref profileList);

            if (!string.IsNullOrEmpty(s2Profile.DirectPhone))
            {
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_O, string.Concat(Resources.Profiles.Constants.COMMAND_NINE, s2Profile.DirectPhone, (!String.IsNullOrEmpty(s2Profile.DirectPhoneCode)) ? string.Concat(Resources.Constants.INDENT, s2Profile.DirectPhoneCode.Substring(0, 1)) : string.Empty), ref profileList);
            }

            if (!string.IsNullOrEmpty(s2Profile.Email))
            {
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_A, string.Concat(Resources.Profiles.Constants.COMMAND_PE_CROSS_LORAINE, remplace_(s2Profile.Email).ToUpper(), Resources.Profiles.Constants.COMMAND_CROSS_LORAINE), ref profileList);
            }

            FrequentFlyer(s2Profile.FrequentFlyer1, ref profileList, ref texts);
            FrequentFlyer(s2Profile.FrequentFlyer2, ref profileList, ref texts);
            FrequentFlyer(s2Profile.FrequentFlyer3, ref profileList, ref texts);
            FrequentFlyer(s2Profile.FrequentFlyer4, ref profileList, ref texts);
            FrequentFlyer(s2Profile.FrequentFlyer5, ref profileList, ref texts);

            texts = s2Profile.Passport.Split(new String[] { "*#*" }, 5, StringSplitOptions.None);

            if (!string.IsNullOrEmpty(texts[0]))
            {
                string passportVigency = string.Format("{0} - {1} {2}", texts[1], texts[2], texts[3]);
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, string.Format("NÚMERO DE PASAPORTE: {0} {1}", texts[0], passportVigency), ref profileList);
            }

            texts = s2Profile.Passport2.Split(new String[] { "*#*" }, 5, StringSplitOptions.None);

            if (!string.IsNullOrEmpty(texts[0]))
            {
                string passportVigency = string.Format("{0} - {1} {2}", texts[1], texts[2], texts[3]);
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, string.Format("NÚMERO DE PASAPORTE: {0} {1}", texts[0], passportVigency), ref profileList);
            }

            texts = s2Profile.Passport3.Split(new String[] { "*#*" }, 5, StringSplitOptions.None);

            if (!string.IsNullOrEmpty(texts[0]))
            {
                string passportVigency = string.Format("{0} - {1} {2}", texts[1], texts[2], texts[3]);
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, string.Format("NÚMERO DE PASAPORTE: {0} {1}", texts[0], passportVigency), ref profileList);
            }

            texts = s2Profile.Birthday.Split(new String[] { "*#*" }, 5, StringSplitOptions.None);
            if (!string.IsNullOrEmpty(texts[0]) && !string.IsNullOrEmpty(texts[1]) && !string.IsNullOrEmpty(texts[2]))
            {
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, string.Format("FECHA DE NACIMIENTO: {0}-{1}-{2}", texts[0], texts[1], texts[2]), ref profileList);
            }

            texts = s2Profile.Visa.Split(new String[] { "*#*" }, 5, StringSplitOptions.None);
            if (!string.IsNullOrEmpty(texts[0]))
            {
                string visaVigency = string.Format("{0} - {1} {2}", texts[1], texts[2], texts[3]);
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, string.Format("NÚMERO DE VISA: {0} {1}", texts[0], visaVigency), ref profileList);
            }

            texts = s2Profile.ImmigrationForm.Split(new String[] { "*#*" }, 5, StringSplitOptions.None);

            if (!string.IsNullOrEmpty(texts[0]))
            {
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, string.Format("FORMA MIGRATORIA: {0}", texts[0]), ref profileList);
            }

            try
            {
                if (!string.IsNullOrEmpty(texts[1]))
                {
                    SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, string.Format("NÚMERO MIGRATORIO: {0}", texts[1]), ref profileList);
                }
            }
            catch { }
            if (!string.IsNullOrEmpty(s2Profile.Rfc))
            {
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, string.Format("RFC: {0}", s2Profile.Rfc), ref profileList);
            }


            TarjetaDeCreditoSegundoNivel(s2Profile.CreditCar, ref profileList, ref texts);

            texts = s2Profile.CreditCar.Split(new String[] { "*#*" }, 5, StringSplitOptions.None);

            if (!string.IsNullOrEmpty(s2Profile.PersonalCar))
            {
                texts = s2Profile.PersonalCar.Split(new String[] { "*#*" }, 5, StringSplitOptions.None);
                if (!string.IsNullOrEmpty(texts[0]))
                {
                    SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, string.Format("TARJETA DE CREDITO CLIENTE: {0} {1} {2}-{3}", texts[0], "XXXXXXXXXXXX" + texts[1].Substring(texts[1].Length - 4), texts[2], texts[3]), ref profileList);
                }
            }

            TarjetaDeCreditoSegundoNivel(s2Profile.CreditCard2, ref profileList, ref texts);
            TarjetaDeCreditoSegundoNivel(s2Profile.CreditCard3, ref profileList, ref texts);

            //-------------------------------------------------------------------------------------------------------------------------------

            if (!string.IsNullOrEmpty(s2Profile.StreetAndNumber))
            {
                textValue = string.Format("DIRECCIÓN PERSONAL: {0}, {1}, {2}, {3}, {4}", s2Profile.StreetAndNumber, s2Profile.Colony, s2Profile.PostalCode, s2Profile.Estate, s2Profile.City);
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, textValue, ref profileList);
            }

            if (!string.IsNullOrEmpty(s2Profile.Name2) && string.IsNullOrEmpty(s2Profile.Paternal))
            {
                textValue = string.Format("NOMBRE COMPLETO: {0} {1} {2} {3}", s2Profile.Name2, s2Profile.LastName2, s2Profile.Paternal, s2Profile.Maternal);
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, textValue, ref profileList);
            }

            if (!string.IsNullOrEmpty(s2Profile.Occupation))
            {
                textValue = string.Format("OCUPACIÓN: {0}", s2Profile.Occupation);
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, textValue, ref profileList);
            }

            if (!string.IsNullOrEmpty(s2Profile.Seat))
            {
                textValue = string.Format("PREFERENCIA DE ASIENTO: {0}", s2Profile.Seat);
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, textValue, ref profileList);
            }

            try
            {
                texts = s2Profile.Family1.Split(new String[] { "*#*" }, 5, StringSplitOptions.None);
                if (!string.IsNullOrEmpty(texts[0]))
                {
                    if (!texts[2].Equals("INF"))
                    {
                        textValue = string.Format("-{0}/{1}", (!string.IsNullOrEmpty(texts[1]) ? texts[1] : familiarLastName), texts[0]);
                        SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_O, textValue, ref profileList);
                    }
                    else
                    {
                        textValue = string.Format("-I/{0}/{1} {2}", (!string.IsNullOrEmpty(texts[1]) ? texts[1] : familiarLastName), texts[0], texts[2]);
                        SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_O, textValue, ref profileList);
                    }
                }
            }
            catch { }

            try
            {
                texts = s2Profile.Family2.Split(new String[] { "*#*" }, 5, StringSplitOptions.None);
                if (!string.IsNullOrEmpty(texts[0]))
                {
                    if (!texts[2].Equals("INF"))
                    {
                        textValue = string.Format("-{0}/{1}", (!string.IsNullOrEmpty(texts[1]) ? texts[1] : familiarLastName), texts[0]);
                        SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_O, textValue, ref profileList);
                    }
                    else
                    {
                        textValue = string.Format("-I/{0}/{1} {2}", (!string.IsNullOrEmpty(texts[1]) ? texts[1] : familiarLastName), texts[0], texts[2]);
                        SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_O, textValue, ref profileList);
                    }
                }
            }
            catch { }

            try
            {
                texts = s2Profile.Family3.Split(new String[] { "*#*" }, 5, StringSplitOptions.None);
                if (!string.IsNullOrEmpty(texts[0]))
                {
                    if (!texts[2].Equals("INF"))
                    {
                        textValue = string.Format("-{0}/{1}", (!string.IsNullOrEmpty(texts[1]) ? texts[1] : familiarLastName), texts[0]);
                        SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_O, textValue, ref profileList);
                    }
                    else
                    {
                        textValue = string.Format("-I/{0}/{1} {2}", (!string.IsNullOrEmpty(texts[1]) ? texts[1] : familiarLastName), texts[0], texts[2]);
                        SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_O, textValue, ref profileList);
                    }
                }
            }
            catch { }

            try
            {
                texts = s2Profile.Family4.Split(new String[] { "*#*" }, 5, StringSplitOptions.None);
                if (!string.IsNullOrEmpty(texts[0]))
                {
                    if (!texts[2].Equals("INF"))
                    {
                        textValue = string.Format("-{0}/{1}", (!string.IsNullOrEmpty(texts[1]) ? texts[1] : familiarLastName), texts[0]);
                        SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_O, textValue, ref profileList);
                    }
                    else
                    {
                        textValue = string.Format("-I/{0}/{1} {2}", (!string.IsNullOrEmpty(texts[1]) ? texts[1] : familiarLastName), texts[0], texts[2]);
                        SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_O, textValue, ref profileList);
                    }
                }
            }
            catch { }

            try
            {
                texts = s2Profile.Family5.Split(new String[] { "*#*" }, 5, StringSplitOptions.None);
                if (!string.IsNullOrEmpty(texts[0]))
                {
                    if (!texts[2].Equals("INF"))
                    {
                        textValue = string.Format("-{0}/{1}", (!string.IsNullOrEmpty(texts[1]) ? texts[1] : familiarLastName), texts[0]);
                        SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_O, textValue, ref profileList);
                    }
                    else
                    {
                        textValue = string.Format("-I/{0}/{1} {2}", (!string.IsNullOrEmpty(texts[1]) ? texts[1] : familiarLastName), texts[0], texts[2]);
                        SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_O, textValue, ref profileList);
                    }
                }
            }
            catch { }

            try
            {
                texts = s2Profile.Family6.Split(new String[] { "*#*" }, 5, StringSplitOptions.None);
                if (!string.IsNullOrEmpty(texts[0]))
                {
                    if (!texts[2].Equals("INF"))
                    {
                        textValue = string.Format("-{0}/{1}", (!string.IsNullOrEmpty(texts[1]) ? texts[1] : familiarLastName), texts[0]);
                        SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_O, textValue, ref profileList);
                    }
                    else
                    {
                        textValue = string.Format("-I/{0}/{1} {2}", (!string.IsNullOrEmpty(texts[1]) ? texts[1] : familiarLastName), texts[0], texts[2]);
                        SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_O, textValue, ref profileList);
                    }
                }
            }
            catch { }


            if (!string.IsNullOrEmpty(s2Profile.Comments))
            {
                texts = s2Profile.Comments.Split(new String[] { "*#*" }, 100, StringSplitOptions.RemoveEmptyEntries);
                foreach (String s in texts)
                    SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, s, ref profileList);
            }

            if (!string.IsNullOrEmpty(s2Profile.HotelCreditCar))
            {
                texts = s2Profile.HotelCreditCar.Split(new String[] { "*#*" }, 5, StringSplitOptions.None);

                try
                {
                    if (!string.IsNullOrEmpty(texts[1]))
                    {
                        SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, string.Format("TARJETA DE CREDITO PARA AUTO/HOTEL: {0}{1} {2}-{3} {4}", texts[0], "XXXXXXXXXXXX" + texts[1].Substring(texts[1].Length - 4), texts[2], texts[3], texts[4]), ref profileList);
                    }
                }
                catch { }
            }
            try
            {
                if (!string.IsNullOrEmpty(s2Profile.CadHotel1))
                {
                    texts = s2Profile.CadHotel1.Split(new String[] { "*#*" }, 5, StringSplitOptions.None);
                    if (!string.IsNullOrEmpty(texts[1]))
                    {
                        SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, string.Format("PREFERENCIA HOTEL: {0}{1}", texts[0], texts[1]), ref profileList);
                    }
                }
            }
            catch { }

            try
            {
                texts = s2Profile.CadHotel2.Split(new String[] { "*#*" }, 5, StringSplitOptions.None);
                if (!string.IsNullOrEmpty(texts[1]))
                {
                    SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, string.Format("PREFERENCIA HOTEL: {0}{1}", texts[0], texts[1]), ref profileList);
                }
            }
            catch { }

            try
            {
                texts = s2Profile.Leasing1.Split(new String[] { "*#*" }, 5, StringSplitOptions.None);
                if (!string.IsNullOrEmpty(texts[1]))
                {
                    SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, string.Format("PREFERENCIA ARRENDADORA: {0}{1}", texts[0], texts[1]), ref profileList);
                }
            }
            catch { }

            try
            {
                texts = s2Profile.Leasing2.Split(new String[] { "*#*" }, 5, StringSplitOptions.None);
                if (!string.IsNullOrEmpty(texts[1]))
                {
                    SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, string.Format("PREFERENCIA ARRENDADORA: {0}{1}", texts[0], texts[1]), ref profileList);
                }
            }
            catch { }

            if (!string.IsNullOrEmpty(s2Profile.Osi))
            {
                string[] linesOsi = s2Profile.Osi.Split('#');
                string[] textAndTypeLine;

                if (linesOsi.Length > 4 || linesOsi.Length == 4)
                {
                    for (int i = 3 - 1; i >= 0; i--)
                    {
                        textAndTypeLine = linesOsi[i].Split(',');
                        if (!string.IsNullOrEmpty(textAndTypeLine[0]))
                        {
                            SetCategoryValue(textAndTypeLine[1], "3OSI " + textAndTypeLine[0], ref profileList);
                        }
                    }

                    for (int i = 3; i < linesOsi.Length - 1; i++)
                    {
                        textAndTypeLine = linesOsi[i].Split(',');
                        if (!string.IsNullOrEmpty(textAndTypeLine[0]))
                        {
                            SetCategoryValue(textAndTypeLine[1], "3OSI " + textAndTypeLine[0], ref profileList);
                        }
                    }
                }
                else if (linesOsi.Length == 3)
                {
                    for (int i = 2 - 1; i >= 0; i--)
                    {
                        textAndTypeLine = linesOsi[i].Split(',');
                        if (!string.IsNullOrEmpty(textAndTypeLine[0]))
                        {
                            SetCategoryValue(textAndTypeLine[1], "3OSI " + textAndTypeLine[0], ref profileList);
                        }
                    }
                }
                else if (linesOsi.Length == 2)
                {
                    for (int i = 1 - 1; i >= 0; i--)
                    {
                        textAndTypeLine = linesOsi[i].Split(',');
                        if (!string.IsNullOrEmpty(textAndTypeLine[0]))
                        {
                            SetCategoryValue(textAndTypeLine[1], "3OSI " + textAndTypeLine[0], ref profileList);
                        }
                    }
                }
            }

            if (!string.IsNullOrEmpty(s2Profile.Remarks))
            {
                string[] linesRemarks = s2Profile.Remarks.Split('#');
                string[] textAndTypeLine;

                if (linesRemarks.Length > 4 || linesRemarks.Length == 4)
                {
                    for (int i = 3 - 1; i >= 0; i--)
                    {
                        textAndTypeLine = linesRemarks[i].Split(',');
                        if (!string.IsNullOrEmpty(textAndTypeLine[0]))
                            SetCategoryValue(textAndTypeLine[1], "5" + textAndTypeLine[2] + textAndTypeLine[0], ref profileList);
                    }
                    for (int i = 3; i < linesRemarks.Length - 1; i++)
                    {
                        textAndTypeLine = linesRemarks[i].Split(',');
                        if (!string.IsNullOrEmpty(textAndTypeLine[0]))
                            SetCategoryValue(textAndTypeLine[1], "5" + textAndTypeLine[2] + textAndTypeLine[0], ref profileList);
                    }
                }
                else if (linesRemarks.Length == 3)
                {
                    for (int i = 2 - 1; i >= 0; i--)
                    {
                        textAndTypeLine = linesRemarks[i].Split(',');
                        if (!string.IsNullOrEmpty(textAndTypeLine[0]))
                            SetCategoryValue(textAndTypeLine[1], "5" + textAndTypeLine[2] + textAndTypeLine[0], ref profileList);
                    }
                }
                else if (linesRemarks.Length == 2)
                {
                    for (int i = 1 - 1; i >= 0; i--)
                    {
                        textAndTypeLine = linesRemarks[i].Split(',');
                        if (!string.IsNullOrEmpty(textAndTypeLine[0]))
                            SetCategoryValue(textAndTypeLine[1], "5" + textAndTypeLine[2] + textAndTypeLine[0], ref profileList);
                    }
                }
            }

            if (!string.IsNullOrEmpty(s2Profile.AlternativeEmail))
            {
                string[] linesAlternativeEmail = s2Profile.AlternativeEmail.Split('#');
                string[] textAndTypeLine;

                if (linesAlternativeEmail.Length > 4 || linesAlternativeEmail.Length == 4)
                {
                    for (int i = 3 - 1; i >= 0; i--)
                    {
                        textAndTypeLine = linesAlternativeEmail[i].Split(',');
                        if (!string.IsNullOrEmpty(textAndTypeLine[0]))
                            SetCategoryValue(textAndTypeLine[1], "PE‡" + textAndTypeLine[0] + "‡", ref profileList);
                    }

                    for (int i = 3; i < linesAlternativeEmail.Length - 1; i++)
                    {
                        textAndTypeLine = linesAlternativeEmail[i].Split(',');
                        if (!string.IsNullOrEmpty(textAndTypeLine[0]))
                            SetCategoryValue(textAndTypeLine[1], "PE‡" + textAndTypeLine[0] + "‡", ref profileList);
                    }
                }
                else if (linesAlternativeEmail.Length == 3)
                {
                    for (int i = 2 - 1; i >= 0; i--)
                    {
                        textAndTypeLine = linesAlternativeEmail[i].Split(',');
                        if (!string.IsNullOrEmpty(textAndTypeLine[0]))
                            SetCategoryValue(textAndTypeLine[1], "PE‡" + textAndTypeLine[0] + "‡", ref profileList);
                    }
                }
                else if (linesAlternativeEmail.Length == 2)
                {
                    for (int i = 1 - 1; i >= 0; i--)
                    {
                        textAndTypeLine = linesAlternativeEmail[i].Split(',');
                        if (!string.IsNullOrEmpty(textAndTypeLine[0]))
                            SetCategoryValue(textAndTypeLine[1], "PE‡" + textAndTypeLine[0] + "‡", ref profileList);
                    }
                }
            }

            if (!string.IsNullOrEmpty(s2Profile.SabreFormats))
            {
                string[] linesSabreFormats = s2Profile.SabreFormats.Split('#');
                string[] textAndTypeLine;

                if (linesSabreFormats.Length > 4 || linesSabreFormats.Length == 4)
                {
                    for (int i = 3 - 1; i >= 0; i--)
                    {
                        textAndTypeLine = linesSabreFormats[i].Split(',');
                        if (!string.IsNullOrEmpty(textAndTypeLine[0]))
                            SetCategoryValue(textAndTypeLine[1], textAndTypeLine[0], ref profileList);
                    }

                    for (int i = 3; i < linesSabreFormats.Length - 1; i++)
                    {
                        textAndTypeLine = linesSabreFormats[i].Split(',');
                        if (!string.IsNullOrEmpty(textAndTypeLine[0]))
                            SetCategoryValue(textAndTypeLine[1], textAndTypeLine[0], ref profileList);
                    }
                }
                else if (linesSabreFormats.Length == 3)
                {
                    for (int i = 2 - 1; i >= 0; i--)
                    {
                        textAndTypeLine = linesSabreFormats[i].Split(',');
                        if (!string.IsNullOrEmpty(textAndTypeLine[0]))
                            SetCategoryValue(textAndTypeLine[1], textAndTypeLine[0], ref profileList);
                    }
                }
                else if (linesSabreFormats.Length == 2)
                {
                    for (int i = 1 - 1; i >= 0; i--)
                    {
                        textAndTypeLine = linesSabreFormats[i].Split(',');
                        if (!string.IsNullOrEmpty(textAndTypeLine[0]))
                            SetCategoryValue(textAndTypeLine[1], textAndTypeLine[0], ref profileList);
                    }
                }
            }

            if (!string.IsNullOrEmpty(s2Profile.MonthPreferences))
            {
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, string.Format("MES PREFERENTE PARA VACACIONAR: {0}", s2Profile.MonthPreferences), ref profileList);
            }
            if (!string.IsNullOrEmpty(s2Profile.PlacePreferences))
            {
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, string.Format("LUGAR PREFERENTE PARA VACACIONAR: {0}", s2Profile.PlacePreferences), ref profileList);
            }
            if (!string.IsNullOrEmpty(s2Profile.WantInformation))
            {
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, string.Format("DESEA INFORMACION  DE CTS: {0}", s2Profile.WantInformation), ref profileList);
            }
            if (!string.IsNullOrEmpty(s2Profile.MiddleName))
            {
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, string.Format("SEGUNDO NOMBRE:{0}", s2Profile.MiddleName), ref profileList);
            }
            if (!string.IsNullOrEmpty(s2Profile.EmployeeID))
            {
                string[] textAndTypeLine = s2Profile.EmployeeID.Split(new String[] { "*#*" }, 7, StringSplitOptions.None);
                if (!string.IsNullOrEmpty(textAndTypeLine[6]))
                {
                    string[] cadena = new string[3];
                    cadena=LineasRemarkOsi(textAndTypeLine[0], textAndTypeLine[1], textAndTypeLine[2], textAndTypeLine[3], textAndTypeLine[4], textAndTypeLine[5]);
                
                    for (int i = 0; i < cadena.Length; i++)
                    {
                        if(!string.IsNullOrEmpty(cadena[i]))
                        SetCategoryValue(textAndTypeLine[6], cadena[i], ref profileList);
                    }
                }
            }
            //if (!string.IsNullOrEmpty(s2Profile.TravelClass))
            //{
            //    string[] textAndTypeLine= s2Profile.TravelClass.Split(new String[] { "*#*" }, 7, StringSplitOptions.None);
            //    if (!string.IsNullOrEmpty(textAndTypeLine[6]))
            //    {
            //        string[] cadena = new string[3];
            //        cadena = LineasRemarkOsi(textAndTypeLine[0], textAndTypeLine[1], textAndTypeLine[2], textAndTypeLine[3], textAndTypeLine[4], textAndTypeLine[5]);

            //        for (int i = 0; i < cadena.Length; i++)
            //        {
            //            if (!string.IsNullOrEmpty(cadena[i]))
            //                SetCategoryValue(textAndTypeLine[6], cadena[i], ref profileList);
            //        }
            //    }
            //}
            if (!string.IsNullOrEmpty(s2Profile.Division))
            {
                string[] textAndTypeLine= s2Profile.Division.Split(new String[] { "*#*" }, 7, StringSplitOptions.None);
                if (!string.IsNullOrEmpty(textAndTypeLine[6]))
                {
                    string[] cadena = new string[3];
                    cadena = LineasRemarkOsi(textAndTypeLine[0], textAndTypeLine[1], textAndTypeLine[2], textAndTypeLine[3], textAndTypeLine[4], textAndTypeLine[5]);

                    for (int i = 0; i < cadena.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(cadena[i]))
                            SetCategoryValue(textAndTypeLine[6], cadena[i], ref profileList);
                    }
                }
            }
            if (!string.IsNullOrEmpty(s2Profile.CostCenter))
            {
                string[] textAndTypeLine= s2Profile.CostCenter.Split(new String[] { "*#*" }, 7, StringSplitOptions.None);
                if (!string.IsNullOrEmpty(textAndTypeLine[6]))
                {
                    string[] cadena = new string[3];
                    cadena = LineasRemarkOsi(textAndTypeLine[0], textAndTypeLine[1], textAndTypeLine[2], textAndTypeLine[3], textAndTypeLine[4], textAndTypeLine[5]);

                    for (int i = 0; i < cadena.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(cadena[i]))
                            SetCategoryValue(textAndTypeLine[6], cadena[i], ref profileList);
                    }
                }
            }
            if (!string.IsNullOrEmpty(s2Profile.ManagerLoginID))
            {
                string[] textAndTypeLine= s2Profile.ManagerLoginID.Split(new String[] { "*#*" }, 7, StringSplitOptions.None);
                if (!string.IsNullOrEmpty(textAndTypeLine[6]))
                {
                    string[] cadena = new string[3];
                    cadena = LineasRemarkOsi(textAndTypeLine[0], textAndTypeLine[1], textAndTypeLine[2], textAndTypeLine[3], textAndTypeLine[4], textAndTypeLine[5]);

                    for (int i = 0; i < cadena.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(cadena[i]))
                            SetCategoryValue(textAndTypeLine[6], cadena[i], ref profileList);
                    }
                }
            }
            if (!string.IsNullOrEmpty(s2Profile.Position_Title))
            {
                string[] textAndTypeLine= s2Profile.Position_Title.Split(new String[] { "*#*" }, 7, StringSplitOptions.None);
                if (!string.IsNullOrEmpty(textAndTypeLine[6]))
                {
                    string[] cadena = new string[3];
                    cadena = LineasRemarkOsi(textAndTypeLine[0], textAndTypeLine[1], textAndTypeLine[2], textAndTypeLine[3], textAndTypeLine[4], textAndTypeLine[5]);

                    for (int i = 0; i < cadena.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(cadena[i]))
                            SetCategoryValue(textAndTypeLine[6], cadena[i], ref profileList);
                    }
                }
            }
            if (!string.IsNullOrEmpty(s2Profile.CustomerField1))
            {
                string[] textAndTypeLine= s2Profile.CustomerField1.Split(new String[] { "*#*" }, 7, StringSplitOptions.None);
                if (!string.IsNullOrEmpty(textAndTypeLine[6]))
                {
                    string[] cadena = new string[3];
                    cadena = LineasRemarkOsi(textAndTypeLine[0], textAndTypeLine[1], textAndTypeLine[2], textAndTypeLine[3], textAndTypeLine[4], textAndTypeLine[5]);

                    for (int i = 0; i < cadena.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(cadena[i]))
                            SetCategoryValue(textAndTypeLine[6], cadena[i], ref profileList);
                    }
                }
            }
            if (!string.IsNullOrEmpty(s2Profile.CustomerField2))
            {
                string[] textAndTypeLine= s2Profile.CustomerField2.Split(new String[] { "*#*" }, 7, StringSplitOptions.None);
                if (!string.IsNullOrEmpty(textAndTypeLine[6]))
                {
                    string[] cadena = new string[3];
                    cadena = LineasRemarkOsi(textAndTypeLine[0], textAndTypeLine[1], textAndTypeLine[2], textAndTypeLine[3], textAndTypeLine[4], textAndTypeLine[5]);

                    for (int i = 0; i < cadena.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(cadena[i]))
                            SetCategoryValue(textAndTypeLine[6], cadena[i], ref profileList);
                    }
                }
            }
            if (!string.IsNullOrEmpty(s2Profile.CustomerField3))
            {
                string[] textAndTypeLine= s2Profile.EmployeeID.Split(new String[] { "*#*" }, 7, StringSplitOptions.None);
                if (!string.IsNullOrEmpty(textAndTypeLine[6]))
                {
                    string[] cadena = new string[3];
                    cadena = LineasRemarkOsi(textAndTypeLine[0], textAndTypeLine[1], textAndTypeLine[2], textAndTypeLine[3], textAndTypeLine[4], textAndTypeLine[5]);

                    for (int i = 0; i < cadena.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(cadena[i]))
                            SetCategoryValue(textAndTypeLine[6], cadena[i], ref profileList);
                    }
                }
            }
            if (!string.IsNullOrEmpty(s2Profile.Gender))
            {
                SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, string.Format("GENERO:{0}", s2Profile.Gender), ref profileList);
            }

            foreach (ListItem content in profileList)
            {
                var item = new Star2ndLevelInfo();
                item.Level1 = s2Profile.Level1;
                item.Level2 = s2Profile.Level2;
                item.Pccid = s2Profile.Pcc;
                item.Text = content.Text;
                item.Purged = false;
                item.Type = content.Value;

                listProfile.Add(item);
            }
            listProfile.Last().Documents = s2Profile.Documents;

            return listProfile;
        }

        public string[] LineasRemarkOsi(string nombre, string rmk1, string rmk2, string osi, string prefix, string sufix)
        {
            string[] cadena = new string[3];

            int i=0;
            string line = string.Empty;

            if ((!string.IsNullOrEmpty(rmk1) && rmk1 == "ITIN") ||
               (!string.IsNullOrEmpty(rmk2) && rmk2 == "ITIN"))
            {
                line = "5‡";
                if(!string.IsNullOrEmpty(prefix))
                line= line + prefix;
                if(!string.IsNullOrEmpty(nombre))
                line=line+nombre;
                if(!string.IsNullOrEmpty(sufix))
                line= line + sufix;
                cadena[i] = line;
                i++;
            }
            if ((!string.IsNullOrEmpty(rmk1) && rmk1 == "CONT") ||
               (!string.IsNullOrEmpty(rmk2) && rmk2 == "CONT"))
            {
                line = "5.";
                if (!string.IsNullOrEmpty(prefix))
                    line = line + prefix;
                if (!string.IsNullOrEmpty(nombre))
                    line = line + nombre;
                if (!string.IsNullOrEmpty(sufix))
                    line = line + sufix;
                cadena[i] = line;
                i++;
            }
            if (!string.IsNullOrEmpty(rmk1) && rmk1 == "HIST" ||
               (!string.IsNullOrEmpty(rmk2) && rmk2 == "HIST"))
            {
                line = "5H-";
                if (!string.IsNullOrEmpty(prefix))
                    line = line + prefix;
                if (!string.IsNullOrEmpty(nombre))
                    line = line + nombre;
                if (!string.IsNullOrEmpty(sufix))
                    line = line + sufix;
                cadena[i] = line;
                i++;
            }
            if (!string.IsNullOrEmpty(rmk1) && rmk1 == "GENER" ||
               (!string.IsNullOrEmpty(rmk2) && rmk2 == "GENER"))
            {
                line = "5";
                if (!string.IsNullOrEmpty(prefix))
                    line = line + prefix;
                if (!string.IsNullOrEmpty(nombre))
                    line = line + nombre;
                if (!string.IsNullOrEmpty(sufix))
                    line = line + sufix;
                cadena[i] = line;
                i++;
            }
            if (!string.IsNullOrEmpty(osi))
            {
                line = "3OSI ";
                if (!string.IsNullOrEmpty(prefix))
                    line = line + prefix;
                if (!string.IsNullOrEmpty(nombre))
                    line = line + nombre;
                if (!string.IsNullOrEmpty(sufix))
                    line = line + sufix;
                cadena[i] = line;
                i++;
            }

            return cadena;
        }

        private void TarjetaDeCreditoSegundoNivel(string numeroTarjeta, ref List<ListItem> profileList, ref string[] texts)
        {
            try
            {
                texts = numeroTarjeta.Split(new String[] { "*#*" }, 5, StringSplitOptions.None);

                if (!string.IsNullOrEmpty(texts[0]))
                {
                    SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, string.Format("TARJETA DE CREDITO: {0} {1} {2}-{3}", texts[0], "XXXXXXXXXXXX"+texts[1].Substring(texts[1].Length-4), texts[2], texts[3]), ref profileList);
                }
            }
            catch { }
        }

        private void FrequentFlyer(string frequentFlyer, ref List<ListItem> profileList, ref string[] texts)
        {
            try
            {
                texts = frequentFlyer.Split(new String[] { "*#*" }, 5, StringSplitOptions.None);

                if (!string.IsNullOrEmpty(texts[0]) && !string.IsNullOrEmpty(texts[1]) && !string.IsNullOrEmpty(texts[2]))
                {
                    SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_O, string.Format("FF{0}{1}-{2}", texts[0], texts[1], texts[2]), ref profileList);
                }
            }
            catch { }
        }

        private void FormatCreditCard(string numeroTarjeta, string expirationDate, ref string textValue, ref List<ListItem> profileList, ref string[] sd)
        {
            if (!string.IsNullOrEmpty(numeroTarjeta))
            {
                try
                {
                    sd = expirationDate.Split(new String[] { "/" }, 5, StringSplitOptions.RemoveEmptyEntries);
                    textValue = (!string.IsNullOrEmpty(expirationDate)) ? string.Format("-{0}/{1}", sd[0], sd[1]) : string.Empty;
                    sd = numeroTarjeta.Split(new String[] { "*" }, 5, StringSplitOptions.RemoveEmptyEntries);
                    SetCategoryValue(Resources.Profiles.Constants.LINE_TYPE_N, string.Concat(sd[0], sd[1], textValue), ref profileList);
                }
                catch (Exception e)
                {
                }
            }

        }

        public static string MascaraNumeroTarjeta(string NumeroTarjeta, string LetraSuplantadora)
        {
            //if (string.IsNullOrEmpty(NumeroTarjeta))
            //{
            //    return String.Empty;
            //}

            //if (string.IsNullOrEmpty(LetraSuplantadora))
            //{
            //    LetraSuplantadora = "X";
            //}

            //if (NumeroTarjeta.Length > 10)
            //{
            //    Int32 iDigitosInvisibles = NumeroTarjeta.Length;
            //    string NumeroTarjetaIzquierda = NumeroTarjeta.Substring(0, 4);
            //    string NumeroTarjetaDerecha = NumeroTarjeta.Substring(iDigitosInvisibles - 4, 4);
            //    NumeroTarjeta = NumeroTarjetaIzquierda.PadRight(NumeroTarjeta.Length - 4, Char.Parse(LetraSuplantadora.Substring(0, 1))) + NumeroTarjetaDerecha;
            //}

            return NumeroTarjeta;
        }

        /// <summary>
        /// Actualiza y guarda el perfil al nuevo formato en la tabla Star1Details o 
        /// Star2Details segun sea el caso
        /// </summary>
        public void UpdateAtNewFormatProfile(string profileNane, string pcc)
        {

        }
    }
}

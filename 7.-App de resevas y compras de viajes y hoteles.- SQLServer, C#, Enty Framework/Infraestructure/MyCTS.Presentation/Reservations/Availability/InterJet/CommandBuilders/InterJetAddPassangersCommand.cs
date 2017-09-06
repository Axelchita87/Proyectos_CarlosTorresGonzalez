using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MyCTS.Entities;

namespace MyCTS.Presentation.Reservations.Availability.InterJet.CommandBuilders
{
    /// <summary>
    /// 
    /// </summary>
    public class InterJetAddPassangersCommand : InterJetCommandBuilder
    {


        /// <summary>
        /// Builds this instance.
        /// </summary>
        /// <returns></returns>
        public override string Build()
        {
            SendDK();
            this.InsertPassangers();
            //this.InsertInfantsPassangers();
            this.AssigTypeOfPassanger();
            Success = true;
            return "";

        }

        private void SendDK()
        {
            if (VolarisSession.IsVolarisProcess)
            {
                this.Comunicator.SendMessage("GENERANDO RESERVA DE VOLARIS...");
            }
            else
            {
                this.Comunicator.SendMessage("GENERANDO RESERVA DE INTERJET...");
            }
            this.Comunicator.SendCommand(string.Format("DK{0}", ucFirstValidations.DK));
        }

        /// <summary>
        /// Assigs the type of passanger.
        /// </summary>
        private void AssigTypeOfPassanger()
        {
            var commands = new List<string>();
            commands.AddRange(this.GetPassangerTypeCommandForAdults());
            //commands.AddRange(this.GetPassangerTypeCommandForChild());
            //commands.AddRange(this.GetPassangerTypeCommandForInfants());

            if (commands.Any())
            {
                // string commandToSend = string.Join(InterJetCommandBuilder.ENDIT, commands.ToArray());

                foreach (var command in commands)
                {
                    this.Comunicator.SendCommand(command);
                }
                //this.Comunicator.SendCommand(commandToSend);
                //this.Ticket.PassangerNumberRecord.PassangersCommand.Add(commandToSend);
            }


        }

        /// <summary>
        /// Gets the passanger type command for adults.
        /// </summary>
        /// <returns></returns>
        private List<string> GetPassangerTypeCommandForAdults()
        {
            var commands = new List<string>();

            if (this.Ticket.Passangers.GetAll().Any())
            {
                foreach (InterJetPassanger pax in this.Ticket.Passangers.GetAll())
                {
                    if (pax is InterJetAdultPassanger || pax is InterJetSeniorAdultPassanger)
                    {
                        string commandToSend = string.Format("PDTADT-{0}", pax.SabrePassangerID);
                        commands.Add(commandToSend);
                        if (pax is InterJetAdultPassanger)
                        {
                            var adultPax = (InterJetAdultPassanger)pax;
                            if (adultPax.AssignedInfant != null)
                            {
                                string commandInfatToSend = string.Format("PDTINF-{0}", adultPax.AssignedInfant.SabrePassangerID);
                                //string sabreCommandToInsertInfants = string.Format("3INFT/{0}/{1}/{2}-{3}", adultPax.AssignedInfant.LastName, adultPax.AssignedInfant.Name,
                                //                                                   adultPax.AssignedInfant.DateOfBirth.ToString("ddMMMyy", new CultureInfo("en-US")),
                                //                                                   adultPax.SabrePassangerID);

                                commands.Add(commandInfatToSend);

                            }

                        }

                        if (pax is InterJetSeniorAdultPassanger)
                        {
                            var seniorPax = (InterJetSeniorAdultPassanger)pax;
                            if (seniorPax.AssignedInfant != null)
                            {
                                string commandInfatToSend = string.Format("PDTINF-{0}", seniorPax.AssignedInfant.SabrePassangerID);
                                //string sabreCommandToInsertInfants = string.Format("3INFT/{0}/{1}/{2}-{3}", seniorPax.AssignedInfant.LastName, seniorPax.AssignedInfant.Name,
                                //                           seniorPax.AssignedInfant.DateOfBirth.ToString("ddMMMyy", new CultureInfo("en-US")),
                                //                           seniorPax.SabrePassangerID);
                                commands.Add(commandInfatToSend);

                            }

                        }
                    }

                    if (pax is InterJetChildPassanger)
                    {
                        string commandToSend = string.Format("PDTCNN-{0}", pax.SabrePassangerID);
                        commands.Add(commandToSend);

                    }

                }
            }
            return commands;
        }

        /// <summary>
        /// Gets the passanger type command for child.
        /// </summary>
        /// <returns></returns>
        private List<string> GetPassangerTypeCommandForChild()
        {
            var commands = new List<string>();
            int totalOfInfants = this.Ticket.Passangers.GetChildrenPassangers().Count;
            if (totalOfInfants > 0)
            {

                foreach (InterJetPassanger pax in this.Ticket.Passangers.GetChildrenPassangers())
                {
                    string commandToSend = string.Format("PDTCNN-{0}", pax.SabrePassangerID);
                    commands.Add(commandToSend);

                }
            }


            return commands;
        }

        /// <summary>
        /// Gets the passanger type command for infants.
        /// </summary>
        /// <returns></returns>
        private List<string> GetPassangerTypeCommandForInfants()
        {

            int totalOfInfant = this.Ticket.Passangers.GetInfants().Count;
            var commands = new List<string>();
            if (totalOfInfant > 0)
            {
                foreach (InterJetPassangerInfant infant in this.Ticket.Passangers.GetInfants())
                {

                    string commandToSend = string.Format("PDTINF-{0}", infant.SabrePassangerID);
                    commands.Add(commandToSend);

                }
            }
            return commands;
        }

        /// <summary>
        /// Inserts the passangers.
        /// </summary>
        private void InsertPassangers()
        {
            List<string> commands = this.GetSabreCommandForAddNames();
            if (commands.Count > 0)
            {

                string commandToSend = string.Join(InterJetCommandBuilder.ENDIT, commands.ToArray());
                string responseFromAPI = this.Comunicator.SendCommand(commandToSend);
                this.Ticket.PassangerNumberRecord.PassangersCommand.Add(commandToSend);
            }
        }

        /// <summary>
        /// Gets the sabre command for add names.
        /// </summary>
        /// <returns></returns>
        private List<string> GetSabreCommandForAddNames()
        {

            int totalOfPassangers = this.Ticket.Passangers.GetAll().Count;
            var commands = new List<string>();
            if (totalOfPassangers > 0)
            {
                foreach (InterJetPassanger pax in this.Ticket.Passangers.GetAll())
                {

                    bool hasSuffix = !string.IsNullOrEmpty(pax.Suffix);
                    string sabreCommand = "";
                    sabreCommand = string.Format("-{0}/{1} {2}", pax.LastName, pax.Name, hasSuffix ? pax.Suffix : pax.Title);
                    commands.Add(sabreCommand);
                    if (pax is InterJetAdultPassanger)
                    {
                        var adultPax = (InterJetAdultPassanger)pax;
                        if (adultPax.AssignedInfant != null)
                        {
                            //string sabreCommandToInsertInfants = string.Format("3INFT/{0}/{1}/{2}-{3}", adultPax.AssignedInfant.LastName, adultPax.AssignedInfant.Name,
                            //                                                       adultPax.AssignedInfant.DateOfBirth.ToString("ddMMMyy", new CultureInfo("en-US")),
                            //                                                       adultPax.SabrePassangerID);

                            string sabreCommandToInsertInfants = string.Format("-I/{0}/{1}", adultPax.AssignedInfant.LastName, adultPax.AssignedInfant.Name);
                            commands.Add(sabreCommandToInsertInfants);
                        }

                    }

                    if (pax is InterJetSeniorAdultPassanger)
                    {
                        var adultPax = (InterJetSeniorAdultPassanger)pax;
                        if (adultPax.AssignedInfant != null)
                        {
                            string sabreCommandToInsertInfants = string.Format("-I/{0}/{1}", adultPax.AssignedInfant.LastName, adultPax.AssignedInfant.Name);
                            //string sabreCommandToInsertInfants = string.Format("3INFT/{0}/{1}/{2}-{3}", adultPax.AssignedInfant.LastName, adultPax.AssignedInfant.Name,
                            //                           adultPax.AssignedInfant.DateOfBirth.ToString("ddMMMyy", new CultureInfo("en-US")),
                            //adultPax.SabrePassangerID);
                            commands.Add(sabreCommandToInsertInfants);
                        }

                    }
                }
            }
            return commands;
        }

        /// <summary>
        /// Inserts the infants passangers.
        /// </summary>
        private void InsertInfantsPassangers()
        {
            List<string> commands = this.GetSabreCommandToInsertInfants();
            if (commands.Count > 0)
            {
                string commandToSend = string.Join(InterJetCommandBuilder.ENDIT, commands.ToArray());
                string responseFromAPi = this.Comunicator.SendCommand(commandToSend);
                this.Ticket.PassangerNumberRecord.PassangersCommand.Add(commandToSend);
            }
        }



        /// <summary>
        /// Gets the sabre command to insert infants.
        /// </summary>
        /// <returns></returns>
        private List<string> GetSabreCommandToInsertInfants()
        {

            var infants = new List<InterJetPassangerInfant>();
            infants = this.Ticket.Passangers.GetInfants();
            int totalOfInfants = this.Ticket.Passangers.GetInfants().Count;
            var commands = new List<string>();
            //TODO:REVISAR al INFANTE nulo
            if (totalOfInfants > 0)
            {
                foreach (InterJetPassangerInfant infant in infants)
                {
                    if (infant != null)
                    {
                        string sabreCommandToInsertInfants = string.Format("-I/{0}/{1}", infant.LastName.Replace('Ñ', '*'), infant.Name.Replace('Ñ', '*'));
                        commands.Add(sabreCommandToInsertInfants);

                    }
                }
            }

            return commands;
        }



    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class InterJetPassangers
    {


        public void RemoveInfants()
        {
            int result = passangers.RemoveAll(p => p is InterJetPassangerInfant);

            var d = result;
        }

        /// <summary>
        /// 
        /// </summary>
        private List<InterJetPassanger> passangers;

        /// <summary>
        /// Gets the passangers.
        /// </summary>
        private List<InterJetPassanger> Passangers
        {
            get
            {
                if (this.passangers == null)
                {
                    this.passangers = new List<InterJetPassanger>();
                }
                return this.passangers;
            }
        }

        /// <summary>
        /// Adds the passangers.
        /// </summary>
        /// <param name="passangersToAdd">The passangers to add.</param>
        public void AddPassangers(List<InterJetPassanger> passangersToAdd)
        {
            int nextId = this.Passangers.Count() + 1;
            int internalId = this.Passangers.Count();
            foreach (var interJetPassanger in passangersToAdd)
            {
                interJetPassanger.InternalID = (short)internalId;
                interJetPassanger.ID = nextId.ToString(CultureInfo.InvariantCulture);
                interJetPassanger.SabrePassangerID = string.Format("{0}.1", nextId);
                nextId += 1;
                internalId += 1;
            }

            this.Passangers.AddRange(passangersToAdd);
        }
        /// <summary>
        /// Ads the passanger.
        /// </summary>
        /// <param name="passangerToAdd">The passanger to add.</param>
        public void AdPassanger(InterJetPassanger passangerToAdd)
        {
            this.AddPassangers(new List<InterJetPassanger> { passangerToAdd });
        }

        /// <summary>
        /// Gets the adults passangers.
        /// </summary>
        /// <returns></returns>
        public List<InterJetAdultPassanger> GetAdultsPassangers()
        {
            return Passangers.Where(p => p is InterJetAdultPassanger).Cast<InterJetAdultPassanger>().ToList();

        }
        /// <summary>
        /// Gets the senior adults passangers.
        /// </summary>
        /// <returns></returns>
        public List<InterJetSeniorAdultPassanger> GetSeniorAdultsPassangers()
        {
            return Passangers.Where(p => p is InterJetSeniorAdultPassanger).Cast<InterJetSeniorAdultPassanger>().ToList();
        }

        /// <summary>
        /// Gets the children passangers.
        /// </summary>
        /// <returns></returns>
        public List<InterJetChildPassanger> GetChildrenPassangers()
        {
            return Passangers.Where(p => p is InterJetChildPassanger).Cast<InterJetChildPassanger>().ToList();

        }

        /// <summary>
        /// Gets all adults passanger.
        /// </summary>
        /// <returns></returns>
        public List<InterJetPassanger> GetAllAdultsPassanger()
        {


            return
                Passangers.Where(p => p is InterJetAdultPassanger || p is InterJetSeniorAdultPassanger).ToList();

        }


        /// <summary>
        /// Assigns the sabre pasannger ID.
        /// </summary>
        private void AssignSabrePasanngerID()
        {
        }

        /// <summary>
        /// Finds the passanger.
        /// </summary>
        /// <param name="id">The ID.</param>
        /// <returns></returns>
        public InterJetPassanger FindPassanger(string id)
        {
            return Passangers.FirstOrDefault(pax => pax.ID.Equals(id));
        }

        public List<InterJetPassanger> GetAll()
        {
            this.AssignSabrePasanngerID();
            return this.Passangers;

        }

        public short Total
        {
            get { return (short)this.Passangers.Count(p => !(p is InterJetPassangerInfant)); }
        }

        public int TotalAdults
        {
            get
            {
                return this.Passangers.Count(pax => pax is InterJetAdultPassanger);

            }
        }

        public int TotalSenior
        {
            get
            {
                return this.Passangers.Count(pax => pax is InterJetSeniorAdultPassanger);

            }
        }
        public int TotalChildren
        {
            get
            {
                return this.Passangers.Count(pax => pax is InterJetChildPassanger);

            }
        }

        public bool HasAdults
        {
            get
            {
                return this.TotalAdults > 0;
            }
        }

        public bool HasChildren
        {
            get
            {
                return this.TotalChildren > 0;
            }
        }

        public bool HasSeniorAdult
        {
            get
            {
                return this.TotalSenior > 0;
            }
        }

        public InterJetPassanger Contact
        {
            get
            {

                return this.Passangers.FirstOrDefault(pax => pax.IsTheContact);

            }

        }

        public bool HasInfants
        {
            get { return this.GetInfants().Count > 0; }
        }
        /// <summary>
        /// Gets the infants.
        /// </summary>
        /// <returns></returns>
        public List<InterJetPassangerInfant> GetInfants()
        {

            return this.Passangers.Where(p => p is InterJetPassangerInfant).Cast<InterJetPassangerInfant>().ToList();

        }


        private Stack<InterJetPassanger> _stackOfPassangers;
        private Stack<InterJetPassanger> StackOfPassangers
        {
            get
            {
                if (this._stackOfPassangers == null)
                {
                    this._stackOfPassangers = new Stack<InterJetPassanger>();
                    foreach (InterJetPassanger passanger in this.GetAll())
                    {
                        this._stackOfPassangers.Push(passanger);
                    }

                }
                return this._stackOfPassangers;

            }
        }


        /// <summary>
        /// Gets the passenger with infants assigned.
        /// </summary>
        /// <returns></returns>
        public List<InterJetPassanger> GetPassengerWithInfantsAssigned()
        {


            return this.GetInfants().Where(p => p.AssignedPassanger != null).Select(infant => infant.AssignedPassanger).ToList();


        }

        public InterJetPassanger GetAndRemove()
        {
            return this.StackOfPassangers.Pop();

        }


    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class InterJetProfile
    {


        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the birth day.
        /// </summary>
        /// <value>
        /// The birth day.
        /// </value>
        public DateTime BirthDay { get; set; }

        /// <summary>
        /// Gets or sets the first level profile.
        /// </summary>
        /// <value>
        /// The first level profile.
        /// </value>
        public string FirstLevelProfile { get; set; }
        /// <summary>
        /// Gets or sets the second level profile.
        /// </summary>
        /// <value>
        /// The second level profile.
        /// </value>
        public string SecondLevelProfile { get; set; }

        /// <summary>
        /// Gets or sets the credit cards.
        /// </summary>
        /// <value>
        /// The credit cards.
        /// </value>
        public InterJetProfileCreditCards CreditCards { get; set; }

        /// <summary>
        /// Gets or sets the address of profile.
        /// </summary>
        /// <value>
        /// The address of profile.
        /// </value>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the Email profile.
        /// </summary>
        /// <value>
        /// The Email.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the Phone.
        /// </summary>
        /// <value>
        /// The Phone.
        /// </value>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the State.
        /// </summary>
        /// <value>
        /// The State.
        /// </value>
        public string State { get; set; }
    }
}

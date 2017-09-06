using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class VolarisProfile
    {

        public VolarisProfile()
        {
            CreditCards = new VolarisProfileCreditCards();
        }
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
        public VolarisProfileCreditCards CreditCards { get; set; }

        public bool HasCreditCards
        {
            get { return CreditCards.HasFristLevelCards || CreditCards.HasSecondLevelCards; }
        }

    }
}

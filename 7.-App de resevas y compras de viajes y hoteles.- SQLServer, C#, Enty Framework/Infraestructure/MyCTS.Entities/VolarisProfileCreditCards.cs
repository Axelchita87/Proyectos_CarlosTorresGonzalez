using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class VolarisProfileCreditCards
    {
        private readonly List<VolarisProfileCreditCard> _cards = new List<VolarisProfileCreditCard>();
        public void Add(List<VolarisProfileCreditCard> creditCards)
        {
            if (creditCards != null)
            {
                _cards.AddRange(creditCards.Where(c => c.IsValid).ToList());
            }

        }

        /// <summary>
        /// Adds the specified card.
        /// </summary>
        /// <param name="card">The card.</param>
        public void Add(VolarisProfileCreditCard card)
        {
            if (card != null)
            {
                Add(new List<VolarisProfileCreditCard>() { card });
            }
        }
        public List<VolarisProfileCreditCard> GetAll()
        {
            return _cards;
        }

        public List<VolarisProfileCreditCard> GetFirstLevelProfile()
        {
            if (_cards.Any())
            {
                return _cards.Where(c => c.Level == VolarisProfileCreditCardLevel.Frist).ToList();
            }
            return new List<VolarisProfileCreditCard>();

        }
        public List<VolarisProfileCreditCard> GetSecondLevelProfile()
        {
            if (_cards.Any())
            {
                return _cards.Where(c => c.Level == VolarisProfileCreditCardLevel.Second).ToList();
            }
            return new List<VolarisProfileCreditCard>();

        }

        public bool HasFristLevelCards
        {
            get { return this.GetFirstLevelProfile().Any(); }
        }

        public bool HasSecondLevelCards
        {
            get { return this.GetSecondLevelProfile().Any(); }
        }



    }
}

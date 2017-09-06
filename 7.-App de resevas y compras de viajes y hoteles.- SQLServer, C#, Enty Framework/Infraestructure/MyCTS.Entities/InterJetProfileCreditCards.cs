using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class InterJetProfileCreditCards
    {

        /// <summary>
        /// 
        /// </summary>
        private List<InterJetProfileCreditCard> _cards = new List<InterJetProfileCreditCard>();

        /// <summary>
        /// Adds the specified cards to add.
        /// </summary>
        /// <param name="cardsToAdd">The cards to add.</param>
        public void Add(List<InterJetProfileCreditCard> cardsToAdd)
        {
            foreach (var card in cardsToAdd.Where(c => c.IsValid))
            {
                this._cards.Add(card);
            }
        }

        /// <summary>
        /// Adds the specified card.
        /// </summary>
        /// <param name="card">The card.</param>
        public void Add(InterJetProfileCreditCard card)
        {
            this.Add(new List<InterJetProfileCreditCard> { card });
        }

        /// <summary>
        /// Gets the cards.
        /// </summary>
        /// <returns></returns>
        public List<InterJetProfileCreditCard> GetCards()
        {
            return _cards;
        }

        /// <summary>
        /// Gets a value indicating whether this instance has credit cards in frist level.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has credit cards in frist level; otherwise, <c>false</c>.
        /// </value>
        public bool HasCreditCardsInFristLevel
        {
            get { return this._cards.Any(card => card.Level == InterJetProfileCrediCardLevelType.Frist); }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has credit cards in second level.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has credit cards in second level; otherwise, <c>false</c>.
        /// </value>
        public bool HasCreditCardsInSecondLevel
        {
            get{return this._cards.Any(card => card.Level == InterJetProfileCrediCardLevelType.Second);}
        }

        /// <summary>
        /// Gets the first level cards.
        /// </summary>
        /// <returns></returns>
        public List<InterJetProfileCreditCard> GetFirstLevelCards()
        {
            return this._cards.Where(card => card.Level == InterJetProfileCrediCardLevelType.Frist).ToList();
        }

        /// <summary>
        /// Gets the second level cards.
        /// </summary>
        /// <returns></returns>
        public List<InterJetProfileCreditCard> GetSecondLevelCards()
        {
            return this._cards.Where(card => card.Level == InterJetProfileCrediCardLevelType.Second).ToList();
        }

        public bool HasCards
        {
            get { return this._cards.Any(); }
        }


        /// <summary>
        /// Clears this instance.
        /// </summary>
        public void Clear()
        {
            if (HasCards)
            {
                this._cards.Clear();
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace KursovoiProectCSharp.Model
{
    public class Deck : NotifyPropertyChanged
    {
        private List<int> cards { get; set; }
        public string deckName { get; set; }
        public int cardsCount 
        { 
            get { return cards.Count; } 
        }

        public int this[int i]
        {
            get
            {
                return cards[i];
            }
        }

        public Deck(List<int> cards, string deckName)
        {
            this.cards = cards;
            this.deckName = deckName;
        }

        public Deck()
        {

        }

        public bool hasNext(int i)
        {
            return i < cardsCount;
        }
    }
}

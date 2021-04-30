using System;
using System.Collections.Generic;
using System.Text;

namespace KursovoiProectCSharp.Model
{
    public class Deck : NotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public List<Card> Cards { get; set; }                
        public Deck()
        {
            Cards = new List<Card>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KursovoiProectCSharp.Model
{
    public class Deck
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Card> Cards { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        
        public int Count
        {
            get
            {
                return DB.getDeckCardCount(Id);
            }
        }


        public Deck()
        {
            Cards = new List<Card>();
        }
    }
}

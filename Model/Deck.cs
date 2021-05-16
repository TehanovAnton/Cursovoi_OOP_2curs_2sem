using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
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


        public Deck()
        {
            Cards = new List<Card>();
        }
        //--------------

        public int TotalCount
        {
            get
            {
                return DB.getDeckTotalCardCount(Id);
            }
        }
        public int TrainingCount
        {
            get
            {
                var c = DB.getCards(this) .Where(c => MemoryzationPresenter.isTimeTrain(c.lastAnswearTime, c.Quality)).ToList().Count;
                return c;
            }
        }
    }
}

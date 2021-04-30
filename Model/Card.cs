using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KursovoiProectCSharp.Model
{
    public class Card
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answear { get; set; }

        public int? DeckId { get; set; }
        [ForeignKey("DeckId")]
        public Deck Deck { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KursovoiProectCSharp.Model
{
    public class Card
    {
        public int Id { get; set; }        
        public DateTime lastAnswearTime { get; set; }
        public MemoryzationQuality Quality { get; set; }
        public int QuestionMediaId { get; set; }
        public int AnswearMediaId { get; set; }
        public int? DeckId { get; set; }

        [ForeignKey("DeckId")]
        public Deck Deck { get; set; }
    }
}

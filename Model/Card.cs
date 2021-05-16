using KursovoiProectCSharp.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Windows.Media.Imaging;

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
        //----------------------------

        public string QuestionText
        {
            get
            {
                return DB.getMedia(QuestionMediaId).Text;
            }
        }
        public string AnswearText
        {
            get
            {
                return DB.getMedia(AnswearMediaId).Text;
            }
        }

        public BitmapImage QuestionImage
        {
            get
            {
                return EditCardViewModel.ToImage(DB.getMedia(QuestionMediaId).Image);
            }
        }
        public BitmapImage AnswearImage
        {
            get
            {
                return EditCardViewModel.ToImage(DB.getMedia(AnswearMediaId).Image);
            }
        }
    }
}

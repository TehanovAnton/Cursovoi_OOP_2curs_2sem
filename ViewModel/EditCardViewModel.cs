using KursovoiProectCSharp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace KursovoiProectCSharp.ViewModel
{
    public class EditCardViewModel : NotifyPropertyChanged
    {
        private TrainingCardViewModel trainingCardVM;

        private Card card;
        public Card Card
        {
            get { return card; }
            set
            {
                card = value;
                OnPropertyChanged("Card");
            }
        }


        private string questionText;
        public string QuestionText
        {
            get
            {
                return questionText;
            }
            set
            {
                questionText = value;
                OnPropertyChanged("QuestionText");
            }
        }

        private string answearText;
        public string AnswearText
        {
            get
            {
                return answearText;
            }
            set
            {
                answearText = value;
                OnPropertyChanged("AnswearText");
            }
        }


        public RelayCommand EditCard
        {
            get
            {
                return new RelayCommand(
                        obj =>
                        {
                            var q = DB.getMedia(Card.QuestionMediaId);
                            q.Text = questionText;

                            var a = DB.getMedia(Card.AnswearMediaId);
                            a.Text = answearText;
                            DB.context.SaveChanges();

                            trainingCardVM.QuestionText = questionText;
                            trainingCardVM.AnswearText = answearText;

                            trainingCardVM.TrainingPage = null;
                        }
                    );
            }
        }


        public EditCardViewModel(Card card, TrainingCardViewModel trainingCardVM)
        {
            Card = card;
            this.trainingCardVM = trainingCardVM;

            QuestionText = DB.getCardQuestionText(Card.QuestionMediaId);
            AnswearText = DB.getCardAnswearText(Card.AnswearMediaId);
        }
    }
}

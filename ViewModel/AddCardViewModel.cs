using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;
using KursovoiProectCSharp.Model;

namespace KursovoiProectCSharp.ViewModel
{
    public class AddCardViewModel : NotifyPropertyChanged
    {
        private MainWindowViewModel mainWinVM;
        private Deck deck;


        private string _question;
        public string _Question
        {
            get
            {
                return _question;
            }
            set
            {
                _question = value;
                OnPropertyChanged("_Question");
            }
        }


        private string _answear;
        public string _Answear
        {
            get
            {
                return _answear;
            }
            set
            {
                _answear = value;
                OnPropertyChanged("_Answear");
            }
        }


        public RelayCommand AddCard
        {
            get
            {
                return new RelayCommand(
                        obj =>
                        {
                            var q = new Media { Text = _Question, Type = MediaType.Question };
                            var a = new Media { Text = _Question, Type = MediaType.Answear };
                            DB.context.Medias.AddRange(q, a);
                            DB.context.SaveChanges();

                            var c = new Card()
                            {
                                QuestionMediaId = q.Id,
                                AnswearMediaId = a.Id,
                                DeckId = deck.Id,
                                lastAnswearTime = new DateTime()
                            };

                            DB.addCard(c);
                            mainWinVM.AppPage = null;
                        }
                    );
            }
        }


        public AddCardViewModel(Deck deck, MainWindowViewModel mainWinVM)
        {
            this.mainWinVM = mainWinVM;
            this.deck = deck;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;
using KursovoiProectCSharp.Model;
using Microsoft.Win32;

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


        private BitmapImage questionImage;
        public BitmapImage QuestionImage
        {
            get
            {
                return questionImage;
            }
            set
            {
                questionImage = value;
                OnPropertyChanged("QuestionImage");
            }
        }

        private BitmapImage answearImage;
        public BitmapImage AnswearImage

        {
            get
            {
                return answearImage;
            }
            set
            {
                answearImage = value;
                OnPropertyChanged("AnswearImage");
            }
        }


        public RelayCommand SetQuestionImage
        {
            get
            {
                return new RelayCommand(
                        obj =>
                        {
                            OpenFileDialog dialog = new OpenFileDialog();
                            if (dialog.ShowDialog() == true)
                            {
                                var imageBitMap = new BitmapImage();
                                imageBitMap.BeginInit();
                                imageBitMap.UriSource = new Uri(dialog.FileName);
                                imageBitMap.EndInit();
                                QuestionImage = imageBitMap;
                            }
                        }
                    );
            }
        }
        public RelayCommand SetAnswearImage
        {
            get
            {
                return new RelayCommand(
                        obj =>
                        {
                            OpenFileDialog dialog = new OpenFileDialog();
                            if (dialog.ShowDialog() == true)
                            {
                                var imageBitMap = new BitmapImage();
                                imageBitMap.BeginInit();
                                imageBitMap.UriSource = new Uri(dialog.FileName);
                                imageBitMap.EndInit();
                                AnswearImage = imageBitMap;
                            }
                        }
                    );
            }
        }
        public RelayCommand AddCard
        {
            get
            {
                return new RelayCommand(
                        obj =>
                        {                          

                            var q = new Media { Text = _Question, Image = RegisterViewModel.getImageBytes(QuestionImage), Type = MediaType.Question };
                            var a = new Media { Text = _Question, Image = RegisterViewModel.getImageBytes(AnswearImage), Type = MediaType.Answear };
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
        public RelayCommand Back
        {
            get
            {
                return new RelayCommand(
                        obj =>
                        {
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

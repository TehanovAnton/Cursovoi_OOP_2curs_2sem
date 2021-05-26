using KursovoiProectCSharp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using KursovoiProectCSharp.View;

namespace KursovoiProectCSharp.ViewModel
{
    public class TrainingCardViewModel : NotifyPropertyChanged
    {
        private MainWindowViewModel mainWinVM;


        private Page trainingPage;
        public Page TrainingPage
        {
            get
            {
                return trainingPage;
            }
            set
            {
                trainingPage = value;
                OnPropertyChanged("TrainingPage");
            }
        }
        private Page footer;
        public Page Footer
        {
            get
            {
                return footer;
            }
            set
            {
                footer = value;
                OnPropertyChanged("Footer");
            }
        }


        private Deck deck;
        public Deck Deck
        {
            get { return deck; }
            set
            {
                deck = value;
                OnPropertyChanged("Deck");
            }
        }


        public Card currentCard;
        public Card CurrentCard

        {
            get { return currentCard; }
            set
            {
                currentCard = value;
                OnPropertyChanged("CurrentCard");
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


        private void SetQuality(MemoryzationQuality quality)
        {
            DB.changeMemoryzationCategory(CurrentCard, quality);
            CurrentCard.lastAnswearTime = DateTime.Now;

            CurrentCard = DB.getTrainCard(Deck.Id);
            if (CurrentCard == null)
                EndTraining.Execute("");
            else
            {
                QuestionText = DB.getMedia(CurrentCard.QuestionMediaId).Text;
                QuestionImage = EditCardViewModel.ToImage(DB.getMedia(CurrentCard.QuestionMediaId).Image);
                AnswearText = DB.getMedia(CurrentCard.AnswearMediaId).Text;
                AnswearImage = EditCardViewModel.ToImage(DB.getMedia(CurrentCard.AnswearMediaId).Image);
            }

            Footer = new HidenAnswerPage(this);
        }


        public RelayCommand SetShowenAnswerPage
        {
            get
            {
                return new RelayCommand(
                        obj =>
                        {
                            Footer = new ShownAnswerPage(this);
                        }
                    );
            }
        }
        public RelayCommand EndTraining
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
        public RelayCommand SetCardSettingPage
        {
            get
            {
                return new RelayCommand(
                        obj =>
                        {
                            TrainingPage = new CardSettingsPage(this);
                        }
                    );
            }
        }
        public RelayCommand EditCard
        {
            get
            {
                return new RelayCommand(
                        obj =>
                        {
                            TrainingPage = new EditCardPage(CurrentCard, this);
                        }
                    );
            }
        }
        public RelayCommand DeleteCard
        {
            get
            {
                return new RelayCommand(
                        obj =>
                        {
                            DB.removeCard(CurrentCard);
                            CurrentCard = DB.getTrainCard(Deck.Id);
                            if (CurrentCard == null)
                                EndTraining.Execute("");
                            else
                            {
                                QuestionText = DB.getMedia(CurrentCard.QuestionMediaId).Text;
                                AnswearText = DB.getMedia(CurrentCard.AnswearMediaId).Text;
                                TrainingPage = null;
                            }
                        }
                    );
            }
        }
        public RelayCommand CloseMenu
        {
            get
            {
                return new RelayCommand(
                        obj =>
                        {
                            TrainingPage = null;
                        }
                    );
            }
        }
        public RelayCommand LeaveTraining
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
        public RelayCommand Again
        {
            get
            {
                return new RelayCommand(
                        obj =>
                        {
                            SetQuality(MemoryzationQuality.Again);
                        }
                    );
            }
        }
        public RelayCommand Bad
        {
            get
            {
                return new RelayCommand(
                        obj =>
                        {
                            SetQuality(MemoryzationQuality.Bad);
                        }
                    );
            }
        }
        public RelayCommand Normal
        {
            get
            {
                return new RelayCommand(
                        obj =>
                        {
                            SetQuality(MemoryzationQuality.Normal);
                        }
                    );
            }
        }
        public RelayCommand Good
        {
            get
            {
                return new RelayCommand(
                        obj =>
                        {
                            SetQuality(MemoryzationQuality.Good);
                        }
                    );
            }
        }
        public RelayCommand Excellent
        {
            get
            {
                return new RelayCommand(
                        obj =>
                        {
                            SetQuality(MemoryzationQuality.Excellent);
                        }
                    );
            }
        }


        public TrainingCardViewModel(Deck deck, MainWindowViewModel mainWinVM)
        {
            Deck = deck;
            this.mainWinVM = mainWinVM;

            CurrentCard = DB.getTrainCard(deck.Id);

            QuestionText = DB.getMedia(CurrentCard.QuestionMediaId).Text;
            QuestionImage = EditCardViewModel.ToImage(DB.getMedia(CurrentCard.QuestionMediaId).Image);

            AnswearText = DB.getMedia(CurrentCard.AnswearMediaId).Text;
            AnswearImage = EditCardViewModel.ToImage(DB.getMedia(CurrentCard.AnswearMediaId).Image);

            Footer = new HidenAnswerPage(this);
        }

        #region Images
        public BitmapImage RollUpIcon
        {
            get
            {
                return MainWindowViewModel.ImageBMP(@"C:\Users\Anton\source\repos\pacei_NV_OOTP\Курсовой ООП 2курс-2семестр\KursovoiProectCSharp\Images\RollUpMenu.png");
            }
        }
        #endregion
    }
}

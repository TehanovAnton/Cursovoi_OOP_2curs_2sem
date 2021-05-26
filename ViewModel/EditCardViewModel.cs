using KursovoiProectCSharp.Model;
using KursovoiProectCSharp.View;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Media.Imaging;

namespace KursovoiProectCSharp.ViewModel
{
    public class EditCardViewModel : NotifyPropertyChanged
    {
        private TrainingCardViewModel trainingCardVM;
        private BrowseDeckViewModel browseDeckCardVM;

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


        public RelayCommand EditCard
        {
            get
            {
                return new RelayCommand(
                        obj =>
                        {
                            var q = DB.getMedia(Card.QuestionMediaId);
                            q.Text = questionText;
                            if (QuestionImage.UriSource != null)
                                q.Image = RegisterViewModel.getImageBytes(QuestionImage);

                            var a = DB.getMedia(Card.AnswearMediaId);
                            a.Text = answearText;
                            if (AnswearImage.UriSource != null)
                                a.Image = RegisterViewModel.getImageBytes(AnswearImage);
                            DB.context.SaveChanges();

                            if (trainingCardVM != null)
                            {
                                trainingCardVM.QuestionText = questionText;
                                trainingCardVM.AnswearText = answearText;
                                trainingCardVM.QuestionImage = EditCardViewModel.ToImage(q.Image);
                                trainingCardVM.AnswearImage = EditCardViewModel.ToImage(a.Image);

                                trainingCardVM.TrainingPage = null;
                            }
                            else
                            {
                                browseDeckCardVM.Decks.Clear();
                                browseDeckCardVM.Items = new BroseList(browseDeckCardVM);
                            }
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
                            if (trainingCardVM != null)
                                trainingCardVM.TrainingPage = null;
                            else
                                browseDeckCardVM.Items = null;
                        }
                    );
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


        public EditCardViewModel(Card card, TrainingCardViewModel trainingCardVM)
        {
            Card = card;
            this.trainingCardVM = trainingCardVM;

            QuestionText = DB.getMedia(Card.QuestionMediaId).Text;
            QuestionImage = ToImage(DB.getMedia(card.QuestionMediaId).Image);            


            AnswearText = DB.getMedia(Card.AnswearMediaId).Text;
            AnswearImage = ToImage(DB.getMedia(card.AnswearMediaId).Image);           
        }
        public EditCardViewModel(Card card, BrowseDeckViewModel browseDeckCardVM)
        {
            Card = card;
            this.browseDeckCardVM = browseDeckCardVM;

            QuestionText = DB.getMedia(Card.QuestionMediaId).Text;
            QuestionImage = ToImage(DB.getMedia(card.QuestionMediaId).Image);


            AnswearText = DB.getMedia(Card.AnswearMediaId).Text;
            AnswearImage = ToImage(DB.getMedia(card.AnswearMediaId).Image);
        }

        public static BitmapImage ToImage(byte[] array)
        {
            if (array != null)
                using (var ms = new MemoryStream(array))
                {
                    var image = new BitmapImage();
                    image.BeginInit();
                    image.CacheOption = BitmapCacheOption.OnLoad; // here
                    image.StreamSource = ms;
                    image.EndInit();
                    return image;
                }
            else
                return new BitmapImage();
        }
    }
}

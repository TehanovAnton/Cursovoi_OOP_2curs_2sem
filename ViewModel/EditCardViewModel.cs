using KursovoiProectCSharp.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;

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

                            trainingCardVM.QuestionText = questionText;
                            trainingCardVM.AnswearText = answearText;
                            trainingCardVM.QuestionImage = EditCardViewModel.ToImage(q.Image);
                            trainingCardVM.AnswearImage = EditCardViewModel.ToImage(a.Image);

                            trainingCardVM.TrainingPage = null;
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
                            trainingCardVM.TrainingPage = null;
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

            QuestionText = DB.getCardQuestionText(Card.QuestionMediaId);
            QuestionImage = ToImage(DB.getMedia(card.QuestionMediaId).Image);            


            AnswearText = DB.getCardAnswearText(Card.AnswearMediaId);
            AnswearImage = ToImage(DB.getMedia(card.AnswearMediaId).Image);           
        }

        public static BitmapImage ToImage(byte[] array)
        {
            using (var ms = new System.IO.MemoryStream(array))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad; // here
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using static System.Net.Mime.MediaTypeNames;

namespace KursovoiProectCSharp
{
    class MainWindowViewModel : NotifyPropertyChanged
    {
        private Window appWin { get; set; }


        #region Deck actions
        private Page deckListPage;
        public Page DeckListPage
        {
            get { return deckListPage; }
            set
            {
                deckListPage = value;
                OnPropertyChanged("DeckListPage");
            }
        }

        private RelayCommand setDeckListPage;
        public RelayCommand SetDeckListPage
        {
            get
            {
                return setDeckListPage ?? new RelayCommand(
                        obj =>
                        {
                            DeckListPage = new View.DeckListPage();
                        }
                    );
            }
        }
        #endregion


        #region CloseApp
        private RelayCommand closeApp;
        public RelayCommand CloseApp
        {
            get
            {
                return closeApp ?? new RelayCommand(
                        obj =>
                        {
                            appWin.Close();
                        }
                    );
            }
        }
        #endregion


        #region ImageBMP
        private BitmapImage ImageBMP(string imgPath)
        {
            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri(imgPath);
            logo.EndInit();
            return logo;
        }
        public BitmapImage MenuIconMainPane
        {
            get {               
                return ImageBMP(@"C:\Users\Anton\source\repos\pacei_NV_OOTP\Курсовой ООП 2курс-2семестр\KursovoiProectCSharp\Images\MenuIconMainPanel.png");
            }
        }
        public BitmapImage CloseIconMainPanel
        {
            get
            {
                return ImageBMP(@"C:\Users\Anton\source\repos\pacei_NV_OOTP\Курсовой ООП 2курс-2семестр\KursovoiProectCSharp\Images\CloseIconMainPanel.png");
            }
        }
        #endregion


        public MainWindowViewModel(Window win)
        {
            appWin = win;
            DeckListPage = new View.StartDeckLsitPage(); ;
        }        
    }
}

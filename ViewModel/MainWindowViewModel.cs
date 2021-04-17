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
    public class MainWindowViewModel : NotifyPropertyChanged
    {
        private Window appWin { get; set; }

        #region Menu actions
        private Page appPage;
        public Page AppPage
        {
            get { return appPage; }
            set
            {
                appPage = value;
                OnPropertyChanged("AppPage");
            }
        }
         
        private RelayCommand setAppPage;
        public RelayCommand SetAppPage
        {
            get
            {
                return setAppPage ?? new RelayCommand(
                        obj =>
                        {
                            AppPage = new View.MenuPage(this);
                        }
                    );
            }
        }

        private RelayCommand removeAppPage;
        public RelayCommand RemoveAppPage
        {
            get
            {
                return removeAppPage ?? new RelayCommand(
                        obj =>
                        {
                            AppPage = null;
                        }
                    );
            }
        }
        #endregion


        #region Deck actions
        private Page deckListPage;
        private bool fixedDeckListPage;
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


        private RelayCommand setStartDeckListPage;
        public RelayCommand SetStartDeckListPage
        {
            get
            {
                return setDeckListPage ?? new RelayCommand(
                        obj =>
                        {
                            DeckListPage = new View.StartDeckLsitPage();
                        },
                        (obj) => !fixedDeckListPage
                    );
            }
        }


        private RelayCommand fixDeckListPage;
        public RelayCommand FixDeckListPage
        {
            get
            {
                return fixDeckListPage ?? new RelayCommand(
                        obj =>
                        {
                            if (fixedDeckListPage)
                            {
                                DeckListPage = new View.StartDeckLsitPage();
                                fixedDeckListPage = false;
                            }
                            else
                                fixedDeckListPage = true;
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
        public static BitmapImage ImageBMP(string imgPath)
        {
            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri(imgPath);
            logo.EndInit();
            return logo;
        }
        public BitmapImage MenuIcon
        {
            get {               
                return ImageBMP(@"C:\Users\Anton\source\repos\pacei_NV_OOTP\Курсовой ООП 2курс-2семестр\KursovoiProectCSharp\Images\MenuIcon.png");
            }
        }
        public BitmapImage CloseIcon
        {
            get
            {
                return ImageBMP(@"C:\Users\Anton\source\repos\pacei_NV_OOTP\Курсовой ООП 2курс-2семестр\KursovoiProectCSharp\Images\CloseIcon.png");
            }
        }
        #endregion


        public MainWindowViewModel(Window win)
        {
            appWin = win;
            fixedDeckListPage = false;
            DeckListPage = new View.DeckListPage();
        }        
    }
}

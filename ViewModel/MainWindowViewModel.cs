using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using KursovoiProectCSharp.View;
using static System.Net.Mime.MediaTypeNames;

namespace KursovoiProectCSharp
{
    public class MainWindowViewModel : NotifyPropertyChanged
    { 
        public static Window appWin { get; set; }        

        #region Pages
        private Page appPage;
        private Page deckListPage;


        public Page AppPage
        {
            get { return appPage; }
            set
            {
                appPage = value;
                OnPropertyChanged("AppPage");
            }
        }
        public Page DeckListPage
        {
            get { return deckListPage; }
            set
            {
                deckListPage = value;
                OnPropertyChanged("DeckListPage");
            }
        }
        #endregion

        #region Commands
        private RelayCommand addDeck;
        private RelayCommand setAppPage;
        private RelayCommand removeAppPage;
        private RelayCommand setDeckListPage;        
        private RelayCommand closeApp;
       
        public RelayCommand AddDeck
        {
            get
            {
                return addDeck ?? new RelayCommand(
                        obj =>
                        {
                            AppPage = new AddDeckPage(this);
                        }
                    );
            }
        }
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
        public RelayCommand SetDeckListPage
        {
            get
            {
                return setDeckListPage ?? new RelayCommand(
                        obj =>
                        {
                            DeckListPage = new View.DeckListPage(this);
                        }
                    );
            }
        }
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


        public string Title
        {
            get { return "Main Panel"; }
        }
        
        public MainWindowViewModel()
        {
            AppPage = new LogInPage(this);
            DeckListPage = new View.DeckListPage(this);
        }


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
            get
            {
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
    }
}

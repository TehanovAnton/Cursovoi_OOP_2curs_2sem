using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using KursovoiProectCSharp.View;
using KursovoiProectCSharp.Model;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.ObjectModel;

namespace KursovoiProectCSharp
{
    public class MainWindowViewModel : NotifyPropertyChanged
    { 
        public static Window appWin { get; set; }
        public User user { get; set; }


        public string Title
        {
            get { return "Main Panel"; }
        }


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
        public RelayCommand AddDeck
        {
            get
            {
                return addDeck ?? new RelayCommand(
                        obj =>
                        {
                            (new NewDeck(user)).ShowDialog();
                        }
                    );
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


        private RelayCommand setDeckListPage;
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


        public MainWindowViewModel()
        {
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

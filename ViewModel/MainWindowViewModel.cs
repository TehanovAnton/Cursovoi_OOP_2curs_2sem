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
        public static MainWindow appWin { get; set; }
        public User user { get; set; }


        #region Pages        

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

        private Page mainPanelPage;
        public Page MainPanelPage
        {
            get
            {
                return mainPanelPage;
            }
            set
            {
                mainPanelPage = value;
                OnPropertyChanged("MainPanelPage");
            }
        }
        #endregion


        #region Commands
        public RelayCommand AddDeck
        {
            get
            {
                return new RelayCommand(
                        obj =>
                        {
                            AppPage = new NewDeck(user, this);
                        }
                    );
            }
        }             
        public RelayCommand RemoveAppPage
        {
            get
            {
                return new RelayCommand(
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
                return new RelayCommand(
                        obj =>
                        {
                            DeckListPage = new View.DeckListPage(this);
                        }
                    );
            }
        }
        #endregion


        public MainWindowViewModel()
        {
            DeckListPage = new DeckListPage(this);
            MainPanelPage = new MainPanelPage(this);
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
        #endregion
    }
}

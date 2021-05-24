using KursovoiProectCSharp.Model;
using KursovoiProectCSharp.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace KursovoiProectCSharp.ViewModel
{
    public class BrowseDeckViewModel : NotifyPropertyChanged
    {
        public MainWindowViewModel mainWinVM { get; set; }
        private TextBox TextBox { get; set; }


        private Page items;
        public Page Items
        {
            get { return items; }
            set
            {
                items = value;
                OnPropertyChanged("Items");
            }
        }


        private ObservableCollection<Deck> decks;
        public ObservableCollection<Deck> Decks
        {
            get { return decks; }
            set
            {
                decks = value;
                OnPropertyChanged("Dekcs");
            }
        }


        private Deck selectedDeck;
        public Deck SelectedDeck
        {
            get { return selectedDeck; }
            set
            {
                selectedDeck = value;
                OnPropertyChanged("SelectedDeck");
            }
        }



        private ObservableCollection<Card> cards;
        public ObservableCollection<Card> Cards
        {
            get { return cards; }
            set
            {
                cards = value;
                OnPropertyChanged("Cards");
            }
        }


        private Card selectedCard;
        public Card SelectedCard
        {
            get { return selectedCard; }
            set
            {
                selectedCard = value;
                OnPropertyChanged("SelectedCard");
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
        public RelayCommand Find
        {
            get
            {
                return new RelayCommand(
                        obj =>
                        {
                            if (!String.IsNullOrEmpty(TextBox.Text))
                            {
                                var ds = DB.FindDeck_SimilarTitle(TextBox.Text, mainWinVM.user.Id);
                                Decks.Clear();
                                Items = new BroseList(this);
                                foreach (Deck d in ds)
                                    Decks.Add(d);
                            }
                        }
                    );
            }
        }
        public RelayCommand SetBrowseCards
        {
            get
            {
                return new RelayCommand(
                        obj =>
                        {
                            if (SelectedDeck != null)
                            {
                                var cs = DB.getCards(SelectedDeck);
                                Cards.Clear();
                                foreach (Card c in cs)
                                    Cards.Add(c);

                                Items = new BrowseCards(this);
                            }
                        }
                    );
            }
        }
        public RelayCommand KeyEventCommands
        {
            get
            {
                return new RelayCommand(
                        obj =>
                        {
                            object[] args = obj as object[];
                            KeyEventArgs e = args[1] as KeyEventArgs;

                            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control)
                            {
                                //EditCard
                                if (e.Key == Key.E)
                                {
                                    Items = new EditCardPage(SelectedCard, this);
                                }
                            }
                        }
                    );
            }
        }


        public BrowseDeckViewModel(MainWindowViewModel mainWinVM, TextBox textBox)
        {
            Decks = new ObservableCollection<Deck>();
            Cards = new ObservableCollection<Card>();
            Items = new BroseList(this);
            this.mainWinVM = mainWinVM;
            this.TextBox = textBox;
        }

        public BitmapImage RollUpIcon
        {
            get
            {
                return MainWindowViewModel.ImageBMP(@"C:\Users\Anton\source\repos\pacei_NV_OOTP\Курсовой ООП 2курс-2семестр\KursovoiProectCSharp\Images\RollUpMenu.png");
            }
        }
    }
}
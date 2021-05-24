using KursovoiProectCSharp.Model;
using KursovoiProectCSharp.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace KursovoiProectCSharp.ViewModel
{
    public class EditDeckPageViewModel : NotifyPropertyChanged
    {
        private MainWindowViewModel mainWinVM;

        private string oldTitle;

        private Deck deck;
        public string DeckTitle
        {
            get
            {
                return deck.Title;
            }
            set
            {
                deck.Title = value;
                OnPropertyChanged("DeckTitle");
            }
        }

        public RelayCommand CloseEditDeckPage
        {
            get
            {
                return new RelayCommand(
                        obj =>
                        {
                            deck.Title = oldTitle;
                            mainWinVM.DeckListPage = new DeckListPage(mainWinVM);
                        }
                    );
            }
        }
        public RelayCommand EditDeck
        {
            get
            {
                return new RelayCommand(
                        obj =>
                        {
                            DB.context.SaveChanges();
                            mainWinVM.DeckListPage = new DeckListPage(mainWinVM);
                        }
                    );
            }
        }

        public EditDeckPageViewModel(MainWindowViewModel mainWindowVM, Deck deck)
        {
            this.mainWinVM = mainWindowVM;
            this.deck = deck;
            oldTitle = deck.Title;
        }
    }
}

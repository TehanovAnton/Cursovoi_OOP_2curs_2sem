using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace KursovoiProectCSharp.View
{
    public class DeckListViewModel : NotifyPropertyChanged
    {
        private MainWindowViewModel mainWinVM;
        private Model.DeckListModel decks;
        public Model.DeckListModel Decks
        {
            get { return decks; }
            set
            {
                decks = value;
            }
        }


        private Model.Deck selectedDeck;
        public Model.Deck SelectedDeck
        {
            get { return selectedDeck; }
            set
            {
                selectedDeck = value;
                OnPropertyChanged("selectedDeck");
            }
        }


        private RelayCommand goCardTraining;

        public RelayCommand GoCardTraining
        {
            get {
                return goCardTraining ?? new RelayCommand(
                  obj =>
                  {
                      mainWinVM.AppPage = new View.TrainingCardPage();
                  }
              );
            }
        }

        public DeckListViewModel(MainWindowViewModel mainWinVM)
        {
            Decks = Model.DeckListModel.GetInstance();
            this.mainWinVM = mainWinVM;
        }
    }
}

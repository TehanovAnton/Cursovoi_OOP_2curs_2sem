using System;
using System.Collections.Generic;
using System.Text;

namespace KursovoiProectCSharp.View
{
    public class DeckListViewModel : NotifyPropertyChanged
    {
        public Model.DeckListModel decks { get; set; }

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

        public DeckListViewModel()
        {
            decks = Model.DeckListModel.GetInstance();
        }
    }
}

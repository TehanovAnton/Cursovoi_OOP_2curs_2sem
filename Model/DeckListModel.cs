using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace KursovoiProectCSharp.Model
{
    public class DeckListModel : NotifyPropertyChanged
    {
        #region SingleTon
        private static readonly Lazy<DeckListModel> instance = new Lazy<DeckListModel>(() => new DeckListModel());       

        public static DeckListModel GetInstance()
        {
            return instance.Value;
        }
        #endregion

        private ObservableCollection<Deck> deckList;
        public ObservableCollection<Deck> DeckList
        {
            get { return deckList; }
            set
            {
                deckList = value;
                OnPropertyChanged("DeckList");
            }
        }

        private DeckListModel()
        {
        }
    }
}

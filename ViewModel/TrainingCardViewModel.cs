using System;
using System.Collections.Generic;
using System.Text;

namespace KursovoiProectCSharp.ViewModel
{
    public class TrainingCardViewModel : NotifyPropertyChanged
    {
        private enum Remembered
        {
            Bad, Normal, Exelent
        }

        private MainWindowViewModel mainWinVM;
        private int card; //класс Card ещё не спроектирован
        private Model.Deck deck;

        public int Card
        {
            get { return card; }
            set
            {
                card = value;
                OnPropertyChanged("Card");
            }
        }
        public string CardTxt
        {
            get { return Card.ToString(); }
        }
        public int CardIndex { get; set; }
        public Model.Deck Deck
        {
            get { return deck; }
            set
            {
                deck = value;
                OnPropertyChanged("Deck");
            }
        }


        private RelayCommand badRemembered;
        private RelayCommand normalRemembered;
        private RelayCommand exelentRemembered;

        public RelayCommand BadRemembered
        {
            get {
                return badRemembered ?? new RelayCommand(
                  obj =>
                  {
                      ProcessingRememveringResult(Remembered.Bad);
                  }
              );
            }
        }
        public RelayCommand NormalRemembered
        {
            get
            {
                return normalRemembered ?? new RelayCommand(
                  obj =>
                  {
                      ProcessingRememveringResult(Remembered.Normal);
                  }
              );
            }
        }
        public RelayCommand ExelentRemembered
        {
            get
            {
                return exelentRemembered ?? new RelayCommand(
                  obj =>
                  {
                      ProcessingRememveringResult(Remembered.Exelent);
                  }
              );
            }
        }

        public TrainingCardViewModel(Model.Deck deck, MainWindowViewModel mainWinVM)
        {
            Deck = deck;
            CardIndex = 0;
            Card = deck[CardIndex];
            this.mainWinVM = mainWinVM;
        }

        private void ProcessingRememveringResult(Remembered remembered)
        {
            // логика для интервалов от remembered
            Card = Deck[CardIndex++]; // после завершения, страница должна перейти в меню
        }
    }
}

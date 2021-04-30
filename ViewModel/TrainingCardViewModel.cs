using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace KursovoiProectCSharp.ViewModel
{
    public class TrainingCardViewModel : NotifyPropertyChanged
    {
        private enum Remembered
        {
            Bad, Normal, Exelent, Terminate
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


        private RelayCommand endTraining;
        private RelayCommand badRemembered;
        private RelayCommand normalRemembered;
        private RelayCommand exelentRemembered;


        public RelayCommand EndTraining
        {
            get
            {
                return endTraining ?? new RelayCommand(
                  obj =>
                  {
                      ProcessingRememberingResult();
                  }
              );
            }
        }
        public RelayCommand BadRemembered
        {
            get {
                return badRemembered ?? new RelayCommand(
                  obj =>
                  {
                      ProcessingRememberingResult(Remembered.Bad);
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
                      ProcessingRememberingResult(Remembered.Normal);
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
                      ProcessingRememberingResult(Remembered.Exelent);
                  }
              );
            }
        }

        public TrainingCardViewModel(Model.Deck deck, MainWindowViewModel mainWinVM)
        {
            Deck = deck;
            CardIndex = 0;
            //Card = deck[CardIndex];
            this.mainWinVM = mainWinVM;
        }

        private void ProcessingRememberingResult(Remembered remembered = Remembered.Terminate, bool froceTerminate = true)
        {
            // логика для интервалов от remembered
            //if (froceTerminate)
            //{
            //    mainWinVM.AppPage = null;
            //    return;
            //}
            //else if (Deck.hasNext(CardIndex + 1))
            //    Card = Deck[++CardIndex];
            //else
            //    mainWinVM.AppPage = null;

        }
    }
}

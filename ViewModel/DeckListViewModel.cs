using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Input;
using KursovoiProectCSharp.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace KursovoiProectCSharp.View
{
    public class DeckListViewModel : NotifyPropertyChanged
    {
        private MainWindowViewModel mainWinVM;
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


        private RelayCommand refresh;
        public RelayCommand Refresh
        {
            get
            {
                return refresh ?? new RelayCommand(
                  obj =>
                  {                      
                      Decks.Clear();
                      foreach (var d in DB.getDecks(mainWinVM.user.Id))
                          Decks.Add(d);
                  }
              );
            }
        }


        private RelayCommand goCardTraining;
        public RelayCommand GoCardTraining
        {
            get
            {
                return goCardTraining ?? new RelayCommand(
                  obj =>
                  {
                      mainWinVM.AppPage = new TrainingCardPage(SelectedDeck, mainWinVM);
                  }
              );
            }
        }


        private RelayCommand keyEventCommands;
        public RelayCommand KeyEventCommands
        {
            get
            {
                return keyEventCommands ?? new RelayCommand(
                        obj =>
                        {
                            KeyEventArgs e = obj as KeyEventArgs;
                            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control)
                                //DeleteDeck
                                if (e.Key == Key.Delete)
                                {
                                    DB.removeDeck(SelectedDeck);
                                }
                                //AddCard
                                else if (e.Key == Key.A)
                                {
                                    mainWinVM.AppPage = new AddCardPage(SelectedDeck, mainWinVM);
                                }
                        }
                    );
            }
        }

        public DeckListViewModel(MainWindowViewModel mainWinVM)
        {
            Decks = new ObservableCollection<Deck>();
            this.mainWinVM = mainWinVM;
        }
    }
}

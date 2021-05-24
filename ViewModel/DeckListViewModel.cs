using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
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


        public RelayCommand Refresh
        {
            get
            {
                return new RelayCommand(
                  obj =>
                  {                      
                      Decks.Clear();
                      foreach (var d in DB.getDecks(mainWinVM.user.Id))
                          Decks.Add(d);
                  }
              );
            }
        }
        public RelayCommand GoCardTraining
        {
            get
            {
                return new RelayCommand(
                  obj =>
                  {
                      if (DB.getTrainCard(SelectedDeck.Id) != null)
                        mainWinVM.AppPage = new TrainingCardPage(SelectedDeck, mainWinVM);
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
                                //TrainingCards
                                else if (e.Key == Key.T)
                                {
                                    GoCardTraining.Execute("");
                                }
                                else if (e.Key == Key.D)
                                {
                                    //delete deck
                                    DB.removeDeck(SelectedDeck);
                                }
                                else if (e.Key == Key.E)
                                {
                                    //edit deeck
                                    mainWinVM.DeckListPage = new EditDeckPage(mainWinVM, SelectedDeck);
                                }
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

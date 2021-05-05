using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
                      //var d = DB.context.Decks.Where(p => p.UserId == mainWinVM.user.Id);
                      SqlParameter param = new SqlParameter($"@userId", mainWinVM.user.Id);
                      var d = DB.context.Decks.FromSqlRaw($"getUsersDeck @userId", param).ToList();

                      Decks.Clear();
                      foreach (var deck in d)
                          Decks.Add(deck);
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


        private RelayCommand deleteDeck;
        public RelayCommand DeleteDeck
        {
            get { return deleteDeck ?? new RelayCommand(
                    obj =>
                    {
                        DB.context.Decks.Remove(SelectedDeck);
                        DB.context.SaveChanges();
                    }
                );}
        }

        public DeckListViewModel(MainWindowViewModel mainWinVM)
        {
            decks = new ObservableCollection<Deck>();

            Decks.Add(new Deck() { Title = "someDeck1"});
            this.mainWinVM = mainWinVM;
        }        
    }
}

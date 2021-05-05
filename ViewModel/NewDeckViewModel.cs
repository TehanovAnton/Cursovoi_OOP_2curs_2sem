using System;
using System.Collections.Generic;
using System.Text;
using KursovoiProectCSharp.Model;
using KursovoiProectCSharp.View;

namespace KursovoiProectCSharp.ViewModel
{
    public class NewDeckViewModel
    {
        private NewDeck Win { get; set; }
        private User _User { get; set; }
        public string _Title { get; set; }


        private RelayCommand addDeck;
        public RelayCommand AddDeck
        {
            get { return addDeck ?? new RelayCommand(
                    obj =>
                    {
                        var deck = new Deck
                        {
                            Title = _Title,
                            User = _User
                        };
                        DB.context.Decks.Add(deck);
                        DB.context.SaveChanges();
                        Win.DialogResult = true;
                    }
                ); 
            }
        }


        public NewDeckViewModel(User user, NewDeck thisWin)
        {
            Win = thisWin;
            _User = user;
        }
    }
}

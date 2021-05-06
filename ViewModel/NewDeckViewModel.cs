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
                        if (!DB.IsDeck(_Title, _User.Password, _User.NickName))
                        {
                            DB.addDeck(new Deck
                            {
                                Title = _Title,
                                UserId = _User.Id
                            });                            
                            Win.DialogResult = true;
                        }
                        else
                        {
                            _Title = "this deck already exists";
                        }
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

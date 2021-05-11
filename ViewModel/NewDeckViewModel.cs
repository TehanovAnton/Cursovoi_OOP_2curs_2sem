using System;
using System.Collections.Generic;
using System.Text;
using KursovoiProectCSharp.Model;
using KursovoiProectCSharp.View;

namespace KursovoiProectCSharp.ViewModel
{
    public class NewDeckViewModel
    {
        public MainWindowViewModel MainWindowVM { get; set; }
        private User _User { get; set; }
        public string _Title { get; set; }


        public RelayCommand AddDeck
        {
            get { return new RelayCommand(
                    obj =>
                    {
                        if (!DB.IsDeck(_Title, _User.Password, _User.NickName))
                        {
                            DB.addDeck(new Deck
                            {
                                Title = _Title,
                                UserId = _User.Id
                            });

                            MainWindowVM.AppPage = null;
                        }
                        else
                        {
                            _Title = "this deck already exists";
                        }
                    }
                ); 
            }
        }
        public RelayCommand CloseMenu
        {
            get
            {
                return new RelayCommand(
                    obj =>
                    {
                        MainWindowVM.AppPage = null;
                    }
                );
            }
        }


        public NewDeckViewModel(User user, MainWindowViewModel MainWindowVM)
        {
            this.MainWindowVM = MainWindowVM;
            _User = user;
        }
    }
}

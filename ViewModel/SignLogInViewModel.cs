using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using KursovoiProectCSharp.Model;
using KursovoiProectCSharp.View;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace KursovoiProectCSharp.ViewModel
{
    public class SignLogInViewModel : NotifyPropertyChanged
    {
        public SignLogInWindow SignLogInWin { get; set; }

        private string messageLabel;
        public string MessageLabel
        {
            get
            {
                return messageLabel;
            }
            set
            {
                messageLabel = value;
                OnPropertyChanged("MessageLabel");
            }
        }


        private MainWindowViewModel mainWindowVM;
        public MainWindowViewModel MainWindowVM
        {
            get { return mainWindowVM; }
            set
            {
                mainWindowVM = value;
            }
        }


        Page logSignInPage;
        public Page LogSignInPage
        {
            get { return logSignInPage; }
            set
            {
                logSignInPage = value;
                OnPropertyChanged("LogSignInPage");
            }
        }


        private string password;
        public string _Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }


        private string nickName;
        public string _NickName
        {
            get { return nickName; }
            set
            {
                nickName = value;
                OnPropertyChanged("NickName");
            }
        }


        private RelayCommand logInUser;
        public RelayCommand LogInUser
        {
            get
            {
                return logInUser ?? new RelayCommand(
                        obj =>
                        {
                            User user = new User
                            {
                                Password = _Password,
                                NickName = _NickName
                            };

                            // здесь нужна проверка наличия пользователя
                            if (DB.IsUser(_Password, _NickName))
                            {
                                //добавить testDeck если её нет
                                if (!DB.IsDeck("TestDeck", _Password, _NickName))
                                {
                                    var ui = DB.context.Users.Where(u => u.Password == _Password && u.NickName == _NickName).Select(u => u.Id).ToList();
                                    Deck deck = new Deck { Title = "TestDeck", UserId = ui[0] };
                                    DB.context.Decks.Add(deck);
                                    DB.context.SaveChanges();
                                }                                

                                MainWindowVM.user = user;
                                MainWindow mainwin = new MainWindow { DataContext = MainWindowVM };

                                SignLogInWin.Hide();
                                mainwin.ShowDialog();

                                SignLogInWin.Close();
                            }
                            else
                            {
                                MessageLabel = "This user doesnt exist";
                            }
                        }
                    );
            }
        }


        private RelayCommand register;
        public RelayCommand Register
        {
            get
            {
                return register ?? new RelayCommand(
                        obj =>
                        {
                            LogSignInPage = new RegisterPage(mainWindowVM, SignLogInWin);
                        }
                    );
            }
        }

        public SignLogInViewModel(SignLogInWindow SignLogInWin)
        {
            this.MainWindowVM = new MainWindowViewModel();
            MessageLabel = "Welcome";
            this.SignLogInWin = SignLogInWin;
        }
    }
}

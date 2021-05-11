using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using KursovoiProectCSharp.Model;
using KursovoiProectCSharp.View;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace KursovoiProectCSharp.ViewModel
{
    public class SignLogInViewModel : NotifyPropertyChanged
    {
        public static SignLogInWindow SignLogInWin { get; set; }       
        public MainWindowViewModel MainWindowVM { get; set; }

        #region Page
        private Page logSignInPage;
        public Page LogSignInPage
        {
            get { return logSignInPage; }
            set
            {
                logSignInPage = value;
                OnPropertyChanged("LogSignInPage");
            }
        }
        #endregion

        #region Fields
        private ObservableCollection<User> users;
        public ObservableCollection<User> Users
        {
            get { return users; }
            set
            {
                users = value;
                OnPropertyChanged("Users");
            }
        }


        private User selectedUser;
        public User SelectedUser
        {
            get { return selectedUser; }
            set
            {
                selectedUser = value;
                OnPropertyChanged("SelectedUser");
            }
        }


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


        private bool savePassword;
        public bool SavePassword
        {
            get
            {
                return savePassword;
            }
            set
            {
                savePassword = value;
                OnPropertyChanged("SavePassword");
            }
        }


        private string password;
        public string _Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("_Password");
            }
        }


        private string nickName;
        public string _NickName
        {
            get { return nickName; }
            set
            {
                nickName = value;
                OnPropertyChanged("_NickName");
            }
        }
        #endregion

        #region Command
        public RelayCommand LogInUser
        {
            get
            {
                return new RelayCommand(
                        obj =>
                        {
                            // здесь нужна проверка наличия пользователя
                            if (DB.IsUser(_Password, _NickName))
                            {
                                //добавить testDeck если её нет
                                if (!DB.IsDeck("TestDeck", _Password, _NickName))
                                {
                                    DB.addDeck(new Deck
                                    {
                                        Title = "TestDeck",
                                        UserId = DB.getUserId(_Password, _NickName)
                                    });
                                }

                                //информация для входа будет сохранена в зависимости от SavePassword
                                DB.saveLog(SavePassword, DB.getUser(_Password, _NickName));

                                var i = DB.getUser(_Password, _NickName);

                                MainWindowVM.user = DB.getUser(_Password, _NickName);
                                MainWindow mainwin = new MainWindow { DataContext = MainWindowVM };

                                SignLogInWin.Close();
                                mainwin.ShowDialog();
                            }
                            else
                            {
                                MessageLabel = "This user doesnt exist";
                            }
                        }
                    );
            }
        }
        public RelayCommand Register
        {
            get
            {
                return new RelayCommand(
                        obj =>
                        {
                            LogSignInPage = new RegisterPage(MainWindowVM);
                        }
                    );
            }
        }
        public RelayCommand Refresh
        {
            get
            {
                return new RelayCommand(
                  obj =>
                  {
                      Users.Clear();

                      var savedList = DB.getSavedUsers();
                      foreach (var d in savedList)
                          Users.Add(d);
                  }
              );
            }
        }
        public RelayCommand SetSavedLog
        {
            get
            {
                return new RelayCommand(
                        obj =>
                        {
                            if (SelectedUser != null)
                            {
                                _Password = SelectedUser.Password;
                                _NickName = SelectedUser.NickName;
                            }
                        }
                    );
            }
        }
        #endregion

        public SignLogInViewModel(SignLogInWindow SignLogInWin)
        {
            this.MainWindowVM = new MainWindowViewModel();
            SignLogInViewModel.SignLogInWin = SignLogInWin;
            Users = new ObservableCollection<User>();

            MessageLabel = "Welcome";
            _Password = "1";
            _NickName = "a";
        }
    }
}
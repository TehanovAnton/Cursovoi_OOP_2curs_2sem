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


        private MainWindowViewModel mainWindowVM;
        public MainWindowViewModel MainWindowVM
        {
            get { return mainWindowVM; }
            set
            {
                mainWindowVM = value;
            }
        }


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


        private Page savedListPage;
        public Page SavedListPage
        {
            get
            {
                return savedListPage;
            }
            set
            {
                savedListPage = value;
                OnPropertyChanged("SavedListPage");
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
            this.SignLogInWin = SignLogInWin;
            this.SavedListPage = new SavedLogPage();

            MessageLabel = "Welcome";
            _Password = "1";
            _NickName = "a";
        }
    }
}

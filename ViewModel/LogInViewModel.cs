using System;
using System.Collections.Generic;
using System.Text;
using KursovoiProectCSharp.Model;
using KursovoiProectCSharp.View;

namespace KursovoiProectCSharp.ViewModel
{
    public class LogInViewModel : NotifyPropertyChanged
    {
        private MainWindowViewModel mainWindowVM;

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        private string nickName;
        public string NickName
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
                            using (ApplicationContext db = new ApplicationContext())
                            {
                                User user = new User(Password, NickName);
                                db.Users.Add(user);
                                db.SaveChanges();
                                mainWindowVM.AppPage = null;
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
                            User user = new User(Password, NickName);
                            mainWindowVM.AppPage = new RegisterPage(mainWindowVM, user);
                        }
                    );
            }
        }

        public LogInViewModel(MainWindowViewModel mainWindowVM)
        {
            this.mainWindowVM = mainWindowVM;
        }
    }
}

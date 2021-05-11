using KursovoiProectCSharp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace KursovoiProectCSharp.ViewModel
{
    public class SavedLogViewModel : NotifyPropertyChanged
    {
        private SignLogInViewModel SignLogInWinVM { get; set; }


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
                                SignLogInWinVM._Password = SelectedUser.Password;
                                SignLogInWinVM._NickName = SelectedUser.NickName;
                            }
                        }
                    );
            }
        }


        public SavedLogViewModel(SignLogInViewModel SignLogInWinVM)
        {
            Users = new ObservableCollection<User>();
            this.SignLogInWinVM = SignLogInWinVM;
        }
    }
}

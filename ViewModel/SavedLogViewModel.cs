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

        //public RelayCommand KeyEventCommands
        //{
        //    get
        //    {
        //        return new RelayCommand(
        //                obj =>
        //                {
        //                    object[] args = obj as object[];
        //                    KeyEventArgs e = args[1] as KeyEventArgs;

        //                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Control)
        //                    {
        //                        //Remove user SaveList
        //                        if (e.Key == Key.Delete)
        //                        {
        //                            DB.removeFromSavedList(SelectedUser.Id);
        //                        }
        //                    }
        //                }
        //            );
        //    }
        //}


        public SavedLogViewModel()
        {
            Users = new ObservableCollection<User>();
        }
    }
}

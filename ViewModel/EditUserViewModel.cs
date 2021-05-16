using KursovoiProectCSharp.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;

namespace KursovoiProectCSharp.ViewModel
{
    public class EditUserViewModel : NotifyPropertyChanged
    {
        private MainWindowViewModel MainWindowVM { get; set; }


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


        private string fio;
        public string _Fio
        {
            get { return fio; }
            set
            {
                fio = value;
                OnPropertyChanged("_Fio");
            }
        }


        private string mail;
        public string _Mail
        {
            get { return mail; }
            set
            {
                mail = value;
                OnPropertyChanged("_Mail");
            }
        }


        private DateTime birthDay;
        public DateTime _BirthDay
        {
            get { return birthDay; }
            set
            {
                birthDay = value;
                OnPropertyChanged("_BirthDay");
            }
        }


        private BitmapImage image;
        public BitmapImage _Image
        {
            get { return image; }
            set
            {
                image = value;
                OnPropertyChanged("_Image");
            }
        }


        public RelayCommand Edit
        {
            get
            {
                return new RelayCommand(
                        obj =>
                        {
                            User user = new User
                            {
                                Password = _Password,
                                NickName = _NickName
                            };

                            var img = _Image.UriSource == null ? DB.getUserInfo(MainWindowVM.user.Id).ImageBytes : RegisterViewModel.getImageBytes(_Image);
                            UserInfo userInfo = new UserInfo
                            {
                                Fio = _Fio,
                                Mail = _Mail,
                                BirthDate = _BirthDay,                                
                                ImageBytes = img
                            };
                            DB.changeUserInfo(MainWindowVM.user.Id, userInfo);
                            DB.changeUser(MainWindowVM.user.Id, user);

                            MainWindowVM.AppPage = null;
                        }
                    );
            }
        }
        public RelayCommand SetImage
        {
            get
            {
                return new RelayCommand(
                  obj =>
                  {
                      OpenFileDialog dialog = new OpenFileDialog();
                      if (dialog.ShowDialog() == true)
                      {
                          var imageBitMap = new BitmapImage();
                          imageBitMap.BeginInit();
                          imageBitMap.UriSource = new Uri(dialog.FileName);
                          imageBitMap.EndInit();
                          _Image = imageBitMap;
                      }
                  }
              );
            }
        }
        public RelayCommand Back
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


        public EditUserViewModel(MainWindowViewModel MainWindowVM)
        {
            this.MainWindowVM = MainWindowVM;

            var ui = DB.getUserInfo(MainWindowVM.user.Id);
            _Image = EditCardViewModel.ToImage(ui.ImageBytes);
            _Password = MainWindowVM.user.Password;
            _NickName = MainWindowVM.user.NickName;
            _Fio = ui.Fio;
            _Mail = ui.Mail;
            _BirthDay = ui.BirthDate;
        }
    }
}

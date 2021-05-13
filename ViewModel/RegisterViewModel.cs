using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Media.Imaging;
using KursovoiProectCSharp.Model;
using KursovoiProectCSharp.View;
using Microsoft.Win32;

namespace KursovoiProectCSharp.ViewModel
{
    public class RegisterViewModel : NotifyPropertyChanged
    {
        private MainWindowViewModel mainWinVM;


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


        public RelayCommand SetImage
        {
            get { return new RelayCommand(
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
                ); }
        }

        public RelayCommand Register
        {
            get
            {
                return new RelayCommand(
                        obj =>
                        {
                            // зарегать если такого пользователя нет
                            if (!DB.IsUser(_Password, _NickName))
                            {           
                                User user = new User
                                {
                                    Password = _Password,
                                    NickName = _NickName
                                };
                                UserInfo userInfo = new UserInfo
                                {
                                    Fio = _Fio,
                                    Mail = _Mail,
                                    BirthDate = _BirthDay,
                                    RegisterDate
                                    = DateTime.Now,
                                    ImageBytes = getImageBytes(_Image),
                                    User = user
                                };
                                DB.saveUserInfo(userInfo);

                                mainWinVM.user = user;
                                MainWindow mainWindow = new MainWindow { DataContext = mainWinVM };

                                SignLogInViewModel.SignLogInWin.Close();
                                mainWindow.ShowDialog();
                            }
                            else
                            {
                                _NickName = "user with such a nickname already exists";
                            }
                        }
                    );
            }
        }

        public RelayCommand BackToLogIn
        {
            get
            {
                return new RelayCommand(
                        obj =>
                        {
                            (SignLogInViewModel.SignLogInWin.DataContext as SignLogInViewModel).LogSignInPage = null;
                        }
                    );
            }
        }

        public RegisterViewModel(MainWindowViewModel mainWinVM)
        {
            _Image = MainWindowViewModel.ImageBMP(@"C:\Users\Anton\source\repos\pacei_NV_OOTP\лабораторные\решения\LabWork10_ado\images\Add.png");
            this.mainWinVM = mainWinVM;            

            _Password = "a";
            _NickName = "a";
            _Fio = "a";
            _Mail = ".com";
            _BirthDay = new DateTime(2002, 6, 6);
        }
        public RegisterViewModel(User _user)
        {
            this.mainWinVM = new MainWindowViewModel { user = _user };

            _Password = _user.Password;
            _NickName = _user.NickName;

            var info = DB.getUserInfo(_user.Id);
            _Fio = info.Fio;
            _Mail = info.Mail;
            _BirthDay = info.BirthDate;
        }

        public static byte[] getImageBytes(BitmapImage image)
        {
            Uri uri = image.UriSource;
            return File.ReadAllBytes(uri.OriginalString);
        }
    }
}

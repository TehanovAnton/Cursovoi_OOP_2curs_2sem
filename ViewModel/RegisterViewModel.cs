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
        private SignLogInWindow SignLogInWin { get; set; }
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

                                MainWindow mainWindow = new MainWindow();
                                mainWindow.ShowDialog();

                                SignLogInWin.Close();
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
                            (SignLogInWin.DataContext as SignLogInViewModel).LogSignInPage = null;
                        }
                    );
            }
        }

        public RegisterViewModel(MainWindowViewModel mainWinVM, SignLogInWindow SignLogInWin)
        {
            _Image = MainWindowViewModel.ImageBMP(@"C:\Users\Anton\source\repos\pacei_NV_OOTP\лабораторные\решения\LabWork10_ado\images\Add.png");
            this.mainWinVM = mainWinVM;
            this.SignLogInWin = SignLogInWin;

            _Password = "a";
            _NickName = "a";
            _Fio = "a";
            _Mail = ".com";
            _BirthDay = new DateTime(2002, 6, 6);
        }

        private static byte[] getImageBytes(BitmapImage image)
        {
            Uri uri = (image as BitmapImage).UriSource;
            return File.ReadAllBytes(uri.OriginalString);
        }
    }
}

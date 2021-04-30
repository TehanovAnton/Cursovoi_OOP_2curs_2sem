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
    public class RegisterViewModel
    {       
        private RegisterPage registerPage {get; set;}
        private User user { get; set; }
        private MainWindowViewModel mainWinVM { get; set; }

        private RelayCommand setImage;
        public RelayCommand SetImage
        {
            get { return setImage ?? new RelayCommand(
                    obj =>
                    {
                        OpenFileDialog dialog = new OpenFileDialog();
                        if (dialog.ShowDialog() == true)
                        {
                            var imageBitMap = new BitmapImage();
                            imageBitMap.BeginInit();
                            imageBitMap.UriSource = new Uri(dialog.FileName);
                            imageBitMap.EndInit();
                            registerPage.imageInput.Source = imageBitMap;
                        }
                    }
                ); }
        }

        private RelayCommand register;
        public RelayCommand Register
        {
            get
            {
                return register ?? new RelayCommand(
                        obj =>
                        {
                            user.Password = registerPage.PasswordInput.Text;
                            user.NickName = registerPage.NickNameInput.Text;

                            Uri uri = (registerPage.imageInput.Source as BitmapImage).UriSource;
                            byte[] imageBytes = File.ReadAllBytes(uri.OriginalString);
                            UserInfo userInfo = new UserInfo
                            {
                                Fio = registerPage.FioInput.Text,
                                Mail = registerPage.MailInput.Text,
                                BirthDate = registerPage.birthdayInput.SelectedDate.Value,
                                RegisterDate = DateTime.Now,
                                ImageBytes = imageBytes,
                                User = user
                            };

                            using (ApplicationContext db = new ApplicationContext())
                            {    
                                db.UsersInfo.Add(userInfo);
                                db.SaveChanges();
                            }

                            mainWinVM.AppPage = null;
                        }
                    );
            }
        }

        public RegisterViewModel(MainWindowViewModel mainWinVM, RegisterPage registerPage, User user)
        {
            this.registerPage = registerPage;
            this.user = user;
            this.mainWinVM = mainWinVM;
        }
    }
}

using KursovoiProectCSharp.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace KursovoiProectCSharp.ViewModel
{
    public class MainPanelViewModel : NotifyPropertyChanged
    {
        public MainWindowViewModel mainWinVM { get; set; }


        private string nickName;
        public string NickName
        {
            get
            {
                return nickName;
            }
            set
            {
                nickName = value;
                OnPropertyChanged("NickName");
            }
        }

        private string mail;
        public string Mail
        {
            get
            {
                return mail;
            }
            set
            {
                mail = value;
                OnPropertyChanged("Mail");
            }
        }


        public RelayCommand SetMaenuPage
        {
            get
            {
                return new RelayCommand(
                        obj =>
                        {
                            mainWinVM.AppPage = new MenuPage(mainWinVM);
                        }
                    );
            }
        }
        public RelayCommand CloseApp
        {
            get
            {
                return new RelayCommand(
                        obj =>
                        {
                            MainWindowViewModel.appWin.Close();
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
                            NickName = mainWinVM.user.NickName;
                            Mail = DB.getUserInfo(mainWinVM.user.Id).Mail;
                        }
                    );
            }
        }


        public BitmapImage MenuIcon
        {
            get
            {
                return MainWindowViewModel.ImageBMP(@"C:\Users\Anton\source\repos\pacei_NV_OOTP\Курсовой ООП 2курс-2семестр\KursovoiProectCSharp\Images\MenuIcon.png");
            }
        }
        public BitmapImage CloseIcon
        {
            get
            {
                return MainWindowViewModel.ImageBMP(@"C:\Users\Anton\source\repos\pacei_NV_OOTP\Курсовой ООП 2курс-2семестр\KursovoiProectCSharp\Images\CloseIcon.png");
            }
        }




        public MainPanelViewModel(MainWindowViewModel mainWinVM)
        {
            this.mainWinVM = mainWinVM;            
        }
    }
}

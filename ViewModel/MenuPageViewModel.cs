using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;
using KursovoiProectCSharp.View;
using KursovoiProectCSharp.Model;

namespace KursovoiProectCSharp.ViewModel
{
    public class MenuPageViewModel : NotifyPropertyChanged
    {
        private MainWindowViewModel mainWinVM;
        public MemoryzationPresenter Presenter { get; set; }

        private bool changeIntervals;
        public bool ChangeIntervals
        {
            get
            {
                return changeIntervals;
            }
            set
            {
                changeIntervals = value;
                OnPropertyChanged("ChangeIntervals");
            }
        }


        public RelayCommand CloseMenu
        {
            get 
            {
                return new RelayCommand
                (
                    obj =>
                    {
                        mainWinVM.AppPage = null;
                    }
                );
            }
        }
        public RelayCommand SetBroseDeckPage
        {
            get
            {
                return new RelayCommand(
                obj =>
                {
                    mainWinVM.AppPage = new BroseDeckPage(mainWinVM);
                }
            );
            }
        }
        public RelayCommand SetEditUserPage
        {
            get
            {
                return new RelayCommand(
                        obj =>
                        {
                            mainWinVM.AppPage = new EditUserPage(mainWinVM);
                        }
                    );
            }
        }

        #region ImageBMP
        public BitmapImage RollUpIcon
        {
            get
            {
                return MainWindowViewModel.ImageBMP(@"C:\Users\Anton\source\repos\pacei_NV_OOTP\Курсовой ООП 2курс-2семестр\KursovoiProectCSharp\Images\RollUpMenu.png");
            }
        }

        public BitmapImage FindIcon
        {
            get
            {
                return MainWindowViewModel.ImageBMP(@"C:\Users\Anton\source\repos\pacei_NV_OOTP\Курсовой ООП 2курс-2семестр\KursovoiProectCSharp\Images\FindIcon.jpg");
            }
        }
        #endregion

        public MenuPageViewModel(MainWindowViewModel mainWinVM)
        {
            this.mainWinVM = mainWinVM;
            this.Presenter = new MemoryzationPresenter();
            this.ChangeIntervals = false;
        }
    }
}

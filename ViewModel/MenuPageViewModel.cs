using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;

namespace KursovoiProectCSharp.ViewModel
{
    public class MenuPageViewModel : NotifyPropertyChanged
    {
        private MainWindowViewModel mainWinVM;



        private RelayCommand closeMenu;
        public RelayCommand CloseMenu
        {
            get { return closeMenu ?? new RelayCommand(
                  obj =>
                  {
                      mainWinVM.AppPage = null;
                  }
              );}
        }



        private RelayCommand setBroseDeckPage;
        public RelayCommand SetBroseDeckPage
        {
            get
            {
                return setBroseDeckPage ?? new RelayCommand(
                obj =>
                {
                    mainWinVM.AppPage = new BrowseDeckPage(mainWinVM);
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
        }
    }
}

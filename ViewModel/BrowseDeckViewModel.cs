using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;

namespace KursovoiProectCSharp.ViewModel
{
    public class BrowseDeckViewModel : NotifyPropertyChanged
    {
        public MainWindowViewModel mainWinVM { get; set; }


        private View.DeckListPage deckListPage;
        public View.DeckListPage DeckListPage
        {
            get { return deckListPage; }
            set
            {
                deckListPage = value;
                OnPropertyChanged("DeckListPage");
            }
        }


        public BitmapImage RollUpIcon
        {
            get
            {
                return MainWindowViewModel.ImageBMP(@"C:\Users\Anton\source\repos\pacei_NV_OOTP\Курсовой ООП 2курс-2семестр\KursovoiProectCSharp\Images\RollUpMenu.png");
            }
        }


        //private RelayCommand rollUp;
        //public RelayCommand RollUp
        //{
        //    get {
        //        return rollUp ?? new RelayCommand(
        //            obj =>
        //            {
        //                mainWinVM.AppPage = 
        //            }
        //      );
        //    }
        //}

        public BrowseDeckViewModel(MainWindowViewModel mainWinVM)
        {
            DeckListPage = new View.DeckListPage(mainWinVM);
            this.mainWinVM = mainWinVM;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace KursovoiProectCSharp.ViewModel
{
    public class AddDeckViewModel
    {
        private MainWindowViewModel mainWindowVM { get; set; }

        private RelayCommand addDeck;
        public RelayCommand AddDeck
        {
            get
            {
                return addDeck ?? new RelayCommand(
                        obj =>
                        {
                            mainWindowVM.AppPage = null;
                        }
                    );
            }
        }
        public AddDeckViewModel(MainWindowViewModel mainWindowVM)
        {
            this.mainWindowVM = mainWindowVM;
        }
    }
}

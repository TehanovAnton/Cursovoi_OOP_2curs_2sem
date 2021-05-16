using KursovoiProectCSharp.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KursovoiProectCSharp.View
{
    /// <summary>
    /// Логика взаимодействия для BrowseCards.xaml
    /// </summary>
    public partial class BrowseCards : Page
    {
        public BrowseCards(BrowseDeckViewModel browseDeckVM)
        {
            InitializeComponent();

            DataContext = browseDeckVM;
        }

        private void ListBox_KeyUp(object sender, KeyEventArgs e)
        {
            (this.DataContext as BrowseDeckViewModel).KeyEventCommands.Execute(new object[] { sender, e });
        }
    }
}

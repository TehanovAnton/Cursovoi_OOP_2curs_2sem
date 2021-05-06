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
    /// Логика взаимодействия для DeckListPage.xaml
    /// </summary>
    public partial class DeckListPage : Page
    {
        private void ListBox_KeyUp(object sender, KeyEventArgs e)
        {
            (this.DataContext as DeckListViewModel).KeyEventCommands.Execute(e);
        }

        public DeckListPage(MainWindowViewModel mainWinVM)
        {
            InitializeComponent();

            DataContext = new DeckListViewModel(mainWinVM);
        }
    }
}
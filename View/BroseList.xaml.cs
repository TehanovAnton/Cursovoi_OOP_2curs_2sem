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
using KursovoiProectCSharp.ViewModel;

namespace KursovoiProectCSharp.View
{
    /// <summary>
    /// Логика взаимодействия для BroseList.xaml
    /// </summary>
    public partial class BroseList : Page
    {
        public BroseList(BrowseDeckViewModel browseDeckVM)
        {
            InitializeComponent();

            DataContext = browseDeckVM;
        }
    }
}

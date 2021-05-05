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
using System.Windows.Shapes;
using KursovoiProectCSharp.ViewModel;
using KursovoiProectCSharp.Model;

namespace KursovoiProectCSharp.View
{
    /// <summary>
    /// Логика взаимодействия для NewDeck.xaml
    /// </summary>
    public partial class NewDeck : Window
    {
        public NewDeck(User user)
        {
            InitializeComponent();

            DataContext = new NewDeckViewModel(user, this);
        }
    }
}

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
    
namespace KursovoiProectCSharp
{
    /// <summary>
    /// Логика взаимодействия для SignLogInWindow.xaml
    /// </summary>
    public partial class SignLogInWindow : Window
    {
        public SignLogInWindow()
        {
            InitializeComponent();

            DataContext = new SignLogInViewModel(this);
        }
    }
}

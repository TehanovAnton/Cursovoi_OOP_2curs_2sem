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
using KursovoiProectCSharp.Model;
using KursovoiProectCSharp.ViewModel;

namespace KursovoiProectCSharp.View
{    
    public partial class RegisterPage : Page
    {
        public RegisterPage(MainWindowViewModel mainWinVM, SignLogInWindow logSignIn)
        {
            InitializeComponent();            

            DataContext = new RegisterViewModel(mainWinVM, logSignIn);
        }
    }
}

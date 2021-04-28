using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KursovoiProectCSharp
{   
    public partial class MainWindow : Window
    {
        static MainWindow()
        {
            MainWindow.ClickEvent = 
                EventManager.RegisterRoutedEvent(
                    "Click", RoutingStrategy.Bubble,
                    typeof(RoutedEventHandler), 
                    typeof(MainWindow));
        }
        public static readonly RoutedEvent ClickEvent;
        public event RoutedEventHandler Click
        {
            add
            {
                base.AddHandler(ClickEvent, value);
            }
            remove
            {
                base.RemoveHandler(ClickEvent, value);
            }
        }

        private void AddCard_Click(object sender, RoutedEventArgs e)
        {
            appPage.Content = new View.AddCardPage();
        }
        public MainWindow()
        {
            InitializeComponent();

            MainWindowViewModel.appWin = this;
            DataContext = new MainWindowViewModel();
        }
    }
}

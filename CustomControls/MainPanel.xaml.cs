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

namespace KursovoiProectCSharp.CustomControls
{
    /// <summary>
    /// Логика взаимодействия для MainPanel.xaml
    /// </summary>
    public partial class MainPanel : UserControl
    {
        static MainPanel()
        {
            FrameworkPropertyMetadata metadata = new FrameworkPropertyMetadata("Title_")
            {
                CoerceValueCallback = new CoerceValueCallback(CorrectValue)
            };
            TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(MainPanel), metadata,
                new ValidateValueCallback(ValidateValue));

            CloseIconProperty = DependencyProperty.Register("CloseIcon", typeof(BitmapImage), typeof(MainPanel));
        }



        public static readonly DependencyProperty TitleProperty;
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }



        public static readonly DependencyProperty CloseIconProperty;       
        public BitmapImage CloseIcon
        {
            get { return (BitmapImage)GetValue(CloseIconProperty); }
            set { SetValue(CloseIconProperty, value); }
        }

        private static bool ValidateValue(object value)
        {
            string currentValue = (string)value;
            if (currentValue != "")
                return true;
            return false;
        }

        private static object CorrectValue(DependencyObject d, object baseValue)
        {
            string currentValue = (string)baseValue;
            if (currentValue != "Title")
                return currentValue;
            return "Main Panel";
        }


        public MainPanel()
        {
            InitializeComponent();

            //DataContext = this;
        }
    }
}
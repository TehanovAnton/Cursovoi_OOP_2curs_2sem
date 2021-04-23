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
    /// Логика взаимодействия для AddCardPage.xaml
    /// </summary>
    public partial class AddCardPage : Page
    {
        static AddCardPage()
        {
            PropertyMetadata metadata = new PropertyMetadata()
            {
                DefaultValue = "_",
                CoerceValueCallback = new CoerceValueCallback(CorrectValue)
            };
            QuestionTextProperty = DependencyProperty.Register("QuestionText", typeof(string), typeof(AddCardPage),
                metadata, new ValidateValueCallback(ValidateQuestionText));
        }
        public static readonly DependencyProperty QuestionTextProperty;
        public string QuestionText
        {
            get { return (string)GetValue(QuestionTextProperty); }
            set { SetValue(QuestionTextProperty, value); }
        }

        private static bool ValidateQuestionText(object value)
        {
            string currentValue = (string)value;
            if (!String.IsNullOrEmpty(currentValue))
                return true;

            return false;
        }

        private static object CorrectValue(DependencyObject d, object baseValue)
        {
            string currentValue = (string)baseValue;
            if (currentValue == "")  // если больше 1000, возвращаем 1000
                return (string)QuestionTextProperty.DefaultMetadata.DefaultValue;
            return currentValue; // иначе возвращаем текущее значение
        }

        public AddCardPage()
        {
            InitializeComponent();

            DataContext = new ViewModel.AddCardViewModel();
        }
    }
}

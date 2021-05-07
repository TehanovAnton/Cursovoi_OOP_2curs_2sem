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
using KursovoiProectCSharp.Model;

namespace KursovoiProectCSharp.View
{
    /// <summary>
    /// Логика взаимодействия для ChangeDeckTitle.xaml
    /// </summary>
    public partial class ChangeDeckTitle : Window
    {
        private Deck deck;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            deck.Title = this.Title.Text;
            DB.context.SaveChanges();
            this.DialogResult = true;
        }

        public ChangeDeckTitle(Deck deck)
        {
            InitializeComponent();

            this.deck = deck;
        }
    }
}

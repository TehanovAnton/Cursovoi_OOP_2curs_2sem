﻿using System;
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
    /// Логика взаимодействия для TrainingCardPage.xaml
    /// </summary>
    public partial class TrainingCardPage : Page
    {
        public TrainingCardPage(Model.Deck deck, MainWindowViewModel mainWinVM)
        {
            InitializeComponent();

            DataContext = new ViewModel.TrainingCardViewModel(deck, mainWinVM);
        }
    }
}

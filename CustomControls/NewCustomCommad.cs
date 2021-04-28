using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace KursovoiProectCSharp.CustomControls
{
    public class NewCustomCommad
    {
        public static RoutedUICommand Exit { get; set; }

        static NewCustomCommad()
        {
            Exit = new RoutedUICommand
            (
                "Exit",
                "Exit",
                typeof(NewCustomCommad),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.F5, ModifierKeys.Alt)
                }
            );
        }
    }
}


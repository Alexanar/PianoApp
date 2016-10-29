using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Reflection;

namespace PianoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public NoteKeyboard keyboard;
        public delegate void KeyNoteEvent(string noteName);
        private KeyNoteEvent keyPressedEvent;


        public MainWindow()
        {
            InitializeComponent();
            keyboard = new NoteKeyboard(this);
        }

        //note played corresponds to button name value
        private void key_PlayNote(object sender, MouseButtonEventArgs e)
        {
            string noteName = ((Button)sender).Name;
            keyboard.PlayNote(noteName);
        }

        private void key_StopNote(object sender, MouseButtonEventArgs e)
        {
            string noteName = ((Button)sender).Name;
            keyboard.StopNote(noteName);
        }

        private void window_KeyDown(object sender, KeyEventArgs e)
        {
            KeyNoteEvent play = new KeyNoteEvent(keyboard.PlayNote);
            UserKeyEvent(e, Key.Z, "keyC1", play);
            UserKeyEvent(e, Key.X, "keyD1", play);
            UserKeyEvent(e, Key.C, "keyE1", play);
            UserKeyEvent(e, Key.V, "keyF1", play);
            UserKeyEvent(e, Key.B, "keyG1", play);
            UserKeyEvent(e, Key.N, "keyA1", play);
            UserKeyEvent(e, Key.M, "keyB1", play);
            UserKeyEvent(e, Key.OemComma, "keyC2", play);

            UserKeyEvent(e, Key.S, "keyDb1", play);
            UserKeyEvent(e, Key.D, "keyEb1", play);
            UserKeyEvent(e, Key.G, "keyGb1", play);
            UserKeyEvent(e, Key.H, "keyAb1", play);
            UserKeyEvent(e, Key.J, "keyBb1", play);
        }

        private void window_KeyUp(object sender, KeyEventArgs e)
        {
            KeyNoteEvent stop = new KeyNoteEvent(keyboard.StopNote);
            UserKeyEvent(e, Key.Z, "keyC1", stop);
            UserKeyEvent(e, Key.X, "keyD1", stop);
            UserKeyEvent(e, Key.C, "keyE1", stop);
            UserKeyEvent(e, Key.V, "keyF1", stop);
            UserKeyEvent(e, Key.B, "keyG1", stop);
            UserKeyEvent(e, Key.N, "keyA1", stop);
            UserKeyEvent(e, Key.M, "keyB1", stop);
            UserKeyEvent(e, Key.OemComma, "keyC2", stop);

            UserKeyEvent(e, Key.S, "keyDb1", stop);
            UserKeyEvent(e, Key.D, "keyEb1", stop);
            UserKeyEvent(e, Key.G, "keyGb1", stop);
            UserKeyEvent(e, Key.H, "keyAb1", stop);
            UserKeyEvent(e, Key.J, "keyBb1", stop);
        }

        private void UserKeyEvent(KeyEventArgs e, Key keyType, string noteName, KeyNoteEvent keyMethod)
        {
            if (e.Key == keyType)
            {
                keyPressedEvent = keyMethod;
                keyPressedEvent(noteName);
            }
        }
        






    }
}

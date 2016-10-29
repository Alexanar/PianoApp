using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Timers;
using System.Windows.Threading;
using System.ComponentModel;
using System.Windows.Controls;

namespace PianoApp
{
    public class NoteSound
    {

        private MediaPlayer noteSound = new MediaPlayer();
        public bool noteHeld { get; set; }
        public Button noteButton;
        public Brush defaultButtonColor;
        private DispatcherTimer noteLength;
        private bool minNoteLengthReached;
        private bool notePlaying;

        public NoteSound(string soundPath, Button _noteButton)
        {
            noteButton = _noteButton;
            defaultButtonColor = noteButton.Background;
            noteSound.Open(new Uri(@"D:\Users\Ara\Documents\Visual Studio 2015\Projects\PianoApp\PianoApp\Sounds\" + soundPath));
        }


        public void Play()
        {
            if (!notePlaying)
            {
                noteButton.Background = Brushes.Red;
                noteHeld = true;
                notePlaying = true;
                minNoteLengthReached = false;
                noteSound.Volume = 0.5f;
                noteSound.Play();
                NoteMinLengthTimer();
            }
        }

        public void Stop()
        {
            noteHeld = false;
            if (minNoteLengthReached)
            {
                FadeOut();
                if (noteSound.Volume <= 0)
                {
                    noteButton.Background = defaultButtonColor;
                    noteSound.Stop();
                    minNoteLengthReached = false;
                    notePlaying = false;
                }
            }

        }

        private void FadeOut()
        {
            while (noteSound.Volume > 0)
            {
                noteSound.Volume -= 0.00001f;
            }
        }

        private void NoteMinLengthTimer()
        {

            noteLength = new DispatcherTimer();
            noteLength.Tick += new EventHandler(TimerEvent);
            noteLength.Interval = new TimeSpan(0, 0, 0, 0, 75);
            noteLength.Start();
        }

        private void TimerEvent(object sender, EventArgs e)
        {
            minNoteLengthReached = true;
            noteLength.Stop();
            if (!noteHeld)
            {
                Stop();
            }
        }



    }
}

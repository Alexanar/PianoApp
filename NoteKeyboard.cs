using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace PianoApp
{
    public class NoteKeyboard
    {
        private string notePrefix = "piano_";
        private string noteSuffix = ".wav";
        public NoteSound noteC, noteD, noteE, noteF, noteG, noteA, noteB, noteC2;
        public NoteSound noteDb, noteEb, noteGb, noteAb, noteBb;
        public delegate void NoteEvent();
        private NoteEvent note;
        private MainWindow main;


        public NoteKeyboard(MainWindow _main)
        {
            main = _main;
            noteC = new NoteSound(NoteNameBuilder("c4"), main.keyC1);
            noteD = new NoteSound(NoteNameBuilder("d4"), main.keyD1);
            noteE = new NoteSound(NoteNameBuilder("e4"), main.keyE1);
            noteF = new NoteSound(NoteNameBuilder("f4"), main.keyF1);
            noteG = new NoteSound(NoteNameBuilder("g4"), main.keyG1);
            noteA = new NoteSound(NoteNameBuilder("a4"), main.keyA1);
            noteB = new NoteSound(NoteNameBuilder("b4"), main.keyB1);
            noteC2 = new NoteSound(NoteNameBuilder("c5"), main.keyC2);

            noteDb = new NoteSound(NoteNameBuilder("db4"), main.keyDb1);
            noteEb = new NoteSound(NoteNameBuilder("eb4"), main.keyEb1);
            noteGb = new NoteSound(NoteNameBuilder("gb4"), main.keyGb1);
            noteAb = new NoteSound(NoteNameBuilder("ab4"), main.keyAb1);
            noteBb = new NoteSound(NoteNameBuilder("bb4"), main.keyBb1);
        }

        private string NoteNameBuilder(string note)
        {
            string combinedName = notePrefix + note + noteSuffix;
            return combinedName;
        }

        public void PlayNote(string noteName)
        {
            EventOnSpecifiedNote(noteName, "keyC1", new NoteEvent(noteC.Play));
            EventOnSpecifiedNote(noteName, "keyD1", new NoteEvent(noteD.Play));
            EventOnSpecifiedNote(noteName, "keyE1", new NoteEvent(noteE.Play));
            EventOnSpecifiedNote(noteName, "keyF1", new NoteEvent(noteF.Play));
            EventOnSpecifiedNote(noteName, "keyG1", new NoteEvent(noteG.Play));
            EventOnSpecifiedNote(noteName, "keyA1", new NoteEvent(noteA.Play));
            EventOnSpecifiedNote(noteName, "keyB1", new NoteEvent(noteB.Play));
            EventOnSpecifiedNote(noteName, "keyC2", new NoteEvent(noteC2.Play));

            EventOnSpecifiedNote(noteName, "keyDb1", new NoteEvent(noteDb.Play));
            EventOnSpecifiedNote(noteName, "keyEb1", new NoteEvent(noteEb.Play));
            EventOnSpecifiedNote(noteName, "keyGb1", new NoteEvent(noteGb.Play));
            EventOnSpecifiedNote(noteName, "keyAb1", new NoteEvent(noteAb.Play));
            EventOnSpecifiedNote(noteName, "keyBb1", new NoteEvent(noteBb.Play));

        }

        public void StopNote(string noteName)
        {
            EventOnSpecifiedNote(noteName, "keyC1", new NoteEvent(noteC.Stop));
            EventOnSpecifiedNote(noteName, "keyD1", new NoteEvent(noteD.Stop));
            EventOnSpecifiedNote(noteName, "keyE1", new NoteEvent(noteE.Stop));
            EventOnSpecifiedNote(noteName, "keyF1", new NoteEvent(noteF.Stop));
            EventOnSpecifiedNote(noteName, "keyG1", new NoteEvent(noteG.Stop));
            EventOnSpecifiedNote(noteName, "keyA1", new NoteEvent(noteA.Stop));
            EventOnSpecifiedNote(noteName, "keyB1", new NoteEvent(noteB.Stop));
            EventOnSpecifiedNote(noteName, "keyC2", new NoteEvent(noteC2.Stop));

            EventOnSpecifiedNote(noteName, "keyDb1", new NoteEvent(noteDb.Stop));
            EventOnSpecifiedNote(noteName, "keyEb1", new NoteEvent(noteEb.Stop));
            EventOnSpecifiedNote(noteName, "keyGb1", new NoteEvent(noteGb.Stop));
            EventOnSpecifiedNote(noteName, "keyAb1", new NoteEvent(noteAb.Stop));
            EventOnSpecifiedNote(noteName, "keyBb1", new NoteEvent(noteBb.Stop));
        }

        private void EventOnSpecifiedNote(string pressedNoteName, string noteName, NoteEvent noteMethod)
        {
            if (pressedNoteName == noteName)
            {
                note = noteMethod;
                note();
            }
        }

    }
}

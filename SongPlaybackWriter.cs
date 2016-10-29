using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PianoApp
{
    class SongPlaybackWriter
    {
        public bool recording { get; set; }
        private StreamWriter songWriter;
        private string songString;

        public void WriteNote(string note, int noteLength)
        {
            songString += " " + note + noteLength;
        }

        public void WritePause(int pauseLength)
        {
            songString += " " + pauseLength;
        }

        public void SaveSong()
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFile.FilterIndex = 2;

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                songWriter = new StreamWriter(saveFile.OpenFile());
                songWriter.WriteLine(songString);
                songWriter.Close();
            }
        }



    }
}

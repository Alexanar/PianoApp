using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PianoApp
{
    class SongPlaybackReader
    {
        private StreamReader songReader;
        public bool playingSong { get; set; }
        private string songCharacter;

        public void OpenSong()
        {
            OpenFileDialog songFile = new OpenFileDialog();
            if (songFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    songReader = new StreamReader(songFile.OpenFile());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not Read File: " + ex.Message);
                }
            }
        }

        public void ReadSong()
        {
            try
            {
                while (!songReader.EndOfStream || playingSong)
                {
                    songCharacter = songReader.Read().ToString();
                    ReadSongNotes();
                }
            }
            catch
            {
                MessageBox.Show("Could not Read Song");
            }
        }

        public void ReadSongNotes()
        {
           
        }





    }
}

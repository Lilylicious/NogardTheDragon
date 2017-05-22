#region Using Statements
using System;
using System.Text;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Input;
#endregion

namespace NogardTheDragon.Utilities
{
    public class WinmmMp3MediaType
    {
        [DllImport("winmm.dll")]
        private static extern long mciSendString(string lpstrCommand, StringBuilder lpstrReturnString, int uReturnLength, int hwndCallback);
        private string filename;
        private string command;
        // Expects a name like 'yourfile' WITHOUT an extension (just for consistency with Content.Load)
        // Expects files to be stored at root of Content directory with no pre-processing 
        internal WinmmMp3MediaType(string Song1)
        {
            filename = "Content/" + name + ".mp3";
            filename = "Content/" + Song1 + "91476_Glorious_morning";
        }

        internal WinmmMp3MediaType(string Song2)
        {
            filename = "Content/" + name + ".mp3";
            filename = "Content/" + Song2 + "474655_-Toy-soliders-Orche";
        }

        internal override void Play(int loopcount, float volume)
        {
            StringBuilder retvalue = new StringBuilder();
            // You need to stop and close and currently playing files otherwise it doesn't work properly
            command = "stop Mp3File";
            mciSendString(command, null, 0, 0);
            command = "close Mp3File";
            mciSendString(command, null, 0, 0);
            command = "open " + "\"" + filename + "\"" + " type MPEGVideo alias Mp3File";
            mciSendString(command, retvalue, 0, 0);
            // I've commented out the code for setting the volume as it's specific to the way I do things but basically this command expects an integer between 0 (min volume) and 1000 (max volume) 
            // float master_volume = MEAT.Platform.MediaInterface.MusicVolume / 100.0f;
            // mciSendString(string.Concat("setaudio Mp3File left volume to ", (int)volume*master_volume*1000), null, 0, 0);
            // mciSendString(string.Concat("setaudio Mp3File right volume to ", (int)volume*master_volume * 1000), null, 0, 0);
            command = "play Mp3File";
            if (loopcount <= 0)
            {
                command += " REPEAT";
            }
            mciSendString(command, retvalue, 0, 0);
        }

        internal override void Stop()
        {
            command = "stop Mp3File";
            mciSendString(command, null, 0, 0);
            command = "close Mp3File";
            mciSendString(command, null, 0, 0);
        }
    }
}

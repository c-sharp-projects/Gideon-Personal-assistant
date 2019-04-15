using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gideon.Media
{
    class MediaPlayer
    {
        private SearchFiles SearchFilesObj;
        public int AudPos;
        public int VidPos;
        public string[] Audios;
        public string[] Videos;

        public MediaPlayer()
        {
            SearchFilesObj = new SearchFiles();
            AudPos = 0;
            VidPos = 0;            
            LoadAllSongs();
        }
        public void LoadFile()
        {
            SearchFilesObj.SearchInAllDrives("*.*");
            SearchFilesObj.LogAudioAndVideoInformation(MediaPath.AudioFile, MediaPath.VideoFile);
        }

        public void LoadAllSongs()
        {

            if ((!File.Exists(MediaPath.AudioFile)) && (!File.Exists(MediaPath.VideoFile)))
            {
                LoadFile();
            }

            Audios = File.ReadAllLines(MediaPath.AudioFile);
            Videos = File.ReadAllLines(MediaPath.VideoFile);
        }

        ~MediaPlayer()
        {
            SearchFilesObj = null;
            Audios = null;
            Videos = null;
        }
    }

    
}

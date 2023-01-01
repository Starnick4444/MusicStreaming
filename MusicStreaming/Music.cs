using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreamingServer
{
    internal class Music
    {
        private FileInfo localFile;

        public string title => Path.GetFileNameWithoutExtension(localFile.Name);

        public Music(FileInfo fileInfo)
        {
            this.localFile = fileInfo;
        }
    }
}

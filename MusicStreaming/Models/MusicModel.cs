using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MusicStreamingServer.Models;

//remake this, code will rename local songs with their id, make info files with same name (idk with what extension),
//it will contain the audio file's extension, description, title, length
[Serializable]
[XmlRoot("MusicDetails")]
internal class MusicModel
{
    //public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Extension { get; set; }
    [XmlIgnore]
    private TimeSpan timeSpan;
    public int Duration => Convert.ToInt32(timeSpan.TotalSeconds);

    public MusicModel(FileInfo fileInfo)
    {
        Title = System.IO.Path.GetFileNameWithoutExtension(fileInfo.Name);
        Description = string.Empty;
        Extension = fileInfo.Extension;
        //https://stackoverflow.com/questions/34517673/how-to-get-a-duration-of-mp3-file-via-net-c
        //Mp3FileReader reader = new Mp3FileReader("<YourMP3>.mp3");
        //this.timeSpan = reader.TotalTime;
    }

    public MusicModel(string title, string path, string description, string extension)
    {
        Title = title;
        Path = path;
        Description = description;
        Extension = extension;
    }
}

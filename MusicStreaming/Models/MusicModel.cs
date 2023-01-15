using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreamingServer.Models;

internal class MusicModel
{
    public string Title { get; set; }
    public string Path { get; set; }
    public string Description { get; set; }

    public string Extension { get; set; }

    //private FileInfo localFile; export to abstraction

    public MusicModel(FileInfo fileInfo)
    {
        Title = System.IO.Path.GetFileNameWithoutExtension(fileInfo.Name);
        Path = fileInfo.FullName;
        Description = string.Empty;
        Extension = fileInfo.Extension;
    }

    public MusicModel(string title, string path, string description, string extension)
    {
        Title = title;
        Path = path;
        Description = description;
        Extension = extension;
    }
}

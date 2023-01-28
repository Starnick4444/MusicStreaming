using Microsoft.VisualBasic.FileIO;
using MusicStreamingServer.Data;
using MusicStreamingServer.DbAccess;
using MusicStreamingServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MusicStreamingServer;

internal class MusicMapper
{
    private static readonly string[] ValidAudioExtensions = { ".mp3", ".aac" };
    private static MusicModel map(string path) => new MusicModel(new FileInfo(path));

    public static async void RegisterNewAudio(string path)
    {
        string newFolder = Path.Combine(path, "new");

        if (!Directory.Exists(newFolder))
        {
            throw new DirectoryNotFoundException();
        }
        //get all file list as fileinfo
        IEnumerable<FileInfo?> newFiles = new DirectoryInfo(newFolder).GetFiles().Where(f => ValidAudioExtensions.Contains(f.Extension));

        //adding them to database
        MusicData data = new MusicData(new SqlDataAccess());
        XmlSerializer serializer = new XmlSerializer(typeof(MusicModel));
        int id = 0;
        foreach (FileInfo? file in newFiles)
        {
            MusicModel model = new MusicModel(file);
            //int id = await data.InsertMusic(model);
            File.Move(file.FullName, Path.Combine(path, id + file.Extension));

            //creating an xml file with the same name
            using (var writer = new StreamWriter(Path.Combine(path, id + ".xml")))
            {
                serializer.Serialize(writer, model);
            }
            id += 1;
        }

    }
    public static async void MapFolder(string path)
    {
        MusicData data = new MusicData(new SqlDataAccess());
        IEnumerable<string> dbTitles = await data.GetAllTitle();
        IEnumerable<string> localTitles = Directory.GetFiles(path).Select(a => a = Path.GetFileNameWithoutExtension(a));
        IEnumerable<string> OnlyInDB = dbTitles.Except(localTitles);
        IEnumerable<string> OnlyOnLocal = localTitles.Except(dbTitles);
        //TODO only select specified file extensions, e.g. .mp3

        if (OnlyInDB.Count() > 0)
        {
            //remove them from db
            foreach (string title in OnlyInDB) await data.DeleteMusic(title);
            Console.WriteLine("Removed {0} entry's from the database.", OnlyInDB.Count());
        }
        
        if (OnlyOnLocal.Count() > 0)
        {
            //add them to db
            foreach (string title in OnlyOnLocal)
            {
                DirectoryInfo hdDirectoryInWhichToSearch = new DirectoryInfo(path);
                FileInfo[] filesInDir = hdDirectoryInWhichToSearch.GetFiles(title + ".*"); //*.*
                await data.InsertMusic(new MusicModel(filesInDir[0]));
            }
            Console.WriteLine("Added {0} entry's to the database.", OnlyOnLocal.Count());
        }
    }
}

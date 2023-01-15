using Microsoft.VisualBasic.FileIO;
using MusicStreamingServer.Data;
using MusicStreamingServer.DbAccess;
using MusicStreamingServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreamingServer;

internal class MusicMapper
{
    private static MusicModel map(string path) => new MusicModel(new FileInfo(path));

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

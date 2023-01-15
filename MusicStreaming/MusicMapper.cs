using Microsoft.VisualBasic.FileIO;
using MusicStreamingServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreamingServer;

internal class MusicMapper
{
    private static MusicModel map(string path)
    {
        return new MusicModel(new FileInfo(path));
    }

    public static IEnumerable<MusicModel> MapFolder(string path)
    {
        List<MusicModel> list = new List<MusicModel>();

        foreach (string filePath in Directory.GetFiles(path))
        {
            list.Add(MusicMapper.map(filePath));
        }
        
        return list;
    }

    public static IEnumerable<MusicModel> MapFolder2(string path)
    {
        List<MusicModel> list = new List<MusicModel>();

        foreach (string filePath in Directory.GetFiles(path))
        {
            list.Add(MusicMapper.map(filePath));
        }

        return list;
    }
}

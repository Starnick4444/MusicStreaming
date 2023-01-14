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
    private static Music map(string path)
    {
        return new Music(new FileInfo(path));
    }

    public static IEnumerable<Music> MapFolder(string path)
    {
        List<Music> list = new List<Music>();

        foreach (string filePath in Directory.GetFiles(path))
        {
            list.Add(MusicMapper.map(filePath));
        }
        
        return list;
    }

    public static IEnumerable<Music> MapFolder2(string path)
    {
        List<Music> list = new List<Music>();

        foreach (string filePath in Directory.GetFiles(path))
        {
            list.Add(MusicMapper.map(filePath));
        }

        return list;
    }
}

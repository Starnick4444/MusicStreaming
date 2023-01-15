using CodeArtEng.Tcp;
using System;
using MusicStreamingServer.Network;
using System.Configuration;
using MusicStreamingServer.Models;

namespace MusicStreamingServer
{
    internal class Program
    {
        static TcpServer Server;
        static TcpAppServer AppServer;

        static void Main(string[] args)
        {
            //Stopping server and disposing of it at close
            AppDomain.CurrentDomain.ProcessExit += OnProcessExit;

            //Local list of available music, TODO REMOVE THIS, use database
            List<MusicModel> asd = MusicMapper.MapFolder($"").ToList();

            //initializing Tcp server
            Server = TcpServerManager.StartServer();

            //initializing TcpApp server
            AppServer = TcpAppServerManager.StartServer();

            //TODO find out how to find serverclient on appserver request, (maybe pair them with dictionary on join?, or ip/port)
            //TODO block this so it doesnt exit
        }

        private static void OnProcessExit(object? sender, EventArgs e)
        {
            Server.Stop(); Server.Dispose();
            AppServer.Stop(); Server.Dispose();
            throw new NotImplementedException();
        }
    }
}
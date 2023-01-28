using CodeArtEng.Tcp;
using System;
using MusicStreamingServer.Network;
using System.Configuration;
using MusicStreamingServer.Models;
//using Microsoft.Extensions.Configuration;

namespace MusicStreamingServer;

internal class Program
{
    static TcpServer Server;
    static TcpAppServer AppServer;

    static void Main(string[] args)
    {
        //Stopping server and disposing of it at close
        AppDomain.CurrentDomain.ProcessExit += OnProcessExit;
        //ClientRequest.clientRequests.OnAdd += ClientRequest.ClientRequests_OnAdd;
        //Local list of available music, TODO REMOVE THIS, use database
        MusicMapper.RegisterNewAudio(AppDomain.CurrentDomain.BaseDirectory);
        
        //initializing Tcp server
        //Server = TcpServerManager.StartServer(10001);

        Console.ReadLine();
        //TODO find out how to find serverclient on appserver request, (maybe pair them with dictionary on join?(<(ip,port),(ip,port)> of tcpServer, appserver, maybe make client send unique id based on something), or ip/port, client.name)
        //TODO block this so it doesnt exit
        //TODO replace CW's with propper logging
    }

    private static void OnProcessExit(object? sender, EventArgs e)
    {
        Server?.Stop(); Server?.Dispose();
        AppServer?.Stop(); AppServer?.Dispose();
        
    }
}
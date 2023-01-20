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
        //MusicMapper.MapFolder(@"");

        //initializing Tcp server
        Server = TcpServerManager.StartServer();

        //CONCLUSION: TCPAPPSERVER HAS TCPSERVER BUILT IN, just use that to stream data, NOT GOOOD
        //can only send data trough sender.appclient.connection after we sent tcpapp response

        //initializing TcpApp server
        //AppServer = TcpAppServerManager.StartServer();
        Console.ReadLine();
        
        //TODO TEST AppServer.Clients vs AppServer.AppClients, might be able to handle TODO below this with it

        //TODO find out how to find serverclient on appserver request, (maybe pair them with dictionary on join?(<(ip,port),(ip,port)> of tcpServer, appserver, maybe make client send unique id based on something), or ip/port, client.name)
        //TODO block this so it doesnt exit
        //TODO replace CW's with propper logging
    }

    private static void OnProcessExit(object? sender, EventArgs e)
    {
        if (Server is not null)
        {
            Server.Stop(); Server.Dispose();
        }

        if (AppServer is not null)
        {
            AppServer.Stop(); AppServer.Dispose();
        }
    }
}
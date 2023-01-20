using CodeArtEng.Tcp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static MusicStreamingServer.Network.TcpAppServerManager;

namespace MusicStreamingServer.Network;

public static class TcpAppServerManager
{
    private static TcpAppServer _appServer;

    private static int RequestDataDelayMilisec = 10; //might need a new place for it
    public static TcpAppServer StartServer()
    {
        _appServer = new TcpAppServer();
        _appServer.MaxClients = 10;
        _appServer.ExecutionTimeout = 5000;
        _appServer.ClientConnected += _appServer_ClientConnected;
        _appServer.ClientDisconnected += _appServer_ClientDisconnected;
        _appServer.ClientSignedIn += _appServer_ClientSignedIn; //might not need
        _appServer.ClientSigningOut+= _appServer_ClientSigningOut; //might not need
        _appServer.RegisterCommand("CustomFunction", "Dummy Custom Function", customFunctionCallback);

        _appServer.Start(10002);
        //TODO start with a port
        //TOOD register new commands
        return _appServer;
    }

    private static void customFunctionCallback(TcpAppInputCommand sender)
    {
        Console.WriteLine("Command recieved!");
        sender.Status = TcpAppCommandStatus.OK;
        sender.OutputMessage = "Custom function exec";
        //sender.AppClient.Connection.WriteToClient("trough tcp connection."); instead of this
        //put this appclient in a request list, with the request, and 

        ThreadPool.QueueUserWorkItem(LambdaOpNeedNewName => asdRename(sender.AppClient.Connection, new Stopwatch(), (TcpAppCommand)sender.Command.Clone()));
    }

    private static void asdRename(TcpServerConnection client, Stopwatch stopwatch, TcpAppCommand command)
    {
        //YES i know its terrible, cant really fix it without using another connection or different tcp library/modify it
        //wait x millisec, maybe remove stopwatch
        int WaitRemainingMilisec = Convert.ToInt32(stopwatch.ElapsedMilliseconds) - RequestDataDelayMilisec;
        if (WaitRemainingMilisec > 0) Thread.Sleep(WaitRemainingMilisec);
        //send requested data trough, lock client
        lock (client)
        {
            client.WriteLineToClient("Second message.");
        }
    }

    private static void _appServer_ClientSigningOut(object? sender, TcpAppServerEventArgs e)
    {
        Console.WriteLine("Client {0} signing out!", e.Client.Name);
        //throw new NotImplementedException();
    }

    private static void _appServer_ClientSignedIn(object? sender, TcpAppServerEventArgs e)
    {
        Console.WriteLine("Client {0} signed in!",e.Client.Name);
        //throw new NotImplementedException();
    }

    private static void _appServer_ClientDisconnected(object? sender, TcpServerEventArgs e)
    {
        Console.WriteLine("Client {0}:{1} disconnected!", e.Client.ClientIPAddress, e.Client.ClientPort);
        //throw new NotImplementedException();
    }

    private static void _appServer_ClientConnected(object? sender, TcpServerEventArgs e)
    {
        Console.WriteLine("Client {0}:{1} connected!", e.Client.ClientIPAddress, e.Client.ClientPort);
        //throw new NotImplementedException();
    }
}

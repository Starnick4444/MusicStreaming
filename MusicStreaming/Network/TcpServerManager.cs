using CodeArtEng.Tcp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreamingServer.Network;

public static class TcpServerManager
{
    private static TcpServer _server;
    public static TcpServer StartServer()
    {
        _server = new TcpServer("MusicServer");
        _server.MaxClients = 10;
        _server.ClientConnected += Server_ClientConnected;
        _server.ClientDisconnected += Server_ClientDisconnected;
        //TODO start with a port
        _server.Start(10001);
        return _server;
    }

    private static void Server_ClientDisconnected(object? sender, TcpServerEventArgs e)
    {
        //throw new NotImplementedException();
        Console.WriteLine("Client {0}:{1} disconnected!",e.Client.ClientIPAddress, e.Client.ClientPort);
        //TODO disconnected logging
        //((TcpServerConnection)e.Client).ClientIPAddress
    }

    private static void Server_ClientConnected(object? sender, TcpServerEventArgs e)
    {
        //throw new NotImplementedException();
        Console.WriteLine("Client {0}:{1} connected!", e.Client.ClientIPAddress, e.Client.ClientPort);

        //TODO: subscribe to e.client. MessageRecieved, BytesRecieved, BytesSent
        e.Client.BytesReceived += Client_BytesReceived;
        e.Client.MessageReceived += Client_MessageReceived;
        //TODO: create class that holds both client objects to this device, client will send the same unique iq on both connection

        //TODO: connected logging
        //((TcpServerConnection)e.Client).ClientIPAddress
    }

    private static void Client_MessageReceived(object? sender, MessageReceivedEventArgs e)
    {
        Console.WriteLine("Message recieved: ");
        //throw new NotImplementedException();
    }

    private static void Client_BytesReceived(object? sender, TcpServerDataEventArgs e)
    {
        Console.WriteLine("Bytes recieved!");
        string data = Encoding.UTF8.GetString(e.Data);
        Encoding.UTF8.
        Console.WriteLine(data); ;
        //throw new NotImplementedException();
    }

    public static byte[] Serialize(object anySerializableObject)
    {
        using (var memoryStream = new MemoryStream())
        {
            (new BinaryFormatter()).Serialize(memoryStream, anySerializableObject);
            return memoryStream.ToArray();
        }
    }
}



public class ClientManager
{
    //TODO new name
    public static List<ClientManager> Clientsasd = new List<ClientManager>();

    private TcpServerConnection dataClient;
    private TcpAppServerConnection appClient;

    public ClientManager(TcpAppServerConnection appClient)
    {
        this.appClient = appClient ?? throw new ArgumentNullException(nameof(appClient));

    }
}

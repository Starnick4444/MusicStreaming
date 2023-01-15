using CodeArtEng.Tcp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreamingServer.Network
{
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

            return _server;
        }

        private static void Server_ClientDisconnected(object? sender, TcpServerEventArgs e)
        {
            throw new NotImplementedException();
            //TODO disconnected logging
            //((TcpServerConnection)e.Client).ClientIPAddress
        }

        private static void Server_ClientConnected(object? sender, TcpServerEventArgs e)
        {
            throw new NotImplementedException();
            //TODO: subscribe to e.client. MessageRecieved, BytesRecieved, BytesSent

            //TODO: create class that holds both client objects to this device, client will send the same unique iq on both connection

            //TODO: connected logging
            //((TcpServerConnection)e.Client).ClientIPAddress
        }
    }
}

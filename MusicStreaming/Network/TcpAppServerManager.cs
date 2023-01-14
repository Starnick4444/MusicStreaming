using CodeArtEng.Tcp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreamingServer.Network
{
    public static class TcpAppServerManager
    {
        private static TcpAppServer _appServer;

        public static TcpAppServer StartServer()
        {
            _appServer = new TcpAppServer();
            _appServer.MaxClients = 10;
            _appServer.ExecutionTimeout = 5000;
            _appServer.ClientConnected += _appServer_ClientConnected;
            _appServer.ClientDisconnected += _appServer_ClientDisconnected;
            _appServer.ClientSignedIn += _appServer_ClientSignedIn; //might not need
            _appServer.ClientSigningOut += _appServer_ClientSigningOut; //might not need
            //TODO start with a port
            //TOOD register new commands
            _appServer.RegisterCommand()
            return _appServer;
        }

        private static void _appServer_ClientSigningOut(object? sender, TcpAppServerEventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void _appServer_ClientSignedIn(object? sender, TcpAppServerEventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void _appServer_ClientDisconnected(object? sender, TcpServerEventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void _appServer_ClientConnected(object? sender, TcpServerEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}

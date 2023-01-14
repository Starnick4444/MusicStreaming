using CodeArtEng.Tcp;

namespace MusicStreamingServer
{
    internal class Program
    {
        static TcpServer Server;
        static TcpAppServer AppServer;

        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += OnProcessExit;
            List<Music> asd = MusicMapper.MapFolder(@"").ToList();
            Server = new TcpServer("MusicServer");
            Server.MaxClients = 10;
            Server.ClientConnected += Server_ClientConnected;
            Server.ClientDisconnected += Server_ClientDisconnected;
            //TODO start with a port

            AppServer = new TcpAppServer()
            
        }

        private static void OnProcessExit(object? sender, EventArgs e)
        {
            Server.Stop(); Server.Dispose();
            throw new NotImplementedException();
        }

        private static void Server_ClientDisconnected(object? sender, TcpServerEventArgs e)
        {
            throw new NotImplementedException();
            //TODO disconnected logging
            //((TcpServerConnection)e.Client).ClientIPAddress
        }

        private static void Server_ClientConnected(object? sender, TcpServerEventArgs e)
        {
;
            throw new NotImplementedException();
            //TODO: subscribe to e.client. MessageRecieved, BytesRecieved, BytesSent

            //TODO: connected logging
            //((TcpServerConnection)e.Client).ClientIPAddress
        }
    }
}
using System.Data.SqlTypes;
using System.Net;
using System.Net.Sockets;

namespace MusicStreamingServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Music> asd = MusicMapper.MapFolder(@"").ToList();
            TcpListener server = null;
            
            try
            {
                //set TcpListener on port, TODO: make it a config
                Int32 port = 9155;

                server = new TcpListener(IPAddress.Any, port);

                //starting server
                server.Start();

                byte[] bytes = new byte[1024];
                string data = null;

                while (true)
                {
                    Console.WriteLine("Waiting for Connection...");

                    using TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Client connected!");

                    data = null;

                    //Get stream object for reading and writing
                    NetworkStream networkStream = client.GetStream();

                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                server.Stop();
            }
        }
    }
}
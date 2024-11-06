using MissionControl.Server;

namespace MissionControl
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // Initialize and start the server on a specified port
            int port = 8080;
            SocketServer server = new SocketServer(port);
            await server.StartAsync();
        }
    }
}

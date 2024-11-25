using System.Net;
using System.Net.Sockets;
using MissionControl.Service;

namespace MissionControl.Server
{
    internal class SocketServer
    {
        private readonly int _port;
        private readonly TcpListener _listener;

        private readonly CommandInterpreterService _commandInterpreter = new CommandInterpreterService();

        public SocketServer(int port)
        {
            _port = port;
            _listener = new TcpListener(IPAddress.Any, _port);
        }

        // Method to start the server
        public async Task StartAsync()
        {
            _listener.Start();
            Console.WriteLine($"Server started on port {_port}");

            while (true)
            {
                TcpClient client = await _listener.AcceptTcpClientAsync();
                ClientManager.Instance.AddClient(client);

                Console.WriteLine("Client connected.");
                _ = HandleClientAsync(client); // Handle each client asynchronously
            }
        }

        // Asynchronous method to handle each client connection
        private async Task HandleClientAsync(TcpClient client)
        {
            using (client)
            {
                _commandInterpreter.CurrentClient = client;
                await _commandInterpreter.Send(Console.ReadLine() ?? "NULL");
            }
        }
    }
}

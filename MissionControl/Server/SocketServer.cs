using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MissionControl.Server
{
    internal class SocketServer
    {
        private readonly int _port;
        private readonly TcpListener _listener;

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
                Console.WriteLine("Client connected.");
                _ = HandleClientAsync(client); // Handle each client asynchronously
            }
        }

        // Asynchronous method to handle each client connection
        private async Task HandleClientAsync(TcpClient client)
        {
            using (client)
            {
                NetworkStream stream = client.GetStream();

                // Read data sent by the client
                byte[] buffer = new byte[1024];
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                string clientMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine($"Received message from client: {clientMessage}");

                // Respond to the client
                string response = Console.ReadLine() ?? string.Empty;
                byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                await stream.WriteAsync(responseBytes, 0, responseBytes.Length);
                Console.WriteLine("Response sent to client.");
            }
        }
    }
}

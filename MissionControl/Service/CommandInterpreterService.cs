using Mars_Rover.Core.Interface;
using MissionControl.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MissionControl.Service
{
    internal class CommandInterpreterService : IInterpreter
    {
        public TcpClient CurrentClient { get; set; }

        public async Task Send(string command)
        {
            if (CurrentClient == null)
                return;

            try
            {
                NetworkStream stream = CurrentClient.GetStream();

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
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
        }
    }
}

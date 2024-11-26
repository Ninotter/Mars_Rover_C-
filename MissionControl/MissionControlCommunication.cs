using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Communication.Communication;

namespace Mars_Rover.MissionControl
{
    internal class MissionControlCommunication : IProtocolCommunication, ICommandSender
    {
        private TcpClient _tcpClient;
        private Thread thread;
        public MissionControlCommunication()
        {
            _tcpClient = new();
        }

        public async Task ConnectAsync(string ipAddress, int port)
        {
            var ipEndPoint = new IPEndPoint(address: IPAddress.Parse(ipAddress), port: port);

            await _tcpClient.ConnectAsync(ipEndPoint);
            thread = new Thread(() => GetStreamAnswer(_tcpClient.GetStream()));
            thread.Start();
        }

        public void DisconnectAsync()
        {
            thread.Interrupt();
            _tcpClient.GetStream().Close();
            _tcpClient.Close();
            Console.WriteLine("Disconnected");
        }

        public async Task SendCommandAsync(string action)
        {
            NetworkStream stream = _tcpClient.GetStream();

            var buffer = Encoding.UTF8.GetBytes(action);

            await stream.WriteAsync(buffer);
            Console.WriteLine($"Commande {action} envoyée.");
            
        }

        private void GetStreamAnswer(NetworkStream stream)
        {
                string data = null;
                Byte[] bytes = new Byte[256];
                int i;
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    data = Encoding.ASCII.GetString(bytes, 0, i);
                    Console.WriteLine(data);
                }
        }
    }
}
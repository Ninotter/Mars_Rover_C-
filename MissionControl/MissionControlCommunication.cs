using System.Net;
using System.Net.Sockets;
using System.Text;
using Communication.Communication;

namespace Mars_Rover.MissionControl
{
    internal class MissionControlCommunication : IProtocolCommunication, ICommandSender
    {
        private TcpClient _tcpClient;

        public MissionControlCommunication()
        {
            _tcpClient = new();
        }

        public async Task ConnectAsync(string ipAddress, int port)
        {
            var ipEndPoint = new IPEndPoint(address: IPAddress.Parse(ipAddress), port: port);

            await _tcpClient.ConnectAsync(ipEndPoint);
        }

        public async Task DisconnectAsync()
        {
            _tcpClient.Close();
        }

        public async Task SendCommandAsync(string action)
        {
            await using NetworkStream stream = _tcpClient.GetStream();

            var buffer = Encoding.UTF8.GetBytes(action);

            await stream.WriteAsync(buffer);
        }
    }
}
using System.Net.Sockets;
using Communication.Communication;
using Mars_Rover.Entities;

namespace Mars_Rover.server;

public class RoverListener : ICommandListener<RoverState>
{
    private Func<string, RoverState> _callback;
    private bool _roverIsAlive = true;

    public RoverListener()
    {
    }

    public void Subscribe(Func<string, RoverState> resultingAction)
    {
        _callback = resultingAction;
    }
    
    public void CreateServer(string ipAddress, int port)
    {
        try
        {
            TcpListener server = new TcpListener(System.Net.IPAddress.Parse(ipAddress), port);
            server.Start();
            Console.WriteLine($"Listening on {ipAddress}:{port}");
            
            string data = null;
            Byte[] bytes = new Byte[256];

            while (_roverIsAlive)
            {
                using TcpClient client = server.AcceptTcpClient();
                NetworkStream stream = client.GetStream();
                int i;
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                    Console.WriteLine("Received: {0}", data);
                    var roverState = _callback(data);
                    data = "Rover State: \n" +
                           roverState;

                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                    stream.Write(msg, 0, msg.Length);
                    Console.WriteLine("Sent: {0}", data);
                }
            }
        }
        catch(SocketException e)
        {
            Console.WriteLine("SocketException: {0}", e);
            _roverIsAlive = false;
        }
    }
}
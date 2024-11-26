using Communication.Communication;
using Mars_Rover.Entities;
using Mars_Rover.Tools;

namespace RoverTest.CommunicationTest
{
    internal class FakeCommunicationTest : IProtocolCommunication, ICommandListener, ICommandSender
    {
        Rover _rover;
        Action<string> _callback;

        public FakeCommunicationTest(Rover rover)
        {
            _rover = rover;
        }

        public async Task ConnectAsync(string ipAddress, int port)
        {
            await Task.Delay(1000);
        }

        public async Task DisconnectAsync()
        {
            await Task.Delay(1000);
        }

        public Task SendCommandAsync(string action)
        {
            _rover.VehicleState = Interpreter.Send(action);
            Console.WriteLine(_rover.VehicleState.ToString());
            _callback(action);
            return Task.CompletedTask;
        }

        public void Subscribe(Action<string> resultingAction)
        {
            _callback = resultingAction;
        }
    }
}
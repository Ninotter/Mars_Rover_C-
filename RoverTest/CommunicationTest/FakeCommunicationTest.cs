using Communication.Communication;
using Mars_Rover.Entities;
using Mars_Rover.Tools;

namespace RoverTest.CommunicationTest
{
    internal class FakeCommunicationTest : IProtocolCommunication, ICommandListener<RoverState>, ICommandSender
    {
        Rover _rover;
        Func<string, RoverState> _callback;

        public FakeCommunicationTest(Rover rover)
        {
            _rover = rover;
        }

        public async Task ConnectAsync(string ipAddress, int port)
        {
            await Task.Delay(1000);
        }

        public void DisconnectAsync()
        {
            Task.Delay(1000);
        }

        public Task SendCommandAsync(string action)
        {
            _rover.VehicleRoverState = Interpreter.Send(action);
            Console.WriteLine(_rover.VehicleRoverState.ToString());
            _callback(action);
            return Task.CompletedTask;
        }

        public void Subscribe(Func<string, RoverState> resultingAction)
        {
            _callback = resultingAction;
        }
    }
}
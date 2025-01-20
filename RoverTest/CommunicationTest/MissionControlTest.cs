using Mars_Rover.Tools;
using Topology.Planet;

namespace RoverTest.CommunicationTest
{
    public class MissionControlTest
    {
        [Test]
        public void TestEnvoiCommandeAvancer()
        {
            Interpreter.CreateRoverWithPlanet(new InfinitePlanet());

            var fake = new FakeCommunicationTest(Interpreter.GetRover());
            fake.Subscribe((action) => { Console.WriteLine(action);
                return Interpreter.GetRoverState();
            });

            fake.SendCommandAsync("A");
        }
    }
}
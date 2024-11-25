using Mars_Rover.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topology.Planet;

namespace RoverTest.CommunicationTest
{
    public class MissionControlTest
    {
        [Test]
        public void TestEnvoiCommande()
        {
            Interpreter.CreateRover(new InfinitePlanet());

            var fake = new FakeCommunicationTest(Interpreter.GetRover());
            fake.Subscribe((action) =>
            {
                Console.WriteLine(action);
            });

            fake.SendCommandAsync("A");
        }
    }
}

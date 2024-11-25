using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverTest.CommunicationTest
{
    public class MissionControlTest
    {
        [Test]
        public void TestEnvoiCommande()
        {
            var fake = new FakeCommunicationTest(RoverBuilder.CreateBuilder().Build());
            fake.Subscribe((action) =>
            {
                Console.WriteLine(action);
            });

            fake.SendCommandAsync("A");
        }
    }
}

using Mars_Rover.Entities;

namespace RoverTest
{
    public class RoverTest
    {
        [Test]
        public void RoverNorth_StartsNorthRotateEastThenForward_GoesEast()
        {
            Rover rover = RoverBuilder.CreateBuilder().AddState(10, 5, Position.NORD).Build();
            rover.RotateToRightSide();
            rover.Avancer();
            Assert.AreEqual(11, rover.VehicleState.Position.Horizontal);
        }

        [Test]
        public void RoverNorth_StartsNorthRotateLeftThenForward_GoesWest()
        {
            Rover rover = RoverBuilder.CreateBuilder().AddState(10, 5, Position.NORD).Build();
            rover.RotateToLeftSide();
            rover.Avancer();
            Assert.AreEqual(9, rover.VehicleState.Position.Horizontal);
        }

        [Test]
        public void RoverNorth_StartsSouthRotateLeftTwiceThenForwardTwice_GoesNorthTwice()
        {
            Rover rover = RoverBuilder.CreateBuilder().AddState(10, 5, Position.SUD).Build();
            rover.RotateToLeftSide();
            rover.RotateToLeftSide();
            rover.Avancer();
            rover.Avancer();
            Assert.AreEqual(7, rover.VehicleState.Position.Vertical);
        }

        [Test]
        public void RoverNorthOnSmallPlanet_GoesNorthOverLimits_GoesAround()
        {
            Rover rover = RoverBuilder.CreateBuilder().AddState(5, 10, Position.NORD).AddTorroidalPlanet(10).Build();
            rover.Avancer();
            Assert.AreEqual(0, rover.VehicleState.Position.Vertical);
        }

        [Test]
        public void RoverEastOnSmallPlanet_GoesEastOverLimitsTwice_GoesAround()
        {
            Rover rover = RoverBuilder.CreateBuilder().AddState(10, 5, Position.EST).AddTorroidalPlanet(10).Build();
            rover.Avancer();
            rover.Avancer();
            Assert.AreEqual(1, rover.VehicleState.Position.Horizontal);
        }
    }
}
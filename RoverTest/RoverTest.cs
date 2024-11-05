using Mars_Rover.Entities;

namespace RoverTest
{
    public class RoverTest
    {
        [Test]
        public void RoverNorth_StartsNorthRotateEastThenForward_GoesEast()
        {
            Rover rover = RoverBuilder.CreateBuilder().AddState(10, 5, Position.NORTH).Build();
            rover.RotateToRightSide();
            rover.GoForward();
            Assert.AreEqual(11, rover.VehicleState.Position.Horizontal);
        }

        [Test]
        public void RoverNorth_StartsNorthRotateLeftThenForward_GoesWest()
        {
            Rover rover = RoverBuilder.CreateBuilder().AddState(10, 5, Position.NORTH).Build();
            rover.RotateToLeftSide();
            rover.GoForward();
            Assert.AreEqual(9, rover.VehicleState.Position.Horizontal);
        }

        [Test]
        public void RoverNorth_StartsSouthRotateLeftTwiceThenForwardTwice_GoesNorthTwice()
        {
            Rover rover = RoverBuilder.CreateBuilder().AddState(10, 5, Position.SOUTH).Build();
            rover.RotateToLeftSide();
            rover.RotateToLeftSide();
            rover.GoForward();
            rover.GoForward();
            Assert.AreEqual(7, rover.VehicleState.Position.Vertical);
        }

        [Test]
        public void RoverNorthOnSmallPlanet_GoesNorthOverLimits_GoesAround()
        {
            Rover rover = RoverBuilder.CreateBuilder().AddState(5, 10, Position.NORTH).AddTorroidalPlanet(10).Build();
            rover.GoForward();
            Assert.AreEqual(0, rover.VehicleState.Position.Vertical);
        }

        [Test]
        public void RoverEastOnSmallPlanet_GoesEastOverLimitsTwice_GoesAround()
        {
            Rover rover = RoverBuilder.CreateBuilder().AddState(10, 5, Position.EAST).AddTorroidalPlanet(10).Build();
            rover.GoForward();
            rover.GoForward();
            Assert.AreEqual(1, rover.VehicleState.Position.Horizontal);
        }
    }
}
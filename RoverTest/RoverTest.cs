using Mars_Rover.Entities;

namespace RoverTest
{
    public class RoverTest
    {
        [Test]
        public void RoverNorth_StartsNorthRotateEastThenForward_GoesEast()
        {
            Rover rover = RoverBuilder.CreateBuilder().AddState(10, 5, State.NORTH).Build();
            rover.RotateToRightSide();
            rover.GoForward();
            Assert.AreEqual(11, rover.VehicleState.Horizontal);
        }

        [Test]
        public void RoverNorth_StartsNorthRotateLeftThenForward_GoesWest()
        {
            Rover rover = RoverBuilder.CreateBuilder().AddState(10, 5, State.NORTH).Build();
            rover.RotateToLeftSide();
            rover.GoForward();
            Assert.AreEqual(9, rover.VehicleState.Horizontal);
        }

        [Test]
        public void RoverNorth_StartsSouthRotateLeftTwiceThenForwardTwice_GoesNorthTwice()
        {
            Rover rover = RoverBuilder.CreateBuilder().AddState(10, 5, State.SOUTH).Build();
            rover.RotateToLeftSide();
            rover.RotateToLeftSide();
            rover.GoForward();
            rover.GoForward();
            Assert.AreEqual(7, rover.VehicleState.Vertical);
        }

        [Test]
        public void RoverNorthOnSmallPlanet_GoesNorthOverLimits_GoesAround()
        {
            Rover rover = RoverBuilder.CreateBuilder().AddState(5, 10, State.NORTH).AddTorroidalPlanet(10).Build();
            rover.GoForward();
            Assert.AreEqual(0, rover.VehicleState.Vertical);
        }

        [Test]
        public void RoverEastOnSmallPlanet_GoesEastOverLimitsTwice_GoesAround()
        {
            Rover rover = RoverBuilder.CreateBuilder().AddState(10, 5, State.EAST).AddTorroidalPlanet(10).Build();
            rover.GoForward();
            rover.GoForward();
            Assert.AreEqual(1, rover.VehicleState.Horizontal);
        }

        [Test]
        public void RoverGoBackwardOnSmallPlanetFromNorthOrientation()
        {
            Rover rover = RoverBuilder.CreateBuilder().AddState(0, 0, State.NORTH).AddTorroidalPlanet(10).Build();
            rover.GoBackward();
            Assert.AreEqual(10, rover.VehicleState.Vertical);
        }
    }
}
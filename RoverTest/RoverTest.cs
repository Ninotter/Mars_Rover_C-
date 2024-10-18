using Mars_Rover.Entities;
using Mars_Rover.src.Enum;

namespace RoverTest
{
    public class RoverTest
    {
        [Test]
        public void RoverNorth_StartsNorthRotateEastThenForward_GoesEast()
        {
            Rover rover = new Rover(new State(10, 5, 0));
            rover.RotateToRightSide();
            rover.Avancer();
            Assert.That(11 == rover.VehicleState.Horizontal);
        }

        [Test]
        public void RoverNorth_StartsNorthRotateLeftThenForward_GoesWest()
        {
            Rover rover = new Rover(new State(10, 5, 0));
            rover.RotateToLeftSide();
            rover.Avancer();
            Assert.That(9 == rover.VehicleState.Horizontal);
        }

        [Test]
        public void RoverNorth_StartsSouthRotateLeftTwiceThenForwardTwice_GoesNorthTwice()
        {
            Rover rover = new Rover(new State(10, 5, OrientationsEnum.SUD));
            rover.RotateToLeftSide();
            rover.RotateToLeftSide();
            rover.Avancer();
            Assert.That(7 == rover.VehicleState.Vertical);
        }

        [Test]
        public void RoverNorthOnSmallPlanet_GoesNorthOverLimits_GoesAround()
        {
            Rover rover = new Rover(new State(10, 5, 0));
            rover.Avancer();
            Assert.That(0 == rover.VehicleState.Vertical);
        }

        [Test]
        public void RoverEastOnSmallPlanet_GoesEastOverLimitsTwice_GoesAround()
        {
            Rover rover = new Rover(new State(10, 5, OrientationsEnum.EST));
            rover.Avancer();
            rover.Avancer();
            Assert.That(1 == rover.VehicleState.Horizontal);
        }
    }
}
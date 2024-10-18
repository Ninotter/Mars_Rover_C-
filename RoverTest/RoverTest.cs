using Mars_Rover.Entities;
using Mars_Rover.src.Enum;

namespace RoverTest
{
    public class RoverTest
    {
        [Test]
        public void RoverNorth_StartsNorthRotateEastThenForward_GoesEast()
        {
            Rover rover = RoverBuilder.CreateBuilder().WithState(10, 5, OrientationsEnum.NORD).Build();
            rover.RotateToRightSide();
            rover.Avancer();
            Assert.AreEqual(11, rover.VehicleState.Horizontal);
        }

        [Test]
        public void RoverNorth_StartsNorthRotateLeftThenForward_GoesWest()
        {
            Rover rover = RoverBuilder.CreateBuilder().WithState(10, 5, OrientationsEnum.NORD).Build();
            rover.RotateToLeftSide();
            rover.Avancer();
            Assert.AreEqual(9, rover.VehicleState.Horizontal);
        }

        [Test]
        public void RoverNorth_StartsSouthRotateLeftTwiceThenForwardTwice_GoesNorthTwice()
        {
            Rover rover = RoverBuilder.CreateBuilder().WithState(10, 5, OrientationsEnum.SUD).Build();
            rover.RotateToLeftSide();
            rover.RotateToLeftSide();
            rover.Avancer();
            rover.Avancer();
            Assert.AreEqual(7, rover.VehicleState.Vertical);
        }

        [Test]
        public void RoverNorthOnSmallPlanet_GoesNorthOverLimits_GoesAround()
        {
            Rover rover = RoverBuilder.CreateBuilder().WithState(5, 10, OrientationsEnum.NORD).WithPlanetSize(10).Build();
            rover.Avancer();
            Assert.AreEqual(0, rover.VehicleState.Vertical);
        }

        [Test]
        public void RoverEastOnSmallPlanet_GoesEastOverLimitsTwice_GoesAround()
        {
            Rover rover = RoverBuilder.CreateBuilder().WithState(10, 5, OrientationsEnum.EST).WithPlanetSize(10).Build();
            rover.Avancer();
            rover.Avancer();
            Assert.AreEqual(1, rover.VehicleState.Horizontal);
        }
    }
}
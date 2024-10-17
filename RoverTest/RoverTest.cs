using Mars_Rover.src.Entities;
using Mars_Rover.src.Entities.Planets;
using Mars_Rover.src.Enum;
using Mars_Rover.src.Services;

namespace RoverTest
{
    public class RoverTest
    {
        [Test]
        public void RoverNorth_StartsNorthRotateEastThenForward_GoesEast()
        {
            Rover rover = new Rover(new State(10, 5, 0));
            VehicleService vehicleService = new(rover, new InfinitePlane());
            vehicleService.RotateRight90Degrees();
            vehicleService.AvancerEst();
            Assert.That(11 == rover.VehicleState.Horizontal);
        }

        [Test]
        public void RoverNorth_StartsNorthRotateLeftThenForward_GoesWest()
        {
            Rover rover = new Rover(new State(10, 5, 0));
            VehicleService vehicleService = new(rover, new InfinitePlane());
            vehicleService.RotateLeft90Degrees();
            vehicleService.AvancerOuest();
            Assert.That(9 == rover.VehicleState.Horizontal);
        }

        [Test]
        public void RoverNorth_StartsSouthRotateLeftTwiceThenForwardTwice_GoesNorthTwice()
        {
            Rover rover = new Rover(new State(10, 5, 180));
            VehicleService vehicleService = new(rover, new InfinitePlane());
            vehicleService.RotateLeft90Degrees();
            vehicleService.RotateLeft90Degrees();
            vehicleService.AvancerNord();
            vehicleService.AvancerNord();
            Assert.That(7 == rover.VehicleState.Vertical);
        }

        [Test]
        public void RoverNorthOnSmallPlanet_GoesNorthOverLimits_GoesAround()
        {
            Rover rover = new Rover(new State(10, 5, 0));
            VehicleService vehicleService = new(rover, new ToroidalPlanet(5));
            vehicleService.AvancerNord();
            Assert.That(0 == rover.VehicleState.Vertical);
        }

        [Test]
        public void RoverEastOnSmallPlanet_GoesEastOverLimitsTwice_GoesAround()
        {
            Rover rover = new Rover(new State(10, 5, 90));
            VehicleService vehicleService = new(rover, new ToroidalPlanet(10));
            vehicleService.AvancerEst();
            vehicleService.AvancerEst();
            Assert.That(1 == rover.VehicleState.Horizontal);
        }
    }
}
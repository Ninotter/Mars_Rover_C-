using Mars_Rover.src.Entities;
using Mars_Rover.src.Entities.Planets;
using Mars_Rover.src.Services;

namespace RoverTest
{
    public class RoverTest
    {
        [Test]
        public void RoverNorth_StartsNorthRotateEastThenForward_GoesEast()
        {
            Rover rover = new(new ToroidalPlanet(60)) { VehicleState = new State(10, 5, 0) };
            VehicleService vehicleService = new(rover);
            vehicleService.RotateRight90Degrees();
            vehicleService.AvancerEst();
            Assert.That(11 == rover.VehicleState.Horizontal);
        }

        [Test]
        public void RoverNorth_StartsNorthRotateLeftThenForward_GoesWest()
        {
            Rover rover = new() { VehicleState = new State(10, 5, 0) };
            VehicleService vehicleService = new(rover);
            vehicleService.RotateLeft90Degrees();
            vehicleService.AvancerOuest();
            Assert.That(9 == rover.VehicleState.Horizontal);
        }

        [Test]
        public void RoverNorth_StartsSouthRotateLeftTwiceThenForwardTwice_GoesNorthTwice()
        {
            Rover rover = new() { VehicleState = new State(10, 5, 180) };
            VehicleService vehicleService = new(rover);
            vehicleService.RotateLeft90Degrees();
            vehicleService.RotateLeft90Degrees();
            vehicleService.AvancerNord();
            vehicleService.AvancerNord();
            Assert.That(7 == rover.VehicleState.Vertical);
        }
    }
}
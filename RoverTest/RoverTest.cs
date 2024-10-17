using Mars_Rover.src.Entities;
using Mars_Rover.src.Services;

namespace RoverTest
{
    public class RoverTest
    {
        [Test]
        public void RoverNorth_MoveEast_GoesEast()
        {
            Rover rover = new() { VehicleState = new State(10, 5, 0) };
            VehicleService vehicleService = new(rover);
            vehicleService.MoveEast();
        }
    }
}
using Mars_Rover.Interfaces;
using Topology.Planet;

namespace Mars_Rover.Entities
{
    public class Rover : IRover
    {
        public RoverState VehicleRoverState { get; set; }
        public Planet Planet { get; set; }

        public Rover(Planet planet)
        {
            VehicleRoverState = new RoverState();
            Planet = planet;
        }

        public Rover(RoverState vehicleRoverState, Planet planet)
        {
            VehicleRoverState = vehicleRoverState;
            Planet = planet;
        }

        public RoverState GoForward()
        {
            RoverState newRoverState = VehicleRoverState.Forward();
            var (x, y) = Planet.CheckLimits(newRoverState.Horizontal, newRoverState.Vertical);
            if (!Planet.CheckForObstacle(x, y))
            {
                VehicleRoverState = new RoverState(newRoverState.Orientation, x, y);
            }
            return VehicleRoverState;
        }

        public RoverState GoBackward()
        {
            RoverState newRoverState = VehicleRoverState.Backward();
            var (x, y) = Planet.CheckLimits(newRoverState.Horizontal, newRoverState.Vertical);
            if (!Planet.CheckForObstacle(x, y))
            {
                VehicleRoverState = new RoverState(newRoverState.Orientation, x, y);
            }
            return VehicleRoverState;
        }

        public RoverState RotateToRightSide()
        {
            VehicleRoverState = VehicleRoverState.ClockwiseRotation();
            return VehicleRoverState;
        }

        public RoverState RotateToLeftSide()
        {
            VehicleRoverState = VehicleRoverState.CounterclockwiseRotation();
            return VehicleRoverState;
        }
    }
}
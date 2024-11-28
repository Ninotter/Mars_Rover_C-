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
            var (horizontalX, verticalY) = Planet.CheckLimits(newRoverState.HorizontalX, newRoverState.VerticalY);
            VehicleRoverState = new RoverState(newRoverState.Orientation, horizontalX, verticalY);
            return VehicleRoverState;
        }

        public RoverState GoBackward()
        {
            RoverState newRoverState = VehicleRoverState.Backward();
            var (horizontalX, verticalY) = Planet.CheckLimits(newRoverState.HorizontalX, newRoverState.VerticalY);
            VehicleRoverState = new RoverState(newRoverState.Orientation, horizontalX, verticalY);
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
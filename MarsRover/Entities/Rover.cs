using Mars_Rover.Interfaces;

namespace Mars_Rover.Entities
{
    public class Rover : IRover
    {
        public State VehicleState { get; set; }
        public Planet Planet { get; set; }

        public Rover(Planet planet)
        {
            VehicleState = new State();
            Planet = planet;
        }

        public Rover(State vehicleState, Planet planet)
        {
            VehicleState = vehicleState;
            Planet = planet;
        }

        public State GoForward()
        {
            State newState = VehicleState.Forward();
            var (x, y) = Planet.CheckLimits(newState.Horizontal, newState.Vertical);
            VehicleState = new State(newState.Orientation, x, y);
            return VehicleState;
        }

        public State GoBackward()
        {
            State newState = VehicleState.Backward();
            var (x, y) = Planet.CheckLimits(newState.Horizontal, newState.Vertical);
            VehicleState = new State(newState.Orientation, x, y);
            return VehicleState;
        }

        public State RotateToRightSide()
        {
            VehicleState = VehicleState.ClockwiseRotation();
            return VehicleState;
        }

        public State RotateToLeftSide()
        {
            VehicleState = VehicleState.CounterclockwiseRotation();
            return VehicleState;
        }
    }
}
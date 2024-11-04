using Mars_Rover.Interfaces;
using Mars_Rover.src.Enum;
using Mars_Rover.src.Interfaces;

namespace Mars_Rover.Entities
{
    public class Rover : ICommand
    {
        public State VehicleState { get; set; }
        public Planet Planet { get; set; }
        private IMovementCalculator movementCalculator;

        public Rover(IMovementCalculator movementCalculator, Planet planet)
        {
            VehicleState = new State();
            Planet = planet;
            this.movementCalculator = movementCalculator;
        }

        public Rover(State vehicleState, IMovementCalculator movementCalculator, Planet planet)
        {
            VehicleState = vehicleState;
            Planet = planet;
            this.movementCalculator = movementCalculator;
        }

        public State Avancer()
        {
            (double x, double y) = movementCalculator.Forward(VehicleState.RoverOrientation, VehicleState.Horizontal, VehicleState.Vertical);
            (x, y) = Planet.CheckLimits(x, y);
            VehicleState = new State(x, y, VehicleState.RoverOrientation);
            return VehicleState;
        }

        public State Reculer()
        {
            (double x, double y) = movementCalculator.Backward(VehicleState.RoverOrientation, VehicleState.Horizontal, VehicleState.Vertical);
            (x, y) = Planet.CheckLimits(x, y);
            VehicleState = new State(x, y, VehicleState.RoverOrientation);
            return VehicleState;
        }

        public State RotateToRightSide()
        {
            OrientationsEnum newOrientation = movementCalculator.RotateToRightSide(this.VehicleState.RoverOrientation);
            VehicleState = new State(VehicleState.Horizontal, VehicleState.Vertical, newOrientation);
            return VehicleState;
        }

        public State RotateToLeftSide()
        {
            OrientationsEnum newOrientation = movementCalculator.RotateToLeftSide(this.VehicleState.RoverOrientation);
            VehicleState = new State(VehicleState.Horizontal, VehicleState.Vertical, newOrientation);
            return VehicleState;
        }
    }
}
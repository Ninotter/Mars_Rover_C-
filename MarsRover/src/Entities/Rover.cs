using Mars_Rover.Interfaces;
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

        public State SendState()
        {
            return VehicleState;
        }

        public void Avancer()
        {
            (double x, double y) = movementCalculator.Forward(VehicleState.RoverOrientation, VehicleState.Horizontal, VehicleState.Vertical);
            (x, y) = Planet.CheckLimits(x, y);
            VehicleState.Horizontal = x;
            VehicleState.Vertical = y;
        }

        public void Reculer()
        {
            (double x, double y) = movementCalculator.Backward(VehicleState.RoverOrientation, VehicleState.Horizontal, VehicleState.Vertical);
            (x, y) = Planet.CheckLimits(x, y);
            VehicleState.Horizontal = x;
            VehicleState.Vertical = y;
        }

        public void RotateToRightSide()
        {
            this.VehicleState.RoverOrientation = movementCalculator.RotateToRightSide(this.VehicleState.RoverOrientation);
        }

        public void RotateToLeftSide()
        {
            this.VehicleState.RoverOrientation = movementCalculator.RotateToLeftSide(this.VehicleState.RoverOrientation);
        }
    }
}
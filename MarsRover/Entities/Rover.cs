using Mars_Rover.Interfaces;

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
            Position pos = movementCalculator.Forward(VehicleState.Position);
            var (x, y) = Planet.CheckLimits(pos.Horizontal, pos.Vertical);
            VehicleState = new State(x, y, pos.Orientation);
            return VehicleState;
        }

        public State Reculer()
        {
            Position pos = movementCalculator.Backward(VehicleState.Position);
            var (x, y) = Planet.CheckLimits(pos.Horizontal, pos.Vertical);
            VehicleState = new State(x, y, pos.Orientation);
            return VehicleState;
        }

        public State RotateToRightSide()
        {
            Position newPosition = movementCalculator.RotateToRightSide(VehicleState.Position);
            VehicleState = new State(newPosition.Horizontal, newPosition.Vertical, newPosition.Orientation);
            return VehicleState;
        }

        public State RotateToLeftSide()
        {
            Position newPosition = movementCalculator.RotateToLeftSide(VehicleState.Position);
            VehicleState = new State(newPosition.Horizontal, newPosition.Vertical, newPosition.Orientation);
            return VehicleState;
        }
    }
}
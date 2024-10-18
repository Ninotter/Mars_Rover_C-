using Mars_Rover.Interfaces;
using Mars_Rover.Tools;

namespace Mars_Rover.Entities
{
    public class Rover : ICommand
    {
        public State VehicleState { get; set; }
        public Planet Planet { get; set; }

        public Rover()
        {
            VehicleState = new State();
            Planet = new Planet();
        }

        public Rover(State vehicleState)
        {
            VehicleState = vehicleState;
            Planet = new Planet();
        }

        public Rover(State vehicleState, Planet planet)
        {
            VehicleState = vehicleState;
            Planet = planet;
        }

        public State SendState()
        {
            return VehicleState;
        }

        public void Avancer()
        {
            (double x, double y) = MovementCalculator.Forward(VehicleState.RoverOrientation, VehicleState.Horizontal, VehicleState.Vertical);
            (x, y) = Planet.CheckLimits(x, y);
            VehicleState.Horizontal = x;
            VehicleState.Vertical = y;
        }

        public void Reculer()
        {
            (double x, double y) = MovementCalculator.Backward(VehicleState.RoverOrientation, VehicleState.Horizontal, VehicleState.Vertical);
            (x, y) = Planet.CheckLimits(x, y);
            VehicleState.Horizontal = x;
            VehicleState.Vertical = y;
        }

        public void RotateToRightSide()
        {
            this.VehicleState.RoverOrientation = MovementCalculator.RotateToRightSide(this.VehicleState.RoverOrientation);
        }

        public void RotateToLeftSide()
        {
            this.VehicleState.RoverOrientation = MovementCalculator.RotateToLeftSide(this.VehicleState.RoverOrientation);
        }
    }
}
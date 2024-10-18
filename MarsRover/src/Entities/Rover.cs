using Mars_Rover.Interfaces;
using Mars_Rover.src.Enum;

namespace Mars_Rover.Entities
{
    public class Rover : ICommand
    {
        private const double MinPlanetSize = 0;
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

        private void CheckLimits()
        {
            if (VehicleState.Horizontal < MinPlanetSize)
            {
                VehicleState.Horizontal = MinPlanetSize - VehicleState.Horizontal - 1;
            }

            if (VehicleState.Vertical < MinPlanetSize)
            {
                VehicleState.Vertical = MinPlanetSize - VehicleState.Vertical - 1;
            }

            if (VehicleState.Horizontal > Planet.Size)
            {
                VehicleState.Horizontal = (VehicleState.Horizontal - Planet.Size - 1);
            }

            if (VehicleState.Vertical > Planet.Size)
            {
                VehicleState.Vertical = (VehicleState.Vertical - Planet.Size - 1);
            }
        }

        public void Avancer()
        {
            switch (VehicleState.RoverOrientation)
            {
                case OrientationsEnum.NORD:
                    VehicleState.Vertical -= 1;
                    break;
                case OrientationsEnum.EST:
                    VehicleState.Horizontal += 1;
                    break;
                case OrientationsEnum.SUD:
                    VehicleState.Vertical += 1;
                    break;
                case OrientationsEnum.OUEST:
                    VehicleState.Horizontal -= 1;
                    break;
            }

            CheckLimits();
        }

        public void Reculer()
        {
            switch (VehicleState.RoverOrientation)
            {
                case OrientationsEnum.NORD:
                    VehicleState.Vertical += 1;
                    break;
                case OrientationsEnum.EST:
                    VehicleState.Horizontal -= 1;
                    break;
                case OrientationsEnum.SUD:
                    VehicleState.Vertical -= 1;
                    break;
                case OrientationsEnum.OUEST:
                    VehicleState.Horizontal += 1;
                    break;
            }

            CheckLimits();
        }

        public void RotateToRightSide()
        {
            switch (VehicleState.RoverOrientation)
            {
                case OrientationsEnum.NORD:
                    VehicleState.RoverOrientation = OrientationsEnum.EST;
                    break;
                case OrientationsEnum.SUD:
                    VehicleState.RoverOrientation = OrientationsEnum.OUEST;
                    break;
                case OrientationsEnum.EST:
                    VehicleState.RoverOrientation = OrientationsEnum.NORD;
                    break;
                case OrientationsEnum.OUEST:
                    VehicleState.RoverOrientation = OrientationsEnum.SUD;
                    break;
                default:
                    VehicleState.RoverOrientation = VehicleState.RoverOrientation;
                    break;
            }
        }
        
        public void RotateToLeftSide()
        {
            switch (VehicleState.RoverOrientation)
            {
                case OrientationsEnum.NORD:
                    VehicleState.RoverOrientation = OrientationsEnum.OUEST;
                    break;
                case OrientationsEnum.SUD:
                    VehicleState.RoverOrientation = OrientationsEnum.EST;
                    break;
                case OrientationsEnum.EST:
                    VehicleState.RoverOrientation = OrientationsEnum.SUD;
                    break;
                case OrientationsEnum.OUEST:
                    VehicleState.RoverOrientation = OrientationsEnum.NORD;
                    break;
                default:
                    VehicleState.RoverOrientation = VehicleState.RoverOrientation;
                    break;
            }
        }
    }
}
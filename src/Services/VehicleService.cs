using Mars_Rover.src.Entities;
using Mars_Rover.src.Enum;
using Mars_Rover.src.Interfaces;

namespace Mars_Rover.src.Services
{
    public class VehicleService : ICommand
    {
        protected Vehicle VehicleModel { get; set; }

        public VehicleService(Rover rover)
        {
            VehicleModel = rover;
        }

        public void Move(double x, double y)
        {
            VehicleModel.vehicleState.Horizontal = x;
            VehicleModel.vehicleState.Vertical = y;
            VehicleModel.SendState();
        }

        public void RotateToMax90Degrees(double angle)
        {
            if (angle > 90 || angle < -90)
            {
                throw new Exception("L'angle est supérieur a 90°");
            }
            else
            {
                VehicleModel.vehicleState.RotationAngle += angle;
            }

            VehicleModel.SendState();
        }

        public void RotateRight90Degrees()
        {
            SetOrientationAfterRotation(true);

            VehicleModel.vehicleState.RotationAngle += 90;

            VehicleModel.SendState();
        }

        public void RotateLeft90Degrees()
        {
            SetOrientationAfterRotation(false);
            
            VehicleModel.vehicleState.RotationAngle -= 90;

            VehicleModel.SendState();
        }

        private void SetOrientationAfterRotation(bool isRight)
        {
            switch (VehicleModel.Orientation)
            {
                case OrientationsEnum.NORD:
                    VehicleModel.Orientation = isRight ? OrientationsEnum.EST : OrientationsEnum.OUEST;
                    break;
                case OrientationsEnum.SUD:
                    VehicleModel.Orientation = isRight ? OrientationsEnum.OUEST : OrientationsEnum.EST;
                    break;
                case OrientationsEnum.EST:
                    VehicleModel.Orientation = isRight ? OrientationsEnum.SUD : OrientationsEnum.NORD;
                    break;
                case OrientationsEnum.OUEST:
                    VehicleModel.Orientation = isRight ? OrientationsEnum.NORD : OrientationsEnum.SUD;
                    break;
            }
        }
    }
}
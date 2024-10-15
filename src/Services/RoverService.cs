using Mars_Rover.src.Entities;
using Mars_Rover.src.Enum;
using Mars_Rover.src.Interfaces;

namespace Mars_Rover.src.Services
{
    public class RoverService : ICommand
    {
        protected Rover ModelRover { get; set; }

        public RoverService(Rover rover) 
        {
            ModelRover = rover;
        }

        public void Move(double x, double y)
        {
            ModelRover.vehicleState.Horizontal = x;
            ModelRover.vehicleState.Vertical = y;
            ModelRover.SendState();
        }

        public void RotateToMax90Degrees(double angle)
        {
            if(angle > 90 || angle < -90)
            {
                throw new Exception("L'angle est supérieur a 90°");
            }
            else
            {
                ModelRover.vehicleState.RotationAngle += angle;
            }

            ModelRover.SendState();

        }

        public void RotateRight90Degrees()
        {
            SetOrientationAfterRotation(true);

            ModelRover.vehicleState.RotationAngle += 90;

            ModelRover.SendState();
        }

        public void RotateLeft90Degrees()
        {
            SetOrientationAfterRotation(false);

            ModelRover.vehicleState.RotationAngle -= 90;

            ModelRover.SendState();
        }
        
        private void SetOrientationAfterRotation(bool isRight)
        {
            switch (ModelRover.Orientation)
            {
                case OrientationsEnum.NORD:
                    ModelRover.Orientation = isRight ? OrientationsEnum.EST : OrientationsEnum.OUEST;
                    break;
                case OrientationsEnum.SUD:
                    ModelRover.Orientation = isRight ? OrientationsEnum.OUEST : OrientationsEnum.EST;
                    break;
                case OrientationsEnum.EST:
                    ModelRover.Orientation = isRight ? OrientationsEnum.SUD : OrientationsEnum.NORD;
                    break;
                case OrientationsEnum.OUEST:
                    ModelRover.Orientation = isRight ? OrientationsEnum.NORD : OrientationsEnum.SUD;
                    break;
            }
        }
        
    }
}

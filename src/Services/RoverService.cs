using Mars_Rover.src.Entities;
using Mars_Rover.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mars_Rover.src.Enum;

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
            ModelRover.Horizontal = x;
            ModelRover.Vertical = y;
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
                ModelRover.RotationAngle += angle;
            }

            ModelRover.SendState();

        }

        public void RotateRight90Degrees()
        {
            SetOrientationAfterRotation(true);

            ModelRover.RotationAngle += 90;

            ModelRover.SendState();
        }

        public void RotateLeft90Degrees()
        {
            SetOrientationAfterRotation(false);

            ModelRover.RotationAngle -= 90;

            ModelRover.SendState();
        }
        
        private void SetOrientationAfterRotation(bool isRight)
        {
            switch (ModelRover.Orientation)
            {
                case Enum.OrientationsEnum.NORD:
                    ModelRover.Orientation = isRight ? OrientationsEnum.EST : OrientationsEnum.OUEST;
                    break;
                case Enum.OrientationsEnum.SUD:
                    ModelRover.Orientation = isRight ? Enum.OrientationsEnum.OUEST : OrientationsEnum.EST;
                    break;
                case Enum.OrientationsEnum.EST:
                    ModelRover.Orientation = isRight ? Enum.OrientationsEnum.SUD : Enum.OrientationsEnum.NORD;
                    break;
                case Enum.OrientationsEnum.OUEST:
                    ModelRover.Orientation = isRight ? Enum.OrientationsEnum.NORD : Enum.OrientationsEnum.SUD;
                    break;
            }
        }
        
    }
}

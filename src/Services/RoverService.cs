using Mars_Rover.src.Entities;
using Mars_Rover.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            switch (ModelRover.Orientation)
            {
                case Enum.OrientationsEnum.NORD:
                    ModelRover.Orientation = Enum.OrientationsEnum.EST;
                    break;
                case Enum.OrientationsEnum.SUD:
                    ModelRover.Orientation = Enum.OrientationsEnum.OUEST;
                    break;
                case Enum.OrientationsEnum.EST:
                    ModelRover.Orientation = Enum.OrientationsEnum.SUD;
                    break;
                case Enum.OrientationsEnum.OUEST:
                    ModelRover.Orientation = Enum.OrientationsEnum.NORD;
                    break;
            }

            ModelRover.RotationAngle += 90;

            ModelRover.SendState();
        }

        public void RotateLeft90Degrees()
        {
            switch (ModelRover.Orientation)
            {
                case Enum.OrientationsEnum.NORD:
                    ModelRover.Orientation = Enum.OrientationsEnum.OUEST;
                    break;
                case Enum.OrientationsEnum.SUD:
                    ModelRover.Orientation = Enum.OrientationsEnum.EST;
                    break;
                case Enum.OrientationsEnum.EST:
                    ModelRover.Orientation = Enum.OrientationsEnum.NORD;
                    break;
                case Enum.OrientationsEnum.OUEST:
                    ModelRover.Orientation = Enum.OrientationsEnum.SUD;
                    break;
            }

            ModelRover.RotationAngle -= 90;

            ModelRover.SendState();
        }
    }
}

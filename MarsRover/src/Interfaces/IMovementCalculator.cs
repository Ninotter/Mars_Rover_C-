using Mars_Rover.Entities;
using Mars_Rover.src.Enum;

namespace Mars_Rover.src.Interfaces
{
    public interface IMovementCalculator
    {
        //Virer tuple
        public Position Forward(OrientationsEnum direction, double x, double y);
        public Position Backward(OrientationsEnum direction, double x, double y);
        public OrientationsEnum RotateToRightSide(OrientationsEnum currentOrientation);
        public OrientationsEnum RotateToLeftSide(OrientationsEnum currentOrientation);
    }
}
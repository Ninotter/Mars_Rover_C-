using Mars_Rover.src.Enum;

namespace Mars_Rover.src.Interfaces
{
    public interface IMovementCalculator
    {
        public (double x, double y) Forward(OrientationsEnum direction, double x, double y);
        public (double x, double y) Backward(OrientationsEnum direction, double x, double y);
        public OrientationsEnum RotateToRightSide(OrientationsEnum currentOrientation);
        public OrientationsEnum RotateToLeftSide(OrientationsEnum currentOrientation);
    }
}
using Mars_Rover.Entities;
namespace Mars_Rover.Interfaces
{
    public interface IMovementCalculator
    {
        public Position Forward(Position currentPosition);
        public Position Backward(Position currentPosition);
        public Position RotateToRightSide(Position currentPosition);
        public Position RotateToLeftSide(Position currentPosition);
    }
}
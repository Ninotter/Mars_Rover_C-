using Mars_Rover.Entities;

namespace Mars_Rover.Interfaces
{
    public interface IRover
    {
        public RoverState RotateToRightSide();
        public RoverState RotateToLeftSide();
        public RoverState GoForward();
        public RoverState GoBackward();
    }
}
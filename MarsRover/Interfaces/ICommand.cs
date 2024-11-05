using Mars_Rover.Entities;

namespace Mars_Rover.Interfaces
{
    public interface ICommand
    {
        public State RotateToRightSide();
        public State RotateToLeftSide();
        public State GoForward();
        public State GoBackward();
    }
}
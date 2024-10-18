using Mars_Rover.Entities;

namespace Mars_Rover.Interfaces
{
    public interface ICommand
    {
        public void RotateToRightSide();
        public void RotateToLeftSide();
        public void Avancer();
        public void Reculer();
        State SendState();
    }
}
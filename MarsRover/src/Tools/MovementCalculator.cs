using Mars_Rover.Entities;
using Mars_Rover.src.Interfaces;

namespace Mars_Rover.Tools
{
    public class MovementCalculator : IMovementCalculator
    {
        public Position Forward(Position currentPosition)
        {
            double x = currentPosition.Horizontal;
            double y = currentPosition.Vertical;
            switch (currentPosition.Orientation)
            {
                case Position.NORD:
                    y += 1;
                    break;
                case Position.EST:
                    x += 1;
                    break;
                case Position.SUD:
                    y -= 1;
                    break;
                case Position.OUEST:
                    x -= 1;
                    break;
            }

            return new(currentPosition.Orientation, x, y);
        }

        public Position Backward(Position currentPosition)
        {
            double x = currentPosition.Horizontal;
            double y = currentPosition.Vertical;
            switch (currentPosition.Orientation)
            {
                case Position.NORD:
                    y -= 1;
                    break;
                case Position.EST:
                    x -= 1;
                    break;
                case Position.SUD:
                    y += 1;
                    break;
                case Position.OUEST:
                    x += 1;
                    break;
            }

            return new(currentPosition.Orientation, x, y);
        }

        public Position RotateToRightSide(Position currentPosition)
        {
            return currentPosition.RotationHoraire();
        }

        public Position RotateToLeftSide(Position currentPosition)
        {
            return currentPosition.RotationAntiHoraire();
        }
    }
}

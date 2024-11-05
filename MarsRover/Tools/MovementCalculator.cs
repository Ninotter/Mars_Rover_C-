using Mars_Rover.Entities;
using Mars_Rover.Interfaces;

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
                case Position.NORTH:
                    y += 1;
                    break;
                case Position.EAST:
                    x += 1;
                    break;
                case Position.SOUTH:
                    y -= 1;
                    break;
                case Position.WEST:
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
                case Position.NORTH:
                    y -= 1;
                    break;
                case Position.EAST:
                    x -= 1;
                    break;
                case Position.SOUTH:
                    y += 1;
                    break;
                case Position.WEST:
                    x += 1;
                    break;
            }

            return new(currentPosition.Orientation, x, y);
        }

        public Position RotateToRightSide(Position currentPosition)
        {
            return currentPosition.ClockwiseRotation();
        }

        public Position RotateToLeftSide(Position currentPosition)
        {
            return currentPosition.CounterclockwiseRotation();
        }
    }
}

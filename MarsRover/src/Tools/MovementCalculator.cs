using Mars_Rover.Entities;
using Mars_Rover.src.Enum;
using Mars_Rover.src.Interfaces;

namespace Mars_Rover.Tools
{
    public class MovementCalculator : IMovementCalculator
    {
        public Position Forward(OrientationsEnum direction, double x, double y)
        {
            switch (direction)
            {
                case OrientationsEnum.NORD:
                    y += 1;
                    break;
                case OrientationsEnum.EST:
                    x += 1;
                    break;
                case OrientationsEnum.SUD:
                    y -= 1;
                    break;
                case OrientationsEnum.OUEST:
                    x -= 1;
                    break;
            }

            return new(x, y);
        }

        public Position Backward(OrientationsEnum direction, double x, double y)
        {
            switch (direction)
            {
                case OrientationsEnum.NORD:
                    y -= 1;
                    break;
                case OrientationsEnum.EST:
                    x -= 1;
                    break;
                case OrientationsEnum.SUD:
                    y += 1;
                    break;
                case OrientationsEnum.OUEST:
                    x += 1;
                    break;
            }

            return new(x, y);
        }

        public OrientationsEnum RotateToRightSide(OrientationsEnum currentOrientation)
        {
            switch (currentOrientation)
            {
                case OrientationsEnum.NORD:
                    return OrientationsEnum.EST;
                case OrientationsEnum.SUD:
                    return OrientationsEnum.OUEST;
                case OrientationsEnum.EST:
                    return OrientationsEnum.SUD;
                case OrientationsEnum.OUEST:
                    return OrientationsEnum.NORD;
                default:
                    return currentOrientation;
            }
        }

        public OrientationsEnum RotateToLeftSide(OrientationsEnum currentOrientation)
        {
            switch (currentOrientation)
            {
                case OrientationsEnum.NORD:
                    return OrientationsEnum.OUEST;
                case OrientationsEnum.SUD:
                    return OrientationsEnum.EST;
                case OrientationsEnum.EST:
                    return OrientationsEnum.NORD;
                case OrientationsEnum.OUEST:
                    return OrientationsEnum.SUD;
                default:
                    return currentOrientation;
            }
        }
    }
}

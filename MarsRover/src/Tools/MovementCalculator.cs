using Mars_Rover.src.Enum;

namespace Mars_Rover.Tools
{
    internal class MovementCalculator
    {
        public static (double x, double y) Forward(OrientationsEnum direction, double x, double y)
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

            return (x, y);
        }

        public static (double x, double y) Backward(OrientationsEnum direction, double x, double y)
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

            return (x, y);
        }

        public static OrientationsEnum RotateToRightSide(OrientationsEnum currentOrientation)
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

        public static OrientationsEnum RotateToLeftSide(OrientationsEnum currentOrientation)
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

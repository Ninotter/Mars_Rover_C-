namespace Mars_Rover.Entities
{
    public class Position
    {
        public const string NORD = "NORD";
        public const string EST = "EST";
        public const string SUD = "SUD";
        public const string OUEST = "OUEST";

        public string Orientation { get; } = NORD;
        public double Horizontal { get; } = 0;

        public double Vertical { get; } = 0;

        public Position()
        {
        }
        public Position(string orientation, double horizontal, double vertical)
        {
            Orientation = orientation;
            Horizontal = horizontal;
            Vertical = vertical;
        }

        public Position RotationHoraire()
        {
            switch (Orientation)
            {
                case NORD:
                    return new Position(EST, Horizontal, Vertical);
                case EST:
                    return new Position(SUD, Horizontal, Vertical);
                case SUD:
                    return new Position(OUEST, Horizontal, Vertical);
                case OUEST:
                    return new Position(NORD, Horizontal, Vertical);
                default:
                    return new Position(Orientation, Horizontal, Vertical);
            }
        }

        public Position RotationAntiHoraire()
        {
            switch (Orientation)
            {
                case NORD:
                    return new Position(OUEST, Horizontal, Vertical);
                case OUEST:
                    return new Position(SUD, Horizontal, Vertical);
                case SUD:
                    return new Position(EST, Horizontal, Vertical);
                case EST:
                    return new Position(NORD, Horizontal, Vertical);
                default:
                    return new Position(Orientation, Horizontal, Vertical);
            }
        }
    }
}
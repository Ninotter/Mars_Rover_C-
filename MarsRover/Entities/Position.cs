namespace Mars_Rover.Entities
{
    public class Position
    {
        public const string NORTH = "NORTH";
        public const string EAST = "EAST";
        public const string SOUTH = "SOUTH";
        public const string WEST = "WEST";

        public string Orientation { get; } = NORTH;
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

        public Position ClockwiseRotation()
        {
            switch (Orientation)
            {
                case NORTH:
                    return new Position(EAST, Horizontal, Vertical);
                case EAST:
                    return new Position(SOUTH, Horizontal, Vertical);
                case SOUTH:
                    return new Position(WEST, Horizontal, Vertical);
                case WEST:
                    return new Position(NORTH, Horizontal, Vertical);
                default:
                    return new Position(Orientation, Horizontal, Vertical);
            }
        }

        public Position CounterclockwiseRotation()
        {
            switch (Orientation)
            {
                case NORTH:
                    return new Position(WEST, Horizontal, Vertical);
                case WEST:
                    return new Position(SOUTH, Horizontal, Vertical);
                case SOUTH:
                    return new Position(EAST, Horizontal, Vertical);
                case EAST:
                    return new Position(NORTH, Horizontal, Vertical);
                default:
                    return new Position(Orientation, Horizontal, Vertical);
            }
        }
    }
}
namespace Mars_Rover.Entities
{
    public class State
    {
        public const string NORTH = "NORTH";
        public const string EAST = "EAST";
        public const string SOUTH = "SOUTH";
        public const string WEST = "WEST";

        public string Orientation { get; } = NORTH;
        public double Horizontal { get; } = 0;

        public double Vertical { get; } = 0;

        public State()
        {
        }

        public State(string orientation, double horizontal, double vertical)
        {
            this.Horizontal = horizontal;
            this.Vertical = vertical;
            this.Orientation = orientation;
        }

        public State ClockwiseRotation()
        {
            switch (Orientation)
            {
                case NORTH:
                    return new State(EAST, Horizontal, Vertical);
                case EAST:
                    return new State(SOUTH, Horizontal, Vertical);
                case SOUTH:
                    return new State(WEST, Horizontal, Vertical);
                case WEST:
                    return new State(NORTH, Horizontal, Vertical);
                default:
                    return new State(Orientation, Horizontal, Vertical);
            }
        }

        public State CounterclockwiseRotation()
        {
            switch (Orientation)
            {
                case NORTH:
                    return new State(WEST, Horizontal, Vertical);
                case WEST:
                    return new State(SOUTH, Horizontal, Vertical);
                case SOUTH:
                    return new State(EAST, Horizontal, Vertical);
                case EAST:
                    return new State(NORTH, Horizontal, Vertical);
                default:
                    return new State(Orientation, Horizontal, Vertical);
            }
        }

        public State Forward()
        {
            double x = Horizontal;
            double y = Vertical;
            switch (Orientation)
            {
                case NORTH:
                    y += 1;
                    break;
                case EAST:
                    x += 1;
                    break;
                case SOUTH:
                    y -= 1;
                    break;
                case WEST:
                    x -= 1;
                    break;
            }

            return new(Orientation, x, y);
        }

        public State Backward()
        {
            double x = Horizontal;
            double y = Vertical;
            switch (Orientation)
            {
                case NORTH:
                    y -= 1;
                    break;
                case EAST:
                    x -= 1;
                    break;
                case SOUTH:
                    y += 1;
                    break;
                case WEST:
                    x += 1;
                    break;
            }

            return new(Orientation, x, y);
        }
    }
}
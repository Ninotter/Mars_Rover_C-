namespace Mars_Rover.Entities
{
    public class RoverState
    {
        public const string NORTH = "NORTH";
        public const string EAST = "EAST";
        public const string SOUTH = "SOUTH";
        public const string WEST = "WEST";

        public string Orientation { get; } = NORTH;
        public double Horizontal { get; } = 0;

        public double Vertical { get; } = 0;

        public RoverState()
        {
        }

        public RoverState(string orientation, double horizontal, double vertical)
        {
            this.Horizontal = horizontal;
            this.Vertical = vertical;
            this.Orientation = orientation;
        }

        public RoverState ClockwiseRotation()
        {
            switch (Orientation)
            {
                case NORTH:
                    return new RoverState(EAST, Horizontal, Vertical);
                case EAST:
                    return new RoverState(SOUTH, Horizontal, Vertical);
                case SOUTH:
                    return new RoverState(WEST, Horizontal, Vertical);
                case WEST:
                    return new RoverState(NORTH, Horizontal, Vertical);
                default:
                    return new RoverState(Orientation, Horizontal, Vertical);
            }
        }

        public RoverState CounterclockwiseRotation()
        {
            switch (Orientation)
            {
                case NORTH:
                    return new RoverState(WEST, Horizontal, Vertical);
                case WEST:
                    return new RoverState(SOUTH, Horizontal, Vertical);
                case SOUTH:
                    return new RoverState(EAST, Horizontal, Vertical);
                case EAST:
                    return new RoverState(NORTH, Horizontal, Vertical);
                default:
                    return new RoverState(Orientation, Horizontal, Vertical);
            }
        }

        public RoverState Forward()
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

        public RoverState Backward()
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

        public override string ToString()
        {
            return $"Orientation : {Orientation} \n X : {Horizontal} \n Y : {Vertical}";
        }
    }
}
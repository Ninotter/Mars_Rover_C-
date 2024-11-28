namespace Mars_Rover.Entities
{
    public class RoverState
    {
        public const string NORTH = "NORTH";
        public const string EAST = "EAST";
        public const string SOUTH = "SOUTH";
        public const string WEST = "WEST";

        public string Orientation { get; } = NORTH;
        public int HorizontalX { get; } = 0;

        public int VerticalY { get; } = 0;

        public RoverState()
        {
        }

        public RoverState(string orientation, int horizontalX, int verticalY)
        {
            this.HorizontalX = horizontalX;
            this.VerticalY = verticalY;
            this.Orientation = orientation;
        }

        public RoverState ClockwiseRotation()
        {
            switch (Orientation)
            {
                case NORTH:
                    return new RoverState(EAST, HorizontalX, VerticalY);
                case EAST:
                    return new RoverState(SOUTH, HorizontalX, VerticalY);
                case SOUTH:
                    return new RoverState(WEST, HorizontalX, VerticalY);
                case WEST:
                    return new RoverState(NORTH, HorizontalX, VerticalY);
                default:
                    return new RoverState(Orientation, HorizontalX, VerticalY);
            }
        }

        public RoverState CounterclockwiseRotation()
        {
            switch (Orientation)
            {
                case NORTH:
                    return new RoverState(WEST, HorizontalX, VerticalY);
                case WEST:
                    return new RoverState(SOUTH, HorizontalX, VerticalY);
                case SOUTH:
                    return new RoverState(EAST, HorizontalX, VerticalY);
                case EAST:
                    return new RoverState(NORTH, HorizontalX, VerticalY);
                default:
                    return new RoverState(Orientation, HorizontalX, VerticalY);
            }
        }

        public RoverState Forward()
        {
            int x = HorizontalX;
            int y = VerticalY;
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
            int x = HorizontalX;
            int y = VerticalY;
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
            return $"Orientation : {Orientation} \n X : {HorizontalX} \n Y : {VerticalY}";
        }
    }
}
using Mars_Rover.src.Enum;

namespace Mars_Rover.Entities
{
    public class State
    {
        Position Position { get; }

        public OrientationsEnum RoverOrientation { get; } = OrientationsEnum.NORD;

        public State()
        {
        }

        public State(double horizontal, double vertical, OrientationsEnum orientation = OrientationsEnum.NORD)
        {
            Position = new Position(horizontal, vertical);
            RoverOrientation = orientation;
        }
    }
}
using Mars_Rover.src.Enum;

namespace Mars_Rover.Entities
{
    public class State
    {
        public double Horizontal { get; set; } = 0;

        public double Vertical { get; set; } = 0;

        public OrientationsEnum RoverOrientation { get; set; } = OrientationsEnum.NORD;

        public State()
        {
        }
        
        public State(double horizontal, double vertical, OrientationsEnum orientation = OrientationsEnum.NORD)
        {
            Horizontal = horizontal;
            Vertical = vertical;
            RoverOrientation = orientation;
        }
    }
}
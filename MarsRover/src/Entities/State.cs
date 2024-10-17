namespace Mars_Rover.src.Entities
{
    public class State
    {
        public double Horizontal { get; set; } = 0;
        
        public double Vertical { get; set; } = 0;
        
        public double RotationAngle {get; set;} = 0;
        
        public State(double horizontal, double vertical, double rotationAngle)
        {
            Horizontal = horizontal;
            Vertical = vertical;
            RotationAngle = rotationAngle;
        }
    }
}

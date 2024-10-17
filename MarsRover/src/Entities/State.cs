namespace Mars_Rover.src.Entities
{
    public class State
    {
        public double Horizontal { get; set; } = 0;
        
        public double Vertical { get; set; } = 0;
        
        public double RotationAngle {get; set;} = 0;
        private double rotationAngle = 0;
        public double RotationAngle {
            get { return rotationAngle; }
            set
            {
                if (value >= 360)
                {
                    rotationAngle = value - 360;
                }
                else if (value < 0)
                {
                    rotationAngle = 360 + value;
                }
                else
                {
                    rotationAngle = value;
                }
            }
        }
        
        public State(double horizontal, double vertical, double rotationAngle)
        {
            Horizontal = horizontal;
            Vertical = vertical;
            RotationAngle = rotationAngle;
        }
    }
}

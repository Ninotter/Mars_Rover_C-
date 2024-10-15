namespace Mars_Rover.src.Entities
{
    public class State
    {
        public double Horizontal { get; set; }
        
        public double Vertical { get; set; }
        
        private double rotationAngle;
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

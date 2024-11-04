namespace Mars_Rover.Entities
{
    public class Position
    {
        public double Horizontal { get; } = 0;

        public double Vertical { get; } = 0;
        public Position()
        {
        }
        public Position(double horizontal, double vertical)
        {
            Horizontal = horizontal;
            Vertical = vertical;
        }
    }
}

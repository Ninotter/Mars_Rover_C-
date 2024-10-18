namespace Mars_Rover.Entities
{
    public class Planet
    {
        public Planet(double size = Double.PositiveInfinity)
        {
            Size = size;
        }

        public double Size { get; }
    }
}
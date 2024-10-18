namespace Mars_Rover.Entities
{
    public class Planet
    {
        private const double MIN_PLANET_SIZE = 0;

        public Planet(double size = Double.PositiveInfinity)
        {
            Size = size;
        }

        public double Size { get; }

        public (double x, double y) CheckLimits(double x, double y)
        {
            if (x < MIN_PLANET_SIZE)
            {
                x = MIN_PLANET_SIZE - x - 1;
            }

            if (y < MIN_PLANET_SIZE)
            {
                y = MIN_PLANET_SIZE - y - 1;
            }

            if (x > this.Size)
            {
                x = (x - this.Size - 1);
            }

            if (y > this.Size)
            {
                y = (y - this.Size - 1);
            }

            return (x, y);
        }
    }
}
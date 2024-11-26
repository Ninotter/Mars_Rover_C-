namespace Topology.Planet
{
    public abstract class Planet
    {
        private const double MIN_PLANET_SIZE_XY = 0;
        protected double MinX { get; set; } = MIN_PLANET_SIZE_XY;
        protected double MinY { get; set; } = MIN_PLANET_SIZE_XY;
        protected double MaxX { get; set; }
        protected double MaxY { get; set; }
        
        protected List<Obstacle> Obstacles { get; set; } = new List<Obstacle>();

        public (double x, double y) CheckLimits(double x, double y)
        {
            if (x < MIN_PLANET_SIZE_XY)
            {
                x = MaxX - x - 1;
            }

            if (y < MIN_PLANET_SIZE_XY)
            {
                y = MaxY - y - 1;
            }

            if (x > this.MaxX)
            {
                x = (x - this.MaxX - 1);
            }

            if (y > this.MaxY)
            {
                y = (y - this.MaxY - 1);
            }

            return (x, y);
        }

        public void AddObstacle(Obstacle obstacle)
        {
            this.Obstacles.Add(obstacle);
        }

        public void AddMultipleObstacles(List<Obstacle> obstacles)
        {
            this.Obstacles.AddRange(obstacles);
        }
    }
}
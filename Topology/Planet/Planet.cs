namespace Topology.Planet
{
    public abstract class Planet
    {
        private const double MIN_PLANET_SIZE_XY = 0;
        protected double MinX { get; set; } = MIN_PLANET_SIZE_XY;
        protected double MinY { get; set; } = MIN_PLANET_SIZE_XY;
        protected int MaxX { get; set; }
        protected int MaxY { get; set; }
        public List<PlanetPoint> points = new List<PlanetPoint>();
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

        /// <summary>
        /// Check for an obstacle in the given position
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>True if there is an obstacle, false if there is none</returns>
        public bool CheckForObstacle(double x, double y)
        {
            return Obstacles.Any(o => o.position.x == x && o.position.y == y);
        }

        public void AddObstacle(Obstacle obstacle)
        {
            if (CheckValidityOfObstaclePosition(obstacle))
            {
                this.Obstacles.Add(obstacle);
            }
        }

        public void AddMultipleObstacles(List<Obstacle> obstacles)
        {
            List<Obstacle> newObstacles = new List<Obstacle>();
            foreach (var obstacle in obstacles)
            {
                CheckValidityOfObstaclePosition(obstacle);
                newObstacles.Add(obstacle);
            }

            this.Obstacles.AddRange(newObstacles);
        }

        public void SetPlanetPoints()
        {
            for (int i = 0; i <= MaxX; i++)
            {
                for (int j = 0; j <= MaxY; j++)
                {
                    foreach (var obstacle in Obstacles)
                    {
                        var isAvailable = obstacle.position != (j, i);
                        PlanetPoint point = new PlanetPoint(i, j, isAvailable);
                        points.Add(point);
                    }
                }
            }
        }

        public (int x, int y) GetPlanetLimits()
        {
            return (MaxX, MaxY);
        }

        public void GetPlanetPoint()
        {

            foreach (var point in points)
            {
                Console.WriteLine(point.x + " " + point.y + " " + point.isAvailable);
            }

            //return pointToDisplay;
        }

        private bool CheckValidityOfObstaclePosition(Obstacle obstacle)
        {
            var isObstaclePositionValid = false;
            if (Obstacles.Count > 0)
            {
                foreach (var existingObstacle in Obstacles)
                {
                    isObstaclePositionValid = obstacle.position.x == existingObstacle.position.x &&
                                              obstacle.position.y == existingObstacle.position.y;
                }
            }

            return isObstaclePositionValid;
        }
    }
}
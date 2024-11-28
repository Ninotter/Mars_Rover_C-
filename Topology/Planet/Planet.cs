namespace Topology.Planet
{
    public abstract class Planet
    {
        private const int MIN_PLANET_SIZE_XY = 0;
        protected int MinX { get; set; } = MIN_PLANET_SIZE_XY;
        protected int MinY { get; set; } = MIN_PLANET_SIZE_XY;
        protected int MaxHorizontalX { get; set; }
        protected int MaxVerticalY { get; set; }
        public List<PlanetPoint> points = new List<PlanetPoint>();
        protected List<Obstacle> Obstacles { get; set; } = new List<Obstacle>();

        public (int x, int y) CheckLimits(int x, int y)
        {
            if (x < MIN_PLANET_SIZE_XY)
            {
                x = MaxHorizontalX - x - 1;
            }

            if (y < MIN_PLANET_SIZE_XY)
            {
                y = MaxVerticalY - y - 1;
            }

            if (x > this.MaxHorizontalX)
            {
                x = (x - this.MaxHorizontalX - 1);
            }

            if (y > this.MaxVerticalY)
            {
                y = (y - this.MaxVerticalY - 1);
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
            return Obstacles.Any(o => o.position.horizontalX == x && o.position.verticalY == y);
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
            for (int j = MaxVerticalY; j >=0 ; j--)
            {
            for (int i = 0; i <= MaxHorizontalX; i++)
            {
                    var isAvailable = true;
                    PlanetPoint point = new PlanetPoint(i, j, isAvailable);
                    foreach (var obstacle in Obstacles)
                    {
                        if ((i, j) == obstacle.position)
                        {
                            point.isAvailable = false;   
                        }
                    }
                    points.Add(point);
                }
            }
        }

        public (int x, int y) GetPlanetLimits()
        {
            return (MaxHorizontalX, MaxVerticalY);
        }

        public void GetPlanetPoint()
        {

            foreach (var point in points)
            {
                Console.WriteLine(point.HorizontalX + " " + point.VerticalY + " " + point.isAvailable);
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
                    isObstaclePositionValid = obstacle.position.horizontalX == existingObstacle.position.horizontalX &&
                                              obstacle.position.verticalY == existingObstacle.position.verticalY;
                }
            }

            return isObstaclePositionValid;
        }
    }
}
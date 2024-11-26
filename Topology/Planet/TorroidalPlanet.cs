namespace Topology.Planet
{
    public class TorroidalPlanet : Planet
    {
        public TorroidalPlanet(double maxX, double maxY)
        {
            MaxX = maxX;
            MaxY = maxY;
        }

        public TorroidalPlanet(double maxX, double maxY, List<Obstacle> obstacles)
        {
            MaxX = maxX;
            MaxY = maxY;
            Obstacles = obstacles;
        } 
    }
}

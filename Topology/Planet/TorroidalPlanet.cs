namespace Topology.Planet
{
    public class TorroidalPlanet : Planet
    {
        public TorroidalPlanet(int maxX, int maxY)
        {
            MaxX = maxX;
            MaxY = maxY;
            SetPlanetPoints();
        }

        public TorroidalPlanet(int maxX, int maxY, List<Obstacle> obstacles)
        {
            MaxX = maxX;
            MaxY = maxY;
            Obstacles = obstacles;
            SetPlanetPoints();
        } 
    }
}

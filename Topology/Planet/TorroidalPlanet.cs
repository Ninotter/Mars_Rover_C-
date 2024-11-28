namespace Topology.Planet
{
    public class TorroidalPlanet : Planet
    {
        public TorroidalPlanet(int maxHorizontalHorizontalX, int maxVerticalVerticalY)
        {
            MaxHorizontalX = maxHorizontalHorizontalX;
            MaxVerticalY = maxVerticalVerticalY;
            SetPlanetPoints();
        }

        public TorroidalPlanet(int maxHorizontalHorizontalX, int maxVerticalVerticalY, List<Obstacle> obstacles)
        {
            MaxHorizontalX = maxHorizontalHorizontalX;
            MaxVerticalY = maxVerticalVerticalY;
            Obstacles = obstacles;
            SetPlanetPoints();
        } 
    }
}

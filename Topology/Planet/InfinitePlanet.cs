namespace Topology.Planet
{
    public class InfinitePlanet : Planet
    {
        public InfinitePlanet()
        {
            MaxX = Int32.MaxValue;
            MaxY = Int32.MaxValue;
            MinX = double.NegativeInfinity;
            MinY = double.NegativeInfinity;
            SetPlanetPoints();
        }

        public InfinitePlanet(List<Obstacle> obstacles)
        {
            MaxX = Int32.MaxValue;
            MaxY = Int32.MaxValue;
            MinX = double.NegativeInfinity;
            MinY = double.NegativeInfinity;
            Obstacles = obstacles;
            SetPlanetPoints();
        }
    }
}

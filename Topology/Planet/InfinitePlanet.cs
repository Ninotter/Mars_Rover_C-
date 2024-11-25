namespace Topology.Planet
{
    public class InfinitePlanet : Planet
    {
        public InfinitePlanet()
        {
            MaxX = double.PositiveInfinity;
            MaxY = double.PositiveInfinity;
            MinX = double.NegativeInfinity;
            MinY = double.NegativeInfinity;
        }
    }
}

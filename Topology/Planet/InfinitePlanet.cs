namespace Topology.Planet
{
    internal class InfinitePlanet : Planet
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

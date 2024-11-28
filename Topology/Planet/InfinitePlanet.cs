namespace Topology.Planet
{
    public class InfinitePlanet : Planet
    {
        public InfinitePlanet()
        {
            MaxHorizontalX = Int32.MaxValue;
            MaxVerticalY = Int32.MaxValue;
            MinX = Int32.MinValue;
            MinY = Int32.MinValue;
        }
    }
}

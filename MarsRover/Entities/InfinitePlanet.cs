namespace Mars_Rover.Entities
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

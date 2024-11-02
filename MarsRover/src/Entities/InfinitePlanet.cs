using Mars_Rover.Entities;

namespace Mars_Rover.src.Entities
{
    public class InfinitePlanet : Planet
    {
        public InfinitePlanet()
        {
            this.MaxX = double.PositiveInfinity;
            this.MaxY = double.PositiveInfinity;
            this.MinX = double.NegativeInfinity;
            this.MinY = double.NegativeInfinity;
        }
    }
}

using Mars_Rover.Entities;

namespace Mars_Rover.src.Entities
{
    public class TorroidalPlanet : Planet
    {
        public TorroidalPlanet(double maxX, double maxY)
        {
            this.MaxX = maxX;
            this.MaxY = maxY;
        }
    }
}

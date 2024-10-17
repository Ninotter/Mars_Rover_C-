using Mars_Rover.src.Entities;
using Mars_Rover.src.Enum;
using Mars_Rover.src.Interfaces;

namespace Mars_Rover.src.Services
{
    public class VehicleService : IRotation, IMouvement
    {
        private const double MIN_PLANET_SIZE = 0;

        protected Vehicle VehicleModel { get; set; } 

        protected Planet PlanetModel { get; set; }

        public VehicleService(Rover rover, Planet planet)
        {
            VehicleModel = rover;
            PlanetModel = planet;
        }
    }
}
using Mars_Rover.Entities;
using Mars_Rover.src.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverTest
{
    internal static class RoverBuilder
    {
        public static Rover CreateBuilder()
        {
            return new Rover();
        }

        public static Rover WithPlanetSize(this Rover rover, double size)
        {
            rover.Planet = new Planet(size);
            return rover;
        }

        public static Rover WithState(this Rover rover, double horizontal, double vertical, OrientationsEnum orientation)
        {
            rover.VehicleState = new State(horizontal, vertical, orientation);
            return rover;
        }

        public static Rover WithState(this Rover rover, State state)
        {
            rover.VehicleState = state;
            return rover;
        }

        public static Rover WithPlanet(this Rover rover, Planet planet)
        {
            rover.Planet = planet;
            return rover;
        }

        public static Rover Build(this Rover rover)
        {
            return rover;
        }
    }
}

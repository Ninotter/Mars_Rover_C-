using Mars_Rover.Entities;
using Mars_Rover.Interfaces;
using Mars_Rover.Tools;

namespace RoverTest
{
    internal class RoverBuilder
    {
        private State state = new State();
        private Planet planet = new InfinitePlanet();
        private IMovementCalculator movementCalculator = new MovementCalculator();

        public static RoverBuilder CreateBuilder()
        {
            return new RoverBuilder();
        }

        public RoverBuilder AddPlanet(Planet planet)
        {
            this.planet = planet;
            return this;
        }

        public RoverBuilder AddTorroidalPlanet(double xy)
        {
            this.planet = new TorroidalPlanet(xy, xy);
            return this;
        }

        public RoverBuilder AddTorroidalPlanet(double x, double y)
        {
            this.planet = new TorroidalPlanet(x, y);
            return this;
        }

        public RoverBuilder AddInfinitePlanet()
        {
            this.planet = new InfinitePlanet();
            return this;
        }

        public RoverBuilder AddState(State state)
        {
            this.state = state;
            return this;
        }

        public RoverBuilder AddState(double horizontal, double vertical, string orientation = Position.NORTH)
        {
            this.state = new State(horizontal, vertical, orientation);
            return this;
        }

        public RoverBuilder AddMovementCalculator(IMovementCalculator movementCalculator)
        {
            this.movementCalculator = movementCalculator;
            return this;
        }

        public Rover Build()
        {
            return new Rover(state, movementCalculator, planet);
        }
    }
}

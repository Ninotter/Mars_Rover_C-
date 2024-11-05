using Mars_Rover.Entities;

namespace RoverTest
{
    internal class RoverBuilder
    {
        private State state = new State();
        private Planet planet = new InfinitePlanet();

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

        public RoverBuilder AddState(double horizontal, double vertical, string orientation = State.NORTH)
        {
            this.state = new State(orientation, horizontal, vertical);
            return this;
        }

        public Rover Build()
        {
            return new Rover(state, planet);
        }
    }
}

using Mars_Rover.Entities;
using Topology;
using Topology.Planet;

namespace RoverTest
{
    internal class RoverBuilder
    {
        private RoverState _roverState = new RoverState();
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

        public RoverBuilder AddTorroidalPlanet(int xy)
        {
            this.planet = new TorroidalPlanet(xy, xy);
            return this;
        }

        public RoverBuilder AddTorroidalPlanetWithObstacles(int xy, params Obstacle[] obstacles)
        {
            var listObstacles = new List<Obstacle>(obstacles);
            this.planet = new TorroidalPlanet(xy, xy, listObstacles);
            return this;
        }

        public RoverBuilder AddTorroidalPlanet(int x, int y)
        {
            this.planet = new TorroidalPlanet(x, y);
            return this;
        }

        public RoverBuilder AddInfinitePlanet()
        {
            this.planet = new InfinitePlanet();
            return this;
        }

        public RoverBuilder AddInfinitePlanetWithObstacles(params Obstacle[] obstacles)
        {
            var listObstacles = new List<Obstacle>(obstacles);
            this.planet = new InfinitePlanet(listObstacles);
            return this;
        }

        public RoverBuilder AddState(RoverState roverState)
        {
            this._roverState = roverState;
            return this;
        }

        public RoverBuilder AddState(int horizontal, int vertical, string orientation = RoverState.NORTH)
        {
            this._roverState = new RoverState(orientation, horizontal, vertical);
            return this;
        }

        public Rover Build()
        {
            return new Rover(_roverState, planet);
        }
    }
}

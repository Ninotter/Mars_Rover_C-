using Mars_Rover.Entities;
using Mars_Rover.server;
using Mars_Rover.Tools;
using Topology.Planet;

namespace Mars_Rover;

public class MainMarsRover
{
    static void Main(string[] args)
    {
        RoverListener roverListener = new RoverListener();
        Interpreter.CreateRover(new InfinitePlanet());
        roverListener.Subscribe((action) =>
        {
            Console.WriteLine(action);
            State state = Interpreter.Send(action);
            Console.WriteLine(state);
        });
        roverListener.CreateServer("127.0.0.1", 8080);
    }
}
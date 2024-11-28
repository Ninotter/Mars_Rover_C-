using Mars_Rover.Entities;
using Topology.Planet;

namespace Mars_Rover.Tools;

public static class Interpreter
{
    private static Rover _rover;
    public const string FORWARD = "F";
    public const string BACKWARD = "B";
    public const string LEFT = "L";
    public const string RIGHT = "R";

    public static RoverState Send(string command) => SetStateFromCommand(command);

    private static RoverState SetStateFromCommand(string command)
    {
        switch (command)
        {
            case FORWARD:
                _rover.GoForward();
                break;
            case BACKWARD:
                _rover.GoBackward();
                break;
            case LEFT:
                _rover.RotateToLeftSide();
                break;
            case RIGHT:
                _rover.RotateToRightSide();
                break;
            default: Console.WriteLine($"Commande inconnue: {command} " +
                                       $"\n " +
                                       $"Entrez une commande valide");
                break;
        }

        return _rover.VehicleRoverState;
    }

    public static Rover CreateRoverWithPlanet(Planet planet)
    {
        if (_rover == null)
        {
            _rover = new Rover(planet);
        }

        return _rover;
    }
    
    public static Rover CreateRover(Rover rover)
    {
        if (_rover == null)
        {
            _rover = rover;
        }

        return _rover;
    }

    public static Rover GetRover() => _rover;

    public static RoverState GetRoverState()
    {
        return _rover.VehicleRoverState;
    }
}
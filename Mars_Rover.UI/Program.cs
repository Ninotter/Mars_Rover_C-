using System.Text;
using Mars_Rover.Entities;
using Mars_Rover.Tools;
using System.Text;
using Topology;
using Topology.Planet;

namespace Mars_Rover.UI;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        List<Obstacle> obstacles = new List<Obstacle>();
        obstacles.Add(new Obstacle((4, 3)));
        obstacles.Add(new Obstacle((4, 8)));
        obstacles.Add(new Obstacle((3, 2)));
        Rover rover = new Rover(
            new RoverState(RoverState.NORTH, 3, 6),
            new TorroidalPlanet(10, 10, obstacles));
        Interpreter.CreateRover(rover);
        Cartes cartes = new Cartes(
            rover);
        Console.Write(cartes.DisplayCard());

        while (true)
        {
            var newInput = Console.ReadKey();
            string input = ArrowKeysControl.KeyToCommand(newInput.Key);
            if (newInput != null)
            {
                rover.VehicleRoverState = Interpreter.Send(input);
            }

            Console.WriteLine(cartes.RefreshCard(rover));

        }
    }
}
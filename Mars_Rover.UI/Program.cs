using System.Text;
using Mars_Rover.Entities;
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
        //obstacles.Add(new Obstacle((4, 3)));
        //obstacles.Add(new Obstacle((3, 2)));
        Rover rover = new Rover(
            new RoverState(RoverState.NORTH, 3, 6),
            new TorroidalPlanet(5, 10, obstacles));
        Cartes cartes = new Cartes(
            rover);
        Console.Write(cartes.DisplayCard());
        
        
        
        Console.WriteLine();
        rover.GoForward();
        Cartes cartes2 = new Cartes(rover);
        Console.Write(cartes2.DisplayCard());
        
        Console.WriteLine();
        
        rover.RotateToLeftSide();
        Cartes cartes3 = new Cartes(rover);
        Console.Write(cartes3.DisplayCard());
        
        Console.WriteLine();
        
        rover.GoForward();
        Cartes cartes4 = new Cartes(rover);
        Console.Write(cartes4.DisplayCard());
    }
}
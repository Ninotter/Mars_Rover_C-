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
        obstacles.Add(new Obstacle((3, 3)));
        obstacles.Add(new Obstacle((4, 3)));
        obstacles.Add(new Obstacle((3, 2)));
        Cartes cartes = new Cartes(new TorroidalPlanet(10, 5, obstacles));
        Console.Write(cartes.DisplayCard());
    }
}
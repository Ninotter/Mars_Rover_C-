using System.Text;
using Mars_Rover.Entities;
using Topology.Planet;

namespace Mars_Rover.UI;

public class Cartes
{
    private Rover _rover;
    private Planet _planet;
    private (int x, int y) _coordinates;

    public Cartes(Rover rover)
    {
        _rover = rover;
        _planet = _rover.Planet;
        _coordinates = _planet.GetPlanetLimits();
    }

    public string DisplayCard()
    {
        var builder = new StringBuilder();
        var verticalLimit = _coordinates.y + 1;
        var horizontalLimit = _coordinates.x + 1;
        for (var i = 0; i < _planet.points.Count; i++)
        {
            var point = _planet.points[i];
            if (horizontalLimit > 0)
            {
                if (_rover.VehicleRoverState.HorizontalX == point.HorizontalX && _rover.VehicleRoverState.VerticalY == point.VerticalY)
                {
                    switch (_rover.VehicleRoverState.Orientation)
                    {
                        case RoverState.NORTH :
                            builder.Append(CarteSymboles.NORTH_ORIENTATION);
                            break;
                        case RoverState.EAST :
                            builder.Append(CarteSymboles.EAST_ORIENTATION);
                            break;
                        case RoverState.SOUTH :
                            builder.Append(CarteSymboles.SOUTH_ORIENTATION);
                            break;
                        case RoverState.WEST :
                            builder.Append(CarteSymboles.WEST_ORIENTATION);
                            break;
                    }
                    point.isDiscovered = true;
                    horizontalLimit--;
                }
                else
                {
                    if (point.isDiscovered)
                    {
                        builder.Append(point.isAvailable ? CarteSymboles.CASE_DISCOVERED : CarteSymboles.OBSTACLE);
                    }
                    else
                    {
                        builder.Append(CarteSymboles.CASE_TO_DISCOVER);
                    }
                    
                    horizontalLimit--;
                }
            }
            if (horizontalLimit == 0){
                builder.AppendLine();
                horizontalLimit = _coordinates.x + 1;
                verticalLimit--;
            }
            
        }
        return builder.ToString();
    }

    public string RefreshCard(Rover rover)
    {
        _rover = rover;
        return DisplayCard();
    }
}
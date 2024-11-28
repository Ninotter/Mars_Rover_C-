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
        var columnLimitY = 0;
        var totalRow = 0;
        for (var i = 0; i < _planet.points.Count; i++)
        {
            var point = _planet.points[i];
            if (totalRow < _coordinates.x + 1)
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
                    columnLimitY++;
                }
                else
                {
                    builder.Append(point.isAvailable ? CarteSymboles.CASE_TO_DISCOVER : CarteSymboles.OBSTACLE);
                    columnLimitY++;
                }
            }
            if (columnLimitY == _coordinates.y + 1 ){
                builder.AppendLine();
                columnLimitY = 0;
                totalRow++;
            }
            
        }
        return builder.ToString();
    }
}
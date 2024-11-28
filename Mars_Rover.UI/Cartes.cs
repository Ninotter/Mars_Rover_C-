using System.Text;
using Topology.Planet;

namespace Mars_Rover.UI;

public class Cartes
{
    private Planet _planet;
    private (int x, int y) _coordinates;

    public Cartes(Planet planet)
    {
        _planet = planet;
        _coordinates = _planet.GetPlanetLimits();
    }

    public string DisplayCard()
    {
        var builder = new StringBuilder();
        var cardLimitX = 0;
        var totalRow = 0;
        
        foreach (var point in _planet.points)
        {
            if (cardLimitX < _coordinates.x && totalRow < _coordinates.x)
            {
                builder.Append(point.isAvailable ? CarteSymboles.CASE_TO_DISCOVER : CarteSymboles.OBSTACLE);
                cardLimitX++;
            }
            else
            {
                builder.AppendLine();
                cardLimitX = 0;
                totalRow++;
            }
        }
        return builder.ToString();
    }
}
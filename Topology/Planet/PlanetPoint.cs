namespace Topology.Planet;

public class PlanetPoint
{
    public int HorizontalX;
    public int VerticalY;
    public bool isAvailable {get;set;}

    public PlanetPoint(int horizontalX, int verticalY, bool isAvailable)
    {
        this.HorizontalX = horizontalX;
        this.VerticalY = verticalY;
        this.isAvailable = isAvailable;
    }
    
    public PlanetPoint(int horizontalX, int verticalY)
    {
        this.HorizontalX = horizontalX;
        this.VerticalY = verticalY;
    }
}
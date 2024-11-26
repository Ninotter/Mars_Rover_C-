namespace Topology.Planet;

public class PlanetPoint
{
    public int x;
    public int y;
    public bool isAvailable {get;set;}

    public PlanetPoint(int x, int y, bool isAvailable)
    {
        this.x = x;
        this.y = y;
        this.isAvailable = isAvailable;
    }
    
    public PlanetPoint(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}
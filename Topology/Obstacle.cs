namespace Topology;

public class Obstacle
{
    public (int x, int y) position { get;}

    public Obstacle((int x, int y) position)
    {
        this.position = position;
    }
}
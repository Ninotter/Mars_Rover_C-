namespace Topology;

public class Obstacle
{
    public (int horizontalX, int verticalY) position { get;}

    public Obstacle((int horizontalX, int verticalY) position)
    {
        this.position = position;
    }
}
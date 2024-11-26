namespace Mars_Rover.UI;

public class Cartes
{
    private int maxX;
    private int maxY;

    public Cartes(int x, int y)
    {
        maxX = x;
        maxY = y;
    }

    public void DisplayCard()
    {
        var xDisplay = "";
        for (int i = 0; i < maxX; i++)
        {
            xDisplay += Carte_Symboles.OBSTACLE;
        }

        for (int y = 0; y < maxY; y++)
        {
            Console.WriteLine(xDisplay);
        }
    }
}
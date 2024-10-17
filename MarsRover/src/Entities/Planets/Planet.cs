namespace Mars_Rover.src.Entities
{
    public abstract class Planet
    {
        public Planet(int size)
        {
            Size = size;
        }
        public int Size { get; }
    }
}
namespace Mars_Rover.Entities
{
    public class State
    {
        public Position Position { get; } = new Position();

        public State()
        {
        }

        public State(double horizontal, double vertical, string orientation = Mars_Rover.Entities.Position.NORTH)
        {
            Position = new Position(orientation, horizontal, vertical);
        }
    }
}
using Mars_Rover.Tools;

namespace Mars_Rover.UI
{
    internal static class ArrowKeysControl
    {
        public static string KeyToCommand(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    return Interpreter.FORWARD;
                case ConsoleKey.DownArrow:
                    return Interpreter.BACKWARD;
                case ConsoleKey.LeftArrow:
                    return Interpreter.LEFT;
                case ConsoleKey.RightArrow:
                    return Interpreter.RIGHT;
                default:
                    return string.Empty;
            }
        }
    }
}

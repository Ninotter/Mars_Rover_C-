using Mars_Rover.MissionControl;

namespace MissionControl
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var comm = new MissionControlCommunication();

            await comm.ConnectAsync("127.0.0.1", 8080);

            bool isAlive = true;

            Console.WriteLine("Envoyer des commandes au rover");

            while (isAlive)
            {
                string action = Console.ReadLine() ?? "null";
                await comm.SendCommandAsync(action);

                if (action.Equals("exit"))
                {
                    isAlive = false;
                    await comm.DisconnectAsync();
                }
            }
        }
    }
}
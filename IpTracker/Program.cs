using System;

namespace IpTracker
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Random rnd = new Random();
            IPInfo info = null;
            string ip = string.Empty;

            while (ip != ConsoleKey.Q.ToString())
            {
                Console.ResetColor();
                Console.WriteLine("Enter an ip(Enter for a random one, q for exit): ");
                ip = Console.ReadLine();

                if (ip == "q" || ip == "Q")
                {
                    break;
                }

                if (Tracker.IsValid(ip))
                {
                    info = await Tracker.Track(ip);
                }
                else
                {
                    string randomIp = $"{rnd.Next(128, 191)}.{rnd.Next(10, 100)}.{rnd.Next(1, 200)}.{rnd.Next(0, 226)}";
                    info = await Tracker.Track(randomIp);
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"Invalid or null IP entered. Using random IP: {randomIp}");
                    Console.ResetColor();
                }

                Console.WriteLine(info);

            }
        }
    }
}
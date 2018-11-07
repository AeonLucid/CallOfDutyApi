using System;
using System.Linq;
using System.Threading.Tasks;
using CallOfDutyApi;
using CallOfDutyApi.Data;

namespace CallOfDuty
{
    internal class Program
    {
        public static async Task Main()
        {
            Console.Title = "CallOfDuty";
            Console.ForegroundColor = ConsoleColor.White;

            await DoStuff();

            Console.WriteLine("Finished.");
            Console.ReadKey();
        }

        private static async Task DoStuff()
        {
            using (var client = new CallOfDutyClient(Environment.GetEnvironmentVariable("TRN_KEY")))
            {
                Console.WriteLine("Looking up player ids..");
                var players = new[]
                {
                    "AeonLucid#2662"
                };

                foreach (var player in players)
                {
                    Console.WriteLine($"Looking up {player}");

                    var response = await client.FindPlayerAsync(Game.Bo4, Platform.BattleNet, player);
                    var ratio = response.Stats.First(x => x.Metadata.Key == "KDRatio");

                    Console.WriteLine($"> The user {player} has a KD Ratio of {ratio.DisplayValue}.");
                }
            }
        }
    }
}
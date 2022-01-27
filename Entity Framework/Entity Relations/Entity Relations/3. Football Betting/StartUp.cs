
using System;
using P03_FootballBetting.Data;

namespace _3._Football_Betting
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            FootballBettingContext dbContext = new FootballBettingContext();

            dbContext.Database.EnsureCreated();

            Console.WriteLine("DB created successfully");

            dbContext.Database.EnsureDeleted();
        }
    }
}

using System;
using ConsoleApp1.Classes;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Random rd = new Random();

            Warrior warrior1 = new Dwarf("Nain", rd.Next(70, 120), rd.Next(1, 6), rd.Next(1, 3));
            Warrior warrior2 = new Elf("Elfe", rd.Next(50, 100), rd.Next(1, 6), rd.Next(1, 6));

            warrior1.GetInfos();
            warrior2.GetInfos();

            while (warrior1.IsAlive &&  warrior2.IsAlive)
            {
                warrior2.TakeDamage(warrior1.NumberOfAttacks);
                if (warrior2.IsAlive)
                {
                    warrior1.TakeDamage(warrior2.NumberOfAttacks);
                }
            }*/

            Random rd = new Random();
            int numberPlayersTeam = 2;

            Team team1 = new Team(rd, "Bleue", ConsoleColor.Blue, numberPlayersTeam);
            Team team2 = new Team(rd, "Verte", ConsoleColor.Green, numberPlayersTeam);

            team1.GetInfos();
            team2.GetInfos();

            while (!team1.CheckGameOver() && !team2.CheckGameOver())
            {
                team1.PlayTurn(team2);
                team2.PlayTurn(team1);
            }
        }
    }
}

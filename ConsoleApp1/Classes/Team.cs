using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Classes
{
    internal class Team
    {
        // Champs privés
        private string name;
        private ConsoleColor teamColor;
        private int numberOfPlayers;
        private List<Warrior> warriors;

        // Constructeur
        public Team(Random rd, string name, ConsoleColor teamColor, int numberOfPlayers)
        {
            Name = name;
            this.teamColor = teamColor;
            NumberOfPlayers = numberOfPlayers;
            warriors = new List<Warrior>();

            for (int i = 0; i < numberOfPlayers; i++)
            {
                int selectedCharacter = rd.Next(0, 3);

                if (selectedCharacter == 0)
                {
                    Warrior w = new Warrior($"Team {Name} - Guerrier_{i}", rd.Next(110, 151), rd.Next(1, 7));
                    warriors.Add(w);
                }
                else if (selectedCharacter == 1)
                {
                    Warrior w = new Dwarf($"Team {Name} - Nain_{i}", rd.Next(70, 121), rd.Next(1, 7), rd.Next(1, 4));
                    warriors.Add(w);
                }
                else if (selectedCharacter == 2)
                {
                    Warrior w = new Elf($"Team {Name} - Elfe_{i}", rd.Next(50, 101), rd.Next(1, 7), rd.Next(1, 7));
                    warriors.Add(w);
                }
            }
        }

        // Propriétés
        public string Name
        {
            get { return name; }
            private set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    name = value;
                }
                else
                {
                    throw new ArgumentException("Le nom ne peut pas être vide.");
                }
            }
        }

        public int NumberOfPlayers
        {
            get { return numberOfPlayers; }
            private set {
                if (value > 0)
                {
                    numberOfPlayers = value;
                }
                else
                {
                    throw new ArgumentException("Le nombre de joueurs doit forcément être supérieur 0 !");
                }
            }
        }

        // Méthodes
        public void PlayTurn(Team otherTeam)
        {
            Console.ForegroundColor = teamColor;
            Console.WriteLine($"\nL'équipe {Name} joue :");
            Console.ResetColor();

            foreach (Warrior warrior in warriors)
            {
                if (warrior.IsAlive)
                {
                    foreach (Warrior otherWarrior in otherTeam.warriors)
                    {
                        if (otherWarrior.IsAlive)
                        {
                            otherWarrior.TakeDamage(warrior.NumberOfAttacks);
                            break;
                        }
                    }
                }
            }
        }

        public void GetInfos()
        {
            Console.WriteLine($"\nL'équipe {Name} compte {NumberOfPlayers} joueurs :");

            Console.ForegroundColor = teamColor;
            foreach (var warrior in warriors)
            {
                Console.Write("  - ");
                warrior.GetInfos();
            }
            Console.ResetColor();
        }

        public bool CheckGameOver()
        {
            int numberDeath = 0;
            foreach (var w in warriors)
            {
                if (!w.IsAlive) numberDeath += 1;
            }

            if (numberDeath == NumberOfPlayers)
            {
                Console.ForegroundColor = teamColor;
                Console.WriteLine($"{Name} a perdu, tous ses joueurs sont morts !\n");
                Console.ResetColor();

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

using System;

namespace ConsoleApp1
{
    internal class Dwarf : Warrior
    {
        // Champs privés
        private int numberOfShield;

        // Constructeur
        public Dwarf(string name, int hp, int numberOfAttacks, int numberOfShield)
            : base(name, hp, numberOfAttacks)
        {
            NumberOfShield = numberOfShield;
        }

        // Propriétés
        public int NumberOfShield
        {
            get { return numberOfShield; }
            private set { numberOfShield = value; }
        }

        // Méthodes
        public override void GetInfos()
        {
            Console.WriteLine($"{Name} possède {NumberOfAttacks} attaques, {Hp} pv et {NumberOfShield} points d'armure !\n");
        }

        public override void TakeDamage(int damage)
        {
            int newDamage = damage - NumberOfShield;

            if (Hp - newDamage > 0)
            {
                if (newDamage > 0)
                {
                    Hp -= newDamage;
                    Console.WriteLine($"{Name} a perdu {newDamage} pv, il lui reste actuellement {Hp} pv !\n");
                } else
                {
                    Console.WriteLine($"{Name} n'a perdu aucun pv !\n");
                }
            }
            else
            {
                IsAlive = false;
                Console.WriteLine($"{Name} est mort !");
            }
        }
    }
}

using System;

namespace ConsoleApp1
{
    internal class Elf: Warrior
    {
        // Champs privés
        private int numberOfBonus;

        // Constructeur
        public Elf(string name, int hp, int numberOfAttacks, int numberOfBonus)
            : base(name, hp, numberOfAttacks)
        {
            NumberOfBonus = numberOfBonus;
        }

        // Propriétés
        public int NumberOfBonus
        {
            get { return numberOfBonus; }
            set { numberOfBonus = value; }
        }

        public override int NumberOfAttacks {
            get => base.NumberOfAttacks + NumberOfBonus;
            protected set => base.NumberOfAttacks = value;
        }

        // Méthodes
        public override void GetInfos()
        {
            Console.WriteLine($"{Name} possède {base.NumberOfAttacks} attaques, {Hp} pv et {NumberOfBonus} points d'attaque supplémentaires !");
        }
    }
}

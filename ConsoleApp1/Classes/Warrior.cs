using System;

namespace ConsoleApp1
{
    internal class Warrior
    {
        // Champs privés
        private string name;
        private int hp;
        private int numberOfAttacks;
        private bool isAlive = true;

        // Constructeur
        public Warrior(string name, int hp, int numberOfAttacks)
        {
            Name = name;
            Hp = hp;
            NumberOfAttacks = numberOfAttacks;
        }

        // Propriétés
        public bool IsAlive
        {
            get { return isAlive; }
            protected set { isAlive = value; }
        }

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

        public int Hp
        {
            get { return hp; }
            protected set
            {
                if (value > 0)
                {
                    hp = value;
                }
                else
                {
                    throw new ArgumentException("Les points de vie doivent être supérieurs à 0.");
                }
            }
        }

        public virtual int NumberOfAttacks
        {
            get { return numberOfAttacks; }
            protected set
            {
                if (value > 0)
                {
                    numberOfAttacks = value;
                }
                else
                {
                    throw new ArgumentException("Le nombre d'attaques doit être supérieur à 0.");
                }
            }
        }

        // Méthodes
        public virtual void GetInfos ()
        {
            Console.WriteLine($"{Name} possède {NumberOfAttacks} attaques et {Hp} pv !");
        }

        public virtual void TakeDamage (int damage)
        {
            if (Hp - damage > 0)
            {
                Hp -= damage;
                Console.WriteLine($"{Name} a perdu {damage} pv, il lui reste actuellement {Hp} pv !");
            }
            else
            {
                IsAlive = false;
                Console.WriteLine($"{Name} est mort !");
            }
        }
    }
}

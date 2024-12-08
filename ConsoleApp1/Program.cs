using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rd = new Random();

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
            }
        }
    }
}

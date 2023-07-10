using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework_number_56
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Database database = new Database();

            database.ShowAllSoldiers();

            Console.WriteLine("Что бы получить список солдат по имени и рангу нажмите любую клавишу ");
            Console.ReadKey();
            Console.Clear();

            database.ShowSoldierAbbreviatedInformation();

            Console.ReadKey();
        }
    }

    class Soldier
    {
        public Soldier(string name, string arms, string rank, int serviceLife)
        {
            Name = name;
            Arms = arms;
            Rank = rank;
            ServiceLife = serviceLife;
        }

        public string Name { get; private set; }
        public string Arms { get; private set; }
        public string Rank { get; private set; }
        public int ServiceLife { get; private set; }
    }

    class Database
    {
        private List<Soldier> _soldiers = new List<Soldier>();

        public Database()
        {
            Fill();
        }

        public void ShowSoldierAbbreviatedInformation()
        {
            var newSoldiers = from Soldier soldier in _soldiers select new { Name = soldier.Name, Rank = soldier.Rank };

            foreach (var newSoldier in newSoldiers)
            {
                Console.WriteLine("Солдат:");
                Console.WriteLine($"Имя : {newSoldier.Name}");
                Console.WriteLine($"Звание: {newSoldier.Rank}");
                Console.WriteLine();
            }
        }

        public void ShowAllSoldiers()
        {
            foreach (Soldier soldier in _soldiers)
            {
                Console.WriteLine("Солдат:");
                Console.WriteLine($"Имя : {soldier.Name}");
                Console.WriteLine($"Оружие : {soldier.Arms}");
                Console.WriteLine($"Звание: {soldier.Rank}");
                Console.WriteLine($"Время службы в месяцах: {soldier.ServiceLife}");
                Console.WriteLine();
            }
        }

        private void Fill()
        {
            Random random = new Random();

            List<string> soldierNames = new List<string>()
            {
            "Иван",
            "Петр",
            "Алексей",
            "Михаил",
            "Сергей"
            };
            List<string> weaponNames = new List<string>()
            {
            "Автомат",
            "Пистолет",
            "Винтовка",
            "Пулемет",
            "Гранатомет"
            };
            List<string> ranks = new List<string>()
        {
            "Рядовой",
            "Ефрейтор",
            "Младший сержант",
            "Сержант",
            "Старший сержант"
        };

            int maxServiceLife = 60;
            int minServiceLife = 1;
            int quantitySoldiers = 10;

            for (int i = 0; i < quantitySoldiers; i++)
            {
                _soldiers.Add(new Soldier(soldierNames[random.Next(soldierNames.Count)],
                                          weaponNames[random.Next(weaponNames.Count)],
                                          ranks[random.Next(ranks.Count)],
                                          random.Next(minServiceLife, maxServiceLife)));
            }
        }
    }
}

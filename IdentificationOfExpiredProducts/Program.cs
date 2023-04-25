using System;
using System.Collections.Generic;
using System.Linq;

namespace IdentificationOfExpiredProducts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Terminal terminal = new Terminal();

            terminal.Work();
        }
    }

    class CannedMeat
    {
        private string _name;
        
        private int _shelfLife = 3;

        public CannedMeat(string name, int yearOfProduction)
        {
            _name = name;
            YearOfProduction = yearOfProduction;
            ExpirationDate = YearOfProduction + _shelfLife;
        }

        public int YearOfProduction { get; private set; }
        public int ExpirationDate { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"{_name} - Год производства:{YearOfProduction}г. Годно до: {ExpirationDate}г.");
        }
    }

    class Terminal
    {
        private List<CannedMeat> _preserves;

        private int _currentYear; 

        public Terminal()
        {
            _currentYear = DateTime.Now.Year;
            _preserves = new List<CannedMeat>()
            {
                new CannedMeat("Тушенка1", 2023),
                new CannedMeat("Тушенка2", 2021),
                new CannedMeat("Тушенка3", 2020),
                new CannedMeat("Тушенка4", 2022),
                new CannedMeat("Тушенка5", 2021),
                new CannedMeat("Тушенка6", 2019),
                new CannedMeat("Тушенка7", 2018),
                new CannedMeat("Тушенка8", 2020),
                new CannedMeat("Тушенка9", 2023),
                new CannedMeat("Тушенка10", 2021),
                new CannedMeat("Тушенка11", 2019),
            };
        }

        public void Work()
        {
            Console.WriteLine("Все консервы:\n");
            
            ShowPreserves();

            Console.WriteLine("\nПросрочка:\n");

            _preserves = GetExpiredPreserves();

            ShowPreserves();

            Console.ReadLine();
        }

        private List<CannedMeat> GetExpiredPreserves() =>        
            _preserves.Where(cannedMeat => cannedMeat.ExpirationDate < _currentYear).ToList();
        
        private void ShowPreserves()
        {
            foreach (CannedMeat cannedMeat in _preserves)            
                cannedMeat.ShowInfo();            
        }
    }
}

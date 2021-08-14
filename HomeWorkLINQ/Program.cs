using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWorkLINQ
{
    class Program
    {
        static void Main(string[] args)

        {
            var cities = new City[]
            {
              new City{ Name = "Rivne", Country="Ukraine", Population = 250000, IsCapital = false },
              new City{ Name = "Warsaw", Country="Poland", Population = 1800000, IsCapital = true },
              new City{ Name = "Lviv", Country="Ukraine", Population = 720000, IsCapital = false },
              new City{ Name = "Krakow", Country="Poland", Population = 780000, IsCapital = false },
              new City{ Name = "Odessa", Country="Ukraine", Population = 1020000, IsCapital = false },
              new City{ Name = "London", Country="Great Britain", Population = 8900000, IsCapital = true },
              new City{ Name = "Paris", Country="France", Population = 2180000, IsCapital = true },
              new City{ Name = "Berlin", Country="Germany", Population = 3600000, IsCapital = true },
              new City{ Name = "Wroclaw", Country="Poland", Population = 640000, IsCapital = false },
              new City{ Name = "Kyiv", Country="Ukraine", Population = 3000000, IsCapital = true },
              new City{ Name = "Munich", Country="Germany", Population = 1480000, IsCapital = false },
              new City{ Name = "Dnipro", Country="Ukraine", Population = 980000, IsCapital = false },
              new City{ Name = "Cologne", Country="Germany", Population = 1000000, IsCapital = false }
            };
            var numbers = new[] { 2, 9, 47, 69, 20, -1, 13, -26, 37, -40, 18, 70, -31, 7, -47, -7, 1 };

            //            Використовуючи синтаксис запитів вивести на екран:
            //> Із "cities"
            //   - інформацію про столиці(назву, країну та населення);

            var selectedCapitals = from city in cities
                                   where city.IsCapital
                                   select city;
            Console.WriteLine("\n\nAll capitals:");
            foreach (City city1 in selectedCapitals)
            {
                Console.WriteLine($"City - {city1.Name }, Country - {city1.Country}, Population - {city1.Population} ");
            }

            //            -назви міст, що містять букву "і" у назві міста;
            var selectedCityI = from city in cities
                                where city.Name.Contains("i")
                                select city;
            Console.WriteLine("\n\nAll cities with i:");
            foreach (City city1 in selectedCityI)
            {
                Console.WriteLine($" {city1.Name }");
            }


            //            -назви столиць разом із населенням у порядку спадання населення;
            var selectedCapitalPopulation = from city in cities
                                            where city.IsCapital
                                            orderby city.Population descending
                                            select city;
            Console.WriteLine("\n\nAll capitals with order desc population:");
            foreach (City city2 in selectedCapitalPopulation)
            {
                Console.WriteLine($"City - {city2.Name}, Population - {city2.Population}");
            }

            //            -назви країн, що містять міста, назви яких закінчуютсья на букву "w";

            var selectedCitiesW = from city in cities
                                  where city.Name.EndsWith("w")
                                  select city.Country;


            Console.WriteLine("\n\nCountries where cities with w in the end:");
            foreach (var city3 in selectedCitiesW)
            {
                Console.WriteLine($"{city3}");
            }

            //            -назви міст, де назва країни закінчується на "e", а назви міст починаються на букву "R";

            var selectCountryE = from city in cities
                                 where city.Country.EndsWith("e")  
                                 where city.Name.StartsWith("R")
                                 select city;

            Console.WriteLine("\n\nCountry with e in the end city with R in the start");
            foreach (City city4 in selectCountryE)
            {
                Console.WriteLine($"Country - {city4.Country}, City - {city4.Name}");
            }

            //> Із "numbers"
            //   - всі непарні числа;
            IEnumerable<int> numb = from i in numbers
                                    where i % 2 != 0
                                    select i;

            Console.WriteLine("\n\nAll odds: ");

            foreach (int i in numb)
            {
                Console.WriteLine(i);
            }

            //            -додатні числа із "numbers" у порядку зростання;

            var numbOrder = from i in numbers
                            where i > 0
                            orderby i
                            select i;
            Console.WriteLine("\n\nAll positive order: ");

            foreach (int i in numbOrder)
            {
                Console.WriteLine(i);
            }


            //            -від'ємні числа із "numbers" у порядку спадання.

            var numbOrderDesc = from i in numbers
                            where i < 0
                            orderby i descending
                            select i;
            Console.WriteLine("\n\nAll negative order desc: ");

            foreach (int i in numbOrderDesc)
            {
                Console.WriteLine(i);
            }


            //Використовуючи синтаксис методів:
            //> Із "cities"
            //   - кількість столиць;
            var countCountries = cities.Where(c => c.IsCapital).Count();

            Console.WriteLine("\n\n Count capitals:");

            Console.WriteLine(countCountries);

            //-назви країн;

            var lowCityd = cities.Select(c => c.Country).Distinct();

            Console.WriteLine("\n\n Name capitals:");

            foreach (var city7 in lowCityd)
            {
                Console.WriteLine(city7);
            }

            //            -кількість міст із населенням більше  1 000 000;

            var bigCities = cities.Where(c => c.Population > 1000000).Count();
            Console.WriteLine("\n\n Count cities bigger than 1000000:");
            Console.WriteLine(bigCities);


            //            -назви міст із населенням менше  1 000 000;

            var smallCity = cities.Where(c => c.Population < 1000000);
            Console.WriteLine("\n\n Cities less than 1000000:");

            foreach (City city5 in smallCity)
            {
                Console.WriteLine($"City - {city5.Name}, Population - {city5.Population}");
            }

            //            -назви країн, у яких назви міст закінчуютсья на букву "w" у назві міста;

            
            Console.WriteLine("\n\n Countries where cities name end to w");
            var countryWithW = cities.Where(c => c.Name.EndsWith("w"));

            foreach (City city6 in countryWithW)
            {
                Console.WriteLine($"Country - {city6.Country}");
            }


            //            -кількість населення в найменш заселеній столиці;


            
            var lowCity = cities.Where(c => c.Population > 1).Min(c=>c.Population);

            Console.WriteLine("\n\n The smallest population:");

            Console.WriteLine(lowCity);



            //            -назви міст, крім перших і останніх чотирьох;

            var nameCityFour = cities.Select(c => c.Name).Skip(4).SkipLast(4);

            Console.WriteLine("\n\n The cities exclude first 4 and last 4:");


            foreach (var city8 in nameCityFour)
            {
                Console.WriteLine(city8);
            }


            //var NameSome = cities.Where(c=>c.Name)

            //> Із "numbers"
            //   - мінімальне, максимальне та середнє значення;

            var minNumb = numbers.Min();

            Console.WriteLine($"\n\nMinimal number: {minNumb}");

            var maxNumb = numbers.Max();

            Console.WriteLine($"\n\nMaximal number: {maxNumb}");

            var avNumb = numbers.Average();

            Console.WriteLine($"\n\nAverage number: {avNumb}");

            //            -чи містить масив значення "-31";

            var ifIsnumber = numbers.Contains(-31);

            if (ifIsnumber)
            {
                Console.WriteLine("\n\nArray have number -31");
            }
            else
            {
                Console.WriteLine("\n\nArray have not number -31");
            }

            //            -останнє парне значення.

            var lastParriedNumb = numbers.Where(n => n % 2 == 0).Last();

            Console.WriteLine($"\n\nLast parried number: {lastParriedNumb}");

        }

        public class City
        {
            public string Name;
            public string Country;
            public int Population;
            public bool IsCapital;
        }



    }
}

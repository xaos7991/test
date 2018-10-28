using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            List<People> peoples = new List<People>();

            People people = new People
            {
                Name = "Иван",
                Age = 31,
                Sex = TypeOfPeople.Male,
                Balance = 400
            };

            peoples.Add(people);

            people = new People
            {
                Name = "Женя",
                Age = 24,
                Sex = TypeOfPeople.Male,
                Balance = 21000
            };

            peoples.Add(people);

            people = new People
            {
                Name = "Даша",
                Age = 22,
                Sex = TypeOfPeople.Female,
                Balance = 570
            };

            peoples.Add(people);

            people = new People
            {
                Name = "Соня",
                Age = 27,
                Sex = TypeOfPeople.Female,
                Balance = 4792
            };


            peoples.Add(people);

            people = new People
            {
                Name = "Леша",
                Age = 25,
                Sex = TypeOfPeople.Male,
                Balance = 14758
            };

            peoples.Add(people);

            // Нахождение старшего 
            Console.WriteLine("Самый старший человек:");
            int MaxAge = peoples.Max(x => x.Age);
            var selectMaxAge = peoples.Where(x => x.Age == MaxAge).Select(x => x);
            foreach (People Max in selectMaxAge)
            {
                Console.WriteLine(Max.Name);
            }

            // Нахождение баланса 
            Console.WriteLine("Человек с наибольшим балансом:");
            int b = peoples.Max(x => x.Balance);
            var selectMaxBalance = peoples.Where(x => x.Balance == b).Select(x => x);
            foreach (People Max in selectMaxBalance)
            {
                Console.WriteLine(Max.Name);
            }
            // Самого старшего и богатого
            var selectMaxBA = from t in peoples
                              where t.Balance == b || t.Age == MaxAge
                              select t;
            Console.WriteLine("Нахождение самого богатого и старого:");
            foreach (People Max in selectMaxBA)
            {
                Console.WriteLine("{0}, {1}, {2} ", Max.Name, Max.Age, Max.Balance);

            }
            // Баланс выше 4000
            Console.WriteLine("Люди у которых баланс больше 4000:");
            var select4 = from t in peoples
                          where t.Balance > 4000
                          select t;


            foreach (People Max in select4)
            {
                Console.WriteLine(Max.Name + " ");
            }

            // Сортировка по возрасту
            Console.WriteLine("Сортировка по возрасту:");
            var selectSAge = from t in peoples
                             orderby t.Age
                             select t;
            Console.WriteLine("      Имя | Возраст | Пол    | Баланс");
            foreach (People Max in selectSAge)
            {
                Console.WriteLine("      " + Max.Name + "      " + Max.Age + "    " + Max.Sex + "      " + Max.Balance);
            }

            // Сортировка по полу
            Console.WriteLine("Сортировка по полу:");
            var selectSex = from t in peoples
                            orderby t.Sex
                            select t;
            Console.WriteLine("      Имя | Возраст | Пол    | Баланс");
            foreach (People Max in selectSex)
            {
                Console.WriteLine("      " + Max.Name + "      " + Max.Age + "    " + Max.Sex + "      " + Max.Balance);
            }


            // Сортировка по балансу
            Console.WriteLine("Сортировка по балансу:");
            var selectBal = from t in peoples
                            orderby t.Balance
                            select t;
            Console.WriteLine("      Имя | Возраст | Пол    | Баланс");
            foreach (People Max in selectBal)
            {
                Console.WriteLine("      " + Max.Name + "      " + Max.Age + "    " + Max.Sex + "      " + Max.Balance);
            }



            Console.ReadKey();




        }
    }
}

using System;
using ToDoList.BL.Controller;
using ToDoList.BL.Model;

namespace ToDoList.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует консольное приложение ToDoList!");

            Console.Write("Введите ваше имя: ");
            var name = Console.ReadLine();

            var userController = new UserController(name);

            ToDoController ToDoController = new ToDoController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                Console.Write("Введите пол: ");
                var gender = Console.ReadLine();
                var birthDate = ParseDateTime("дату рождения");

                userController.SetNewUserData(gender, birthDate);
            }

            Console.WriteLine(userController.CurrentUser);

            Console.WriteLine("Что вы хотите сделать?");
            Console.WriteLine("A - добавить новое дело");
            var key = Console.ReadKey();
            Console.WriteLine();

            if (key.Key == ConsoleKey.A)
            {
                var affair = EnterAffair();
                ToDoController.Add(affair);

                foreach (var item in ToDoController.Affairs)
                {
                    Console.WriteLine($"{item}");
                }
            }

            Console.ReadLine();
        }

        private static Affair EnterAffair()
        {
            Console.Write("Введите имя дела: ");
            var affair = Console.ReadLine();
            Console.Write("Введите описание дела: ");
            var description = Console.ReadLine();
            var duration = ParseTimeSpan("дела");
            var moment = ParseDateTime("дату начала выполнения списка дел");

            var bussiness = new Affair(affair, description, duration, moment);


            return bussiness;
        }

        private static TimeSpan ParseTimeSpan(string v)
        {
            TimeSpan duration;
            while (true)
            {
                Console.Write($"Введите продолжительность {v} (hh:mm:ss): ");
                if (TimeSpan.TryParse(Console.ReadLine(), out duration))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный формат времени.");
                }
            }

            return duration;
        }

        /// <summary>
        /// Запрос даты рождения.
        /// </summary>
        /// <returns>Дата рождения</returns>
        private static DateTime ParseDateTime(string name)
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write($"Введите {name} (dd.MM.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный формат даты.");
                }
            }

            return birthDate;
        }
    }
}

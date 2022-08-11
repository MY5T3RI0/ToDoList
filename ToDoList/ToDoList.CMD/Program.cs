using System;
using System.Globalization;
using System.Resources;
using ToDoList.BL.Controller;
using ToDoList.BL.Model;
using System.Threading;

namespace ToDoList.CMD
{
    class Program
    {
        static void Main(string[] args)
        {

            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");

            Console.WriteLine(Languages.Messages.Welcome);
            Console.Write(Languages.Messages.EnterName);

            var name = Console.ReadLine();

            var userController = new UserController(name);

            ToDoController ToDoController = new ToDoController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                Console.Write(Languages.Messages.EnterGender);
                var gender = Console.ReadLine();
                var birthDate = ParseDateTime("дата рождения");

                userController.SetNewUserData(gender, birthDate);
            }

            Console.WriteLine(userController.CurrentUser);

            Console.WriteLine(Languages.Messages.WhatToDo);
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
            var duration = ParseTimeSpan("дело");
            var moment = ParseDateTime("дату начала выполнения списка дел");

            var bussiness = new Affair(affair, description, duration, moment);


            return bussiness;
        }

        private static TimeSpan ParseTimeSpan(string v)
        {
            TimeSpan duration;
            while (true)
            {
                Console.Write($"Введите продолжительность события {v} (hh:mm:ss): ");
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
                Console.Write($"Введите параметр {name} (dd.MM.yyyy): ");
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

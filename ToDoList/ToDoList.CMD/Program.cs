using System;
using ToDoList.BL.Controller;
using ToDoList.BL.Model;

namespace ToDoList.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует консольное приложение ToDoList");

            Console.WriteLine("Введите ваше имя");
            var name = Console.ReadLine();

            Console.WriteLine("Введите ваш пол");
            var gender = Console.ReadLine();

            Console.WriteLine("Введите ваш возраст");
            var year = int.Parse(Console.ReadLine());

            var userController = new UserController(name, gender, year);
            userController.Save();
        }
    }
}

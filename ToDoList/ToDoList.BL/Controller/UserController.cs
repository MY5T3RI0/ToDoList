using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ToDoList.BL.Model;

namespace ToDoList.BL.Controller
{
    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Пользователь приложения.
        /// </summary>
        public User User { get; }

        /// <summary>
        /// Создание нового контроллера.
        /// </summary>
        /// <param name="userName">Имя. </param>
        /// <param name="genderName">Имя пола. </param>
        /// <param name="Year">Возраст. </param>
        public UserController(string userName, string genderName, int year)
        {
            if (year <= 0)
            {
                throw new ArgumentException("Некорректный возраст", nameof(userName));
            }
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentException("Имя пользователя не может быть пустым или null", nameof(userName));
            }

            if (string.IsNullOrEmpty(genderName))
            {
                throw new ArgumentException("Имя пола не может быть путсым или null", nameof(genderName));
            }

            var gender = new Gender(genderName);
            User = new User(userName, gender, year);
        }

        /// <summary>
        /// Получить данные пользователя.
        /// </summary>
        public UserController()
        {
            var formatter = new BinaryFormatter();

            using (var file = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(file) is User user)
                {
                    User = user;
                }
            }
        }

        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();

            using (var file = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(file, User);
            }

        }
    }
}

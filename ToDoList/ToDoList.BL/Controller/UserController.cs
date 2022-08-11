using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using ToDoList.BL.Model;

namespace ToDoList.BL.Controller
{
    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController : ControllerBase
    {
        public const string USERS_FILE_NAME = "users.dat";
        /// <summary>
        /// Пользователь приложения.
        /// </summary>
        public List<User> Users { get; }

        public User CurrentUser { get; }

        public bool IsNewUser { get; } = false;

        /// <summary>
        /// Создание нового контроллера.
        /// </summary>
        /// <param name="userName">Имя. </param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentException("Имя пользователя не может быть пустым.", nameof(userName));
            }

            Users = GetUsersData();

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }
        }

        /// <summary>
        /// Получить сохраненный список пользователей.
        /// </summary>
        private List<User> GetUsersData()
        {
            return Load<List<User>>(USERS_FILE_NAME) ?? new List<User>();
        }

        /// <summary>
        /// Изменить данные пользователя.
        /// </summary>
        /// <param name="genderName">Имя пользователя.</param>
        /// <param name="birthDate">Дата рождения.</param>
        public void SetNewUserData(string genderName, DateTime birthDate)
        {
            if (string.IsNullOrWhiteSpace(genderName))
            {
                throw new ArgumentException("Имя пользователя не может быть пустым или null.", nameof(genderName));
            }

            if (DateTime.Now.Year - birthDate.Year >= 100 || DateTime.UtcNow.Year - birthDate.Year <= 1)
            {
                throw new ArgumentException("Некорректная дата рождения.", nameof(birthDate));
            }

            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            Save();
        }

        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void Save()
        {
            Save(USERS_FILE_NAME, Users);
        }
    }
}

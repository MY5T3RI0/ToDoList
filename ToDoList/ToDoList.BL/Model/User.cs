using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.BL.Model
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    [Serializable]
    public class User
    {
        /// <summary>
        /// Номер объекта.
        /// </summary>
        private static int ObjectNumber = 0;

        /// <summary>
        /// Идентификатор.
        /// </summary>
        private int ID { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Пол.
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime BirthDate { get; set; }

        public int Age { get { return DateTime.UtcNow.Year - BirthDate.Year; } }

        /// <summary>
        /// Создать нового пользователя
        /// </summary>
        /// <param name="name">Имя. </param>
        /// <param name="gender">Пол. </param>
        /// <param name="year">Возраст. </param>
        public User(string name, Gender gender, DateTime birthDate)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым или null.", nameof(name));
            }

            if (DateTime.UtcNow.Year - birthDate.Year >= 100 || DateTime.UtcNow.Year - birthDate.Year <= 1)
            {
                throw new ArgumentException("Некорректная дата рождения.", nameof(birthDate));
            }

            Gender = gender ?? throw new ArgumentNullException("Пол не может быть null.", nameof(gender));

            BirthDate = birthDate;
            Name = name;
            ObjectNumber++;
            ID = ObjectNumber;
        }

        /// <summary>
        /// Создать нового пользователя
        /// </summary>
        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым или null.", nameof(name));
            }

            Name = name;
        }

        public override string ToString()
        {
            return Name + " " + Age;
        }
    }
}

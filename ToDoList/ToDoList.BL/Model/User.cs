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
        public Gender Gender { get; }

        /// <summary>
        /// Возраст.
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Создать нового пользователя
        /// </summary>
        /// <param name="name">Имя. </param>
        /// <param name="gender">Пол. </param>
        /// <param name="year">Возраст. </param>
        public User(string name, Gender gender, int year)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым или null", nameof(name));
            }

            if (year <= 0)
            {
                throw new ArgumentException("Некорректный возраст", nameof(year));
            }

            Gender = gender ?? throw new ArgumentNullException("Пол не может быть null", nameof(gender));

            Year = year;
            Name = name;
            ObjectNumber++;
            ID = ObjectNumber;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

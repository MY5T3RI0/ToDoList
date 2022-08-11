using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.BL.Model
{
    /// <summary>
    /// Список дел.
    /// </summary>
    [Serializable]
    public class ToDo
    {
        /// <summary>
        /// Дела.
        /// </summary>
        public List<Affair> Affairs { get; set; }

        /// <summary>
        /// Пользователь.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Создать новый список дел.
        /// </summary>
        /// <param name="user">Пользователь.</param>
        public ToDo(User user)
        {
            User = user ?? throw new ArgumentNullException("Пользователь не может быть пустым.", nameof(user));

            Affairs = new List<Affair>();
        }

    }
}

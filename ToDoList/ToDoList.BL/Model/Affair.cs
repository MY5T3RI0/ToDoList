using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.BL.Model
{
    /// <summary>
    /// Дело.
    /// </summary>
    [Serializable]
    public class Affair
    {
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Описание.
        /// </summary>
        public string Description { get; } = "";

        /// <summary>
        /// Продолжительность.
        /// </summary>
        public TimeSpan Duration { get; set; }

        /// <summary>
        /// Время начала.
        /// </summary>
        public DateTime Moment { get; }

        /// <summary>
        /// Создать новое дело.
        /// </summary>
        /// <param name="name">Название.</param>
        /// <param name="description">Описание.</param>
        /// <param name="duration">Продолжительность.</param>
        public Affair(string name, string description, TimeSpan duration, DateTime moment)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Название дела не может быть пустым или null.", nameof(name));
            }

            if (duration.Ticks == 0)
            {
                throw new ArgumentNullException("Продолжительность не может быть равна нулю.", nameof(duration));
            }

            if (moment.Year < DateTime.UtcNow.Year)
            {
                throw new ArgumentException("Некорректная дата", nameof(duration));
            }

            Name = name;
            Description = description;
            Duration = duration;
            Moment = moment;
        }

        /// <summary>
        /// Создать новое дело.
        /// </summary>
        public Affair(string name) : this(name, " ", TimeSpan.Zero, DateTime.MinValue) { }

        public override string ToString()
        {
            return $"{Name}\t{Duration.Hours}h {Duration.Minutes}m";
        }
    }
}

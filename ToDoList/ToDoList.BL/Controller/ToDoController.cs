using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.BL.Model;

namespace ToDoList.BL.Controller
{
    public class ToDoController : ControllerBase
    {

        private readonly User User;
        public ToDo ToDo { get; }

        public List<Affair> Affairs { get; }

        public const string TODO_FILE_NAME = "ToDo.dat";

        public ToDoController(User user)
        {
            User = user;
            ToDo = GetToDo();
            Affairs = GetAllAffairs();
        }

        public void Add(Affair affair)
        {
            Affairs.Add(affair);
            ToDo.Affairs.Add(affair);
            Save();
        }

        private ToDo GetToDo()
        {
            return Load<ToDo>(TODO_FILE_NAME) ?? new ToDo(User);
        }

        private List<Affair> GetAllAffairs()
        {
            return Load<List<Affair>>(TODO_FILE_NAME) ?? new List<Affair>();
        }
        public void Save()
        {
            Save(TODO_FILE_NAME, ToDo);
            Save(TODO_FILE_NAME, Affairs);
        }
        private List<User> GetUsersData()
        {
            return Load<List<User>>(TODO_FILE_NAME) ?? new List<User>();
        }

    }
}

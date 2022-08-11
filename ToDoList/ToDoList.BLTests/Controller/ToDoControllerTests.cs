using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.BL.Model;

namespace ToDoList.BL.Controller.Tests
{
    [TestClass()]
    public class ToDoControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            var affairName = Guid.NewGuid().ToString();
            var affairDescription = Guid.NewGuid().ToString();
            var rnd = new Random();
            var userController = new UserController(userName);
            var ToDoController = new ToDoController(userController.CurrentUser);
            var affair = new Affair(affairName, affairDescription, new TimeSpan(rnd.Next(0, 23), rnd.Next(0, 59), rnd.Next(0, 59)), new DateTime(2022, rnd.Next(0, 12), rnd.Next(0, 30)));

            // Act
            ToDoController.Add(affair);

            // Assert
            Assert.AreEqual(affair.Name, ToDoController.ToDo.Affairs.First().Name);
        }
    }
}
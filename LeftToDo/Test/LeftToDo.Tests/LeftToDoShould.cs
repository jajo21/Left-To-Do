using System;
using System.Collections.Generic;
using Xunit;

namespace LeftToDo.Tests
{
    
    public class LeftToDoShould
    {
        ToDos todoList;
        Task task1;
        Task task2;

         public LeftToDoShould() {
             todoList = new ToDos();
             task1 = new Task("Do");
             task2  = new Task("Do2"); 
        } 

        [Fact]
        public void AddTaskToList()
        {         
            todoList.AddTaskToToDoList(task1);
            todoList.AddTaskToToDoList(task2);
            
            var expected = 2;

            var actual = todoList.CountTasksInToDoList();
            
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void MarkTaskAsDone()
        {
            task1.SetTaskAsDone();

            Assert.True(task1.CheckIfTaskIsDone());
        }
        [Fact]
        public void ArchiveTasksMarkedAsDone() {
            
            todoList.AddTaskToToDoList(task1);
            todoList.AddTaskToToDoList(task2);

            task1.SetTaskAsDone();
            todoList.ArchieveTasksMarkedAsDone();

            var expected = 1;
            var arcActual = todoList.CountTasksInArchivedList();
            var todoActual = todoList.CountTasksInToDoList();

            Assert.Equal(expected, arcActual);
            Assert.Equal(expected, todoActual);
        }
        [Fact]
        public void test1(){

        }
    }
}

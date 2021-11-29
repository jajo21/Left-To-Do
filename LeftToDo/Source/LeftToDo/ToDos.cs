using System;
using System.Collections.Generic;

namespace LeftToDo
{
public class ToDos
    {
        List<Task> todoList;
        List<Task> archivedList;

        public ToDos(){
            todoList = new List<Task>();
            archivedList = new List<Task>();
        }
        
        public void AddTaskToToDoList(Task task) { 
            todoList.Add(task);
        }
        
        public void AddTaskToArchiveList (Task task) {
            archivedList.Add(task);
        }

        public void ArchieveTasksMarkedAsDone()
        {
            for (int i = 0; i < todoList.Count; i++)
            {
                if (todoList[i].CheckIfTaskIsDone())
                {
                    AddTaskToArchiveList(todoList[i]);
                    todoList.Remove(todoList[i]);
                    i--;
                } 
            }
        }

        public int CountTasksInToDoList()
        {
            return todoList.Count;
        }
        public int CountTasksInArchivedList()
        {
            return archivedList.Count;
        }
        public List<Task> GetToDoList(){
            return todoList;
        }
    }
}
using System;
using System.Collections.Generic;

namespace LeftToDo
{
public class ToDoStorage
    {
        List<Tasks> todoList;
        List<Tasks> archivedList;

        public ToDoStorage(){
            todoList = new List<Tasks>();
            archivedList = new List<Tasks>();
        }
        
        public void AddTaskToToDoList(Tasks task) { 
            todoList.Add(task);
        }
        
        public void AddTaskToArchiveList (Tasks task) {
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
        public List<Tasks> GetToDoList(){
            return todoList;
        }
        public string GetAllTasks()
        {
            string taskString = "";
            int count = 1;
            foreach (Tasks task in todoList)
            {
                taskString += $"({count}) [ ] {task.GetTaskString()}\n";
                count++;
            }
            return taskString;
        }

    }
}
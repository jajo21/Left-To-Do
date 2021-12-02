using System;
using System.Collections.Generic;

namespace LeftToDo
{
    public class ToDoStorage
    {
        List<Task> todoList;
        List<Task> archivedList;

        public ToDoStorage()
        {
            todoList = new List<Task>();
            archivedList = new List<Task>();
        }

        public void AddTaskToToDoList(Task taskToAdd)
        {
            todoList.Add(taskToAdd);
        }

        public void AddTaskToArchiveList(Task taskToAdd)
        {
            archivedList.Add(taskToAdd);
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
        public List<Task> GetToDoList()
        {
            return todoList;
        }
        public List<Task> GetArchivedList()
        {
            return archivedList;
        }

        public string GetAllTasksInTodoList()
        {
            string taskString = "";
            int count = 1;
            foreach (Task task in todoList)
            {
                var taskIsDone = task.CheckIfTaskIsDone();
                if (taskIsDone)
                {
                    taskString += $"({count}) [X] {task.GetTaskString()}\n";
                    count++;
                }
                else
                {
                    taskString += $"({count}) [ ] {task.GetTaskString()}\n";
                    count++;
                }

            }
            return taskString;
        }
        public string GetAllTasksInArchivedList()
        {
            string taskString = "";
            int count = 1;
            foreach (Task task in archivedList)
            {
                var taskIsDone = task.CheckIfTaskIsDone();
                if (taskIsDone) // Behöver ingen if sats här.. Ta bort när du är säker på programmet
                {
                    taskString += $"({count}) [X] {task.GetTaskString()}\n";
                    count++;
                }
                else
                {
                    taskString += $"({count}) [ ] {task.GetTaskString()}\n";
                    count++;
                }
            }
            return taskString;
        }

        public void SetTaskInToDoListAsDone(int taskToSet)
        {
            if (IsTaskAnChecklistTask(taskToSet))
            {
                //subTaskList
            }
            else
            {
                todoList[taskToSet - 1].SetTaskAsDone();
            }
        }
        public bool IsTaskAnChecklistTask(int taskToCheck)
        {

            if (todoList[taskToCheck - 1] is Checklist)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void GetAllCheckLists()
        {
            foreach(var task in todoList)
            {
                if(task is Checklist) {
                    
                }
            }
        }
    }
}
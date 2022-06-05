using System;
using System.Collections.Generic;

namespace LeftToDo
{
    /*  En klass som innehåller de listor som behövs för att spara all information.
        Därav namnet storage. Innehåller även de metoder som behövs för att fylla, 
        ändra, läsa och tömma listor.   */
    public class Storage
    {
        List<Task> todoList;
        List<Task> archivedList;
        List<Checklist> checklistList;

        public Storage()
        {
            todoList = new List<Task>();
            archivedList = new List<Task>();
            checklistList = new List<Checklist>();
        }

        public void AddTaskToToDoList(Task taskToAdd) // Lägger till uppgift i todolistan
        {
            todoList.Add(taskToAdd);
        }

        public void AddTaskToArchiveList(Task taskToAdd) // Lägger till uppgift i arkivlistan
        {
            archivedList.Add(taskToAdd);
        }
        public void AddTaskToChecklist(Checklist taskToAdd) // Lägger till uppgift i checklistlistan
        {
            checklistList.Add(taskToAdd);
        }

        public void ArchieveTasksMarkedAsDone() // Arkiverar uppgifter som är färdigmarkerade
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

        public int CountTasksInToDoList() // Räknar och returnerar en summa av alla uppgifter som finns i att todolistan
        {
            return todoList.Count;
        }
        public int CountTasksInArchivedList() // Räknar och returnerar en summa av alla uppgifter som finns i den arkiverade listan
        {
            return archivedList.Count;
        }
        public List<Task> GetToDoList() // Denna och de två under returnerar respektive lista om metoden kallas på.
        {
            return todoList;
        }
        public List<Task> GetArchivedList()
        {
            return archivedList;
        }
        public List<Checklist> GetChecklistList()
        {
            return checklistList;
        }
        public string GetAllTasksFromStorageLists(List<Task> list)  // Returnerar stringar alla stringar från vald lista.
        {
            string taskString = "";
            int count = 1;
            foreach (Task task in list)
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

        public void SetTaskInToDoListAsDone(int taskToSet) // Sätter en uppgift som färdig i todolistan
        {
            todoList[taskToSet - 1].SetTaskAsDone();
        }
        public void SetSubTaskChecklistListAsDone(int todoListChoice, int subTaskToSet) 
        {
            foreach (var checklist in checklistList)
            {
                if (todoList[todoListChoice - 1] == checklist) // Kollar om checklistan och todolistan stämmer överens
                {
                    if (checklist.CheckIfAllSubTasksIsDone()) // Om alla subuppgifter i checklistan är klara
                    {
                        SetTaskInToDoListAsDone(todoListChoice); // Sätt checklistan i todolistan som färdig
                    }
                    else
                    {
                        checklist.SetTaskInSubTaskListAsDone(subTaskToSet); // Annars sätt subuppgiften som färdig
                    }
                }
            }
        }
        public bool isTaskAChecklist (int chooseTask) {
            return todoList[chooseTask -1] is Checklist;
        }
    }
}
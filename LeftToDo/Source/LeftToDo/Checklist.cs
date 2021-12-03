using System;
using System.Collections.Generic;

namespace LeftToDo
{
    /*  Subklass som ärver av superklassen Task. En klass som tar hand om uppgifter som innehåller
        delmål/subuppgifter. Innehåller en egen lista som samlar "subuppgifter" i denne.  */
    public class Checklist : Task
    {
        List<ChecklistSubTask> subTaskList;

        public Checklist(string taskDescription) : base(taskDescription)
        {
            subTaskList = new List<ChecklistSubTask>();
        }

        public void AddSubTaskToChecklist(ChecklistSubTask task) // Adderar subuppgifter till sublistan.
        {
            subTaskList.Add(task);
        }
        public List<ChecklistSubTask> GetSubTaskList() // returnerar sublistan
        {
            return subTaskList;
        }
        public bool CheckIfAllSubTasksIsDone() //Kontrollerar om alla subuppgifter i listan är färdiga, är dom det returneras true.
        {
            var checkedSubTask = subTaskList.FindAll(task => task.CheckIfTaskIsDone() == true);
            if (checkedSubTask.Count == subTaskList.Count)
            {
                return true;
            }
            else return false;
        }        
        public void SetTaskInSubTaskListAsDone(int taskToSet) // Sätter en subtask som färdig.
        {
            subTaskList[taskToSet - 1].SetTaskAsDone();
        }

        public string GetSubTaskStrings() // Returnerar alla strängar i sublistan på två olika sätt beroende på om uppgiften är färdig eller ej.
        {
            string subTaskString = "";
            int count = 1;
            foreach (ChecklistSubTask task in subTaskList)
            {
                var taskIsDone = task.CheckIfTaskIsDone();
                if (taskIsDone)
                {
                    string message = $"({count}) [X] {task.GetTaskString()}\n";
                    subTaskString += message.PadLeft(message.Length + 4);
                    count++;
                }
                else
                {
                    string message = $"({count}) [ ] {task.GetTaskString()}\n";
                    subTaskString += message.PadLeft(message.Length + 4);
                    count++;
                }
            }
            return subTaskString;
        }

        public override string GetTaskString() // Returnar en sträng som kör över den virtuella superklassen
        {
            return $"{taskDescription} - Checklista: \n{GetSubTaskStrings()}";
        }
    }
}
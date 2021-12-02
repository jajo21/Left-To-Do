using System;
using System.Collections.Generic;

namespace LeftToDo
{
    public class Checklist : Task
    {
        List<Task> subTaskList;

        public Checklist(string taskDescription) : base(taskDescription)
        {
            subTaskList = new List<Task>();
        }

        public void AddSubTaskToChecklist(Task task) { 
                subTaskList.Add(task);
        }
        public string GetSubTaskStrings()
        {
            string subTaskString = "";
            int count = 1;
            foreach (Task task in subTaskList)
            {
                var taskIsDone = task.CheckIfTaskIsDone();
                if(taskIsDone)
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

        public override string GetTaskString()
        {
            return $"{taskDescription} - Checklista: \n{GetSubTaskStrings()}";
        }
    } 
}
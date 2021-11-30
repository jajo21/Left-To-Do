using System;
using System.Collections.Generic;

namespace LeftToDo
{
    public class Checklist : Tasks
    {
        List<Tasks> subTaskList;
        string taskDescription;
        public Checklist(string taskDescription) : base(taskDescription)
        {
            subTaskList = new List<Tasks>();
            this.taskDescription = taskDescription;
        }

        public void AddSubTaskToChecklist(Tasks task) { 
                subTaskList.Add(task);
        }
        public string GetSubTaskStrings()
        {
            string subTaskString = "";
            int count = 1;
            foreach (Tasks task in subTaskList)
            {
                string message = $"({count}) [ ] {task.GetTaskString()}\n";
                subTaskString += message.PadLeft(message.Length + 5);
                count++;
            }
            return subTaskString;
        }

        public override string GetTaskString()
        {
            return $"{this.taskDescription}\n{GetSubTaskStrings()}";
        }
    } 
}
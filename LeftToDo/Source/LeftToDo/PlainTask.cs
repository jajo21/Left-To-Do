using System;

namespace LeftToDo
{
    public class PlainTask : Tasks
    {
        string taskDescription;
        public PlainTask(string taskDescription) : base(taskDescription)
        {
            this.taskDescription = taskDescription;
        }
        public override string GetTaskString() {
            return this.taskDescription;
        }
    }
}
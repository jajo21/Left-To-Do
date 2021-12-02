using System;

namespace LeftToDo
{
    public class PlainTask : Task
    {
        public PlainTask(string taskDescription) : base(taskDescription)
        {
        }
        public override string GetTaskString() {
            return this.taskDescription;
        }
    }
}
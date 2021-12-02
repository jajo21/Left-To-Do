using System;

namespace LeftToDo
{
    public class ChecklistSubTask : Task
    {
        public ChecklistSubTask(string taskDescription) : base(taskDescription){}
        public override string GetTaskString() {
            return this.taskDescription;
        }
    }
}
using System;

namespace LeftToDo
{
    /*  Subklass som ärver egenskaperna av superklassen Task. En klass som 
        skapar mer tydlighet i strukturen.    */
    public class ChecklistSubTask : Task
    {
        public ChecklistSubTask(string taskDescription) : base(taskDescription){}
        public override string GetTaskString() {
            return this.taskDescription;
        }
    }
}
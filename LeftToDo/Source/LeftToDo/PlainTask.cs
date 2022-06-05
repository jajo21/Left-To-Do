using System;

namespace LeftToDo
{
    /*  Subklass som ärver av superklassen Task. En klass som tar hand om vanliga 
        uppgifter som enbart innehåller uppgiftsbeskrivning     */
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
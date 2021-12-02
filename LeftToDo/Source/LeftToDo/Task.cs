using System;

namespace LeftToDo
{
    public abstract class Task
    {
        protected string taskDescription;
        protected bool isDone;
        
        public Task(string taskDescription) {
            this.taskDescription = taskDescription;
            this.isDone = false;
        }
        public void SetTaskAsDone()
        {
            if(isDone) {
                isDone = false;
            }
            else {
                isDone = true;
            }
        }
        public bool CheckIfTaskIsDone() {
            return isDone;
        }
        public virtual string GetTaskString(){
            return this.taskDescription;
        }
    }
}
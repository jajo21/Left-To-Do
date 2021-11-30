using System;

namespace LeftToDo
{
    public abstract class Tasks
    {
        string taskDescription;
        bool markedAsDone;
        
        public Tasks(string taskDescription) {
            this.taskDescription = taskDescription;
            markedAsDone = false;
        }

        public void SetTaskAsDone()
        {
            if(markedAsDone) {
                markedAsDone = false;
            }
            else {
                markedAsDone = true;
            }
        }
        public bool CheckIfTaskIsDone() {
            return markedAsDone;
        }

        public abstract string GetTaskString();
    }
}
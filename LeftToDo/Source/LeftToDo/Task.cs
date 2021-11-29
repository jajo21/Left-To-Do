using System;

namespace LeftToDo
{
    public class Task
    {
        string taskToDo;
        bool markedAsDone;

        public Task(string taskToDo) {
            markedAsDone = false;
            this.taskToDo = taskToDo;
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
        public string GetTaskString() {
            return taskToDo;
        }
    }
}
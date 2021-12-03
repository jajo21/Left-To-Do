using System;

namespace LeftToDo
{
    public abstract class Task
    {
        protected string taskDescription; // Beskrivning av varje uppgift
        protected bool isDone;  // Bockar av om en uppgift är färdig eller inte

        public Task(string taskDescription)
        {
            this.taskDescription = taskDescription;
            this.isDone = false;
        }
        public void SetTaskAsDone() //Sätter en uppgift som färdig
        {
            if (isDone)
            {
                isDone = false;
            }
            else
            {
                isDone = true;
            }
        }
        public bool CheckIfTaskIsDone() // Kollar om en uppgift är färdig
        { 
            return isDone;
        }
        public virtual string GetTaskString() // Returnar en sträng med uppgiftens beskrivning. Virtuell metod som körs över av subklasserna
        {
            return this.taskDescription;
        }
    }
}
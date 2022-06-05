using System;

namespace LeftToDo
{
    /*  Subklass som ärver av superklassen Task. En klass som tar hand om uppgifter
        med deadline. När en uppgift skapas behöver användaren mata in datum då uppgiften
        ska vara färdig.    */
    public class Deadline : Task
    {
        string deadline;
        public Deadline(string taskDescription, string deadline) : base(taskDescription)
        {
            this.deadline = deadline;
        }

        private int CountDaysLeft() // Uträkning som räknar ut hur många dagar det är kvar till deadline och returnar resultatet.
        {
            var deadlineDate = DateTime.Parse(this.deadline);
            DateTime today = DateTime.Today;
            TimeSpan timeLeft = deadlineDate - today;
            int daysLeft = timeLeft.Days;
            return daysLeft;
        }

        public override string GetTaskString() //Returnerar sträng som overridar superklassens virtuella metod.
        {
            return $"{taskDescription} | Deadline: {CountDaysLeft()} dagar";
        }
    }
}
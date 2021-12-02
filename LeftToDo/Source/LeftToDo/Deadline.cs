using System;

namespace LeftToDo
{
    public class Deadline : Task
    {
        string deadline;
        public Deadline(string taskDescription, string deadline) : base(taskDescription)
        {   
            this.deadline = deadline;
        }

        private int CountDaysLeft(){
            var deadlineDate = DateTime.Parse(this.deadline);
            DateTime today = DateTime.Today;
            TimeSpan timeLeft = deadlineDate - today;
            int daysLeft = timeLeft.Days;
            if(daysLeft >= 0) {
                return daysLeft;
            }
            else {
                daysLeft = 0;
                return daysLeft;
            }
        }

        public override string GetTaskString()
        {
            return $"{taskDescription} | Deadline: {CountDaysLeft()} dagar";
        }
    }
} 

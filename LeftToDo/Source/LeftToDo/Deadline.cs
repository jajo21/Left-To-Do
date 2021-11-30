using System;

namespace LeftToDo
{
    public class Deadline : Tasks
    {
        string deadline;
        int daysLeft;
        string taskDescription;
        public Deadline(string taskDescription, string deadline) : base(taskDescription)
        {   
            this.deadline = deadline;
            this.taskDescription = taskDescription;
        }

        private int CountDaysLeft(){
            var deadlineDate = DateTime.Parse(this.deadline);
            DateTime today = DateTime.Today;
            TimeSpan timeLeft = deadlineDate - today;
            daysLeft = timeLeft.Days;
            if(daysLeft >= 0) {
                return daysLeft;
            }
            else {
                daysLeft = 0;
                return daysLeft;
            }
            // BEHÖVER GÖRA FELHANTERING SÅ MAN ENDAST KAN SKRIVA IN DATUM PÅ ETT SÄTT OCH THROWA ERROR OM MAN GÖR FEL
        }

        public override string GetTaskString()
        {
            return $"{this.taskDescription} | Deadline: {CountDaysLeft()} dagar";
        }
    }

} 

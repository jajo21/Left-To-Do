using System;
using System.Globalization;

namespace LeftToDo
{
    class Menu
    {
        ToDoStorage leftToDo;
        string menuChoice;
        public Menu()
        {
            leftToDo = new ToDoStorage();
        }

        public void RunStartMenu()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Left To Do");
                Console.WriteLine("Gör dina menyval genom att trycka på en siffra och sedan Enter.");
                Console.WriteLine("Här kan du välja vad du vill göra:\n");
                Console.WriteLine("[1] Lägga till en ny uppgift");
                Console.WriteLine("[2] Lista alla uppgifter");
                Console.WriteLine("[3] Lista alla arkiverade uppgifter");
                Console.WriteLine("[4] Arkivera alla avklarade uppgifter");
                Console.WriteLine("[Q] Avsluta programmet\n");
                Console.Write("Skriv här: ");

                menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
                        RunAddToDoMenu();
                        break;
                    case "2":
                        PrintAllTasksAndSetToDone();
                        break;
                    case "3":
                        PrintAllArchivedTasks();
                        break;
                    case "4":
                        ArchiveAllTasksMarkedAsDone();
                        break;
                    case "Q":
                        return;
                    default:
                        Console.WriteLine("\nFelaktig inmatning! Du kan bara mata in siffror mellan 1-4, eller Q för att avsluta programmet.");
                        Console.WriteLine("Gå gärna tillbaka till menyn och försök igen!");
                        Console.WriteLine("\n---Tryck på valfri tangent för att gå tillbaka till menyn---");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }
        public void RunAddToDoMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Vilken typ av uppgift vill du skapa?");
                Console.WriteLine("[1] Tidlös uppgift");
                Console.WriteLine("[2] Uppgift med deadline");
                Console.WriteLine("[3] Uppgift med checklista");
                Console.WriteLine("[0] Avbryt och gå tillbaka till startmenyn\n");
                Console.Write("Skriv här: ");

                menuChoice = Console.ReadLine();
                switch (menuChoice)
                {
                    case "1":
                        AddPlainTask();
                        break;
                    case "2":
                        AddDeadlineTask();
                        break;
                    case "3":
                        AddChecklistTask();
                        break;
                    case "0":
                        Console.Clear();
                        return;
                    default:
                        Console.WriteLine("\nFelaktig inmatning! Du kan bara mata in siffror mellan 1-3, eller Q för att avsluta programmet.");
                        Console.WriteLine("Gå gärna tillbaka till menyn och försök igen!");
                        Console.WriteLine("\n---Tryck på valfri tangent för att gå tillbaka till menyn---");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }

        public void AddPlainTask()
        {
            Console.Clear();
            Console.WriteLine("Skriv in uppgiften här och klicka sedan på Enter.");
            Console.Write($"Skriv här: ");
            string task = Console.ReadLine();
            leftToDo.AddTaskToToDoList(new PlainTask(task));
            Console.Clear();
        }
        public void AddDeadlineTask()
        {
            Console.Clear();
            Console.WriteLine("Skriv in uppgiften här och klicka sedan på Enter.");
            Console.Write($"Skriv här: ");
            string task = Console.ReadLine();

            Console.WriteLine("\nSkriv in vilket datum uppgiften ska va klar i formatet YYYY/MM/DD.");
            Console.Write($"Skriv här: ");

            while (true)
            {
                string deadline = Console.ReadLine();

                if (!DateTime.TryParseExact(deadline, "yyyy/MM/dd", null, DateTimeStyles.None, out DateTime date))
                {
                    Console.WriteLine($"Felaktig inmatning av datum. Testa igen! Format: YYYY/MM/DD\n");
                    Console.Write($"Skriv här:");
                }
                else
                {
                    leftToDo.AddTaskToToDoList(new Deadline(task, deadline));
                    break;
                }
            }
            Console.Clear();
        }
        //AddCheckListTask behöver ändras/fixas.. Hur sparar man i den nya listan som ligger i Checklist? Hur kommer jag åt listan?
        // Exempel: Ta bort så att konstruktorn i alla Tasks inte behöver en inparameter och lägger till tasken manuellet med metod senare?
        // Ändra abstracta metoden på något sätt?
        // Öppna upp så checklist inte blir lika låst?
        //
        public void AddChecklistTask()
        {
            Console.Clear();
            Console.WriteLine("Här ska du skriva in en huvuduppgift med mindre delmål.");
            Console.WriteLine("Du kan lägga till hur många delmål du vill.");
            Console.WriteLine("Börja med att skriva in huvuduppgiften här och klicka sedan på Enter.\n");
            Console.Write($"Skriv här: ");
            string task = Console.ReadLine();
            Checklist checklistStorage = new Checklist(task);
            leftToDo.AddTaskToToDoList(checklistStorage);

            int count = 1;
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Vill du skriva delmål nummer {count} till uppgiften \"{task}\"?");
                Console.WriteLine("[1] Ja");
                Console.WriteLine("[2] Nej");
                Console.Write($"\nSkriv här: ");

                menuChoice = Console.ReadLine();
                switch (menuChoice)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine($"Delmål nummer {count}: ");
                        Console.Write($"\nSkriv här: ");
                        string subTask = Console.ReadLine();
                        checklistStorage.AddSubTaskToChecklist(new ChecklistSubTask(subTask));

                        Console.Clear();
                        Console.WriteLine("Delmål adderat!");
                        Console.WriteLine("Din nuvarande uppgift ser ut såhär: \n");
                        Console.WriteLine(checklistStorage.GetTaskString());
                        Console.WriteLine("---Tryck på valfri tangent för att gå tillbaka och göra fler val---");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        return;
                    default:
                        Console.WriteLine("\nFelaktig inmatning! Du kan bara mata in siffror mellan 1-2");
                        Console.WriteLine("\n---Tryck på valfri tangent för att gå tillbaka och göra ett nytt val---");
                        count--;
                        Console.ReadKey();
                        break;
                }
                count++;
            }
        }
        public void PrintAllTasksAndSetToDone()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Här är alla dina uppgifter:");
                Console.WriteLine("Vill du markera en uppgift som avklarad, tryck på motsvarande siffra och sedan Enter.");
                Console.WriteLine("Annars klicka på 0 och sedan Enter för att gå tillbaka till menyn.\n");
                Console.WriteLine(leftToDo.GetAllTasksInTodoList());      //Skriv ut alla todos till användaren


                var todoList = leftToDo.GetToDoList();      //Hämta listan för att kunna loopa genom den

                Console.Write("Skriv här: ");

                while (true)
                {
                    string input = Console.ReadLine();
                    if (input == "0")
                    {
                        Console.Clear();
                        return;
                    }
                    else
                    {
                        if (Int32.TryParse(input, out int chooseTask))
                        {
                            try
                            {
                                leftToDo.SetTaskInToDoListAsDone(chooseTask);
                                Console.Clear();
                                break;
                            }
                            catch (ArgumentOutOfRangeException ex)
                            {
                                Console.WriteLine("\n" + ex.Message);
                                Console.WriteLine("Testa igen!");
                                Console.Write("\nSkriv här:");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Felaktig inmatning. Du måste skriva en siffra. Testa igen!");
                            Console.Write("\nSkriv här: ");
                        }
                    }
                }
            }
        }
        public void PrintAllArchivedTasks()
        {
            Console.Clear();
            Console.WriteLine($"Här är alla dina arkiverade uppgifter:\n"); 
            Console.WriteLine(leftToDo.GetAllTasksInArchivedList());
            Console.WriteLine("\n---Tryck på valfri tangent för att gå tillbaka till startmenyn---");
            Console.ReadKey();
            Console.Clear();

        }
        public void ArchiveAllTasksMarkedAsDone()
        {
            Console.Clear();
            leftToDo.ArchieveTasksMarkedAsDone(); 
            Console.WriteLine("Alla färdiga uppgifter är arkiverade!");
            Console.WriteLine("\n---Tryck på valfri tangent för att gå tillbaka till startmenyn---");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
using System;
using System.Globalization;

namespace LeftToDo
{
    /*  Application är klassen som kör igång menyn och tar emot alla val som användaren gör.    
        Klassen är byggd på det sättet att först kommer metoden RunStartMenu som har en switch
        som tar sig in i alla metoder. Ser du första caset i switchen som en metod. Så kommer den metoden
        finnas på första plats under RunStartMenu. Är det inbyggda metoder i case:1 metoden så hittar du 
        dessa under den metoden. Sedan kommer du till Case 2 i switchen och den kommer finnas på andra plats 
        efter case:1 och dennes tillhörande metoder och så vidare. Det är en tydlig uppbyggnad som utgår från 
        startmenyn högst upp */
    class Application
    {
        Storage storage;
        string menuChoice;
        public Application()
        {
            storage = new Storage();
        }
        public void RunStartMenu()  // Visar menyn och leder användaren genom programmet, beroende på val, 
        {                           // RunStartMenu tar användaren in i rätt metoder och funktionalitet.
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
                    case "Q": case "q":
                        return;
                    default:
                        Console.WriteLine("\nFelaktig inmatning! Du kan bara mata in siffror mellan 1-4, eller Q för att avsluta programmet.");
                        Console.WriteLine("\n---Tryck på valfri tangent för att gå tillbaka till menyn---");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }
        public void RunAddToDoMenu() // Kör menyn och metoderna för addering av olika uppgifter.
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
        public void AddPlainTask() // Adderar en "vanlig"/enkel uppgift till todolistan
        {
            Console.Clear();
            Console.WriteLine("Skriv in uppgiften här och klicka sedan på Enter.");
            Console.Write($"Skriv här: ");
            string task = ReadLineCheckString();
            storage.AddTaskToToDoList(new PlainTask(task));
            Console.Clear();
        }
        public void AddDeadlineTask() // Adderar en uppgift med deadline till todolistan
        {
            Console.Clear();
            Console.WriteLine("Skriv in uppgiften här och klicka sedan på Enter.");
            Console.Write($"Skriv här: ");
            string task = ReadLineCheckString();

            Console.WriteLine("\nSkriv in vilket datum uppgiften ska va klar i formatet YYYY/MM/DD.");
            Console.Write($"Skriv här: ");

            while (true)
            {
                string deadline = Console.ReadLine();

                // Felhantering och formatering så vi får rätt sträng av användaren.
                if (!DateTime.TryParseExact(deadline, "yyyy/MM/dd",  new CultureInfo("swe-SV"), DateTimeStyles.None, out DateTime date))
                {
                    Console.WriteLine($"Felaktig inmatning av datum. Testa igen! Format: YYYY/MM/DD\n");
                    Console.Write($"Skriv här:"); 
                }
                else if(date<DateTime.Now){
                    Console.WriteLine($"\nDatumet har redan varit, skriv ett datum minst en dag framåt.\nTesta igen! Format: YYYY/MM/DD\n");
                    Console.Write($"Skriv här:"); 
                }
                else
                {
                    storage.AddTaskToToDoList(new Deadline(task, deadline));
                    break;
                }
            }
            Console.Clear();
        }
        public void AddChecklistTask() // Addera en uppgift med delmål(checklista) till todolistan
        {
            Console.Clear();
            Console.WriteLine("Här ska du skriva in en huvuduppgift med mindre delmål.");
            Console.WriteLine("Du kan lägga till hur många delmål du vill.");
            Console.WriteLine("Börja med att skriva in huvuduppgiften här och klicka sedan på Enter.\n");
            Console.Write($"Skriv här: ");
            string task = ReadLineCheckString();
            Checklist checklistStorage = new Checklist(task);
            storage.AddTaskToToDoList(checklistStorage);
            storage.AddTaskToChecklist(checklistStorage);

            int count = 1; // En räknare som gör det tydligare för användaren när den ska addera delmål
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Vill du skriva delmål nummer {count} till uppgiften \"{task}\"?");
                Console.WriteLine("Väljer du nej kommer du tillbaka till menyn för att lägga till uppgifter.\n");
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
                        string subTask = ReadLineCheckString();
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
        // Skriver ut alla uppgifter som finns todolistan och ger användaren möjlighet att markera dessa som avklarade
        public void PrintAllTasksAndSetToDone() 
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Här är alla dina uppgifter:");
                Console.WriteLine("Vill du markera en uppgift som avklarad, tryck på motsvarande siffra och sedan Enter.");
                Console.WriteLine("Annars klicka på 0 och sedan Enter för att gå tillbaka till menyn.\n");
                
                var todoList = storage.GetToDoList();      // Hämtar todolistan från storage för att tydligare kunna skriva ut den.
                Console.WriteLine(storage.GetAllTasksFromStorageLists(todoList));      //Skriv ut alla todos till användaren

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
                                if (storage.isTaskAChecklist(chooseTask))
                                {
                                    while (true)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("\n" + todoList[chooseTask - 1].GetTaskString());
                                        Console.WriteLine("Skriv in vilket nummer i checklistan du vill kryssa i.");
                                        Console.WriteLine("Är listan fullt ikryssad, fyll i nummer 1 och klicka på Enterknappen.");
                                        Console.WriteLine("Skriv 0 för att ta dig ut ur checklistan.");
                                        Console.Write("\nSkriv här: ");
                                        string checkListInput = Console.ReadLine();
                                        if (checkListInput == "0")
                                        {
                                            Console.Clear();
                                            break;
                                        }

                                        if (Int32.TryParse(checkListInput, out int checkListInputChooseTask))
                                        {
                                            try
                                            {
                                                storage.SetSubTaskChecklistListAsDone(chooseTask, checkListInputChooseTask);
                                                Console.Clear();
                                                break;
                                            }
                                            catch
                                            {
                                                Console.WriteLine("\nFelaktig inmatning. Du kan bara skriva nummer som finns i checklistan. Testa igen!");
                                                Console.Write("\nSkriv här:");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nFelaktig inmatning. Du kan bara skriva nummer som finns i listan. Testa igen!");
                                            Console.Write("\nSkriv här:");
                                        }
                                    }
                                }
                                else
                                {
                                    storage.SetTaskInToDoListAsDone(chooseTask);
                                }
                                Console.Clear();
                                break;
                            }
                            catch
                            {
                                Console.WriteLine("\nFelaktig inmatning. Du kan bara skriva nummer som finns i listan. Testa igen!");
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
        public void PrintAllArchivedTasks() // Skriver ut alla arkiverade uppgifter
        {
            Console.Clear();
            Console.WriteLine($"Här är alla dina arkiverade uppgifter:\n");
            Console.WriteLine(storage.GetAllTasksFromStorageLists(storage.GetArchivedList()));
            Console.WriteLine("\n---Tryck på valfri tangent för att gå tillbaka till startmenyn---");
            Console.ReadKey();
            Console.Clear();
        }
        public void ArchiveAllTasksMarkedAsDone() // Arkiverar alla uppgifter som är ikryssade som färdiga
        {
            Console.Clear();
            storage.ArchieveTasksMarkedAsDone();
            Console.WriteLine("Alla färdiga uppgifter är arkiverade!");
            Console.WriteLine("\n---Tryck på valfri tangent för att gå tillbaka till startmenyn---");
            Console.ReadKey();
            Console.Clear();
        }        
        private string ReadLineCheckString() // Kolla att en sträng inte är tom
        {
            string inputString;
            while (true)
            {
                inputString = Console.ReadLine();
                if (!string.IsNullOrEmpty(inputString))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Du kan inte lämna ett tomt fält! Försök igen.");
                    Console.Write("\nSkriv här: ");
                }
            }
            return inputString;
        }
    }
}
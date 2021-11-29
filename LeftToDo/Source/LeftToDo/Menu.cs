using System;

namespace LeftToDo
{
    class Menu
    {
        ToDos leftToDo;
        string menuChoice;
        public Menu() {
            leftToDo = new ToDos();
        }
        public void RunMenu()
        {
            Console.Clear();
            while (true)
            {
                PrintStartMenu();

                menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
                        AddToDo();
                        break;
                    case "2":
                        PrintToDo();
                        break;
                    case "3":
                        Console.WriteLine($"3");
                        break;
                    case "4":
                        Console.WriteLine($"4");
                        break;
                    case "Q":
                        return;
                    default:
                        Console.WriteLine("\nFelaktig inmatning! Du kan bara mata in siffror mellan 0-4. Gå gärna tillbaka till menyn och försök igen!");
                        Console.WriteLine("\n---Tryck på valfri tangent för att gå tillbaka till menyn---");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }
        public void PrintStartMenu() {
            Console.WriteLine("Left To Do");
            Console.WriteLine("Gör dina menyval genom att trycka på en siffra och sedan Enter.");
            Console.WriteLine("Här kan du välja vad du vill göra:");
            Console.WriteLine("[1] Lägga till en ny uppgift");
            Console.WriteLine("[2] Lista alla uppgifter");
            Console.WriteLine("[3] Lista alla arkiverade uppgifter");
            Console.WriteLine("[4] Arkivera alla avklarade uppgifter");
            Console.WriteLine("[Q] Avsluta programmet\n");
            Console.Write("Skriv här: ");
        }
        public void PrintAddToDoMenu(){
            
        }

        public void AddToDo() {
            Console.Write("Skriv in TODO: ");
            string input = Console.ReadLine();
            leftToDo.AddTaskToToDoList(new Task(input));
        }
        public void PrintToDo() {
            foreach(var task in leftToDo.GetToDoList()) {
                Console.WriteLine(task.GetTaskString());
            }
        }

    }
}
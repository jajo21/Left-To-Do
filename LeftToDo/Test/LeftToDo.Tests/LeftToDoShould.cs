using System;
using System.Collections.Generic;
using Xunit;

namespace LeftToDo.Tests
{

    public class LeftToDoShould
    {
        Storage storage;
        Task task1;
        Task task2;
        public LeftToDoShould()
        {
            storage = new Storage();
            task1 = new PlainTask("Do");
            task2 = new PlainTask("Do2");
        }

        [Fact]
        public void AddTaskToList() // Kollar att en uppgift kan läggas till i todolist
        {
            storage.AddTaskToToDoList(task1);
            storage.AddTaskToToDoList(task2);

            var expected = 2;

            var actual = storage.CountTasksInToDoList();

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void MarkTaskAsDone() // Kollar att en uppgift går att markera som färdig
        {
            task1.SetTaskAsDone();

            Assert.True(task1.CheckIfTaskIsDone());
        }
        [Fact]
        public void ArchiveTasksMarkedAsDone() // Kollar att man kan arkivera en lista som är markerad som klar
        {

            storage.AddTaskToToDoList(task1);
            storage.AddTaskToToDoList(task2);

            task1.SetTaskAsDone();
            storage.ArchieveTasksMarkedAsDone();

            var expected = 1;
            var arcActual = storage.CountTasksInArchivedList();
            var todoActual = storage.CountTasksInToDoList();

            Assert.Equal(expected, arcActual);
            Assert.Equal(expected, todoActual);
        }
        [Fact]
        public void CheckIfArchivedTaskIsCorrectTask() // Kollar att en arkiverad uppgift är rätt uppgit
        {
            storage.AddTaskToToDoList(task1);
            storage.AddTaskToToDoList(task2);

            var expected = "Do2";
            task2.SetTaskAsDone();
            storage.ArchieveTasksMarkedAsDone();

            var taskFromArchive = storage.GetArchivedList()[0].GetTaskString();

            Assert.Equal(expected, taskFromArchive);
        }
        [Fact]
        public void FillToDoListWithCheckListTaskAndCheckIfCorrect() // Kollar att korrekt Checklist-subtask läggs till i todolistan
        {
            Checklist checklist = new Checklist("DoCheck");
            ChecklistSubTask subtask = new ChecklistSubTask("DoSub");

            checklist.AddSubTaskToChecklist(subtask);

            storage.AddTaskToToDoList(checklist);

            var myTaskString = storage.GetToDoList()[0].GetTaskString();

            Assert.Contains("DoSub", myTaskString);
        }
        [Fact]
        public void SetSubTaskAsDone() // Kollar att en checklists-subtask går att sätta som färdig
        {
            Checklist checklist = new Checklist("DoCheck");
            ChecklistSubTask subtask = new ChecklistSubTask("DoSub");

            checklist.AddSubTaskToChecklist(subtask);
            storage.AddTaskToToDoList(checklist);

            checklist.GetSubTaskList()[0].SetTaskAsDone();
            var isSubTaskDone = checklist.GetSubTaskList()[0].CheckIfTaskIsDone();

            Assert.True(isSubTaskDone);

        }
                [Fact]
        public void CheckIfAllSubtasksInListIsDone() // Kollar om funktionaliteten för att se om alla subtasks är satta som färdiga i en lista fungerar.
        {
            Checklist checklist = new Checklist("DoCheck");
            ChecklistSubTask subtask = new ChecklistSubTask("DoSub");
            ChecklistSubTask subtask2 = new ChecklistSubTask("DoSub2");

            storage.AddTaskToChecklist(new Checklist("DoCheck"));
            checklist.AddSubTaskToChecklist(subtask);
            checklist.AddSubTaskToChecklist(subtask2);
            storage.AddTaskToChecklist(checklist);

            checklist.GetSubTaskList()[0].SetTaskAsDone();
            checklist.GetSubTaskList()[1].SetTaskAsDone();

            var isAllSubtaskSetToDone = storage.GetChecklistList()[0].CheckIfAllSubTasksIsDone();

            Assert.True(isAllSubtaskSetToDone);
        }
    }
}

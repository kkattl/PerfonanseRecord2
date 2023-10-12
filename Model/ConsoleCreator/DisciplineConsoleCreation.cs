using PerformanceRecord2.Controler;
using PerformanceRecord2.Model.Classes;
using System;
using static PerformanceRecord2.Model.Classes.Discipline;

namespace PerformanceRecord2.Model.ConsoleCreator
{
    public class DisciplineConsoleCreation : IConsoleCreation
    {
        IData data;
        public DisciplineConsoleCreation(IData data) 
        { 
            this.data = data;
        }
        public void ConsoleCreation()
        {
            int amountOfDisciplines;
            int disciplineId;
            string disciplineName;
            FormOfControl formOfControl;
            int numberOfCreditModuls;
            do
            {
                Console.WriteLine("Enter amount of disciplines");
            } while (!int.TryParse(Console.ReadLine(), out amountOfDisciplines) || amountOfDisciplines < 0);
            for (int i = 0; i < amountOfDisciplines; i++)
            {
                Console.WriteLine("Create new discipline");
                do
                {
                    Console.WriteLine("Enter discipline id");
                } while (!int.TryParse(Console.ReadLine(), out disciplineId) || disciplineId <= 0);
                do
                {
                    Console.WriteLine("Entre name of disciplines");
                    disciplineName = Console.ReadLine();
                } while (string.IsNullOrEmpty(disciplineName));
                do
                {
                    Console.WriteLine("Enter form of controle(1 - Test");
                } while (!Enum.TryParse(Console.ReadLine(), out formOfControl) || !Enum.IsDefined(typeof(FormOfControl), formOfControl));
                do
                {
                    Console.WriteLine("Enter amount of credit moduls");
                } while (!int.TryParse(Console.ReadLine(), out numberOfCreditModuls) || numberOfCreditModuls <= 0);

                data.Disciplines.Add(new Discipline() { DisciplineId = disciplineId, DisciplineName = disciplineName, 
                    ConcreteFormOfControl = formOfControl, NumberOfCreditModul = numberOfCreditModuls});
            }
        }
    }
}

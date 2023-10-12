using PerformanceRecord2.Controler;
using PerformanceRecord2.Model.Classes;
using System;

namespace PerformanceRecord2.Model.ConsoleCreator
{
    public class DisciplineResultConsoleCreation : IConsoleCreation
    {
        IData data;
        public DisciplineResultConsoleCreation(IData data)
        {
            this.data = data;
        }
        public void ConsoleCreation()
        {
            int amountOfMarks;
            int studentId;
            int disciplineId;
            int courseId;
            int mark;
            do
            {
                Console.WriteLine("Enter amount of marks");
            } while (!int.TryParse(Console.ReadLine(), out amountOfMarks) || amountOfMarks < 0);
            for (int i = 0; i < amountOfMarks; i++)
            {
                Console.WriteLine("Create new mark");
                do
                {
                    Console.WriteLine("Enter discipline id");
                } while (!int.TryParse(Console.ReadLine(), out disciplineId) || disciplineId <= 0);
                do
                {
                    Console.WriteLine("Enter student id");
                } while (!int.TryParse(Console.ReadLine(), out studentId) || studentId <= 0);
                do
                {
                    Console.WriteLine("Enter course id");
                } while (!int.TryParse(Console.ReadLine(), out courseId) || courseId <= 0);
                do
                {
                    Console.WriteLine("Enter mark");
                } while (!int.TryParse(Console.ReadLine(), out mark) || mark < 0 || mark > 100);

                data.DisciplineResults.Add(new DisciplineResult() { DisciplineId = disciplineId, StudentId = studentId, 
                    CourseId = courseId, Mark = mark});
            }
        }
    }
}

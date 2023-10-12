using PerformanceRecord2.Controler;
using PerformanceRecord2.Model.Classes;
using System;

namespace PerformanceRecord2.Model.ConsoleCreator
{
    public class StudentConsoleCreation : IConsoleCreation
    {
        public IData data;
        public StudentConsoleCreation(IData data) {  this.data = data; }
        public void ConsoleCreation()
        {
            int amountOfStudents;
            int studentId;
            string pib;
            do
            {
                Console.WriteLine("Enter amount of students");
            } while (!int.TryParse(Console.ReadLine(), out amountOfStudents) || amountOfStudents < 0);
            for (int i = 0; i < amountOfStudents; i++)
            {
                Console.WriteLine("Create new student");
                do
                {
                    Console.WriteLine("Enter student id");
                } while (!int.TryParse(Console.ReadLine(), out studentId) || studentId <= 0);
                do
                {
                    Console.WriteLine("Entre student's PIB");
                    pib = Console.ReadLine();
                } while (string.IsNullOrEmpty(pib));

                data?.Students.Add(new Student() { StudentId = studentId, PIB = pib});
            }
        } 
    }
}

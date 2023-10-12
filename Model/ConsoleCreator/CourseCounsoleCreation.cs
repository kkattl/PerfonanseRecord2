using PerformanceRecord2.Controler;
using PerformanceRecord2.Model.Classes;
using System;
using static PerformanceRecord2.Model.Classes.Course;

namespace PerformanceRecord2.Model.ConsoleCreator
{
    public class CourseCounsoleCreation : IConsoleCreation
    {
        IData data;
        public CourseCounsoleCreation(IData data)
        {
            this.data = data;
        }
        public void ConsoleCreation()
        {
            int amountOfCourses;
            int courseId;
            NumberOfCourses numberOfCourse;
            Semesters semester;
            int yearOfEducation;
            do
            {
              Console.WriteLine("Enter amount of courses");
            } while (!int.TryParse(Console.ReadLine(), out amountOfCourses) || amountOfCourses < 0);
            for (int i = 0; i < amountOfCourses; i++)
            {
                Console.WriteLine("Create new course");
                do
                {
                    Console.WriteLine("Enter course id");
                } while (!int.TryParse(Console.ReadLine(), out courseId) || courseId <= 0);
                do
                {
                    Console.WriteLine("Enter course number");
                } while (!Enum.TryParse(Console.ReadLine(), out numberOfCourse) || !Enum.IsDefined(typeof(NumberOfCourses), numberOfCourse));
                do
                {
                    Console.WriteLine("Enter semestr");
                } while (!Enum.TryParse(Console.ReadLine(), out semester) || !Enum.IsDefined(typeof(Semesters), semester));
                do
                {
                    Console.WriteLine("Enter year");
                } while (!int.TryParse(Console.ReadLine(), out yearOfEducation) || yearOfEducation < 0);

                data.Courses.Add(new Course() { CourseId = courseId, NumberOfCourse = numberOfCourse, Semester = semester, YearOfEducation = yearOfEducation});
            }
        }
    }
}

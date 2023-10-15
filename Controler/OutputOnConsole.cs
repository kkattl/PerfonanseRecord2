using PerformanceRecord2.Model.Classes;
using System;

namespace PerformanceRecord2.Controler
{
    public class OutputOnConsole : IOutput
    {
        IRequest _request;
        public OutputOnConsole(IRequest request)
        {
            this._request = request;
        }
        //0
        public void OutputAllStudents()
        {
            Console.WriteLine("Output all students");
            var students = _request.GetAllStudents();
            foreach (var student in students) 
            {
                Console.WriteLine($"{student.StudentId} - {student.PIB}");
            }
        }
        //1
        public void OutputGroupedDisciplinesByFormOfControle()
        {
            Console.WriteLine("Output grouped disciplines by form of controle");
            var groupedDisciplines = _request.GetGroupedDisciplinesByFormOfControle();
            foreach (var group in groupedDisciplines)
            {
                Console.WriteLine($"FormOfControl: {group.Key}");
                foreach (var discipline in group)
                {
                    Console.WriteLine($"  DisciplineName: {discipline.DisciplineName}");
                }
            }
        }
        //2
        public void OutputBestStudent()
        {
            Console.WriteLine("Output students with Max mark");
            var bestStudent = _request.GetBestStudent();
            foreach (dynamic student in bestStudent)
            {
                Console.WriteLine($"{student.studentId}-{student.pib}({student.mark})");
            }
        }
        //3
        public void OutputStudentsWherePIBStartWith(string letter)
        {
            Console.WriteLine($"Output students where PIB start with{letter}");
            var studentsStartsWith = _request.GetStudentsWherePIBStartWith(letter);
            foreach (var student in studentsStartsWith)
            {
                Console.WriteLine($"{student.StudentId} - {student.PIB}");
            }
        }
        //4
        public void OutputDisciplinesOnCourses()
        {
            Console.WriteLine("Output disciplines on courses ");
            var result = _request.GetDisciplinesOnCourses();
            foreach (dynamic item in result)
            {
                Console.WriteLine($"\nCourse: {item.numberOfCourse}, Semestr: {item.semester}\nDisciplines");
                foreach (dynamic discipline in item.disciplines)
                {
                    Console.WriteLine(discipline);
                }
            }
        }
        //5
        public void OutputConcatDisciplinesStartWith(string letter1, string letter2)
        {
            Console.WriteLine($"Output concat disciplines start with {letter1} and {letter2}");
            var disciplines = _request.GetConcatDisciplinesStartWith(letter1, letter2);
            foreach (var discipline in disciplines)
            {
                Console.WriteLine(discipline.ToString());
            }
        }
        //6
        public void OutputAverageMarkOnDiscipline()
        {
            Console.WriteLine("Output average mark on discipline");
            var result = _request.GetAverageMarkOnDiscipline();
            foreach (dynamic row in result)
            {
                Console.WriteLine($"{row.disciplineName}:\n   Average mark:{row.averageMark}");
            };
        }
        //7
        public void OutputStudentsWithOddId()
        {
            Console.WriteLine("Output students with odd Id");
            var students = _request.GetStudentsWithOddId();
            foreach (var student in students)
            {
                Console.WriteLine(student.ToString());
            }
        }
        //8
        public void OutputSearchMarkOnStudentDiscipline(int studentId, int disciplineId)
        {
            var studentMark = _request.GetSearchMarkOnStudentDiscipline(studentId, disciplineId);
            foreach (dynamic item in studentMark)
            {
                Console.WriteLine($"Mark: {item.Mark}");
            }
        }
        //9
        public void OutputStudentsWithMarkBetterThan(int mark)
        {
            Console.WriteLine($"Output students with mark better than ({mark})");
            var studentsMark = _request.GetStudentsWithMarkBetterThan(mark);
            foreach (dynamic item in studentsMark)
            {
                Console.WriteLine($"{item.pib} ({item.mark})");
            }
        }
        //10
        public void OutputNumberOfDisciplineOnCours()
        {
            Console.WriteLine("Output number of disciplines on cours");
            var result = _request.GetNumberOfDisciplineOnCours();
            foreach (dynamic item in result)
            {
                Console.WriteLine($"Course({item.courseNumber}) semestr({item.semestr}):\nAmount of disciplines: {item.disciplines}");
            }
        }
        //11
        public void OutputGroupeCoursesByYears()
        {
            Console.WriteLine("Output course grouping by years");
            var groupedCourses = _request.GetGroupeCoursesByYears();
            foreach (var groupe in groupedCourses)
            {
                Console.WriteLine($"\nCourse Year {groupe.Key}");
                foreach (var course in groupe)
                {
                    Console.WriteLine(course.CourseId);
                }
            }
        }
        //12
        public void OutputStudentResultOnDiscipline()
        {
            Console.WriteLine("Output students results");
            var result = _request.GetStudentResultOnDiscipline();
            foreach (dynamic item in result)
            {
                Console.WriteLine($"\n{item.disciplineName}");

                foreach (var row in item.studentsResults)
                {
                    Console.WriteLine($"      {row.pib} ({row.mark})");
                }
            }
        }
        //13
        public void OutputHighestMarkOnDiscipline()
        {
            Console.WriteLine("Output highest mark on discipline");
            var discipline100 = _request.GetHighestMarkOnDiscipline();
            foreach (dynamic item in discipline100)
            {
                Console.WriteLine($"{item.disciplineId}-{item.disciplineName} ({item.mark})");
            }
        }
        //14
        public void OutputStudentsConcat()
        {
            Console.WriteLine("Output list of first 3 students and skiped 5");
            var students = _request.GetStudentsConcat();
            foreach (var student in students)
            {
                Console.WriteLine(student.ToString());
            }
        }
        //15 
        public void OutputCreditModulOnDiscipline(int n)
        {
            Console.WriteLine("Output credit modul on discipline");
            var result = _request.GetCreditModulOnDiscipline(n);
            foreach (var item in result)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}

using PerformanceRecord2.Model.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;


namespace PerformanceRecord2.Controler
{
    public class OutputOnXML : IOutput
    {
        IRequest _request;
        string _folderPath;
        public OutputOnXML(IRequest request, string folder)
        {
            _request = request;
            this._folderPath = folder;
        }
        private object GetSafeValue(dynamic obj, string propertyName)
        {
            try
            {
                return obj.GetType().GetProperty(propertyName)?.GetValue(obj, null);
            }
            catch (Exception)
            {
                return $"Something went wrong";
            }
        }
        //1
        public void OutputGroupedDisciplinesByFormOfControle()
        {
            var groupedDisciplines = _request.GetGroupedDisciplinesByFormOfControle();

            XDocument resultXml = new XDocument(
            new XDeclaration("1.0", "utf-8", null),
            new XElement("GroupedDisciplines",
                groupedDisciplines.Select(group =>
                    new XElement("Group",
                        new XAttribute("FormOfControl", group.Key.ToString()),
                        group.Select(discipline =>
                            new XElement("Discipline",
                                new XElement("DisciplineId", discipline.DisciplineId),
                                new XElement("DisciplineName", discipline.DisciplineName),
                                new XElement("NumberOfCreditModul", discipline.NumberOfCreditModul)))))));
            
            string filePath = Path.Combine( _folderPath, "groupedDisciplinesByFormOfControle.xml");

            resultXml.Save(filePath);    
        }
        //2
        public void OutputBestStudent()
        {
            var bestStudent = _request.GetBestStudent();
            XDocument resultXml = new XDocument(
                new XDeclaration("1.0", "utf-8", null),
                new XElement("BestStudents",
                bestStudent.Select((student =>
                    new XElement("Student",
                        new XAttribute("StudentId", GetSafeValue(student, "studentId")),
                        new XElement("PIB", GetSafeValue(student, "pib")),
                        new XElement("Mark", GetSafeValue(student, "mark")))))));

            string filePath = Path.Combine(_folderPath, "bestStudent.xml");

            resultXml.Save(filePath);
        }
        //3
        public void OutputStudentsWherePIBStartWith(string letter)
        {
            var studentsStartsWith = _request.GetStudentsWherePIBStartWith(letter);
            XDocument resultXml = new XDocument(
                new XDeclaration("1.0", "utf-8", null),
                new XElement("Students",
                    studentsStartsWith.Select(student =>
                        new XElement("Student",
                        new XAttribute("StudentId", student.StudentId),
                        new XElement("PIB", student.PIB)))));
            string filePath = Path.Combine(_folderPath, "studentsStartsWith.xml");

            resultXml.Save(filePath);
        }
        //4
        public void OutputDisciplinesOnCourses()
        {
            var disciplinesOnCourses = _request.GetDisciplinesOnCourses();

            XDocument resultXml = new XDocument(
                new XDeclaration("1.0", "utf-8", null),
                new XElement("Courses",
                    from courseInfo in disciplinesOnCourses
                    select new XElement("Course",
                        new XAttribute("Number", GetSafeValue(courseInfo, "numberOfCourse")),
                        new XAttribute("Semester", GetSafeValue(courseInfo, "semester")),
                        new XElement("Disciplines",
                            ((IEnumerable<string>)GetSafeValue(courseInfo, "disciplines")).Select(disciplineName =>
                                 new XElement("Discipline", disciplineName))))));

            string filePath = Path.Combine(_folderPath, "disciplinesOnCourses.xml");

            resultXml.Save(filePath);
        }
        //5
        public void OutputConcatDisciplinesStartWith(string letter1, string letter2)
        {
            var concatedDisciplines = _request.GetConcatDisciplinesStartWith(letter1, letter2);
            XDocument resultXml = new XDocument(
               new XDeclaration("1.0", "utf-8", null),
                new XElement("Disciplines",
                    from discipline in concatedDisciplines
                    select new XElement("Discipline",
                        new XAttribute("DisciplineId", discipline.DisciplineId),
                        new XElement("DisciplineName", discipline.DisciplineName))));

            string filePath = Path.Combine(_folderPath, "concatedDisciplines.xml");

            resultXml.Save(filePath);
        }
        //6
        public void OutputAverageMarkOnDiscipline()
        {
            var averageMarks = _request.GetAverageMarkOnDiscipline();
            XDocument resultXml = new XDocument(
               new XDeclaration("1.0", "utf-8", null),
               new XElement("Disciplines",
                from averageMark in averageMarks
                select new XElement("Discipline",
                    new XElement("DisciplineName", GetSafeValue(averageMark, "disciplineName")),
                    new XElement("AverageMark", GetSafeValue(averageMark, "averageMark")))));

            string filePath = Path.Combine(_folderPath, "averageMarks.xml");

            resultXml.Save(filePath);

        }
        //7
        public void OutputStudentsWithOddId()
        {
            var students = _request.GetStudentsWithOddId();
            XDocument resultXml = new XDocument(
                new XDeclaration("1.0", "utf-8", null),
                new XElement("Students",
                from student in students
                select new XElement("Student",
                    new XAttribute("StudentId", student.StudentId),
                    new XElement("PIB", student.PIB))));

            string filePath = Path.Combine(_folderPath, "studentsWithOddId.xml");

            resultXml.Save(filePath);
        }
        //8
        public void OutputSearchMarkOnStudentDiscipline(int studentId, int disciplineId)
        {
            var marks = _request.GetSearchMarkOnStudentDiscipline(studentId, disciplineId);
            XDocument resultXml = new XDocument(
                new XDeclaration("1.0", "utf-8", null),
                new XElement("DisciplinesResults",
                from mark in marks
                select new XElement("DisciplinesResult",
                    new XAttribute("StudentId", mark.StudentId),
                    new XAttribute("DisciplineId", mark.DisciplineId),
                    new XElement("Mark", mark.Mark))));

            string filePath = Path.Combine(_folderPath, "searchMarkOnStudentDiscipline.xml");

            resultXml.Save(filePath);
        }
        //9
        public void OutputStudentsWithMarkBetterThan(int mark)
        {
            var students = _request.GetStudentsWithMarkBetterThan(mark);
            XDocument resultXml = new XDocument(
                new XDeclaration("1.0", "utf-8", null),
                new XElement("Students",
                    from student in students
                    select new XElement("Student",
                        new XElement("PIB", GetSafeValue(student, "pib")),
                        new XElement("Mark", GetSafeValue(student, "mark")))));

            string filePath = Path.Combine(_folderPath, "studentsWithMarkBetterThan.xml");

            resultXml.Save(filePath);
        }
        //10
        public void OutputNumberOfDisciplineOnCours()
        {
            var numberOfDisciplines = _request.GetNumberOfDisciplineOnCours();
            XDocument resultXml = new XDocument(
                 new XDeclaration("1.0", "utf-8", null),
                 new XElement("Coursess",
                 from numberOfDiscipline in numberOfDisciplines
                 select new XElement("Course",
                    new XAttribute("Number", GetSafeValue(numberOfDiscipline, "courseNumber")),
                        new XAttribute("Semester", GetSafeValue(numberOfDiscipline, "semestr")),
                        new XElement("NumberOfDisciplines", GetSafeValue(numberOfDiscipline, "disciplines")))));

            string filePath = Path.Combine(_folderPath, "numberOfDisciplines.xml");

            resultXml.Save(filePath);
        }
        //11
        public void OutputGroupeCoursesByYears()
        {
            var groupedCourses = _request.GetGroupeCoursesByYears();

            XDocument resultXml = new XDocument(
                new XDeclaration("1.0", "utf-8", null),
                new XElement("CoursesByYears",
                    from g in groupedCourses
                    select new XElement("Group",
                        new XAttribute("Year", GetSafeValue(g, "Key")),
                        from course in g
                        select new XElement("Course",
                            new XAttribute("Number", GetSafeValue(course, "NumberOfCourse")),
                            new XAttribute("Semester", GetSafeValue(course, "Semester"))))));

            string filePath = Path.Combine(_folderPath, "groupedCourses.xml");

            resultXml.Save(filePath);
        }
        //12
        public void OutputStudentResultOnDiscipline()
        {
            var studentResult = _request.GetStudentResultOnDiscipline();
            XDocument resultXml = new XDocument(
                new XDeclaration("1.0", "utf-8", null),
                new XElement("StudentResults",
                    from result in studentResult
                    select new XElement("Discipline",
                        new XAttribute("Name", GetSafeValue(result, "disciplineName")),
                        new XElement("Students",
                            from student in GetSafeValue(result, "studentsResults") as IEnumerable<dynamic>
                            select new XElement("Student",
                                new XElement("PIB", GetSafeValue(student, "pib")),
                                new XElement("Mark", GetSafeValue(student, "mark")))))));

            string filePath = Path.Combine(_folderPath, "studentResultOnDisciplines.xml");

            resultXml.Save(filePath);
        }
        //13
        public void OutputHighestMarkOnDiscipline()
        {
            var highestMarkOnDiscipline = _request.GetHighestMarkOnDiscipline();

            XDocument resultXml = new XDocument(
                new XDeclaration("1.0", "utf-8", null),
                 new XElement("Marks",
                    from result in highestMarkOnDiscipline
                    select new XElement("Disciplines",
                        new XAttribute("DisciplineId", GetSafeValue(result, "disciplineId")),
                        new XElement("DisciplineName", GetSafeValue(result, "disciplineName")),
                        new XElement("Mark", GetSafeValue(result, "mark")))));

            string filePath = Path.Combine(_folderPath, "highestMarkOnDiscipline.xml");

            resultXml.Save(filePath);
        }
        //14
        public void OutputStudentsConcat()
        {
            var studentConcat = _request.GetStudentsConcat();

            XDocument resultXml = new XDocument(
                new XDeclaration("1.0", "utf-8", null),
                new XElement("Students",
                from student in studentConcat
                select new XElement("Student",
                    new XAttribute("StudentId", student.StudentId),
                    new XElement("PIB", student.PIB))));

            string filePath = Path.Combine(_folderPath, "studentConcat.xml");

            resultXml.Save(filePath);
        }
        //15
        public void OutputCreditModulOnDiscipline(int n)
        {
            var disciplines = _request.GetCreditModulOnDiscipline(n);

            XDocument resultXml = new XDocument(
                new XDeclaration("1.0", "utf-8", null),
                new XElement("Disciplines",
                from discipline in disciplines
                select new XElement("Discipline",
                    new XAttribute("DisciplineId", discipline.DisciplineId),
                    new XElement("DisciplineName", discipline.DisciplineName),
                    new XElement("FormOfControl", discipline.ConcreteFormOfControl))));

            string filePath = Path.Combine(_folderPath, "creditModulOnDiscipline.xml");

            resultXml.Save(filePath);
        }
        }
}


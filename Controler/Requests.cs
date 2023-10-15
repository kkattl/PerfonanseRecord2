using PerformanceRecord2.Model.Classes;
using System.Collections.Generic;
using System.Linq;
using PerformanceRecord2.Model.XMLCreator;
using System;

namespace PerformanceRecord2.Controler
{
    public class Requests : IRequest
    {
        IConcretLouder _loader;
        IClassesFromXML _classes;
        public Requests(IConcretLouder louder, IClassesFromXML classes)
        {
            this._loader = louder;
            this._classes = classes;
        }
        //0
        public IEnumerable<Student> GetAllStudents()
        {
            return _loader.StudentDocument.Descendants("Student").Select(element => _classes.StudentElements(element));
        }
        //1
        public IEnumerable<IGrouping<Discipline.FormOfControl, Discipline>> GetGroupedDisciplinesByFormOfControle()
        {
            return _loader.DisciplineDocument.Descendants("Discipline")
                .Select(_classes.DisciplineElements)
                .Where(discipline => discipline != null)
                .GroupBy(discipline => discipline.ConcreteFormOfControl);
        }
        //2
        public IEnumerable<object> GetBestStudent()
        {
            var maxMark = _loader.DisciplineResultsDocument.Descendants("DisciplineResult")
                .Max(dr => _classes.DisciplineResultElements(dr).Mark);

            var bestStudents = from student in _loader.StudentDocument.Descendants("Student")
                               join disciplineResult in _loader.DisciplineResultsDocument.Descendants("DisciplineResult")
                               on _classes.StudentElements(student).StudentId equals _classes.DisciplineResultElements(disciplineResult).StudentId
                               where _classes.DisciplineResultElements(disciplineResult).Mark == maxMark
                               select new
                               {
                                   studentId = _classes.StudentElements(student).StudentId,
                                   pib = _classes.StudentElements(student).PIB,
                                   mark = maxMark
                               };

            return bestStudents;
        }
        //3
        public IEnumerable<Student> GetStudentsWherePIBStartWith(string letter)
        {
            var students = _loader.StudentDocument.Descendants("Student")
                .Where(student => _classes.StudentElements(student).PIB.StartsWith(letter, StringComparison.OrdinalIgnoreCase) == true)
                .Select(student => new Student
                {
                    StudentId = _classes.StudentElements(student).StudentId,
                    PIB = _classes.StudentElements(student).PIB
                });

            return students;
        }
        //4
        public IEnumerable<object> GetDisciplinesOnCourses()
        {
            var disciplinesOnCourses = from course in _loader.CourseDocument.Descendants("Course")
                                       join disciplineResult in _loader.DisciplineResultsDocument.Descendants("DisciplineResult")
                                       on _classes.CourseElements(course).CourseId equals _classes.DisciplineResultElements(disciplineResult).CourseId
                                       join discipline in _loader.DisciplineDocument.Descendants("Discipline")
                                       on _classes.DisciplineResultElements(disciplineResult).DisciplineId equals _classes.DisciplineElements(discipline).DisciplineId
                                       group discipline by new { _classes.CourseElements(course).NumberOfCourse, _classes.CourseElements(course).Semester } into courseGroup
                                       select new
                                       {
                                           numberOfCourse = courseGroup.Key.NumberOfCourse,
                                           semester = courseGroup.Key.Semester,
                                           disciplines = courseGroup.Select(ds => _classes.DisciplineElements(ds).DisciplineName)
                                       };
            return disciplinesOnCourses;
        }
        //5
        public IEnumerable<Discipline> GetConcatDisciplinesStartWith(string letter1, string letter2)
        {
            var result1 = _loader.DisciplineDocument.Descendants("Discipline")
                .Where(ds => _classes.DisciplineElements(ds).DisciplineName
                .StartsWith(letter1, StringComparison.OrdinalIgnoreCase));
            var result2 = _loader.DisciplineDocument.Descendants("Discipline")
                .Where(ds => _classes.DisciplineElements(ds).DisciplineName
                .StartsWith(letter2, StringComparison.OrdinalIgnoreCase));

            var result = result1.Concat(result2).Select(ds => _classes.DisciplineElements(ds));
            return result;
        }
        //6
        public IEnumerable<object> GetAverageMarkOnDiscipline()
        {
            var averageMark = _loader.DisciplineDocument.Descendants("Discipline")
                .GroupJoin(_loader.DisciplineResultsDocument.Descendants("DisciplineResult"),
                d => _classes.DisciplineElements(d).DisciplineId,
                dr => _classes.DisciplineResultElements(dr).StudentId,
                (d, drGroup) => new
                {
                    disciplineName = _classes.DisciplineElements(d).DisciplineName,
                    averageMark = drGroup.Average(dr => _classes.DisciplineResultElements(dr).Mark)
                });
            return averageMark;
        }
        //7
        public IEnumerable<Student> GetStudentsWithOddId()
        {
            return _loader.StudentDocument.Descendants("Student")
                .Where(s => _classes.StudentElements(s).StudentId % 2 != 0)
                 .Select(s => _classes.StudentElements(s));
        }
        //8
        public IEnumerable<DisciplineResult> GetSearchMarkOnStudentDiscipline(int studentId, int disciplineId)
        {
            return _loader.DisciplineResultsDocument.Descendants("DisciplineResult")
                .Where(dr => _classes.DisciplineResultElements(dr).StudentId == studentId
                     && _classes.DisciplineResultElements(dr).DisciplineId == disciplineId)
                .Select(dr => _classes.DisciplineResultElements(dr));
        }
        //9
        public IEnumerable<object> GetStudentsWithMarkBetterThan(int mark)
        {
            var result = _loader.DisciplineResultsDocument.Descendants("DisciplineResult")
                .Where(dr => _classes.DisciplineResultElements(dr).Mark >= mark)
                .Join(_loader.StudentDocument.Descendants("Student"),
                      dr => _classes.DisciplineResultElements(dr).StudentId,
                      s => _classes.StudentElements(s).StudentId,
                      (dr, s) => new
                      {
                          pib = _classes.StudentElements(s).PIB,
                          mark = _classes.DisciplineResultElements(dr).Mark
                      });
            return result;
        }
        //10
        public IEnumerable<object> GetNumberOfDisciplineOnCours()
        {
            var result = _loader.CourseDocument.Descendants("Course")
                .GroupJoin(_loader.DisciplineResultsDocument.Descendants("DisciplineResult"),
                           c => _classes.CourseElements(c).CourseId,
                           dr => _classes.DisciplineResultElements(dr).DisciplineId,
                           (c, drGroup) => new
                           {
                                courseNumber = _classes.CourseElements(c).NumberOfCourse,
                                semestr = _classes.CourseElements(c).Semester,
                                disciplines = drGroup.Count()
                           });
            return result;
        }
        //11
        public IEnumerable<IGrouping<int, Course>> GetGroupeCoursesByYears()
        {
            return _loader.CourseDocument.Descendants("Course")
                .Select(_classes.CourseElements)
                .Where(c => c != null)
                .GroupBy(c => c.YearOfEducation);
        }
        //12
        public IEnumerable<object> GetStudentResultOnDiscipline()
        {
            var result = from dr in _loader.DisciplineResultsDocument.Descendants("DisciplineResult")
                         join s in _loader.StudentDocument.Descendants("Student")
                         on _classes.DisciplineResultElements(dr).StudentId equals _classes.StudentElements(s).StudentId
                         join ds in _loader.DisciplineDocument.Descendants("Discipline")
                         on _classes.DisciplineResultElements(dr).DisciplineId equals _classes.DisciplineElements(ds).DisciplineId
                         group new { dr, s, ds } by _classes.DisciplineElements(ds).DisciplineName into g
                         select new
                         {
                             disciplineName = g.Key,
                             studentsResults = from x in g
                                               select new
                                               {
                                                   pib = _classes.StudentElements(x.s).PIB,
                                                   mark = _classes.DisciplineResultElements(x.dr).Mark
                                               }
                         };
            return result;
        }
        //13
        public IEnumerable<object> GetHighestMarkOnDiscipline()
        {
            var result = _loader.DisciplineDocument.Descendants("Discipline").GroupJoin(_loader.DisciplineResultsDocument.Descendants("DisciplineResult"),
                                                 ds => _classes.DisciplineElements(ds).DisciplineId,
                                                 dr => _classes.DisciplineResultElements(dr).DisciplineId,
                                                 (ds, drGroup) => new
                                                 {
                                                     disciplineId = _classes.DisciplineElements(ds).DisciplineId,
                                                     disciplineName = _classes.DisciplineElements(ds).DisciplineName,
                                                     mark = drGroup.Max(dr => _classes.DisciplineResultElements(dr).Mark)
                                                 });
            return result;
        }
        //14
        public IEnumerable<Student> GetStudentsConcat()
        {
            return _loader.StudentDocument.Descendants("Student").Take(3)
                   .Concat(_loader.StudentDocument.Descendants("Student").Skip(5))
                   .Select(s => _classes.StudentElements(s));
        }
        //15
        public IEnumerable<Discipline> GetCreditModulOnDiscipline(int n)
        {
            var result = from ds in _loader.DisciplineDocument.Descendants("Discipline")
                         where _classes.DisciplineElements(ds).NumberOfCreditModul == n
                         select _classes.DisciplineElements(ds);
            return result;
        }

    }
}

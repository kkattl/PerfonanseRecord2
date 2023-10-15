using PerformanceRecord2.Model.Classes;
using System.Collections.Generic;
using System.Linq;

namespace PerformanceRecord2.Controler
{
    public interface IRequest
    {
        //0
        IEnumerable<Student> GetAllStudents();
        //1
        IEnumerable<IGrouping<Discipline.FormOfControl, Discipline>> GetGroupedDisciplinesByFormOfControle();
        //2
        IEnumerable<object> GetBestStudent();
        //3
        IEnumerable<Student> GetStudentsWherePIBStartWith(string letter);
        //4
        IEnumerable<object> GetDisciplinesOnCourses();
        //5
        IEnumerable<Discipline> GetConcatDisciplinesStartWith(string letter1, string letter2);
        //6
        IEnumerable<object> GetAverageMarkOnDiscipline();
        //7
        IEnumerable<Student> GetStudentsWithOddId();
        //8
        IEnumerable<DisciplineResult> GetSearchMarkOnStudentDiscipline(int studentId, int disciplineId);
        //9
        IEnumerable<object> GetStudentsWithMarkBetterThan(int mark);
        //10
        IEnumerable<object> GetNumberOfDisciplineOnCours();
        //11
        IEnumerable<IGrouping<int, Course>> GetGroupeCoursesByYears();
        //12
        IEnumerable<object> GetStudentResultOnDiscipline();
        //13
        IEnumerable<object> GetHighestMarkOnDiscipline();
        //14
        IEnumerable<Student> GetStudentsConcat();
        //15
        IEnumerable<Discipline> GetCreditModulOnDiscipline(int n);
    }
}

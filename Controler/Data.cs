using PerformanceRecord2.Model.Classes;
using System.Collections.Generic;

namespace PerformanceRecord2.Controler
{
    public class Data : IData
    {
        public List<Student> Students { get; set; } = new List<Student>();
        public List<Course> Courses { get; set; } = new List<Course>();
        public List<Discipline> Disciplines { get; set; } = new List<Discipline>();   
        public List<DisciplineResult> DisciplineResults { get; set;} = new List<DisciplineResult>();
    }
}

using PerformanceRecord2.Model.Classes;
using System;
using System.Collections.Generic;


namespace PerformanceRecord2.Controler
{
    public interface IData
    {
        List<Student> Students { get; set; }
        List<Course> Courses { get; set; }
        List<Discipline> Disciplines { get; set; }
        List<DisciplineResult> DisciplineResults { get; set;}
    }
}

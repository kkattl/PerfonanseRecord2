using PerformanceRecord2.Model.Classes;
using System.Xml.Linq;

namespace PerformanceRecord2.Model.XMLCreator
{
    public interface IClassesFromXML
    {
        Student StudentElements(XElement xElement);
        Course CourseElements(XElement xElement);
        Discipline DisciplineElements(XElement xElement);
        DisciplineResult DisciplineResultElements(XElement xElement);
    }
}

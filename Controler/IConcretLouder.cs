using System.Xml.Linq;

namespace PerformanceRecord2.Controler
{
    public interface IConcretLouder
    {
        XDocument StudentDocument { get;}
        XDocument CourseDocument { get; }
        XDocument DisciplineDocument { get; }
        XDocument DisciplineResultsDocument { get; }
    }
}

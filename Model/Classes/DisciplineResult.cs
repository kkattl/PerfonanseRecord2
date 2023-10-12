using System;
using System.Xml.Serialization;

namespace PerformanceRecord2.Model.Classes
{
    public class DisciplineResult
    {
        [XmlElement("DisciplineId")]
        public int DisciplineId { get; set; }
        [XmlElement("StudentId")]
        public int StudentId { get; set; }
        [XmlElement("CourseId")]
        public int CourseId { get; set; }
        private int _mark;
       
        [XmlElement("Mark")]
        public int Mark
        {
            get { return _mark; }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    _mark = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("DisciplineResult must be between 0 and 100.");
                }
            }
        }
    }
}

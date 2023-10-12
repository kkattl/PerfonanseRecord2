using System.Xml.Serialization;
using System;


namespace PerformanceRecord2.Model.Classes
{
    [Serializable]
    [XmlRoot("Student")]
    public class Student
    {
        [XmlAttribute("StudentId")]
        public int StudentId { get; set; }
        [XmlElement("PIB")]
        public string PIB { get; set; }
        public override string ToString()
        {
            return $"{StudentId} - {PIB}";
        }
    }
}

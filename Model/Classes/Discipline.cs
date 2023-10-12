using System.Xml.Serialization;
using System;

namespace PerformanceRecord2.Model.Classes
{
    [Serializable]
    [XmlRoot("Discipline")]
    public class Discipline
    {
        [XmlAttribute("DisciplineId")]
        public int DisciplineId { get; set; }
        [XmlElement("DisciplineName")]
        public string DisciplineName { get; set; }
        [XmlElement("FormOfControl")]
        public FormOfControl ConcreteFormOfControl { get; set; }
        [XmlElement("NumberOfCreditModul")]
        public int NumberOfCreditModul { get; set; }

       

        public enum FormOfControl
        {
            Test = 1,
            Exam = 2,
        }

        public override string ToString()
        {
            return $"DisciplineName of discipline {DisciplineName}\n Type: {ConcreteFormOfControl}\n Number of credit modul {NumberOfCreditModul}";
        }

    }
}


using System.Xml.Serialization;
using System;

namespace PerformanceRecord2.Model.Classes
{
    [Serializable]
    [XmlRoot("Course")]
    public class Course
    {
        [XmlAttribute("CourseId")]
        public int CourseId { get; set; }
        [XmlElement("NumberOfCourse")]
        public NumberOfCourses NumberOfCourse { get; set; }
        [XmlElement("Semester")]
        public Semesters Semester { get; set; }
        [XmlElement("Year")]
        public int YearOfEducation { get; set; }

        public enum NumberOfCourses
        {
            First = 1,
            Second = 2,
            Third = 3,
            Forth = 4,
        }
        public enum Semesters
        {
            First = 1,
            Second = 2,
        }
    }
}


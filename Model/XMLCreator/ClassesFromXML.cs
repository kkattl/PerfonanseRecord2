using PerformanceRecord2.Model.Classes;
using System;
using System.Xml.Linq;

namespace PerformanceRecord2.Model.XMLCreator
{
    public class ClassesFromXML : IClassesFromXML
    {
        public Student StudentElements(XElement xElement)
        {
            Student student = null;

            if (xElement != null)
            {
                var studentIdAttribute = xElement.Attribute("StudentId");
                var pibElement = xElement.Element("PIB");

                if (studentIdAttribute != null && pibElement != null)
                {
                    if (int.TryParse(studentIdAttribute.Value, out int studentId))
                    {
                        student = new Student()
                        {
                            StudentId = studentId,
                            PIB = pibElement.Value,
                        };
                    }
                    else
                    {
                        throw new ArgumentException("Students can`t be converted to int");
                    }
                }
                else
                {
                    throw new ArgumentException("Student Id or pib wasn`t found");
                }
            }
            else
            {
                throw new ArgumentException("XElement = null");
            }
            return student;
        }

        public Course CourseElements(XElement xElement)
        {
            Course course = null;

            if (xElement != null)
            {
                var courseIdAttribute = xElement.Attribute("CourseId");
                var numberOfCourseElement = xElement.Element("NumberOfCourse");
                var semesterElement = xElement.Element("Semester");
                var yearElement = xElement.Element("Year");

                if (courseIdAttribute != null && numberOfCourseElement != null && semesterElement != null && yearElement != null)
                {
                    if (int.TryParse(courseIdAttribute.Value, out int courseId))
                    {
                        if (Enum.TryParse(numberOfCourseElement.Value, out Course.NumberOfCourses numberOfCourse) &&
                            Enum.TryParse(semesterElement.Value, out Course.Semesters semester))
                        {
                            if (int.TryParse(yearElement.Value, out int year))
                            {
                                course = new Course()
                                {
                                    CourseId = courseId,
                                    NumberOfCourse = numberOfCourse,
                                    Semester = semester,
                                    YearOfEducation = year,
                                };
                            }
                            else
                            {

                                throw new ArgumentException("Year can`t be converted to int");
                            }
                        }
                        else
                        {

                            throw new ArgumentException("NumberOfCourse or Semester can`t be converted ");
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Course Id can`t be converted to int");
                    }
                }
                else
                {
                    throw new ArgumentException("Course Id, NumberOfCourse, Semester, Year wasn`t found");
                }
            }
            else
            {
                throw new ArgumentException("XElement = null");
            }
            return course;
        }

        public Discipline DisciplineElements(XElement xElement)
        {
            Discipline discipline = null;

            if (xElement != null)
            {
                var disciplineIdAttribute = xElement.Attribute("DisciplineId");
                var disciplineNameElement = xElement.Element("DisciplineName");
                var formOfControlElement = xElement.Element("FormOfControl");
                var numberOfCreditModulElement = xElement.Element("NumberOfCreditModul");

                if (disciplineIdAttribute != null && disciplineNameElement != null && formOfControlElement != null && numberOfCreditModulElement != null)
                {
                    if (int.TryParse(disciplineIdAttribute.Value, out int disciplineId) && int.TryParse(numberOfCreditModulElement.Value, out int numberOfCreditModul))
                    {
                        Discipline.FormOfControl formOfControl;
                        if (Enum.TryParse(formOfControlElement.Value, out formOfControl))
                        {
                            discipline = new Discipline()
                            {
                                DisciplineId = disciplineId,
                                DisciplineName = disciplineNameElement.Value,
                                ConcreteFormOfControl = formOfControl,
                                NumberOfCreditModul = numberOfCreditModul,
                            };
                        }
                        else
                        {
                            Console.WriteLine("FormOfControl can`t be converted");
                        }
                    }
                    else
                    {
                        Console.WriteLine("DisciplineId or NumberOfCreditModul can`t be converted to int");
                    }
                }
                else
                {
                    Console.WriteLine("DisciplineId, DisciplineName, FormOfControl or NumberOfCreditModul weren`t found");
                }
            }
            else
            {
                Console.WriteLine("XElement = null");
            }

            return discipline;
        }
        public DisciplineResult DisciplineResultElements(XElement xElement)
        {
            DisciplineResult disciplineResult = null;

            if (xElement != null)
            {
                var disciplineIdElement = xElement.Element("DisciplineId");
                var studentIdElement = xElement.Element("StudentId");
                var courseIdElement = xElement.Element("CourseId");
                var markElement = xElement.Element("Mark");

                if (disciplineIdElement != null && studentIdElement != null && courseIdElement != null && markElement != null)
                {
                    if (int.TryParse(disciplineIdElement.Value, out int disciplineId) &&
                        int.TryParse(studentIdElement.Value, out int studentId) &&
                        int.TryParse(courseIdElement.Value, out int courseId) &&
                        int.TryParse(markElement.Value, out int mark))
                    {
                        disciplineResult = new DisciplineResult()
                        {
                            DisciplineId = disciplineId,
                            StudentId = studentId,
                            CourseId = courseId,
                            Mark = mark,
                        };
                    }
                    else
                    {
                        throw new ArgumentException("DisciplineResult can't be converted to int");
                    }
                }
                else
                {
                    throw new ArgumentException("DisciplineId, StudentId, CourseId, Mark weren't found");
                }
            }
            else
            {
                throw new ArgumentException("XElement = null");
            }

            return disciplineResult;
        }
    }
}

    

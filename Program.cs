using PerformanceRecord2.Controler;
using PerformanceRecord2.Model.Classes;
using PerformanceRecord2.Model.ConsoleCreator;
using PerformanceRecord2.Model.XMLCreator;
using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

namespace PerformanceRecord2
{
    public class Program
    {
        static void Main(string[] args)
        {
            string folderPath = @"C:\Users\Admin\Desktop\3cours5sem\NET\lab2XMLDocuments";
            LoadXML xmlLoader = new LoadXML();
            List<Student> students = xmlLoader.LoadFromXml<Student>(folderPath, "students.xml");

            if (students != null)
            {
                foreach (Student student in students)
                {
                    Console.WriteLine(student.ToString());
                }
            }
            //ReadXML readXML = new ReadXML();
            //List<Student> students = readXML.ReadListFromXml<Student>("students.xml");
            //Console.WriteLine(students.Count);
            // IData data = new Data();
            //// DisciplineResultConsoleCreation disciplineResultConsoleCreation = new DisciplineResultConsoleCreation(data);
            // //disciplineResultConsoleCreation.ConsoleCreation();
            // string folderPath = @"C:\Users\Admin\Desktop\3cours5sem\NET\lab2XMLDocuments";
            // LoadXML loadXml = new LoadXML();

            // XmlDocument xmlDoc = loadXml.LoadXmlDocument(folderPath, "courses");
            // ReadXML read = new ReadXML();

            // if (xmlDoc != null)
            // {
            //     Student student =read.DeserializeFromXml<Student>(xmlDoc);
            //     Console.WriteLine(student);
            // }

            ////WriteXML writeXml = new WriteXML(data); 
            ////writeXml.WriteListToXml(data.DisciplineResults, "disciplinesResults.xml", floderPath); 
            //LoadXML loadXml = new LoadXML();
            //XmlDocument xmlDocument = loadXml.LoadXmlDocument(folderPath, "students.xml");



            //ReadXML readXml = new ReadXML(data); // Создайте экземпляр класса ReadXML
            //Student loadedStudent = readXml.DeserializeFromXml<Student>(xmlDocument);
            Console.ReadKey();

        }
    }
}

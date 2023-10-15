using System;
using System.IO;
using System.Xml;

namespace PerformanceRecord2.Controler
{
    public class OutputXMLDocumentOnConsole
    {
        string _folderPath;
        string _filePath;
        public OutputXMLDocumentOnConsole(string folderPath, string filePath) 
        { 
            this._folderPath = folderPath;
            this._filePath = filePath;
        }
        public void XMLDocumentCourse()
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                string filePath = Path.Combine(_folderPath, _filePath);
                xmlDoc.Load(filePath);

                XmlNode root = xmlDoc.DocumentElement;
                XmlNodeList courseNodes = root.SelectNodes("Course");

                foreach (XmlNode courseNode in courseNodes)
                {
                    string courseId = courseNode.Attributes["CourseId"].Value;
                    string numberOfCourse = courseNode.SelectSingleNode("NumberOfCourse").InnerText;
                    string semester = courseNode.SelectSingleNode("Semester").InnerText;
                    string year = courseNode.SelectSingleNode("Year").InnerText;

                    Console.WriteLine($"CourseId: {courseId}");
                    Console.WriteLine($"NumberOfCourse: {numberOfCourse}");
                    Console.WriteLine($"Semester: {semester}");
                    Console.WriteLine($"Year: {year}");
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}

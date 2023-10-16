using PerformanceRecord2.Controler;
using PerformanceRecord2.Model.XMLCreator;
using PerformanceRecord2.View;
using System;

namespace PerformanceRecord2
{
    public class Program
    {
        static void Main(string[] args)
        {
            string folderPath = @"C:\Users\Admin\Desktop\3cours5sem\NET\lab2XMLDocuments";
            LoadXML xmlLoader = new LoadXML();
            ConcretLoader concretLoader = new ConcretLoader(xmlLoader, folderPath);
            ClassesFromXML classesFromXML = new ClassesFromXML();
            Requests requests = new Requests(concretLoader, classesFromXML);
            //Дописати меню
            //IOutput consoleOutput = new ();
            //OutputXMLDocumentOnConsole document = new OutputXMLDocumentOnConsole(folderPath, "courses.xml");
            //Menu menu = new Menu();
            
            //document.XMLDocumentCourse();

            Console.ReadKey();
        }
    }
}

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

            IOutput consoleOutput = new OutputOnConsole(requests);
            IOutputXMLDocumentOnConsole outputXMLDocumentOnConsole = new OutputXMLDocumentOnConsole(folderPath, "courses.xml");
            IOutput xmlOutput = new OutputOnXML(requests, folderPath);

            Console.WriteLine("Choose type of output (1 - console/2 - xml)");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                if (choice == 1) { Menu menu = new Menu(outputXMLDocumentOnConsole, consoleOutput); menu.Display(); }
                if (choice == 2) { Menu menu = new Menu(outputXMLDocumentOnConsole, xmlOutput); menu.Display(); }
                else
                {
                    Console.WriteLine("Incorrect number");
                }
            }
            else
            {
                Console.WriteLine("You have to enter number");
            }
            
            Console.ReadKey();
        }
    }
}

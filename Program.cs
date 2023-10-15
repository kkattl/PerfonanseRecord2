using PerformanceRecord2.Controler;
using PerformanceRecord2.Model.XMLCreator;
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
            OutputOnConsole output = new OutputOnConsole(requests);
            OutputOnXML outputXML = new OutputOnXML(requests, folderPath);
            //outputXML.OutputCreditModulOnDiscipline(4);
            //output.OutputCreditModulOnDiscipline(4);
            OutputXMLDocumentOnConsole document = new OutputXMLDocumentOnConsole(folderPath, "courses.xml");
            document.XMLDocumentCourse();

            Console.ReadKey();
        }
    }
}

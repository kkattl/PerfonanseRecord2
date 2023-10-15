using System.IO;
using System.Xml;
using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Xml.Linq;

namespace PerformanceRecord2.Model.XMLCreator
{
    public class LoadXML : ILoadXML
    {
        public XDocument LoadXmlDocument(string folderPath, string fileName)
        {
            XDocument xmlDoc = null;

            if (folderPath != null && fileName != null)
            {
                string filePath = Path.Combine(folderPath, fileName);

                try
                {
                    xmlDoc = XDocument.Load(filePath);
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine($"File {filePath} not found.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error while loading {filePath}: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("folderPath or fileName is null.");
            }

            return xmlDoc;
           
        }
    }
}

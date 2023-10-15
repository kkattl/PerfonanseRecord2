using System.Xml.Linq;

namespace PerformanceRecord2.Model.XMLCreator
{
    public interface ILoadXML
    {
        XDocument LoadXmlDocument(string folderPath, string fileName);
      
    }
}

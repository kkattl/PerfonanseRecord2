using System.Xml;

namespace PerformanceRecord2.Model.XMLCreator
{
    public interface ILoadXML
    {
        XmlDocument LoadXmlDocument(string folderPath, string fileName);
    }
}

using System.Collections.Generic;

namespace PerformanceRecord2.Model.XMLCreator
{
    public interface IWriterXML
    {
        void WriteListToXml<T>(List<T> data, string fileName, string folderPath);
    }
}

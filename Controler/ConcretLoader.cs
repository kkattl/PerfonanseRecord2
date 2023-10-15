using System.Xml;
using System.Xml.Linq;

using PerformanceRecord2.Model.XMLCreator;

namespace PerformanceRecord2.Controler
{
    public class ConcretLoader : IConcretLouder
    {
        ILoadXML xmlLoader;
        private string _folderPath;
        public ConcretLoader(ILoadXML xmlLoader, string floderPath)
        {
            this.xmlLoader = xmlLoader;
            this._folderPath = floderPath;
        }

        private XDocument _sdoc;
        private XDocument _cdoc;
        private XDocument _dsdoc;
        private XDocument _drdoc;
        public XDocument StudentDocument
        {
            get
            {
                if (_cdoc == null)
                {
                    _sdoc = xmlLoader.LoadXmlDocument(_folderPath, "students.xml");
                }
                
                return _sdoc;

            }
        }
        public XDocument CourseDocument 
        {
            get
            {
                if (_cdoc == null)
                {
                    _cdoc = xmlLoader.LoadXmlDocument(_folderPath, "courses.xml");
                }

                return _cdoc;
            }
        }
        public XDocument DisciplineDocument 
        {
            get
            {
                if (_dsdoc == null)
                {
                    _dsdoc = xmlLoader.LoadXmlDocument(_folderPath, "disciplines.xml");
                }

                return _dsdoc;
            }
        }
        public XDocument DisciplineResultsDocument 
        {
            get
            {
                if (_drdoc == null)
                {
                    _drdoc = xmlLoader.LoadXmlDocument(_folderPath, "disciplinesResults.xml");
                }

                return _drdoc;
            }
        }
    }
}

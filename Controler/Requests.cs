using PerformanceRecord2.Model.XMLCreator;

namespace PerformanceRecord2.Controler
{
    public class Requests
    {
        ILoadXML loadXML;
        public Requests(ILoadXML loadXML)
        {
            this.loadXML = loadXML;
        }
    }
}

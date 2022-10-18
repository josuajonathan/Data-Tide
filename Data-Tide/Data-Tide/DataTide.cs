using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTide
{
    public class JSONResponse
    {
        public List<data> data { get; set; }
        public meta meta { get; set; }
    }

    public class data
    {
        public double height { get; set; }
        public DateTime time { get; set; }
        public string type { get; set; }
    }

    public class meta
    {
        public double cost { get; set; }
        public double dailyQouta { get; set; }
        public string datum { get; set; }
        public DateTime end { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public double requestCount { get; set; }
        public DateTime start { get; set; }
        public station Station { get; set; }
    }

    public class station
    {
        public double distance { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public string name { get; set; }
        public string source { get; set; }
    }
}

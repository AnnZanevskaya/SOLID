using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BecomeSolid.Day1
{
    public class Rate
    {
        public string id { get; set; }
        public string Name { get; set; }
        public string RateCurrency { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Ask { get; set; }
        public string Bid { get; set; }
    }

    public class Results
    {
        public List<Rate> rate { get; set; }
    }

    public class Query
    {
        public int count { get; set; }
        public string created { get; set; }
        public string lang { get; set; }
        public Results results { get; set; }
    }

    public class RootObjectCurrency
    {
        public Query query { get; set; }
    }
}

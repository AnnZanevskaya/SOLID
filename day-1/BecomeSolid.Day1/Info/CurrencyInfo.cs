using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BecomeSolid.Day1
{
    public class Rate
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string RateCurrency { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Ask { get; set; }
        public string Bid { get; set; }
    }

    public class Results
    {
        public List<Rate> Rate { get; set; }
    }

    public class Query
    {
        public int Count { get; set; }
        public string Created { get; set; }
        public string Lang { get; set; }
        public Results Results { get; set; }
    }

    public class CurrencyResponce
    {
        public Query Query { get; set; }
    }
}

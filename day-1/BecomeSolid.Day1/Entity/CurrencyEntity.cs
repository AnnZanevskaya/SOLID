using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BecomeSolid.Day1.Entity;
using Newtonsoft.Json.Linq;

namespace BecomeSolid.Day1
{

    public class CurrencyEntity : IEntity
    {
        public string Name { get; set; }
        public string Currency { get; set; }
    }
}

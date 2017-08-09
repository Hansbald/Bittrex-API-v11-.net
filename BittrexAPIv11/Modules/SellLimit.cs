using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bittrexAPIv11
{
    public class SellLimit
    {
        public string uuid { get; set; }
    }

    internal class SellLimitRequest
    {
        public bool success { get; set; }
        public string message { get; set; }
        public SellLimit result { get; set; }
    }
}

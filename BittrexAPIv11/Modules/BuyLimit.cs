using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bittrexAPIv11
{
    public class BuyLimit
    {
        public string uuid { get; set; }
    }

    internal class BuyLimitRequest
    {
        public bool success { get; set; }
        public string message { get; set; }
        public BuyLimit result { get; set; }
    }
}

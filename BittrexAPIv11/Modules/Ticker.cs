using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bittrexAPIv11
{
    public class Ticker
    {
        public double Bid { get; set; }
        public double Ask { get; set; }
        public double Last { get; set; }
    }

    internal class TickerRequest
    {
        public bool success { get; set; }
        public string message { get; set; }
        public Ticker result { get; set; }
    }
}

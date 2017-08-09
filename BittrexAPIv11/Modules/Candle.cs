using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bittrexAPIv11
{
    public class Candle
    {
        public double O { get; set; }
        public double H { get; set; }
        public double L { get; set; }
        public double C { get; set; }
        public double V { get; set; }
        public string T { get; set; }
        public double BV { get; set; }
    }

    internal class CandleRequest
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<Candle> result { get; set; }
    }
}

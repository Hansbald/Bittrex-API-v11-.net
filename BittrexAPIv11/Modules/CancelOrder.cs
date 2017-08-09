using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bittrexAPIv11
{
    internal class CancelOrderRequest
    {
        public bool success { get; set; }
        public string message { get; set; }
        public string result { get; set; }
    }
}

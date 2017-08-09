using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bittrexAPIv11
{
    public class DepositAddress
    {
        public string Currency { get; set; }
        public string Address { get; set; }
    }

    internal class DepositAddressRequest
    {
        public bool success { get; set; }
        public string message { get; set; }
        public DepositAddress result { get; set; }
    }
}

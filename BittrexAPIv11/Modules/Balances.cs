using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bittrexAPIv11
{
    public class Balance
    {
        public string Currency { get; set; }
        [JsonProperty("Balance")]
        public double TotalBalance { get; set; }
        public double Available { get; set; }
        public double Pending { get; set; }
        public string CryptoAddress { get; set; }
        public bool Requested { get; set; }
        public object Uuid { get; set; }
    }

    internal class BalancesRequest
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<Balance> result { get; set; }
    }
}

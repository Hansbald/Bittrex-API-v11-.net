using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bittrexAPIv11
{
    public class Currency
    {
        [JsonProperty("Currency")]
        public string CurrencyShort { get; set; }
        public string CurrencyLong { get; set; }
        public int MinConfirmation { get; set; }
        public double TxFee { get; set; }
        public bool IsActive { get; set; }
        public string CoinType { get; set; }
        public string BaseAddress { get; set; }
        public string Notice { get; set; }
    }

    internal class CurrenciesRequest
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<Currency> result { get; set; }
    }
}

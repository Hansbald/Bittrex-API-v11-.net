using System.Collections.Generic;

namespace bittrexAPIv11
{
    public class Buy
    {
        public double Quantity { get; set; }
        public double Rate { get; set; }
    }

    public class Sell
    {
        public double Quantity { get; set; }
        public double Rate { get; set; }
    }

    public class OrderBook
    {
        public List<Buy> buy { get; set; }
        public List<Sell> sell { get; set; }
    }

    internal class OrderBookRequest
    {
        public bool success { get; set; }
        public string message { get; set; }
        public OrderBook result { get; set; }
    }
    public enum OrderBookType
    {
        Sell,
        Buy,
        Both,
    }

}

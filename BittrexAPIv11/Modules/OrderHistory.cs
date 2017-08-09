using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bittrexAPIv11
{
    public class OrderHistory
    {
        public string OrderUuid { get; set; }
        public string Exchange { get; set; }
        public string TimeStamp { get; set; }
        public string OrderType { get; set; }
        public double Limit { get; set; }
        public double Quantity { get; set; }
        public double QuantityRemaining { get; set; }
        public double Commission { get; set; }
        public double Price { get; set; }
        public double? PricePerUnit { get; set; }
        public bool IsConditional { get; set; }
        public object Condition { get; set; }
        public object ConditionTarget { get; set; }
        public bool ImmediateOrCancel { get; set; }
    }

    internal class OrderHistoryRequest
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<OrderHistory> result { get; set; }
    }
}

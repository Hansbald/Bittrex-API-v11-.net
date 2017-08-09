using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bittrexAPIv11
{
    public class Deposit
    {
        public string PaymentUuid { get; set; }
        public string Currency { get; set; }
        public double Amount { get; set; }
        public string Address { get; set; }
        public string Opened { get; set; }
        public bool Authorized { get; set; }
        public bool PendingPayment { get; set; }
        public double TxCost { get; set; }
        public string TxId { get; set; }
        public bool Canceled { get; set; }
        public bool InvalidAddress { get; set; }
        public string __invalid_name__Opened { get; set; }
    }

    internal class DepositHistoryRequest
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<Deposit> result { get; set; }
    }
}

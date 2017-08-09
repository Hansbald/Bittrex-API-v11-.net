using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace bittrexAPIv11
{
    class BittrexAPI
    {
        private string _API_KEY;
        private string _API_SECRET;
        private string _NONCE;
        private string _SIGN;
        private string _API_URL;
        private Uri _URI;

        public BittrexAPI(string API_KEY, string API_SECRET, string API_URL = "https://bittrex.com/api/", string API_VERSION = "1.1")
        {
            _API_KEY = API_KEY;
            _API_SECRET = API_SECRET;
            _API_URL = API_URL + "v" + API_VERSION;
            Console.WriteLine("Bittrex API URL: " + API_URL);
        }

        #region /Public/
        //public/getmarkets
        public List<Market> GetMarkets()
        {
            MarketsRequest mr = JsonConvert.DeserializeObject<MarketsRequest>(getPublicRequest("/public/getmarkets"));
            if (mr.success) { return mr.result; }
            Exception e = new Exception(mr.message);
            throw e;
        }

        //public/getcurrencies
        public List<Currency> GetCurrencies()
        {
            CurrenciesRequest cr = JsonConvert.DeserializeObject<CurrenciesRequest>(getPublicRequest("/public/getcurrencies"));
            if (cr.success) { return cr.result; }
            Exception e = new Exception(cr.message);
            throw e;
        }

        //public/getticker
        public Ticker GetTicker(string pair)
        {
            TickerRequest tr = JsonConvert.DeserializeObject<TickerRequest>(getPublicRequest("/public/getticker", "?market=" + pair));
            if (tr.success) { return tr.result; }
            Exception e = new Exception(tr.message);
            throw e;
        }

        //public/getmarketsummaries
        //public/getmarketsummary
        public List<MarketSummary> GetMarketSummary(string pair = null)
        {
            if (pair == null)
            {
                MarketSummariesRequest msr = JsonConvert.DeserializeObject<MarketSummariesRequest>(getPublicRequest("/public/getmarketsummaries"));
                if (msr.success) { return msr.result; }
                Exception ex = new Exception(msr.message);
                throw ex;
            }

            MarketSummariesRequest msr2 = JsonConvert.DeserializeObject<MarketSummariesRequest>(getPublicRequest("/public/getmarketsummary", "?market=" + pair));
            if (msr2.success) { return msr2.result; }
            Exception e = new Exception(msr2.message);
            throw e;
        }

        //public/getorderbook
        public OrderBook GetOrderBook(string pair, OrderBookType type)
        {
            string json = "";
            if (type == OrderBookType.Buy) { json = getPublicRequest("/public/getorderbook", "?market=" + pair, "&type=buy"); }
            if (type == OrderBookType.Sell) { json = getPublicRequest("/public/getorderbook", "?market=" + pair, "&type=sell"); }
            if (type == OrderBookType.Both) { json = getPublicRequest("/public/getorderbook", "?market=" + pair, "&type=both"); }
            OrderBookRequest obr = JsonConvert.DeserializeObject<OrderBookRequest>(json);
            if (obr.success) { return obr.result; }
            Exception e = new Exception(obr.message);
            throw e;
        }

        //public/getmarkethistory
        public List<MarketHistory> GetMarketHistory(string pair)
        {
            MarketHistoryRequest mhr = JsonConvert.DeserializeObject<MarketHistoryRequest>(getPublicRequest("/public/getmarkethistory", "?market=" + pair));
            if (mhr.success) { return mhr.result; }
            Exception e = new Exception(mhr.message);
            throw e;
        }
        #endregion

        #region /Market/

        //bittrex.com/Api/v2.0/pub/market/GetTicks?tickInterval=%s&marketName=%s&_=%d
        public List<Candle> GetTicks(string pair)
        {
            string o = "";
            _URI = new Uri("https://bittrex.com/Api/v2.0/pub/market/GetTicks?tickInterval=fiveMin&marketName=" + pair);


            Console.WriteLine("Querry: " + _URI);
            WebRequest rq = WebRequest.Create(_URI);
            WebResponse webResponse = rq.GetResponse();
            using (var sr = new StreamReader(webResponse.GetResponseStream()))
            {
                o = sr.ReadToEnd();
            }
            CandleRequest cr = JsonConvert.DeserializeObject<CandleRequest>(o);
            if (cr.success) { return cr.result; }
            Exception e = new Exception(cr.message);
            throw e;
        }

        //market/buylimit
        public BuyLimit BuyLimit(string market, string quantity, string rate)
        {
            BuyLimitRequest blr = JsonConvert.DeserializeObject<BuyLimitRequest>(getPrivateRequest("/market/buylimit", "&market=" + market, "&quantity=" + quantity, "&rate=" + rate));
            if (blr.success) { return blr.result; }
            Exception e = new Exception(blr.message);
            throw e;
        }

        //market/selllimit
        public SellLimit SellLimit(string market, string quantity, string rate)
        {
            SellLimitRequest slr = JsonConvert.DeserializeObject<SellLimitRequest>(getPrivateRequest("/market/selllimit", "&market=" + market, "&quantity=" + quantity, "&rate=" + rate));
            if (slr.success) { return slr.result; }
            Exception e = new Exception(slr.message);
            throw e;
        }

        //market/cancel
        public bool CancelOrder(string UUID)
        {
            CancelOrderRequest slr = JsonConvert.DeserializeObject<CancelOrderRequest>(getPrivateRequest("/market/cancel", "&uuid=" + UUID));
            if (slr.success) { return true; }
            Exception e = new Exception(slr.message);
            throw e;
        }

        //market/getopenorders
        public List<OpenOrder> GetOpenOrders(string pair = null)
        {
            string json = "";
            if (pair == null) { json = getPrivateRequest("/market/getopenorders"); }
            if (pair != null) { json = getPrivateRequest("/market/getopenorders", "&market=" + pair); }

            OpenOrdersRequest oor = JsonConvert.DeserializeObject<OpenOrdersRequest>(json);
            if (oor.success) { return oor.result; }
            Exception e = new Exception(oor.message);
            throw e;

        }
        #endregion

        #region /Account/
        //account/getbalances
        public List<Balance> GetAllBalances()
        {
            BalancesRequest br = JsonConvert.DeserializeObject<BalancesRequest>(getPrivateRequest("/account/getbalances"));
            if (br.success) { return br.result; }
            Exception e = new Exception(br.message);
            throw e;
        }

        //account/getbalance
        public Balance GetBalance(string currency)
        {
            /*
            BalancesRequest br = JsonConvert.DeserializeObject<BalancesRequest>(getPrivateRequest("/account/getbalance", "&currency=" + currency));
            if (br.success) { return br.result.First(); }
            Exception e = new Exception(br.message);
            throw e;*/
            Console.WriteLine("Not Implemented");
            return null;
        }

        //account/getdepositaddress
        public DepositAddress GetDepositAddress(string currency)
        {
            DepositAddressRequest dar = JsonConvert.DeserializeObject<DepositAddressRequest>(getPrivateRequest("/account/getdepositaddress", "&currency=" + currency));
            if (dar.success) { return dar.result; }
            Exception e = new Exception(dar.message);
            throw e;
        }

        //account/getorder
        public Order GetOrderByUUID(string UUID)
        {
            OrderRequest or = JsonConvert.DeserializeObject<OrderRequest>(getPrivateRequest("/account/getorder", "&uuid=" + UUID));
            if (or.success) { return or.result; }
            Exception e = new Exception(or.message);
            throw e;
        }

        //account/getorderhistory
        public List<OrderHistory> GetOrderHistory(string pair = null)
        {
            string json = "";
            if (pair == null) { json = getPrivateRequest("/account/getorderhistory"); }
            if (pair != null) { json = getPrivateRequest("/account/getorderhistory", "&market=" + pair); }

            OrderHistoryRequest ohr = JsonConvert.DeserializeObject<OrderHistoryRequest>(json);
            if (ohr.success) { return ohr.result; }
            Exception e = new Exception(ohr.message);
            throw e;

        }

        //account/getwithdrawalhistory
        public List<Withdrawal> GetWithdrawalHistory(string currency = null)
        {
            string json = "";
            if (currency == null) { json = getPrivateRequest("/account/getwithdrawalhistory"); }
            if (currency != null) { json = getPrivateRequest("/account/getwithdrawalhistory", "&currency=" + currency); }

            WithdrawalHistoryRequest whr = JsonConvert.DeserializeObject<WithdrawalHistoryRequest>(json);
            if (whr.success) { return whr.result; }
            Exception e = new Exception(whr.message);
            throw e;
        }

        //account/getdeposithistory
        public List<Deposit> GetDepositHistory(string currency = null)
        {
            string json = "";
            if (currency == null) { json = getPrivateRequest("/account/getdeposithistory"); }
            if (currency != null) { json = getPrivateRequest("/account/getdeposithistory", "&currency=" + currency); }

            DepositHistoryRequest dhr = JsonConvert.DeserializeObject<DepositHistoryRequest>(json);
            if (dhr.success) { return dhr.result; }
            Exception e = new Exception(dhr.message);
            throw e;
        }
        #endregion

        private string getPrivateRequest(string message, string arg1 = null, string arg2 = null, string arg3 = null)
        {
            string o = null;
            _NONCE = System.DateTime.Now.Ticks.ToString();

            string uri_string = _API_URL + message + "?apikey=" + _API_KEY + "&nonce=" + _NONCE;
            if (arg1 != null) { uri_string += arg1; }
            if (arg2 != null) { uri_string += arg2; }
            if (arg3 != null) { uri_string += arg3; }

            _URI = new Uri(uri_string);
            _SIGN = SignRequest(uri_string);
            Console.WriteLine("Querry: " + _URI);
            Console.WriteLine("Hash: " + _SIGN);
            Console.WriteLine("NONCE: " + _NONCE);
            WebRequest rq = WebRequest.Create(_URI);
            rq.Headers.Add("apisign:" + _SIGN);
            WebResponse webResponse = rq.GetResponse();

            using (var sr = new StreamReader(webResponse.GetResponseStream()))
            {
                o = sr.ReadToEnd();
            }
            return o;
        }
        private string getPublicRequest(string message, string arg1 = null, string arg2 = null)
        {
            string o = "";
            if (arg1 == null && arg2 == null) { _URI = new Uri(_API_URL + message); }
            if (arg1 != null) { _URI = new Uri(_API_URL + message + arg1); }
            if (arg2 != null) { _URI = new Uri(_API_URL + message + arg1 + arg2); }

            Console.WriteLine("Querry: " + _URI);
            WebRequest rq = WebRequest.Create(_URI);
            WebResponse webResponse = rq.GetResponse();
            using (var sr = new StreamReader(webResponse.GetResponseStream()))
            {
                o = sr.ReadToEnd();
            }
            return o;
        }

        private string SignRequest(string URI)
        {
            /* The Key is API_SECRET
             * The message is the URL of the request
             * Return is the Hash
             */
            string output = null;
            // Initialize the keyed hash object with API_SECRET.
            using (HMACSHA512 hmac = new HMACSHA512(Encoding.UTF8.GetBytes(_API_SECRET)))
            {
                hmac.ComputeHash(Encoding.UTF8.GetBytes(URI));
                output = ByteToString(hmac.Hash);
            }
            return output;
        }

        static string ByteToString(byte[] buff)
        {
            string sbinary = "";
            for (int i = 0; i < buff.Length; i++)
                sbinary += buff[i].ToString("X2"); /* hex format */
            return sbinary;
        }
    }
}

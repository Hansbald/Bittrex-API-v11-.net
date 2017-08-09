# Bittrex-API-v11-.net
A full implementation of the Bittrex API v1.1 (and the GetTicks() method) in C# (.net).

This libary is licensed under MIT and uses the json.NET libary for deserialization.

**Init:**
```C#
BittrexAPI myAPI = new BittrexAPI("API_KEY", "API_SECRET");
```
This initializes the Wrapper, every function returns an object with every return-paramter:
```C#
OrderBook ob = myAPI.GetOrderBook("BTC-LTC", OrderBookType.Both);
```   
This example gets both the Buy and Sell side of the Order Book, you can loop through the results like this:
```C#
foreach(Buy b in ob.buy){
   Console.WriteLine("Quantitiy: "  + b.Quantity + " Rate: " + b.Rate);
}
```

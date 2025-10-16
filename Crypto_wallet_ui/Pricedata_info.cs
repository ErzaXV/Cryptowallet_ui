using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Crypto_wallet_ui
{
    internal class Pricedata_info
    {
        public class root
        {
            public string status { get; set; }

            // Coins dictionary
            public Dictionary<string, coin> data { get; set; }

            // Optional helper to access specific coins easily
            [JsonIgnore]
            public coin BTCUSD => data.ContainsKey("BTC-USD") ? data["BTC-USD"] : new coin();
            [JsonIgnore]
            public coin ETHUSD => data.ContainsKey("ETH-USD") ? data["ETH-USD"] : new coin();
            [JsonIgnore]
            public coin LTCUSD => data.ContainsKey("LTC-USD") ? data["LTC-USD"] : new coin();
            [JsonIgnore]
            public coin SOLUSD => data.ContainsKey("SOL-USD") ? data["SOL-USD"] : new coin();
            [JsonIgnore]
            public coin USDTUSD => data.ContainsKey("USDT-USD") ? data["USDT-USD"] : new coin();
            [JsonIgnore]
            public coin XMRUSD => data.ContainsKey("XMR-USD") ? data["XMR-USD"] : new coin();
        }

        public class coin
        {
            public double VALUE { get; set; }
            public string VALUE_FLAG { get; set; }
        }
    }
}

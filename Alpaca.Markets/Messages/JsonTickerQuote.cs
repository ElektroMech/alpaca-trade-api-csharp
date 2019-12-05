using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Alpaca.Markets
{
    /// <summary>
    /// 
    /// </summary>
    [SuppressMessage(
        "Microsoft.Performance", "CA1812:Avoid uninstantiated internal classes",
        Justification = "Object instances of this class will be created by Newtonsoft.JSON library.")]
    internal sealed class JsonTickerQuote : ITickerQuote
    {
        [JsonProperty(PropertyName = "p", Required = Required.Always)]
        public decimal BidPrice { get; set; }

        [JsonProperty(PropertyName = "P", Required = Required.Always)]
        public decimal AskPrice { get; set; }

        [JsonProperty(PropertyName = "s", Required = Required.Always)]
        public long BidSize { get; set; }

        [JsonProperty(PropertyName = "S", Required = Required.Always)]
        public long AskSize { get; set; }

        [JsonProperty(PropertyName = "t", Required = Required.Always)]
        public Int64 UpdatedTime { get; set; }
    }
}

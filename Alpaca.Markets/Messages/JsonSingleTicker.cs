using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace Alpaca.Markets
{
    /// <summary>
    /// 
    /// </summary> 
    [SuppressMessage(
        "Microsoft.Performance", "CA1812:Avoid uninstantiated internal classes",
        Justification = "Object instances of this class will be created by Newtonsoft.JSON library.")]
    internal sealed class JsonSingleTicker : ISingleTicker
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "ticker", Required = Required.Always)]
        public string Symbol { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "lastTrade", Required = Required.Default)]
        public JsonTickerLast JsonLastTrade { get; set; }
        public ITickerLast LastTrade => this.JsonLastTrade;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "lastQuote", Required = Required.Default)]
        public JsonTickerQuote JsonLastQuote { get; set; }
        public ITickerQuote LastQuote => this.JsonLastQuote;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "day", Required = Required.Default)]
        public JsonDayAgg JsonDay { get; set; }
        public IAgg Day => this.JsonDay;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "prevDay", Required = Required.Default)]
        public JsonDayAgg JsonPrevDay { get; set; }
        public IAgg PrevDay => this.JsonPrevDay;
    }
}


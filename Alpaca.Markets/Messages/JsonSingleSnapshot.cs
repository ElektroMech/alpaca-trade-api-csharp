using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alpaca.Markets
{
    /// <summary>
    /// 
    /// </summary>
    public class JsonSingleSnapshot : ISingleSnapshot
    {
        /// <summary>
        /// 
        /// </summary>           
        [JsonProperty(PropertyName = "status", Required = Required.Always)]
        public String Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "ticker", Required = Required.Always)]
        internal JsonSingleTicker JsonTicker { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ISingleTicker Ticker => this.JsonTicker;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "todaysChange", Required = Required.Default)]
        public Decimal TodaysChange { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "todaysChangePerc", Required = Required.Default)]
        public Decimal TodaysChangePerc { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "updated", Required = Required.Default)]
        public Int32 UpdatedAt { get; set; }
    }
}

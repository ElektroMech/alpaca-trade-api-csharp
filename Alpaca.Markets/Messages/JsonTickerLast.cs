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

    internal sealed class JsonTickerLast : ITickerLast
    {
        [JsonProperty(PropertyName = "p", Required = Required.Always)]
        public decimal Price { get; set; }

        [JsonProperty(PropertyName = "s", Required = Required.Always)]
        public long Size { get; set; }

        [JsonProperty(PropertyName = "c", Required = Required.Default)]
        public IEnumerable<int> Conditions { get; set; }

        [JsonProperty(PropertyName = "t", Required = Required.Always)]
        public Int64 Time { get; set; }
    }
}

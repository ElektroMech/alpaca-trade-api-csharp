using System;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Alpaca.Markets
{
    [SuppressMessage(
        "Microsoft.Performance", "CA1812:Avoid uninstantiated internal classes",
        Justification = "Object instances of this class will be created by Newtonsoft.JSON library.")]
    internal class JsonHistoricalTrade : IHistoricalTrade
    {
        [JsonProperty(PropertyName = "c1", Required = Required.Always)]
        public Int32 Condition1 { get; }

        [JsonProperty(PropertyName = "c2", Required = Required.Always)]
        public Int32 Condition2 { get; }

        [JsonProperty(PropertyName = "c3", Required = Required.Always)]
        public Int32 Condition3 { get; }

        [JsonProperty(PropertyName = "c4", Required = Required.Always)]
        public Int32 Condition4 { get; }

        [JsonProperty(PropertyName = "e", Required = Required.Always)]
        public String Exchange { get; set; }

        [JsonProperty(PropertyName = "t", Required = Required.Always)]
        public Int64 TimeOffset { get; set; }

        [JsonProperty(PropertyName = "p", Required = Required.Default)]
        public Decimal Price { get; set; }

        [JsonProperty(PropertyName = "s", Required = Required.Default)]
        public Int64 Size { get; set; }
    }
}

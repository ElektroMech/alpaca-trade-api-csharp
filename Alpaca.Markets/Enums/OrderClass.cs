using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Alpaca.Markets
{
    /// <summary>
    /// Order class for advanced orders in the Alpaca REST API.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OrderClass
    {
        /// <summary>
        /// Simple order
        /// </summary>
        [EnumMember(Value = "simple")]
        Simple,

        /// <summary>
        /// Bracket order
        /// </summary>
        [EnumMember(Value = "bracket")]
        Bracket,

        /// <summary>
        /// OTO order
        /// </summary>
        [EnumMember(Value = "oto")]
        OTO,
    }
}

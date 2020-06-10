using System;
using Newtonsoft.Json;

namespace Alpaca.Markets
{
    internal sealed class JsonAuthRequest
    {
        [JsonProperty(PropertyName = "action", Required = Required.Always)]
        public JsonAction Action { get; set; }

        [JsonProperty(PropertyName = "data", Required = Required.Default)]
        public Object Data { get; set; }

        [JsonProperty(PropertyName = "params", Required = Required.Default)]
        public String Params { get; set; }
    }

    internal sealed class JsonSecretData
    {
        [JsonProperty(PropertyName = "key_id", Required = Required.Default)]
        public String KeyId { get; set; }

        [JsonProperty(PropertyName = "secret_key", Required = Required.Default)]
        public String SecretKey { get; set; }
    }
    internal sealed class JsonOAuthData
    {
        [JsonProperty(PropertyName = "oauth_token", Required = Required.Default)]
        public String oAuthToken { get; set; }
    }
}

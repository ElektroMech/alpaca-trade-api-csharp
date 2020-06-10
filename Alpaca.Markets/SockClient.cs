﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Alpaca.Markets
{
    /// <summary>
    /// Provides unified type-safe access for Alpaca streaming API.
    /// </summary>
    [SuppressMessage(
        "Globalization", "CA1303:Do not pass literals as localized parameters",
        Justification = "We do not plan to support localized exception messages in this SDK.")]
    // ReSharper disable once PartialTypeWithSinglePart
    public sealed partial class SockClient : SockClientBase
    {
        // Available Alpaca message types

        // ReSharper disable InconsistentNaming

        private const String TradeUpdates = "trade_updates";

        private const String AccountUpdates = "account_updates";

        private const String Authorization = "authorization";

        private const String Listening = "listening";

        // ReSharper restore InconsistentNaming

        private readonly IDictionary<String, Action<JToken>> _handlers;

        private readonly String _keyId;

        private readonly String _secretKey;
        private readonly String _oauth_token;

        /// <summary>
        /// Creates new instance of <see cref="SockClient"/> object.
        /// </summary>
        /// <param name="keyId">Application key identifier.</param>
        /// <param name="secretKey">Application secret key.</param>
        /// <param name="alpacaRestApi">Alpaca REST API endpoint URL.</param>
        /// <param name="webSocketFactory">Factory class for web socket wrapper creation.</param>
        public SockClient(
            String keyId,
            String secretKey,
            String alpacaRestApi = null,
            IWebSocketFactory webSocketFactory = null)
            : this(
                keyId,
                secretKey,
                new Uri(alpacaRestApi ?? "https://api.alpaca.markets"),
                webSocketFactory ?? new WebSocket4NetFactory())
        {
        }

        /// <summary>
        /// Creates new instance of <see cref="SockClient"/> object.
        /// </summary>
        /// <param name="keyId">Application key identifier.</param>
        /// <param name="secretKey">Application secret key.</param>
        /// <param name="alpacaRestApi">Alpaca REST API endpoint URL.</param>
        /// <param name="webSocketFactory">Factory class for web socket wrapper creation.</param>
        public SockClient(
            String keyId,
            String secretKey,
            Uri alpacaRestApi,
            IWebSocketFactory webSocketFactory)
            : base(getUriBuilder(alpacaRestApi), webSocketFactory)
        {
            _keyId = keyId ?? throw new ArgumentException(
                         "Application key id should not be null", nameof(keyId));
            _secretKey = secretKey ?? throw new ArgumentException(
                             "Application secret key should not be null", nameof(secretKey));

            _handlers = new Dictionary<String, Action<JToken>>(StringComparer.Ordinal)
            {
                { Listening, _ => { } },
                { Authorization, handleAuthorization },
                { AccountUpdates, handleAccountUpdate },
                { TradeUpdates, handleTradeUpdate }
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oAuthToken"></param>
        /// <param name="alpacaRestApi"></param>
        /// <param name="webSocketFactory"></param>
        public SockClient(
            String oAuthToken,
            String alpacaRestApi = null,
            IWebSocketFactory webSocketFactory = null)
            : this("", "", alpacaRestApi, webSocketFactory)
        {
            _oauth_token = oAuthToken;
        }

        /// <summary>
        /// Occured when new account update received from stream.
        /// </summary>
        public event Action<IAccountUpdate> OnAccountUpdate;

        /// <summary>
        /// Occured when new trade update received from stream.
        /// </summary>
        public event Action<ITradeUpdate> OnTradeUpdate;

        /// <inheritdoc/>
        protected override void OnOpened()
        {
            object dataRequest = !string.IsNullOrEmpty(this._oauth_token)
                ? new JsonOAuthData() { oAuthToken = _oauth_token } as object
                : new JsonSecretData() { KeyId = _keyId, SecretKey = _secretKey } as object;

            this.SendAsJsonString(new JsonAuthRequest
            {
                Action = JsonAction.Authenticate,
                Data = dataRequest
            });

            base.OnOpened();
        }

        /// <inheritdoc/>
        [SuppressMessage(
            "Design", "CA1031:Do not catch general exception types",
            Justification = "Expected behavior - we report exceptions via OnError event.")]
        protected override void OnDataReceived(
            Byte[] binaryData)
        {
            try
            {
                var token = JObject.Parse(Encoding.UTF8.GetString(binaryData));
                HandleMessage(_handlers, token["stream"].ToString(), token["data"]);
            }
            catch (Exception exception)
            {
                HandleError(exception);
            }
        }

        private static UriBuilder getUriBuilder(
            Uri alpacaRestApi)
        {
            alpacaRestApi = alpacaRestApi ?? new Uri("https://api.alpaca.markets");

            var uriBuilder = new UriBuilder(alpacaRestApi)
            {
                Scheme = alpacaRestApi.Scheme == "http" ? "ws" : "wss"
            };

            if (!uriBuilder.Path.EndsWith("/", StringComparison.Ordinal))
            {
                uriBuilder.Path += "/";
            }

            uriBuilder.Path += "stream";
            return uriBuilder;
        }

        private void handleAuthorization(
            JToken token)
        {
            var response = token.ToObject<JsonAuthResponse>();
            OnConnected(response.Status);

            if (response.Status == AuthStatus.Authorized)
            {
                var listenRequest = new JsonListenRequest
                {
                    Action = JsonAction.Listen,
                    Data = new JsonListenRequest.JsonData()
                    {
                        Streams = new List<String>
                        {
                            TradeUpdates,
                            AccountUpdates
                        }
                    }
                };

                SendAsJsonString(listenRequest);
            }
        }

        private void handleTradeUpdate(
            JToken token) =>
            OnTradeUpdate.DeserializeAndInvoke<ITradeUpdate, JsonTradeUpdate>(token);

        private void handleAccountUpdate(
            JToken token) =>
            OnAccountUpdate.DeserializeAndInvoke<IAccountUpdate, JsonAccountUpdate>(token);
    }
}

using System;
using Flurl.Http.Configuration;

namespace SKIT.FlurlHttpClient
{
    using SKIT.FlurlHttpClient.Configuration;
    using SKIT.FlurlHttpClient.Configuration.Internal;

    /// <summary>
    /// SKIT.FlurlHttpClient 客户端配置项。
    /// </summary>
    public sealed class CommonClientSettings
    {
        /// <summary>
        ///
        /// </summary>
        public TimeSpan? Timeout { get; set; }

        /// <summary>
        ///
        /// </summary>
        public IJsonSerializer JsonSerializer { get; set; } = default!;

        /// <summary>
        ///
        /// </summary>
        public IHttpClientFactory FlurlHttpClientFactory { get; set; } = default!;

        internal CommonClientSettings(ClientFlurlHttpSettings flurlClientSettings)
        {
            Timeout = flurlClientSettings.Timeout;
            JsonSerializer = ((InternalWrappedJsonSerializer)flurlClientSettings.JsonSerializer)!.Serializer;
            FlurlHttpClientFactory = flurlClientSettings.HttpClientFactory;
        }
    }
}

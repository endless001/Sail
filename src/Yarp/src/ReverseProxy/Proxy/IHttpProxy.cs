// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Yarp.ReverseProxy.Proxy
{
    /// <summary>
    /// Provides a method to proxy an HTTP request to a target server.
    /// </summary>
    public interface IHttpProxy
    {
        /// <summary>
        /// Proxies the incoming request to the destination server, and the response back to the client.
        /// </summary>
        /// <param name="context">The HttpContent to proxy from.</param>
        /// <param name="destinationPrefix">The url prefix for where to proxy the request to.</param>
        /// <param name="httpClient">The HTTP client used to send the proxy request.</param>
        /// <param name="requestConfig">Config for the outgoing request.</param>
        /// <param name="transformer">Request and response transforms. Use <see cref="HttpTransformer.Default"/> if
        /// custom transformations are not needed.</param>
        /// <returns>The result of the request proxying to the destination.</returns>
        ValueTask<ProxyError> ProxyAsync(
            HttpContext context,
            string destinationPrefix,
            HttpMessageInvoker httpClient,
            RequestProxyConfig requestConfig,
            HttpTransformer transformer);
    }
}

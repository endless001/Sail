using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Sail.Configuration;
using Sail.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sail.RateLimit.Middleware
{
    public class ClientRateLimitMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ClientRateLimitMiddleware> _logger;

        public ClientRateLimitMiddleware(RequestDelegate next, ILogger<ClientRateLimitMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var downstreamRoute = httpContext.Items.DownstreamRoute();
            var options = downstreamRoute.RateLimitOptions;


            var identity = SetIdentity(httpContext, options);
            if (!IsWhitelisted(identity,options))
            {
                await _next.Invoke(httpContext);
                return;
            }
            var rule = options.RateLimitRule;
            if (rule.Limit > 0)
            {
             
            }

            await _next.Invoke(httpContext);
        }
        public virtual ClientRequestIdentity SetIdentity(HttpContext httpContext, RateLimitOptions  options)
        {
            var clientId = "client";

            if (httpContext.Request.Headers.Keys.Contains(options.ClientIdHeader))
            {
                clientId = httpContext.Request.Headers[options.ClientIdHeader].First();
            }
            return new ClientRequestIdentity
            {
                ClientId = clientId,
                HttpVerb = httpContext.Request.Method.ToLowerInvariant(),
                Path = httpContext.Request.Path.ToString().ToLowerInvariant()
            };
          
        }
        public bool IsWhitelisted(ClientRequestIdentity requestIdentity, RateLimitOptions options)
        {
            return options.ClientWhitelist.Contains(requestIdentity.ClientId);
        }
        public virtual void LogBlockedRequest(HttpContext httpContext,ClientRequestIdentity identity, RateLimitCounter counter, RateLimitRule rule,DownstreamRoute downstreamRoute)
        {
            _logger.LogInformation(@$"Request { identity.HttpVerb}:{ identity.Path} from ClientId { identity.ClientId} has been blocked, quota { rule.Limit}/{ rule.Period} exceeded by { counter.TotalRequests}. Blocked by rule .");
        }
        private string GetResponseMessage(RateLimitOptions options)
        {
            var message = string.IsNullOrEmpty(options.QuotaExceededMessage)
                  ? $"API calls quota exceeded! maximum admitted {options.RateLimitRule.Limit} per {options.RateLimitRule.Period}."
                : options.QuotaExceededMessage;
            return message;
        }
        private Task SetRateLimitHeaders(object rateLimitHeaders)
        {
            var headers = (RateLimitHeaders)rateLimitHeaders;

            headers.Context.Response.Headers["X-Rate-Limit-Limit"] = headers.Limit;
            headers.Context.Response.Headers["X-Rate-Limit-Remaining"] = headers.Remaining;
            headers.Context.Response.Headers["X-Rate-Limit-Reset"] = headers.Reset;

            return Task.CompletedTask;
        }
    }
}

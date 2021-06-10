// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Yarp.ReverseProxy.Proxy;
using Yarp.ReverseProxy.Utilities;

namespace Yarp.ReverseProxy.Configuration
{
    /// <summary>
    /// A cluster is a group of equivalent endpoints and associated policies.
    /// </summary>
    public sealed record ClusterConfig
    {
        /// <summary>
        /// The Id for this cluster. This needs to be globally unique.
        /// This field is required.
        /// </summary>
        public string ClusterId { get; init; } = default!;

        /// <summary>
        /// Load balancing policy.
        /// </summary>
        public string? LoadBalancingPolicy { get; init; }

        /// <summary>
        /// Session affinity config.
        /// </summary>
        public SessionAffinityConfig? SessionAffinity { get; init; }

        /// <summary>
        /// Health checking config.
        /// </summary>
        public HealthCheckConfig? HealthCheck { get; init; }

        /// <summary>
        /// Config for the HTTP client that is used to call destinations in this cluster.
        /// </summary>
        public HttpClientConfig? HttpClient { get; init; }

        /// <summary>
        /// Config for outgoing HTTP requests.
        /// </summary>
        public RequestProxyConfig? HttpRequest { get; init; }

        /// <summary>
        /// The set of destinations associated with this cluster.
        /// </summary>
        public IReadOnlyDictionary<string, DestinationConfig>? Destinations { get; init; }

        /// <summary>
        /// Arbitrary key-value pairs that further describe this cluster.
        /// </summary>
        public IReadOnlyDictionary<string, string>? Metadata { get; init; }

        /// <inheritdoc />
        public bool Equals(ClusterConfig? other)
        {
            if (other == null)
            {
                return false;
            }

            return EqualsExcludingDestinations(other)
                && CaseInsensitiveEqualHelper.Equals(Destinations, other.Destinations, (a, b) => a == b);
        }

        internal bool EqualsExcludingDestinations(ClusterConfig other)
        {
            if (other == null)
            {
                return false;
            }

            return string.Equals(ClusterId, other.ClusterId, StringComparison.OrdinalIgnoreCase)
                && string.Equals(LoadBalancingPolicy, other.LoadBalancingPolicy, StringComparison.OrdinalIgnoreCase)
                // CS0252 warning only shows up in VS https://github.com/dotnet/roslyn/issues/49302
                && SessionAffinity == other.SessionAffinity
                && HealthCheck == other.HealthCheck
                && HttpClient == other.HttpClient
                && HttpRequest == other.HttpRequest
                && CaseInsensitiveEqualHelper.Equals(Metadata, other.Metadata);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return HashCode.Combine(
                ClusterId?.GetHashCode(StringComparison.OrdinalIgnoreCase),
                LoadBalancingPolicy?.GetHashCode(StringComparison.OrdinalIgnoreCase),
                SessionAffinity,
                HealthCheck,
                HttpClient,
                HttpRequest,
                Destinations,
                Metadata);
        }
    }
}

using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sail.Authentication.Secret
{
    public static class SecretExtensions
    {
        public static AuthenticationBuilder AddSecret(this AuthenticationBuilder builder)
         => builder.AddSecret(SecretDefaults.AuthenticationScheme, _ => { });

        public static AuthenticationBuilder AddSecret(this AuthenticationBuilder builder, Action<SecretOptions> configureOptions)
         => builder.AddSecret(SecretDefaults.AuthenticationScheme, configureOptions);
        public static AuthenticationBuilder AddSecret(this AuthenticationBuilder builder, string authenticationScheme,
            Action<SecretOptions> configureOptions)
           => builder.AddSecret(authenticationScheme, SecretDefaults.DisplayName, configureOptions);
        public static AuthenticationBuilder AddSecret(this AuthenticationBuilder builder, string authenticationScheme, string displayName,
            Action<SecretOptions> configureOptions)
        {
            return builder.AddScheme<SecretOptions, SecretHandler>(authenticationScheme, displayName, configureOptions);
        }
    }
}
using System;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Sail.Authentication.IdentityServer
{
    public class IdentityServerHandler : AuthenticationHandler<IdentityServerAuthenticationOptions>
    {
        private readonly ILogger _logger;

        public IdentityServerHandler(
          IOptionsMonitor<IdentityServerAuthenticationOptions> options,
          ILoggerFactory logger,
          UrlEncoder encoder,
          ISystemClock clock)
          : base(options, logger, encoder, clock)
        {
            _logger = logger.CreateLogger<IdentityServerHandler>();
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            _logger.LogTrace("HandleAuthenticateAsync called");

            var jwtScheme = Scheme.Name + IdentityServerDefaults.JwtAuthenticationScheme;
            var introspectionScheme = Scheme.Name + IdentityServerDefaults.IntrospectionAuthenticationScheme;


            var token = Options.TokenRetriever(Context.Request);
            bool removeToken = false;

            try
            {
                if (token != null)
                {
                    _logger.LogTrace("Token found: {token}", token);

                    removeToken = true;
                    Context.Items.Add(IdentityServerDefaults.TokenItemsKey, token);

                    // seems to be a JWT
                    if (token.Contains('.') && Options.SupportsJwt)
                    {
                        _logger.LogTrace("Token is a JWT and is supported.");

                        Context.Items.Add(IdentityServerDefaults.EffectiveSchemeKey + Scheme.Name,
                          jwtScheme);
                        return await Context.AuthenticateAsync(jwtScheme);
                    }
                    else if (Options.SupportsIntrospection)
                    {
                        _logger.LogTrace("Token is a reference token and is supported.");

                        Context.Items.Add(IdentityServerDefaults.EffectiveSchemeKey + Scheme.Name,
                          introspectionScheme);
                        return await Context.AuthenticateAsync(introspectionScheme);
                    }
                    else
                    {
                        _logger.LogTrace(
                          "Neither JWT nor reference tokens seem to be correctly configured for incoming token.");
                    }
                }

                // set the default challenge handler to JwtBearer if supported
                if (Options.SupportsJwt)
                {
                    Context.Items.Add(IdentityServerDefaults.EffectiveSchemeKey + Scheme.Name, jwtScheme);
                }

                return AuthenticateResult.NoResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return AuthenticateResult.Fail(ex);
            }
            finally
            {
                if (removeToken)
                {
                    Context.Items.Remove(IdentityServerDefaults.TokenItemsKey);
                }
            }
        }
    }
}

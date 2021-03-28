using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Sail.Storage.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Sail.Authentication.Secret
{
    public class SecretHandler : AuthenticationHandler<SecretOptions>
    {
        private readonly ITenantStore _tenantStore;
        public SecretHandler(IOptionsMonitor<SecretOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
        }
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {

            var secret = Request.Headers[Options.Secret];

            if (string.IsNullOrEmpty(secret))
            {
                return AuthenticateResult.NoResult();
            }
            var tenant = await _tenantStore.VerificationSecretAsync(secret);

            if (tenant == null)
            {
                return AuthenticateResult.NoResult();
            }

            var claims = new List<Claim>()
            {
                new Claim("Secret", secret),
            };

            var principal = new ClaimsPrincipal(new ClaimsIdentity(claims, Scheme.Name));

            var ticket = new AuthenticationTicket(
                principal,
                Scheme.Name
            );
            return AuthenticateResult.Success(ticket);
        }
    }
}

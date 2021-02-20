using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;

namespace Sail.Authentication.Secret
{
    public class SecretOptions:AuthenticationSchemeOptions
    {
        public string Secret { get; set; } = "Secret";

    }
}
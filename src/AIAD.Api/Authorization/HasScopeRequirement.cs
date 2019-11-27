using Microsoft.AspNetCore.Authorization;
using System;

namespace AIAD.Api.Authorization
{
    /// <summary>
    /// Copied from https://auth0.com/docs/quickstart/backend/aspnet-core-webapi#validate-scopes
    /// </summary>
    public class HasScopeRequirement : IAuthorizationRequirement
    {
        public string Issuer { get; }
        public string Scope { get; }

        public HasScopeRequirement(string scope, string issuer)
        {
            this.Issuer = issuer ?? throw new ArgumentNullException(nameof(issuer));
            this.Scope = scope ?? throw new ArgumentNullException(nameof(scope));
        }
    }
}

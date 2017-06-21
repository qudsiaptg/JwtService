using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;

namespace JwtService
{
    public class JwtOAuthProvider : OAuthAuthorizationServerProvider
    {
        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            var user = new JSonIdentityProvider().GetUser();

            //Verify context credentials against authentication store(UserName/Password)
            if (!context.UserName.Equals(user.UserName))
            {
                context.SetError("invalid_grant", "The user name or password is incorrect");
                context.Rejected();

                return Task.FromResult<object>(null);
            }

            var ticket = new AuthenticationTicket(SetClaimsIdentity(context, user), new AuthenticationProperties());

            context.Validated(ticket);

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();

            return Task.FromResult<object>(null);
        }

        private static ClaimsIdentity SetClaimsIdentity(OAuthGrantResourceOwnerCredentialsContext context, IUser user)
        {
            var identity = new ClaimsIdentity("JWT");
            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            identity.AddClaim(new Claim("sub", context.UserName));

            //obtain user roles from authorization store
            var userRoles = new List<string>();

            foreach (var role in userRoles)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, role));
            }

            return identity;
        }
    }
}
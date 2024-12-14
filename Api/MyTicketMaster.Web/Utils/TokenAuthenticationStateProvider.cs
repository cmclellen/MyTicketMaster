using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MyTicketMaster.Web.Utils
{
    public class TokenAuthenticationStateProvider(IHttpContextAccessor httpContextAccessor) : AuthenticationStateProvider
    {
        public string AccessToken { get; set; }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            AccessToken = await httpContextAccessor.HttpContext!.GetTokenAsync("access_token");
            
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(AccessToken);
            var principle = new ClaimsPrincipal(new ClaimsIdentity(token.Claims, "local"));
            return new AuthenticationState(principle);
        }
    }
}

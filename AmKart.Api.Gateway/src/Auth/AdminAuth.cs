using AmKart.Common.Authentication;

namespace AmKart.Api.Auth
{
    public class AdminAuth : JwtAuthAttribute
    {
        public AdminAuth() : base("admin")
        {
        }
    }
}
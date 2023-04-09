using AmKart.Common.Commands.Identity;
using RestEase;
using System.Threading.Tasks;
using AmKart.Common.Authentication;
using AmKart.Common.Models;

namespace AmKart.Api.Services
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface IIdentityService
    {
        [AllowAnyStatusCode]
        [Post("api/v1/identity/sign-up")]
        Task<RegisterUserResponse> SignUp([Body] SignUpCommand signUpCommand);

        [AllowAnyStatusCode]
        [Post("api/v1/identity/sign-in")]
        Task<JsonWebToken> SignIn([Body] SignInCommand signInCommand);
    }
}
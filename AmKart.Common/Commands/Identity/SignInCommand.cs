namespace AmKart.Common.Commands.Identity
{
    public class SignInCommand
    {
        public string Email { get; }
        public string Password { get; }

        public SignInCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
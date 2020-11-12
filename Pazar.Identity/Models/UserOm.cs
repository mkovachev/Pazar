namespace Pazar.Identity.Models
{
    public class UserOm
    {
        public UserOm(string token)
        {
            this.Token = token;
        }

        public string Token { get; }
    }
}

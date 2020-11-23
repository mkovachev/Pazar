namespace Pazar.Identity.Models
{
    public class UserVm
    {
        public UserVm(string token)
        {
            this.Token = token;
        }

        public string Token { get; }
    }
}

namespace Pazar.Identity.Models
{
    public class UserAuthVm
    {
        public UserAuthVm(string id, string token)
        {
            this.Id = id;
            this.Token = token;
        }

        public string Token { get; }

        public string Id { get; }
    }
}

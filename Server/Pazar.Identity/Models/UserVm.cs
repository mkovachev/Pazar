namespace Pazar.Identity.Models
{
    public class UserVm
    {
        public UserVm(string token)
        {
            this.Token = token;
            // this.Id = id;
        }

        public string Token { get; }
        //public string Id { get; }
    }
}

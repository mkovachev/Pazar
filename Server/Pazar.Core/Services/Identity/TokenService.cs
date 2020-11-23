namespace Pazar.Core.Services.Identity
{
    public class TokenService
    {
        private string currentToken;

        public string Get() => this.currentToken;

        public void Set(string token) => this.currentToken = token;
    }
}

namespace Pazar.Core.Services.Identity
{
    public interface ITokenService
    {
        string Get();

        void Set(string token);
    }
}

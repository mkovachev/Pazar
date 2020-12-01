namespace Pazar.Core
{
    public class AppSettings
    {
        public string Secret { get; private set; } = "THIS IS A TEST SECRET TO SIGN AND VERIFY JWT TOKENS";

        public bool SeedInitialData { get; private set; } = true;
    }
}

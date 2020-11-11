namespace Pazar.Core
{
    public class ApplicationSettings
    {
        public string Secret { get; private set; } = "some awesome default secret";

        public bool SeedInitialData { get; private set; }
    }
}

namespace Pazar.Core
{
    public class ApplicationSettings
    {
        public string Secret { get; private set; }

        public bool SeedInitialData { get; private set; }
    }
}

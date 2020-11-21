namespace Pazar.Core.Messages.Ads
{
    public class AdCreateMessage
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }
    }
}

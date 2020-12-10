namespace Pazar.Core.Messages.Ads
{
    public class AdCreatedMessage
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public decimal Price { get; set; }

        public string? Category { get; set; }
    }
}

using SteamKeyStore.Model.Models;

namespace SteamKeyStore.Model.Requests
{
    public class ProductInsertRequest
    {
        public ProductType Type { get; set; }

        public string Title { get; set; }

        public string? Description { get; set; }

        public string? SystemRequirements { get; set; }

        public int DeveloperId { get; set; }

        public int PublisherId { get; set; }

        public int? GameId { get; set; }

        public decimal Price { get; set; }

        public DateOnly? ReleaseDate { get; set; }

        public string? MainImageUrl { get; set; }
    }
}

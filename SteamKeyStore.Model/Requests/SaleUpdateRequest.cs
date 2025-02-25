namespace SteamKeyStore.Model.Requests
{
    public class SaleUpdateRequest
    {
        public int? ProductId { get; set; }

        public int? EditionId { get; set; }

        public decimal? DiscountPercentage { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}

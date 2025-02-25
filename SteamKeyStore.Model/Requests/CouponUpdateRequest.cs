namespace SteamKeyStore.Model.Requests
{
    public class CouponUpdateRequest
    {
        public string? Code { get; set; } = null!;

        public decimal? DiscountPercentage { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? MaxUsage { get; set; }

        public int? CurrentUsage { get; set; }
    }
}

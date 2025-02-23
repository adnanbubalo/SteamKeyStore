namespace SteamKeyStore.Model.Models;

public class Coupon
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public decimal DiscountPercentage { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int? MaxUsage { get; set; }

    public int? CurrentUsage { get; set; }
}

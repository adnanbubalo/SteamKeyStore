namespace SteamKeyStore.Model.Models;

public partial class Sale
{
    public int Id { get; set; }

    public int? ProductId { get; set; }

    public int? EditionId { get; set; }

    public decimal DiscountPercentage { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    //public virtual Edition? Edition { get; set; }

    //public virtual Product? Product { get; set; }
}

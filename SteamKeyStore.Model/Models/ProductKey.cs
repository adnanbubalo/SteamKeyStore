namespace SteamKeyStore.Model.Models;

public partial class ProductKey
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public string KeyCode { get; set; } = null!;

    public bool IsSold { get; set; }

    public DateTime? DateSold { get; set; }
}

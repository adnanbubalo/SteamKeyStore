namespace SteamKeyStore.Model.Models;

public class Edition
{
    public int Id { get; set; }

    public int GameId { get; set; }

    public string Title { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual Product Game { get; set; } = null!;

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}

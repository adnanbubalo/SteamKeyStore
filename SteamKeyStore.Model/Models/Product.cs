namespace SteamKeyStore.Model.Models;

public class Product
{
    public int Id { get; set; }

    public ProductType Type { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string? SystemRequirements { get; set; }

    public int DeveloperId { get; set; }

    public int PublisherId { get; set; }

    public decimal Price { get; set; }

    public DateOnly? ReleaseDate { get; set; }

    public string? MainImageUrl { get; set; }

    public int? GameId { get; set; }


    public virtual User? Developer { get; set; }

    public virtual User? Publisher { get; set; }

    public virtual Product? Game { get; set; }

    public virtual ICollection<Edition> Editions { get; set; } = new List<Edition>();
    
    public virtual ICollection<News> News { get; set; } = new List<News>();
    
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
    
    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
    
    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
public enum ProductType
{
    BASE_GAME,
    DLC
}
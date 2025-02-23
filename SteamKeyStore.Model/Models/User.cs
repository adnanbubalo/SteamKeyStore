namespace SteamKeyStore.Model.Models;

public partial class User
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Role { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string PasswordSalt { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }
    /*
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Product> ProductDevelopers { get; set; } = new List<Product>();

    public virtual ICollection<Product> ProductPublishers { get; set; } = new List<Product>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<Wishlist> Wishlists { get; set; } = new List<Wishlist>();
    */
}

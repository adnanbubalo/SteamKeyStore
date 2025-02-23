namespace SteamKeyStore.Model.Models;

public class User
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public UserRole Role { get; set; }

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
public enum UserRole
{
    ADMIN,
    CREATOR,
    CUSTOMER
}
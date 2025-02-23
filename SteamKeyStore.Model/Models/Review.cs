namespace SteamKeyStore.Model.Models;

public partial class Review
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int CustomerId { get; set; }

    public int Rating { get; set; }

    public int HoursPlayed { get; set; }

    public string? ReviewText { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    //public virtual User Customer { get; set; } = null!;

    //public virtual Product Product { get; set; } = null!;
}

namespace SteamKeyStore.Model.Models;

public partial class News
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }
}

using System;
using System.Collections.Generic;

namespace SteamKeyStore.Services.Database;

public partial class Wishlist
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int ProductId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual User Customer { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}

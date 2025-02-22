using System;
using System.Collections.Generic;

namespace SteamKeyStore.Services.Database;

public partial class ProductKey
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public string KeyCode { get; set; } = null!;

    public bool IsSold { get; set; }

    public DateTime? DateSold { get; set; }

    public virtual ICollection<OrderItemKey> OrderItemKeys { get; set; } = new List<OrderItemKey>();

    public virtual Product Product { get; set; } = null!;
}

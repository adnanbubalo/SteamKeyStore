using System;
using System.Collections.Generic;

namespace SteamKeyStore.Services.Database;

public partial class OrderItem
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int? EditionId { get; set; }

    public int? ProductId { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal DiscountApplied { get; set; }

    public decimal FinalPrice { get; set; }

    public virtual Edition? Edition { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual ICollection<OrderItemKey> OrderItemKeys { get; set; } = new List<OrderItemKey>();

    public virtual Product? Product { get; set; }
}

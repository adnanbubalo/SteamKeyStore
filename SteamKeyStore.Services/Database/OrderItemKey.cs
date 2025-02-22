using System;
using System.Collections.Generic;

namespace SteamKeyStore.Services.Database;

public partial class OrderItemKey
{
    public int OrderItemKeyId { get; set; }

    public int OrderItemId { get; set; }

    public int ProductKeyId { get; set; }

    public virtual OrderItem OrderItem { get; set; } = null!;

    public virtual ProductKey ProductKey { get; set; } = null!;
}

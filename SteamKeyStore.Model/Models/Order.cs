namespace SteamKeyStore.Model.Models;

public partial class Order
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public DateTime OrderDate { get; set; }

    public int? CouponId { get; set; }

    public decimal TotalPrice { get; set; }

    public virtual Coupon? Coupon { get; set; }

    public virtual User? Customer { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}

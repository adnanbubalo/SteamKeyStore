namespace SteamKeyStore.Model.Requests
{
    public class OrderInsertRequest
    {
        public int CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        public int? CouponId { get; set; }

        public decimal TotalPrice { get; set; }
    }
}

namespace SteamKeyStore.Model.Requests
{
    public class OrderItemInsertRequest
    {
        public int OrderId { get; set; }

        public int? EditionId { get; set; }

        public int? ProductId { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal DiscountApplied { get; set; }

        public decimal FinalPrice { get; set; }
    }
}

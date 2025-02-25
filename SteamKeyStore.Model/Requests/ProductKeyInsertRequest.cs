namespace SteamKeyStore.Model.Requests
{
    public class ProductKeyInsertRequest
    {
        public int ProductId { get; set; }

        public string KeyCode { get; set; }

        public bool IsSold { get; set; } = false;

        public DateTime? DateSold { get; set; }
    }
}

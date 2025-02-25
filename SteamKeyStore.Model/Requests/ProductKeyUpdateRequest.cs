namespace SteamKeyStore.Model.Requests
{
    public class ProductKeyUpdatetRequest
    {
        public int? ProductId { get; set; }

        public string? KeyCode { get; set; }

        public bool? IsSold { get; set; }

        public DateTime? DateSold { get; set; }
    }
}

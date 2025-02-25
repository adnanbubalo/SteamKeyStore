namespace SteamKeyStore.Model.Requests
{
    public class NewsUpdateRequest
    {
        public int? ProductId { get; set; }

        public string? Title { get; set; }

        public string? Content { get; set; }
    }
}

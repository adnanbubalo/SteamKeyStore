namespace SteamKeyStore.Model.Requests
{
    public class EditionUpdateRequest
    {
        public int? GameId { get; set; }

        public string? Title { get; set; }

        public decimal? Price { get; set; }
    }
}

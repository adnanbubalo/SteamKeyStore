namespace SteamKeyStore.Model.Requests
{
    public class ReviewInsertRequest
    {
        public int ProductId { get; set; }

        public int CustomerId { get; set; }

        public int Rating { get; set; }

        public int HoursPlayed { get; set; }

        public string? ReviewText { get; set; }
    }
}

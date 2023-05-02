namespace PerfumeApiBackend.Models
{
    public class UserToken
    {
        // This class contains userLogin data and his token configurations

        public int Id { get; set; }
        public string Token { get; set; }
        public string UserName { get; set; }
        public string RefreshToken { get; set; }
        public string EmailId { get; set; }
        public string Category { get; set; }
        public TimeSpan Validity { get; set; }
        public Guid Guid { get; set; }
        public DateTime Expired { get; set; }
    }
}

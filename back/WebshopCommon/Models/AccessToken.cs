namespace WebshopCommon.Models
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime ExpireAt { get; set; }
        public User UserData { get; set; }
    }
}

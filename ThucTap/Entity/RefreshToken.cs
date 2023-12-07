namespace ThucTap.Entity
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public DateTime ExpiredTime { get; set; }
        public int Account_id { get; set; }
        public Account? account { get; set; }
    }
}

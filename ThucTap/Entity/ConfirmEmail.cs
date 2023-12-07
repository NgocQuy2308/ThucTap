namespace ThucTap.Entity
{
    public class ConfirmEmail
    {
        public int Id { get; set; }
        public User? User { get; set; }
        public int User_id { get; set; }
        public DateTime RequiredDateTime { get; set; }
        public DateTime ExpiredTime { get; set; }
        public string CodeActive { get; set; }
        public bool IsConfirm { get; set; }
    }
}

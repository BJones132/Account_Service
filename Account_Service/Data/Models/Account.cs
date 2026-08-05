namespace Account_Service.Data.Models
{
    public class Account
    {
        public int id { get; set; }
        public decimal balance { get; set; }
        public required int user_id { get; set; }
    }
}

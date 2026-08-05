using Account_Service.Data.Models;

namespace Account_Service.Data
{
    public class AccountDTO
    {
        public required int id { get; set; }
        public required decimal balance { get; set; }

        public AccountDTO() { }
        public AccountDTO(Account account) =>
            (id, balance) = (account.id, account.balance);
    }
}

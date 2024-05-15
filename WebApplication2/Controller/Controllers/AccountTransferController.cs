namespace WebApplication2.Controller.Controllers
{
    public class AccountTransferController
    {
        private Dictionary<string, decimal> _accounts = new Dictionary<string, decimal>();

        public bool TransferMoney(string sourceAccountId, string targetAccountId, decimal amount)
        {
            if (!_accounts.ContainsKey(sourceAccountId) || !_accounts.ContainsKey(targetAccountId))
            {
                return false; // Акаунти не знайдені
            }

            if (_accounts[sourceAccountId] < amount)
            {
                return false; // На джерельному акаунті недостатньо коштів
            }

            _accounts[targetAccountId] += amount;
            _accounts[sourceAccountId] -= amount;

            return true;
        }

        public decimal GetSourceAccountBalance(string accountId)
        {
            if (!_accounts.ContainsKey(accountId))
            {
                return 0; // Акаунт не знайдений
            }

            return _accounts[accountId];
        }

        public decimal GetTargetAccountBalance(string accountId)
        {
            if (!_accounts.ContainsKey(accountId))
            {
                return 0; // Акаунт не знайдений
            }

            return _accounts[accountId];
        }
    }
}

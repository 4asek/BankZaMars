namespace WebApplication2.Controller.Services.Contracts
{
    public interface IAccountTransferService
    {
        bool TransferMoney(string sourceAccountId, string targetAccountId, decimal amount);
        decimal GetSourceAccountBalance(string accountId);
        decimal GetTargetAccountBalance(string accountId);
    }
}

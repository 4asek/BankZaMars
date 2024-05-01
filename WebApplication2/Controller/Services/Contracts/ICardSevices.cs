using WebApplication2.Data.Models;
using WebApplication2.Models;

namespace WebApplication2.Controller.Services.Contracts
{
    public interface ICardSevices
    {
        Task CreateCard(Card card);
        Task<IEnumerable<Card>> GetAllCard();
        Task<Card> GetCardById(Guid id);
        Task UpdateCard(Card card);
        Task DeleteCard(Guid id);
    }
}

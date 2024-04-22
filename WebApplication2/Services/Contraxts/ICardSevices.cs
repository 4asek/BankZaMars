using WebApplication2.Data.Models;

namespace WebApplication2.Services.Contraxts
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

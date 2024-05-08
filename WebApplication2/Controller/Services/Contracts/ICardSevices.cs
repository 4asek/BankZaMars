using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data.Models;
using WebApplication2.Model;
using WebApplication2.Models;

namespace WebApplication2.Controller.Services.Contracts
{
    public interface ICardSevices
    {
        Task<ActionResult<List<Card>>> GetAllCard();
        Task<CardRequesModel> GetCard(Guid id);
        Task<Card> AddCard(CardRequesModel card);
        Task<Guid> UpdateCard(Guid id, CardRequesModel requestModel);
        Task<Guid> DeleteCard(Guid id);
    }
}

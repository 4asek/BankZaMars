using Microsoft.AspNetCore.Mvc;
using WebApplication2.Controller.Services.Contracts;
using WebApplication2.Data;
using WebApplication2.Model;
using WebApplication2.Models;

namespace WebApplication2.Controller.Services.Servic1
{
    
        public class CardService : ICardSevices
    {
            private readonly DataContext _context;

            public CardService(DataContext context)
            {
                _context = context;
            }
            async Task<Card> ICardSevices.AddCard(CardRequesModel card)
            {
                if (card == null)
                {
                    throw new ArgumentNullException(nameof(card));
                }
                var res = MapRequestToCard(card);

                _context.Cards.AddAsync(res);
                await _context.SaveChangesAsync();

                return res;
            }

            async Task<Guid> ICardSevices.DeleteCard(Guid id)
            {
                var card = await _context.Cards.FindAsync(id);
                if (card == null)
                {
                    return Guid.Empty;
                }

                card.AccountId = Guid.Empty;

                _context.Cards.Remove(card);
                await _context.SaveChangesAsync();

                return id;
            }

            async Task<ActionResult<List<Card>>> ICardSevices.GetAllCard()
            {
                var card = await _context.Cards.ToListAsync();

                return card;
            }

            async Task<CardRequesModel> ICardSevices.GetCard(Guid id)
            {
                var card = await _context.Cards.FindAsync(id);

                if (card == null)
                {
                    return null;
                }
                var res = MapRequestToDB(card);

                return res;
            }

            async Task<Guid> ICardSevices.UpdateCard(Guid id, CardRequesModel requestModel)
            {
                var card = await _context.Cards.FindAsync(id);
                if (card == null)
                {
                    return Guid.Empty;
                }
                card = MapRequestToSet(card, requestModel);
                _context.Cards.Update(card);
                await _context.SaveChangesAsync();

                return id;
            }

            private Card MapRequestToCard(CardRequesModel requestModel)
            {
                var card = new Card();
                card.Id = Guid.NewGuid();
                card.NumberCard = requestModel.NumberCard;
                card.CardName = requestModel.CardName;
                card.Pincode = requestModel.Pincode;
                card.Data = requestModel.Data;
                card.CVV = requestModel.CVV;
                card.Balance = requestModel.Balance;
                card.AccountId = requestModel.AccountId;
                return card;
            }

            private CardRequesModel MapRequestToDB(Card card)
            {
                var requestModel = new CardRequesModel();
                requestModel.NumberCard = card.NumberCard;
                requestModel.CardName = card.CardName;
                requestModel.Pincode = card.Pincode;
                requestModel.Data = card.Data;
                requestModel.CVV = card.CVV;
                requestModel.Balance = card.Balance;

                return requestModel;
            }

            private Card MapRequestToSet(Card res, CardRequesModel card)
            {
                res.NumberCard = card.NumberCard;
                res.CardName = card.CardName;
                res.Pincode = card.Pincode;
                res.Data = card.Data;
                res.CVV = card.CVV;
                res.Balance = card.Balance;

                return res;
            }
        }
 }


using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;
using WebApplication2.Data.Models;
using WebApplication2.Services.Contraxts;

namespace WebApplication2.Services.Iplametation
{
    public class CardService : ICardSevices
    {
        private readonly DataContext _context;
        public CardService(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Card>> GetAllCard()
        {
            return await _context.Cards.ToListAsync();
        }
        public async Task<Card> GetCardById(Guid id)
        {
            return await _context.Cards.FindAsync(id);
        }
        public async Task CreateCard(Card card)
        {
            _context.Cards.Add(card);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateCard(Card card)
        {
            _context.Entry(card).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteCard(Guid id)
        {
            var card = await _context.Cards.FindAsync(id);
            if (card != null)
            {
                _context.Cards.Remove(card);
                await _context.SaveChangesAsync();
            }
        }
    }
}

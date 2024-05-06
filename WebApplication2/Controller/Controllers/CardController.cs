using Microsoft.AspNetCore.Mvc;
using WebApplication2.Controller.Services.Contracts;
using WebApplication2.Controller.Services.Servic1;
using WebApplication2.Data;
using WebApplication2.Model;
using WebApplication2.Models;

namespace ProjectBank.Controller.Controllers
{
    [Route("api/card")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ICardSevices cardService;

        public CardController(DataContext context, ICardSevices cardService)
        {
            _context = context;
            this.cardService = cardService;
        }

        [HttpGet("GetAllCards")]
        public async Task<ActionResult<List<Card>>> GetAllCards() //work
        {
            var card = await cardService.GetAllCard();

            return Ok(card);
        }

        [HttpGet("GetCard/{id}")]
        public async Task<ActionResult<Card>> GetCard(Guid id) //work
        {
            var card = await _context.Cards.FindAsync(id);
            if (card == null)
            {
                return NotFound();
            }
            return Ok(card);
        }


        [HttpPost("AddCard")]
        public async Task<ActionResult<Card>> AddCard(CardRequesModel card) //тут
        {
            try
            {
                var createdCard = await cardService.AddCard(card);
                return Ok(createdCard);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPut("UpdateCard/{id}")]
        public async Task<IActionResult> UpdateCard(Guid id, CardRequesModel card) //Work
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }
            await cardService.UpdateCard(id, card);
            return Ok(id);
        }


        [HttpDelete("DeleteCard/{id}")]
        public async Task<IActionResult> DeleteCard(Guid id) //work
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }
            await cardService.DeleteCard(id);
            return NoContent();
        }
    }
}


using DebetCards.Data;
using DebetCards.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DebetCards.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardController : Controller
    {
        private readonly IRepository<Card> _context;
        private readonly CardValidator _validator;

        public CardController(IRepository<Card> context, CardValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        /// <summary>
        /// Получение данных карты по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Card</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromQuery] int id)
        {
            var result = await _context.GetById(id);
            return Ok(result);
        }

        /// <summary>
        /// Получение списка всех карт
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _context.GetAll();
            return Ok(result);
        }

        /// <summary>
        /// Добавление карты
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Card card)
        {
            if (!_validator.Validate(card).IsValid) return BadRequest();
            await _context.Add(card);
            return Ok();
        }

        /// <summary>
        /// Обновление данных карты
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Card card)
        {
            if (!_validator.Validate(card).IsValid) return BadRequest();
            await _context.Update(card);
            return Ok();
        }

        /// <summary>
        /// Удаление карты
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] Card card)
        {
            if (!_validator.Validate(card).IsValid) return BadRequest();
            await _context.Update(card);
            return Ok();
        }
    }
}

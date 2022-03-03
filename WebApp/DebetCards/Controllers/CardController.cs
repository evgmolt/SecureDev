using DebetCards.Data;
using DebetCards.Models;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReportService;

namespace DebetCards.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardController : Controller
    {
        private readonly IRepository<Card> _repository;
        private readonly IValidator<Card> _validator;
        private readonly IReport<Card> _reportService;

        public CardController(IRepository<Card> context, IValidator<Card> validator, IReport<Card> reportService)
        {
            _repository = context;
            _validator = validator;
            _reportService = reportService;
        }

        /// <summary>
        /// Получение данных карты по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Card</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromQuery] int id)
        {
            var result = await _repository.GetById(id);
            return Ok(result);
        }

        /// <summary>
        /// Получение списка всех карт
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _repository.GetAll();
            return Ok(result);
        }

        /// <summary>
        /// Получение отчета
        /// </summary>
        /// <returns></returns>
        [HttpGet("/report/{filename}")]
        public async Task<IActionResult> GetReport([FromQuery] string filename)
        {
            var result = await _repository.GetAll();
            _reportService.CreateReport(filename, result);
            return Ok();
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
            await _repository.Add(card);
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
            await _repository.Update(card);
            return Ok();
        }

        /// <summary>
        /// Удаление карты
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            await _repository.DeleteById(id);
            return Ok();
        }
    }
}

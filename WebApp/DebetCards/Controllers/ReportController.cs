using AutoMapper;
using DebetCards.Data;
using DebetCards.Models;
using DebetCards.Report;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DebetCards.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : Controller
    {
        private readonly IRepository<Card> _repository;
        private readonly IReporter<CardForReport> _reporter;
        private readonly IMapper _mapper;

        public ReportController(
            IRepository<Card> context, 
            IReporter<CardForReport> reporter,
            IMapper mapper)
        {
            _repository = context;
            _reporter = reporter;
            _mapper = mapper;
        }

        /// <summary>
        /// Создание отчета - списка всех карт
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            var result = await _repository.GetAll();
            List<CardForReport> listForReport = new(); 
            foreach (Card card in result)
            {
                listForReport.Add(_mapper.Map<CardForReport>(card));
            }
            _reporter.CreateReport(listForReport);
            return Ok(result);
        }
    }
}

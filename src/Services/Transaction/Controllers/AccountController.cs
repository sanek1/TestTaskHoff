namespace Transaction.WebApi.Controllers
{
    using Transaction.WebApi.Models;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using Transaction.Framework.Domain;
    using Transaction.Framework.Services.Interface;
    using Transaction.Framework.Types;
    using Transaction.Framework.DTO;
    using Transaction.Framework.Services;
    using System.ComponentModel.DataAnnotations;
    using System;
    using Transaction.WebApi.Services.Interface;

    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ICurrencyService _currencyService;
        private readonly IMapper _mapper;
        private readonly ILoggerService _logger;

        public AccountController(ICurrencyService currencyService,  IMapper mapper, ILoggerService logger)
        {
            _currencyService = currencyService;
            _mapper = mapper;
            _logger = logger;

            _logger.InitLogger();
            _logger.SetLog("Session start");
        }

        [HttpGet("GetCurrency")]
        public async Task<IActionResult> GetCurrency([FromBody] Data request)
        {
            _logger.SetLog("Сall GetCurrency");
            _logger.SetLog(String.Format("Initial data X-> {0}, Y -> {1}, ValutaCode -> {2}", request.X, request.Y, request.ValutaCode));
            var result = await _currencyService.GetCurrency(request);
            return Ok(result);
        }

    }
}

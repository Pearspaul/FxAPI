using FxAPI.Context;
using FxAPI.Helpers;
using FxAPI.Models;
using FxAPI.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FxAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly FxDbContext _fxContext;

        public CurrencyController(FxDbContext fxDbContext)
        {
            _fxContext = fxDbContext;
        }

        /// <summary>
        /// Get all currency from db which are active in status
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<Currency>> GetAllCurrency()
        {
            return Ok(await _fxContext.Currency.Where(x=>x.Status == Constants.Active).ToListAsync());
        }

        /// <summary>
        /// Calculate the Exchange rate depends on UI fields and return the values 
        /// </summary>
        /// <param name="conversionRateApiDto"></param>
        /// <returns></returns>
        [HttpPost("calculateConverstion")]
        public async Task<IActionResult> CalculateConverstionRate(ConversionRateApiDto conversionRateApiDto)
        {
            if (conversionRateApiDto is null)
                return BadRequest(Constants.InvalidRequest);

            var currencyFrom = await _fxContext.Currency.FirstOrDefaultAsync(u => u.CurrencyCode == conversionRateApiDto.FromCurrencyCode);
            if (currencyFrom is null || currencyFrom.Status != Constants.Active)
                return BadRequest(Constants.InvalidRequest);
            var currencyTo = await _fxContext.Currency.FirstOrDefaultAsync(u => u.CurrencyCode == conversionRateApiDto.ToCurrencyCode);
            if (currencyTo is null || currencyTo.Status != Constants.Active)
                return BadRequest(Constants.InvalidRequest);
            RateMapper.CalculateAndMap(currencyFrom, currencyTo, conversionRateApiDto);
            return Ok(conversionRateApiDto);
        }

    }
}

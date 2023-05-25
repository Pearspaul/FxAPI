using FxAPI.Models;
using FxAPI.Models.Dto;

namespace FxAPI.Helpers
{
    public class RateMapper
    {
        /// <summary>
        /// Mapping UI after calculation in exchange rate
        /// </summary>
        public static ConversionRateApiDto CalculateAndMap(Currency fromCurrency, Currency toCurrency, ConversionRateApiDto conversionRateApiDto)
        {
            conversionRateApiDto.FromCurrencySymbol = fromCurrency.Symbol;
            conversionRateApiDto.FromCurrencyCode = fromCurrency.CurrencyCode;
            conversionRateApiDto.FromCurrencyAmount = conversionRateApiDto.FromCurrencyAmount;
            conversionRateApiDto.ExchangeRate = (float)(fromCurrency.ExchangeRate / toCurrency.ExchangeRate);
            conversionRateApiDto.ToCurrencyCode = toCurrency.CurrencyCode;
            conversionRateApiDto.ToCurrencySymbol = toCurrency.Symbol;
            conversionRateApiDto.ToCurrencyAmount = conversionRateApiDto.FromCurrencyAmount * conversionRateApiDto.ExchangeRate;
            conversionRateApiDto.CommissionPercentage = Constants.CommissionPercentage;
            conversionRateApiDto.CommissionRate = Constants.MinCommission + (conversionRateApiDto.FromCurrencyAmount * (float)fromCurrency.ExchangeRate * Constants.CommissionPercentage) / (100* (float)toCurrency.ExchangeRate);
            conversionRateApiDto.FinalTransferAmount = conversionRateApiDto.ToCurrencyAmount - conversionRateApiDto.CommissionRate;

            return conversionRateApiDto;
        }
    }
}

namespace FxAPI.Models.Dto
{
    public class ConversionRateApiDto
    {
        public string FromCurrencyCode { get; set; } = string.Empty;
        public string FromCurrencySymbol { get; set; } = string.Empty;
        public float FromCurrencyAmount { get; set; }
        public string ToCurrencyCode { get; set; } = string.Empty;
        public string ToCurrencySymbol { get; set; } = string.Empty;
        public float ToCurrencyAmount { get; set; }
        public float ExchangeRate { get; set; }
        public float CommissionPercentage { get; set; }
        public float CommissionRate { get; set; }
        public float FinalTransferAmount { get; set; }

    }
}

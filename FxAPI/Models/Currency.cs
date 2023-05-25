using System.ComponentModel.DataAnnotations;

namespace FxAPI.Models
{
    public class Currency
    {
        [Key]
        public int Id { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencyCode { get; set; }
        public string Country { get; set; }
        public string Symbol { get; set; }
        public decimal ExchangeRate { get; set; }
        public DateTime RateLastUpdated { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        
    }
}

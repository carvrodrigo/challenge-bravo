using System;

namespace CurrencyConverter.API.DTO
{
    public class CurrencyResponse
    {
        public string name { get; set; }
        public decimal rate { get; set; }
        public string @base { get; set; }
        public DateTime lastUpdate { get; set; } = DateTime.Now;
    }
}

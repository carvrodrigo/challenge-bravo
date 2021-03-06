using CurrencyConverter.Domain.Entities;
using CurrencyConverter.Infrastructure;
using System.Linq;

namespace CurrencyConverter.Infrasctructure
{
    public static class DatabaseInitialSeed
    {
        public static bool EnsureSeedDataForContext(this DatabaseContext context)
        {
            if (context.Currencies.Any()) return false;
            //initial currencies
            Configuration configuration = new Configuration()
            {
                baseRate = "USD",
                refreshTime = 20
            };
            context.configurations.Add(configuration);
            context.SaveChanges();

            Currency usd = new Currency()
            {
                @base = "USD",
                name = "USD",
                rate = 0
            };
            context.Currencies.Add(usd);

            Currency brl = new Currency()
            {
                @base = usd.name,
                name = "BRL",
                rate = 0
            };
            context.Currencies.Add(brl);

            Currency eur = new Currency()
            {
                @base = usd.name,
                name = "EUR",
                rate = 0
            };
            context.Currencies.Add(eur);

            Currency btc = new Currency()
            {
                @base = usd.name,
                name = "BTC",
                rate = 0
            };
            context.Currencies.Add(btc);

            Currency eth = new Currency()
            {
                @base = usd.name,
                name = "ETH",
                rate = 0
            };
            context.Currencies.Add(eth);
            var result = context.SaveChanges();
            return true;
        }
    }
}

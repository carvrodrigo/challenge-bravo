using CurrencyConverter.Domain.Entities;
using CurrencyConverter.Infrasctructure.Interfaces;
using CurrencyConverter.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurrencyConverter.Service.Services
{
    public class CurrencySrvc : ICurrencySrvc
    {
        private readonly IRepositoryBase<Currency> _repoCurrency;
        private readonly IPriceSrvc _prices;
        private readonly Configuration _config;

        public CurrencySrvc(IRepositoryBase<Currency> repoCurrency, IRepositoryBase<Configuration> repoConfig, IPriceSrvc price)
        {
            _prices = price;
            _repoCurrency = repoCurrency;
            _config = repoConfig.GetAll<Configuration>().ToList().FirstOrDefault();
        }        

        public int AddCurrency(Currency currency)
        {
            currency.@base = _config.baseRate;
            _prices.UpdateRate(currency);
            return currency.id;
        }

        public bool DeleteCurrency(int currencyId)
        {
            if (currencyId > 0)
            {
                var item = _repoCurrency.GetById<Currency>(currencyId);
                item.isActive = false;
                return _repoCurrency.Update<Currency>(item);
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<Currency> GetAll()
        {
            return _repoCurrency.GetAll<Currency>();
        }

        public IEnumerable<Currency> GetAllActive()
        {
            return _repoCurrency.GetAll<Currency>(i => i.isActive == true);
        }

        public Currency GetById(int id)
        {
            if (id > 0)
            {
                return _repoCurrency.GetById<Currency>(id);
            }
            else
            {
                return null;
            }
        }

        public bool UpdateCurrency(int id, Currency currency)
        {
            if (id > 0)
            {
                currency.id = id;
                return _repoCurrency.Update<Currency>(currency);
            }
            else
            {
                return false;
            }
        }
    }
}
using CurrencyConverter.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyConverter.Service.Interfaces
{
    public interface ICurrencySrv
    {
        Currency GetById(int id);
        IEnumerable<Currency> GetAll();
        IEnumerable<Currency> GetAllActive();
        int AddCurrency(Currency currency);
        bool DeleteCurrency(Currency currency);
        bool UpdateCurrency(Currency currency);
    }
}
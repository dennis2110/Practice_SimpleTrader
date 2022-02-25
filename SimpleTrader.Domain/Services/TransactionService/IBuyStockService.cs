﻿using SimpleTrader.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.Domain.Services.TransactionService
{
    public interface IBuyStockService
    {
        Task<Account> BuyStock(Account buyer, string symbol, int shares);
    }
}

using SimpleTrader.Domain.Services;
using SimpleTrader.FinancialModelingPrepAPI.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTrader.WPF.ViewModels
{
    public class PortfolioViewModel : ViewModelBase
    {
        //private readonly IStockPriceService _stockPriceService;
        //private StockPriceResult _stockPriceResult;
        //public StockPriceResult StockPriceResult
        //{
        //    get
        //    {
        //        return _stockPriceResult;
        //    }
        //    set
        //    {
        //        _stockPriceResult = value;
        //        OnPropertyChanged(nameof(StockPriceResult));
        //    }
        //}

        //public PortfolioViewModel(IStockPriceService stockPriceService)
        //{
        //    _stockPriceService = stockPriceService;
        //}
        //public static PortfolioViewModel LoadPortfolioViewModel(IStockPriceService stockPriceService)
        //{
        //    PortfolioViewModel portfolioViewModel = new PortfolioViewModel(stockPriceService);
        //    portfolioViewModel.LoadStockPrice();
        //    return portfolioViewModel;
        //}

        //private void LoadStockPrice()
        //{
        //    _stockPriceService.GetPrice("AAPL").ContinueWith(task =>
        //    {
        //        if (task.Exception == null)
        //        {
        //            StockPriceResult.Price = task.Result;
        //        }
        //    });
        //}
    }
}

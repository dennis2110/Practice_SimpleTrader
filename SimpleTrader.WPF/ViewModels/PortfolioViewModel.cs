using SimpleTrader.Domain.Services;
using SimpleTrader.FinancialModelingPrepAPI.Results;
using SimpleTrader.WPF.State.Assets;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace SimpleTrader.WPF.ViewModels
{
    public class PortfolioViewModel : ViewModelBase
    {
        public AssetListingViewModel AssetListingViewModel { get; }
        public PortfolioViewModel(AssetStore assetStore)
        {
            AssetListingViewModel = new AssetListingViewModel(assetStore);
        }

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

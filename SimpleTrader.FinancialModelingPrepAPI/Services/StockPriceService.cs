using Newtonsoft.Json;
using SimpleTrader.Domain.Exceptions;
using SimpleTrader.Domain.Services;
using SimpleTrader.FinancialModelingPrepAPI.Results;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.FinancialModelingPrepAPI.Services
{
    public class StockPriceService : IStockPriceService
    {
        public async Task<double> GetPrice(string symbol)
        {
            using (HttpClient client = new HttpClient())
            {
                string uri = "https://financialmodelingprep.com/api/v3/quote-short/" + symbol + "?apikey=d12491f08d6e2153e904f01b3760de35";

                //StockPriceResult stockPriceResult = await client.GetAsync<StockPriceResult>(uri);
                HttpResponseMessage response = await client.GetAsync(uri);
                string jsonResponse = await response.Content.ReadAsStringAsync();
                char[] MyChar = { '[', ']',' ' };
                string jsonResponse2 = jsonResponse.Trim(MyChar);
                StockPriceResult stockPriceResult = JsonConvert.DeserializeObject<StockPriceResult>(jsonResponse2);
                if (stockPriceResult.Price == 0.0)
                {
                    throw new InvalidSymbolException(symbol);
                }


                return stockPriceResult.Price;
            }
        }
    }
}

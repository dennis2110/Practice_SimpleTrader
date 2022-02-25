using Newtonsoft.Json;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.FinancialModelingPrepAPI.Services
{
    public class MajorIndexService : IMajorIndexService
    {
        public async Task<MajorIndex> GetMajorIndex(MajorIndexType indexType)
        {
            
            using(FinancialModelingPrepHttpClient client = new FinancialModelingPrepHttpClient())
            {
                string uri = "majors-indexes/" + GetUriSuffix(indexType) + "?apikey=d12491f08d6e2153e904f01b3760de35";

                //https://financialmodelingprep.com//api/v3/majors-indexes/.DJI
                //"https://financialmodelingprep.com/api/v3/majors-indexes/.DJI?apikey=d12491f08d6e2153e904f01b3760de35"
                //HttpResponseMessage response = await client.GetAsync(uri);
                //string jsonResponse = await response.Content.ReadAsStringAsync();
                //MajorIndex majorIndex = JsonConvert.DeserializeObject<MajorIndex>(jsonResponse);

                MajorIndex majorIndex = await client.GetAsync<MajorIndex>(uri);
                majorIndex.Type = indexType;


                return majorIndex;
            }
        }

        private string GetUriSuffix(MajorIndexType indexType)
        {
            switch (indexType)
            {
                case MajorIndexType.DowJones:
                    return ".DJI";
                case MajorIndexType.Nasdaq:
                    return ".IXIC";
                case MajorIndexType.SP500:
                    return ".INX";
                default:
                    throw new Exception("MajorIndexType dose not have a suffix defined."); 
            }
        }
    }
}

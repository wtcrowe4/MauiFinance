using MauiFinance.Models;
using System.Net.Http;
using MauiFinance.Views;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography.X509Certificates;

namespace MauiFinance.Services
{
    public class StockDataService
    {
        HttpClient _httpClient;
        private List<Stock> top_stocks;
        private readonly IConfiguration _config;

        

        public StockDataService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
            //var RAPIDAPIKEY = config["STOCK_API:KEY"];
            //var RAPIDAPIHOST = config["STOCK_API:HOST"];
        

        
        }


        //Service for search bar auto-complete
        //searchTerm comes from search input in view
        //public string searchTerm = "Microsoft";
        //readonly string RAPIDAPIKEY = SecureStorage.
        //public async Task<Stock> SearchAutoComplete(string searchTerm)
        //{
        //    var client = new HttpClient();
        //    var request = new HttpRequestMessage
        //    {
        //        Method = HttpMethod.Get,
        //        RequestUri = new Uri($"https://yh-finance.p.rapidapi.com/auto-complete?q={searchTerm}&region=US"),
        //        Headers =
        //            {
        //                { "X-RapidAPI-Key", RAPIDAPIKEY },
        //                { "X-RapidAPI-Host", "yh-finance.p.rapidapi.com" },
        //            },
        //    };
        //    using (var response = await client.SendAsync(request))
        //    {
        //        response.EnsureSuccessStatusCode();
        //        var body = await response.Content.ReadAsStringAsync();
        //        Console.WriteLine(body);
        //        //use body to fill Stock models and return it here to list in view
        //    }
        //}

        //Service for getting specific stock prices
        //public async Task<StockPrices> GetStockData(string symbol)
        //{
        //    var client = new HttpClient();
        //    var request = new HttpRequestMessage
        //    {
        //        Method = HttpMethod.Get,
        //        RequestUri = new Uri($"https://yh-finance.p.rapidapi.com/stock/v2/get-chart?interval=1d&symbol={symbol}&region=US"),
        //        Headers =
        //            {
        //                { "X-RapidAPI-Key", RAPIDAPIKEY },
        //                { "X-RapidAPI-Host", "yh-finance.p.rapidapi.com" },
        //            },
        //    };
        //    using (var response = await client.SendAsync(request))
        //    {
        //        response.EnsureSuccessStatusCode();
        //        var body = await response.Content.ReadAsStringAsync();
        //        Console.WriteLine(body);
        //        //use body to fill StockPrices and return it to use in ChartViewModel/ChartPage


        //Service for getting specific stock information
        //public async Task<StockDetail> GetStockInfo(string symbol)
        //{
        //    var client = new HttpClient();
        //    var request = new HttpRequestMessage
        //    {
        //        Method = HttpMethod.Get,
        //        RequestUri = new Uri($"https://yh-finance.p.rapidapi.com/stock/v2/get-summary?symbol={symbol}&region=US"),
        //        Headers =
        //            { 
        //                { "X-RapidAPI-Key", RAPIDAPIKEY },
        //                { "X-RapidAPI-Host", "yh-finance.p.rapidapi.com" },
        //            },
        //    };
        //    using (var response = await client.SendAsync(request))
        //    {
        //        response.EnsureSuccessStatusCode();
        //        var body = await response.Content.ReadAsStringAsync();
        //        Console.WriteLine(body);
        //        //use body to fill StockDetail and return it to use in StockDetailViewModel/StockDetailPage

        //Service for getting top performing stocks
        public async Task<List<Stock>> GetTopStocks(IConfiguration config)
        {
            var client = new HttpClient();
            var RAPIDAPIKEY = config["STOCK_API:KEY"];
            var RAPIDAPIHOST = config["STOCK_API:HOST"];
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://yh-finance.p.rapidapi.com/stock/v2/get-movers?region=US&lang=en-US"),
                Headers =
                    {
                        { "X-RapidAPI-Key", RAPIDAPIKEY },
                        { "X-RapidAPI-Host", "yh-finance.p.rapidapi.com" },
                    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);

                //use body to fill Stock models and return it here to list in view
                top_stocks = new List <Stock>();
                return top_stocks;

                //Service for getting watchlist stocks
                //public async Task<Stock> GetWatchlistStocks()
                //{
                //    var client = new HttpClient();
                //    var request = new HttpRequestMessage
                //    {
                //        Method = HttpMethod.Get,
                //        RequestUri = new Uri("https://yh-finance.p.rapidapi.com/stock/v2/get-movers?region=US&lang=en-US"),
                //        Headers =
                //            {
                //                { "X-RapidAPI-Key", RAPIDAPIKEY },
                //                { "X-RapidAPI-Host", "yh-finance.p.rapidapi.com" },
                //            },
                //    };
                //    using (var response = await client.SendAsync(request))
                //    {
                //        response.EnsureSuccessStatusCode();
                //        var body = await response.Content.ReadAsStringAsync();
                //        Console.WriteLine(body);
                //        


            }
}
    }

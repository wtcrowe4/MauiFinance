﻿using MauiFinance.Models;
using System.Net.Http;
using MauiFinance.Views;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.Linq.Expressions;

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
        }
        public async Task<List<Stock>> GetTopStocks(IConfiguration config)
        {
            string RAPIDAPIKEY = config["STOCK_API:KEY"];
            string RAPIDAPIHOST = config["STOCK_API:HOST"];
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://yh-finance.p.rapidapi.com/stock/v2/get-top-lists?region=US"),
                Headers =
                {
                    { "X-RapidAPI-Key", RAPIDAPIKEY },
                    { "X-RapidAPI-Host", RAPIDAPIHOST },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
                return top_stocks;
                //use body to fill Stock models and return it here to list in view
            };
        }

        public async Task<Stock> SearchAutoComplete(string searchTerm, IConfiguration config)
        {
            string RapidApiKey = config["STOCK_API:KEY"];
            string RapidApiHost = config["STOCK_API:HOST"];
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://yh-finance.p.rapidapi.com/auto-complete?q={searchTerm}&region=US"),
                Headers =
                {
                    { "X-RapidAPI-Key", RapidApiKey },
                    { "X-RapidAPI-Host", RapidApiHost }
                }
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
                //convert body into a Stock to return
                //return body;

            }

        }

        public async Task<Stock> GetStockInfo(string symbol, IConfiguration config)
        {
            string RapidApiKey = config["STOCK_API:KEY"];
            string RapidApiHost = config["STOCK_API:HOST"];
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://yh-finance.p.rapidapi.com/stock/v2/get-summary?symbol={symbol}&region=US"),
                Headers =
                {
                    { "X-RapidAPI-Key", RapidApiKey },
                    { "X-RapidAPI-Host", RapidApiHost }
                }
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
                //convert body into a Stock to return
                //return body;

            }
        }


        public async Task<List<Stock>> GetWatchList(List<string> symbols, IConfiguration config)
        {
            string RapidApiKey = config["STOCK_API:KEY"];
            string RapidApiHost = config["STOCK_API:HOST"];
            var client = new HttpClient();
            foreach (var symbol in symbols)
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://yh-finance.p.rapidapi.com/auto-complete?q={symbol}&region=US")
                    Headers =
                    {
                        { "X-RapidAPI-Key", RapidApiKey },
                        { "X-RapidAPI-Host", RapidApiHost }

                    }
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(body);
                    //convert body into Stocks
                }


            }
        }
        

        public async Task<List<StockPrice>> GetStockChartData(string symbol, string range, string interval, IConfiguration config)
        {
            string RapidApiKey = config["STOCK_API:KEY"];
            string RapidApiHost = config["STOCK_API:HOST"];
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://yh-finance.p.rapidapi.com/stock/v3/get-chart?interval={interval}&symbol={symbol}&range={range}&region=US&includePrePost=false&useYfid=true&includeAdjustedClose=true&events=capitalGain%2Cdiv%2Csplit"),
                Headers =
                {
                    { "X-RapidAPI-Key", RapidApiKey },
                    { "X-RapidAPI-Host", RapidApiHost }
                }
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
                //convert body into a Stock to return
                //return body;

            }

        }

    }
}


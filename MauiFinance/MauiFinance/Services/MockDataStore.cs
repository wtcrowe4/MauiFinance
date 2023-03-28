using MauiFinance.Models;

namespace MauiFinance.Services
{
    public class MockDataStore : IDataStore<Stock>
    {
        readonly List<Stock> stocks;

        public MockDataStore()
        {
            DateTime baseDate = DateTime.Today;
            this.stocks = new List<Stock>()
            {
                new Stock {Id = "1", Name = "Google", Symbol = "GOGL", Industry = "Technology", ProfitMargin = "+25", Delta = 2.7},
                new Stock {Id = "2", Name = "Apple", Symbol = "APPL", Industry = "Technology", ProfitMargin = "+15", Delta = -.3},
                new Stock {Id = "3", Name = "Microsoft", Symbol = "MSFT", Industry = "Technology", ProfitMargin = "+67", Delta = 1.2 },
                new Stock {Id = "4", Name = "Amazon", Symbol = "AMZN", Industry = "Technology", ProfitMargin = "+45", Delta = -.7 },
                new Stock {Id = "5", Name = "Facebook", Symbol = "FB", Industry = "Technology", ProfitMargin = "-25", Delta = 1.9 },
                new Stock {Id = "6", Name = "Tesla", Symbol = "TSLA", Industry = "Technology", ProfitMargin = "80", Delta = 3.3 },
                new Stock {Id = "7", Name = "Netflix", Symbol = "NFLX", Industry = "Technology", ProfitMargin = "+52", Delta = -1.8},
                
              
            };
        //    new Item { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description.", StartTime = baseDate.AddHours(1), EndTime = baseDate.AddHours(2), Value=17.098 },
        //    new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description.", StartTime = baseDate.AddHours(2), EndTime = baseDate.AddHours(4), Value=9.985 },
        //    new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description.", StartTime = baseDate.AddHours(3), EndTime = baseDate.AddHours(5), Value=9.597},
        //    new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description.", StartTime = baseDate.AddHours(5), EndTime = baseDate.AddHours(6), Value=9.834 },
        //    new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description.", StartTime = baseDate.AddHours(9), EndTime = baseDate.AddHours(12), Value=3.287 },
        //    new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description.", StartTime = baseDate.AddHours(12), EndTime = baseDate.AddHours(15), Value=81.2 }
        //};

        }

        //public async Task<bool> AddItemAsync(Item item)
        //{
        //    this.items.Add(item);

        //    return await Task.FromResult(true);
        //}

        public async Task<bool> AddItemAsync(Stock stock)
        {
            this.stocks.Add(stock);
            return await Task.FromResult(true);
        }

        //public async Task<bool> UpdateItemAsync(Item item)
        //{
        //    var oldItem = this.items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
        //    this.items.Remove(oldItem);
        //    this.items.Add(item);

        //    return await Task.FromResult(true);
        //}

        public async Task<bool> UpdateItemAsync(Stock stock)
        {
            var oldItem = this.stocks.Where((Stock arg) => arg.Id == stock.Id).FirstOrDefault();
            this.stocks.Remove(oldItem);
            this.stocks.Add(stock);
            return await Task.FromResult(true);
        }

        //public async Task<bool> DeleteItemAsync(string id)
        //{
        //    var oldItem = this.items.Where((Item arg) => arg.Id == id).FirstOrDefault();
        //    this.items.Remove(oldItem);

        //    return await Task.FromResult(true);
        //}

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = this.stocks.Where((Stock arg) => arg.Id == id).FirstOrDefault();
            this.stocks.Remove(oldItem);
            return await Task.FromResult(true);
        }

        //public async Task<Item> GetItemAsync(string id)
        //{
        //    return await Task.FromResult(this.items.FirstOrDefault(s => s.Id == id));
        //}

        public async Task<Stock> GetItemAsync(string id)
        {
            return await Task.FromResult(this.stocks.FirstOrDefault(s => s.Id == id));
        }

        //public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        //{
        //    return await Task.FromResult(this.items);
        //}

        public async Task<IEnumerable<Stock>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(this.stocks);
        }
    }
}
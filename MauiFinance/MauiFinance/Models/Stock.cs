
using MauiFinance.ViewModels;

namespace MauiFinance.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public StockPrices stockPrices { get; set; }


    }

    public class StockDetail
    {
        
        

    }
}


using MauiFinance.ViewModels;

namespace MauiFinance.Models
{
    public class Stock
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public StockPrices stockPrices { get; set; }
        public string ProfitMargin { get; set; }
        public string Sector { get; set; }
        public string Industry { get; set; }
        public string Location { get; set; }
        public string Website { get; set; }
        public string Summary { get; set; }

    }

    public class StockPrice
    {
        public DateTime Date { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Open { get; set; }
        public double Close { get; set; }
        public double Volume { get; set; }
    }

}

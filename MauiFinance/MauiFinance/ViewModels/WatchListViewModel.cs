using MauiFinance.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MauiFinance.ViewModels
{
    public class WatchListViewModel : BaseViewModel
    {
        public WatchListViewModel()
        {
            Title = "Watchlist";
            Stocks = new ObservableCollection<Stock>();
        }

        public ObservableCollection<Stock> Stocks { get; private set; }

        async public void OnAppearing()
        {
            IEnumerable<Stock> stocks = await DataStore.GetItemsAsync(true);

            Stocks.Clear();
            foreach (Stock stock in stocks)
            {
                Stocks.Add(stock);
                Debug.WriteLine(stock.Symbol);
            }
        }
    }
}
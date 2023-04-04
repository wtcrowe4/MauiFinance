using MauiFinance.Models;
using System.Collections.ObjectModel;


namespace MauiFinance.ViewModels
{
    public class TopPerformersViewModel : BaseViewModel
    {
        public TopPerformersViewModel() 
        {
            Title = "Top Performers";
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
            }
        }

    }
    {
    }
}

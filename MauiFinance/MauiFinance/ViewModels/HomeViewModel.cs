using MauiFinance.Services;
using System.Windows.Input;

namespace MauiFinance.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public const string ViewName = "HomePage";
        public HomeViewModel()
        {
            Title = "Home";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://www.devexpress.com/maui/"));
            //GetTopStocksCommand = new Command(async () => await StockDataService.GetTopStocks());
        }

        public ICommand OpenWebCommand { get; }
    }
}
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
        }

        public ICommand OpenWebCommand { get; }
    }
}
using MauiFinance.ViewModels;

namespace MauiFinance.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WatchListPage : ContentPage
    {
        public WatchListPage()
        {
            InitializeComponent();
            BindingContext = ViewModel = new WatchListViewModel();
            ViewModel.OnAppearing();
        }

        WatchListViewModel ViewModel { get; }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.OnAppearing();
        }
    }
}
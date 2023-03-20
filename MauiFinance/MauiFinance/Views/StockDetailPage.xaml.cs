using MauiFinance.ViewModels;

namespace MauiFinance.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new StockDetailViewModel();
        }
    }
}
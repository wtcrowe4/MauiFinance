using System.Web;

namespace MauiFinance.ViewModels
{
    public class StockDetailViewModel : BaseViewModel, IQueryAttributable
    {
        public const string ViewName = "ItemDetailPage";

        string name;
        string symbol;
        string description;


        public string Id { get; set; }

        public string Name
        {
            get => this.Name;
            set => SetProperty(ref this.name, value);
        }

        public string Description
        {
            get => this.description;
            set => SetProperty(ref this.description, value);
        }

        public async Task LoadItemId(string stockId)
        {
            try
            {
                var stock = await DataStore.GetItemAsync(stockId);
                Id = stock.Id;
                Name = stock.Name;
                Description = stock.Summary;
            }
            catch (Exception)
            {
                System.Diagnostics.Debug.WriteLine("Failed to Load Item");
            }
        }

        public override async Task InitializeAsync(object parameter)
        {
            await LoadItemId(parameter as string);
        }

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            string id = HttpUtility.UrlDecode(query["id"] as string);
            await LoadItemId(id);
        }
    }
}
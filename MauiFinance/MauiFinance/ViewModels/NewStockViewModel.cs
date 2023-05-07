using DevExpress.Maui.DataForm;
using MauiFinance.Models;

namespace MauiFinance.ViewModels
{
    public class NewStockViewModel : BaseViewModel
    {
        public const string ViewName = "NewStockPage";


        string name;
        string symbol;
        string sector;
        string industry;
        string founded;


        public NewStockViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        //public string Text
        //{
        //    get => this.text;
        //    set => SetProperty(ref this.text, value);
        //}

        //public string Description
        //{
        //    get => this.description;
        //    set => SetProperty(ref this.description, value);
        //}

        public string Name
        {
            get => this.name; set => this.name = value;
        }

        public string Symbol
        {
            get => this.symbol; set => this.symbol = value;
        }


        [DataFormDisplayOptions(IsVisible = false)]
        public Command SaveCommand { get; }

        [DataFormDisplayOptions(IsVisible = false)]
        public Command CancelCommand { get; }


        bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(this.text)
                && !String.IsNullOrWhiteSpace(this.description);
        }

        async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Navigation.GoBackAsync();
        }

        async void OnSave()
        {
            Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Text = Text,
                Description = Description
            };

            //await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Navigation.GoBackAsync();
        }

        //Search Command
        public Command SearchCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var stock = await App.StockManager.GetStockAsync(this.symbol);
                    if (stock != null)
                    {
                        this.name = stock.Name;
                        this.sector = stock.Sector;
                        this.industry = stock.Industry;
                        this.founded = stock.Founded;
                    }
                });
            }
        }   
    }
}
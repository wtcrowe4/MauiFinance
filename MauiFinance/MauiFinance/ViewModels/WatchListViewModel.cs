using MauiFinance.Models;
using System.Collections.ObjectModel;

namespace MauiFinance.ViewModels
{
    public class WatchListViewModel : BaseViewModel
    {
        public WatchListViewModel()
        {
            Title = "DataGrid";
            Items = new ObservableCollection<Item>();
        }

        public ObservableCollection<Item> Items { get; private set; }

        async public void OnAppearing()
        {
            IEnumerable<Item> items = await DataStore.GetItemsAsync(true);
            Items.Clear();
            foreach (Item item in items)
            {
                Items.Add(item);
            }
        }
    }
}
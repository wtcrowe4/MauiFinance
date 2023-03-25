namespace MauiFinance.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T stock);

        Task<bool> UpdateItemAsync(T stock);

        Task<bool> DeleteItemAsync(string id);

        Task<T> GetItemAsync(string id);

        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}
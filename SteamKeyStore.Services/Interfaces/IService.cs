using SteamKeyStore.Model.Utlity;

namespace SteamKeyStore.Services.Interfaces
{
    public interface IService<T, TSearch> where T : class where TSearch : class
    {
        Task<PagedResult<T>> Get(TSearch search = null);
        Task<T> GetById(int id);
    }
}

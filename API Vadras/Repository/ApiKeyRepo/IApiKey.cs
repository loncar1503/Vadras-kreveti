using Domain;

namespace API_Vadras.Repository.ApiKeyRepo
{
   public interface IApiKey
    {
        Task<ApiKey> CreateAsync(int radnikId, int expireHours = 12);
        Task<ApiKey?> GetValidAsync(string key);
        Task DeactivateAllForRadnikAsync(int radnikId);

        Task DeleteAllForRadnikAsync(int radnikId);
    }
}

using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Cryptography;

namespace API_Vadras.Repository.ApiKeyRepo
{
    public class ApiKeyEF : IApiKey

    {
        private readonly VadrasDbContext dbContext;

        public ApiKeyEF(VadrasDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ApiKey> CreateAsync(int radnikId, int expireHours = 20)
        {
            // (opciono) obori stare ključeve da radnik ima samo 1 aktivan
            await DeleteAllForRadnikAsync(radnikId);

            var key = GenerateSecureKey(32); // 32 bytes -> dobar key string

            var entity = new ApiKey
            {
                RadnikId = radnikId,
                Key = key,
                CreatedAt = DateTime.Now,
                ExpiresAt = DateTime.Now.AddHours(expireHours),
                IsActive = true
            };

            dbContext.ApiKeys.Add(entity);
            await dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<ApiKey?> GetValidAsync(string key)
        {
            return await dbContext.ApiKeys
                .FirstOrDefaultAsync(x =>
                    x.Key == key &&
                    x.IsActive &&
                    x.ExpiresAt > DateTime.Now);
        }

        public async Task DeactivateAllForRadnikAsync(int radnikId)
        {
            var keys = await dbContext.ApiKeys
                .Where(x => x.RadnikId == radnikId && x.IsActive)
                .ToListAsync();
            if(keys.Count == 0)
                return;

            foreach (var k in keys)
                k.IsActive = false;

            if (keys.Count > 0)
                await dbContext.SaveChangesAsync();
        }

        private static string GenerateSecureKey(int bytesLength)
        {
            var bytes = RandomNumberGenerator.GetBytes(bytesLength);
            // url-safe base64
            return Convert.ToBase64String(bytes)
                .Replace("+", "-")
                .Replace("/", "_")
                .Replace("=", "");
        }

        public async Task DeleteAllForRadnikAsync(int radnikId)
        {
            var keys = await dbContext.ApiKeys
       .Where(x => x.RadnikId == radnikId)
       .ToListAsync();

            if (keys.Count == 0)
                return;

            dbContext.ApiKeys.RemoveRange(keys);
            await dbContext.SaveChangesAsync();
        }
    }
}


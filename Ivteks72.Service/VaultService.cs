using Azure.Security.KeyVault.Secrets;
using System;
using System.Threading.Tasks;

namespace Ivteks72.Service
{
    public class VaultService : IVaultService
    {
        private readonly SecretClient _secretClient;

        public VaultService(SecretClient client)
        {
            _secretClient = client;
        }

        public async Task<string> GetSecretAsStringOrDefaultAsync(string secret)
        {
            return (await _secretClient.GetSecretAsync(secret)).Value.Value;
        }
    }
}

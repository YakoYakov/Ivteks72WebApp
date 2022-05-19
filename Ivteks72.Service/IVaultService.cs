using System.Threading.Tasks;

namespace Ivteks72.Service
{
    public interface IVaultService
    {
        Task<string> GetSecretAsStringOrDefaultAsync(string secret);
    }
}

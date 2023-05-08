using Upbit.Net.Objects.Models.Exchanges;

namespace Upbit.Net.Clients.ExchangeApis
{
    public class UpbitServiceInfoApi : BaseClient
    {
        public UpbitServiceInfoApi(HttpClient client, string accessKey, string secretKey) : base(client, accessKey, secretKey)
        {
        }

        public async Task<IEnumerable<UpbitWalletStatus>> GetWalletStatusAsync()
        {
            return await GetAsync<IEnumerable<UpbitWalletStatus>>(Client, "https://api.upbit.com/v1/status/wallet" + SetJwtToken()).ConfigureAwait(false);
        }

        public async Task<IEnumerable<UpbitApiKey>> GetApiKeyListAsync()
        {
            return await GetAsync<IEnumerable<UpbitApiKey>>(Client, "https://api.upbit.com/v1/api_keys" + SetJwtToken()).ConfigureAwait(false);
        }
    }
}

using Upbit.Net.Objects.Models.Exchanges;

namespace Upbit.Net.Clients.ExchangeApis
{
    public class UpbitAssetsApi : BaseClient
    {
        public UpbitAssetsApi(HttpClient client, string accessKey, string secretKey) : base(client, accessKey, secretKey)
        {
        }

        public async Task<IEnumerable<UpbitAccount>> GetOverallAccountAsync()
        {
            return await GetAsync<IEnumerable<UpbitAccount>>(Client, "https://api.upbit.com/v1/accounts" + SetJwtToken()).ConfigureAwait(false);
        }
    }
}

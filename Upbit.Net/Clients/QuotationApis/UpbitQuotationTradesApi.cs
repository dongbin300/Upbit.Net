using Upbit.Net.Objects.Models.Exchanges;

namespace Upbit.Net.Clients.QuotationApis
{
    public class UpbitQuotationTradesApi : BaseClient
    {
        public UpbitQuotationTradesApi(HttpClient client, string accessKey, string secretKey) : base(client, accessKey, secretKey)
        {
        }

        public async Task<IEnumerable<UpbitAccount>> GetOverallAccount()
        {
            return await GetAsync<IEnumerable<UpbitAccount>>(Client, "https://api.upbit.com/v1/accounts").ConfigureAwait(false);
        }
    }
}

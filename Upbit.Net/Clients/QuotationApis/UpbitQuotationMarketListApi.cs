using Upbit.Net.Objects.Models.Quotations;

namespace Upbit.Net.Clients.QuotationApis
{
    public class UpbitQuotationMarketListApi : BaseClient
    {
        public UpbitQuotationMarketListApi(HttpClient client, string accessKey, string secretKey) : base(client, accessKey, secretKey)
        {
        }

        public async Task<IEnumerable<UpbitMarket>> GetMarketListAsync(bool isDetails = false)
        {
            var parameters = new Dictionary<string, string>()
            {
                { "isDetails", isDetails.ToString() }
            };

            return await GetAsync<IEnumerable<UpbitMarket>>(Client, "https://api.upbit.com/v1/market/all" + SetJwtToken(parameters)).ConfigureAwait(false);
        }
    }
}

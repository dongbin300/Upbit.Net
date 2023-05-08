using Upbit.Net.Extensions;
using Upbit.Net.Objects.Models.Quotations;

namespace Upbit.Net.Clients.QuotationApis
{
    public class UpbitQuotationTickersApi : BaseClient
    {
        public UpbitQuotationTickersApi(HttpClient client, string accessKey, string secretKey) : base(client, accessKey, secretKey)
        {
        }

        public async Task<IEnumerable<UpbitTicker>> GetTickersAsync(IEnumerable<string> marketIds)
        {
            var parameters = new Dictionary<string, string>()
            {
                { "markets", marketIds.ToCommaString() }
            };

            return await GetAsync<IEnumerable<UpbitTicker>>(Client, "https://api.upbit.com/v1/ticker" + SetJwtToken(parameters)).ConfigureAwait(false);
        }
    }
}

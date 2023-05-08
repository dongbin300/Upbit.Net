using Upbit.Net.Extensions;
using Upbit.Net.Objects.Models.Quotations;

namespace Upbit.Net.Clients.QuotationApis
{
    public class UpbitQuotationOrderBookApi : BaseClient
    {
        public UpbitQuotationOrderBookApi(HttpClient client, string accessKey, string secretKey) : base(client, accessKey, secretKey)
        {
        }

        public async Task<IEnumerable<UpbitOrderBook>> GetOrderBooksAsync(IEnumerable<string> marketIds)
        {
            var parameters = new Dictionary<string, string>()
            {
                { "markets", marketIds.ToCommaString() }
            };

            return await GetAsync<IEnumerable<UpbitOrderBook>>(Client, "https://api.upbit.com/v1/orderbook" + SetJwtToken(parameters)).ConfigureAwait(false);
        }
    }
}

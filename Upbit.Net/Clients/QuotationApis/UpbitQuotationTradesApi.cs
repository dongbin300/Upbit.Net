using Upbit.Net.Enums;
using Upbit.Net.Objects.Models.Exchanges;
using Upbit.Net.Objects.Models.Quotations;

namespace Upbit.Net.Clients.QuotationApis
{
    public class UpbitQuotationTradesApi : BaseClient
    {
        public UpbitQuotationTradesApi(HttpClient client, string accessKey, string secretKey) : base(client, accessKey, secretKey)
        {
        }

        public async Task<IEnumerable<UpbitTradeHistory>> GetRecentTradesHistoryAsync(string marketId, DateTime? lastCandleTime = null, int count = 1, int pageCursor = 1, int? daysAgo = null)
        {
            lastCandleTime ??= DateTime.Now;
            var daysAgoString = daysAgo == null ? string.Empty : daysAgo.ToString() ?? string.Empty;

            var parameters = new Dictionary<string, string>()
            {
                { "market", marketId },
                { "to", lastCandleTime.Value.ToString("yyyy-MM-dd HH:mm:ss") },
                { "count", count.ToString() },
                { "cursor", pageCursor.ToString() },
                { "daysAgo", daysAgoString }
            };

            return await GetAsync<IEnumerable<UpbitTradeHistory>>(Client, "https://api.upbit.com/v1/trades/ticks" + SetJwtToken(parameters)).ConfigureAwait(false);
        }
    }
}

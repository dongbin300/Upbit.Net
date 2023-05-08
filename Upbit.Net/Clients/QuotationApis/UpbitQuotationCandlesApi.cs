using Upbit.Net.Enums;
using Upbit.Net.Objects.Models.Quotations;

namespace Upbit.Net.Clients.QuotationApis
{
    public class UpbitQuotationCandlesApi : BaseClient
    {
        public UpbitQuotationCandlesApi(HttpClient client, string accessKey, string secretKey) : base(client, accessKey, secretKey)
        {
        }

        public async Task<IEnumerable<UpbitMinuteCandle>> GetMinutesCandlesAsync(string marketId, UpbitMinuteInterval interval, DateTime? lastCandleTime = null, int count = 1)
        {
            lastCandleTime ??= DateTime.Now;

            var parameters = new Dictionary<string, string>()
            {
                { "market", marketId },
                { "to", lastCandleTime.Value.ToString("yyyy-MM-dd HH:mm:ss") },
                { "count", count.ToString() }
            };

            return await GetAsync<IEnumerable<UpbitMinuteCandle>>(Client, $"https://api.upbit.com/v1/candles/minutes/{(int)interval}" + SetJwtToken(parameters)).ConfigureAwait(false);
        }

        public async Task<IEnumerable<UpbitDayCandle>> GetDaysCandlesAsync(string marketId, DateTime? lastCandleTime = null, int count = 1, UpbitPriceUnit convertingPriceUnit = UpbitPriceUnit.None)
        {
            lastCandleTime ??= DateTime.Now;
            var priceUnit = convertingPriceUnit == UpbitPriceUnit.None ? string.Empty : convertingPriceUnit.ToString();

            var parameters = new Dictionary<string, string>()
            {
                { "market", marketId },
                { "to", lastCandleTime.Value.ToString("yyyy-MM-dd HH:mm:ss") },
                { "count", count.ToString() },
                { "convertingPriceUnit", priceUnit }
            };

            return await GetAsync<IEnumerable<UpbitDayCandle>>(Client, "https://api.upbit.com/v1/candles/days" + SetJwtToken(parameters)).ConfigureAwait(false);
        }

        public async Task<IEnumerable<UpbitWeekCandle>> GetWeeksCandlesAsync(string marketId, DateTime? lastCandleTime = null, int count = 1)
        {
            lastCandleTime ??= DateTime.Now;

            var parameters = new Dictionary<string, string>()
            {
                { "market", marketId },
                { "to", lastCandleTime.Value.ToString("yyyy-MM-dd HH:mm:ss") },
                { "count", count.ToString() }
            };

            return await GetAsync<IEnumerable<UpbitWeekCandle>>(Client, "https://api.upbit.com/v1/candles/weeks" + SetJwtToken(parameters)).ConfigureAwait(false);
        }

        public async Task<IEnumerable<UpbitMonthCandle>> GetMonthsCandlesAsync(string marketId, DateTime? lastCandleTime = null, int count = 1)
        {
            lastCandleTime ??= DateTime.Now;

            var parameters = new Dictionary<string, string>()
            {
                { "market", marketId },
                { "to", lastCandleTime.Value.ToString("yyyy-MM-dd HH:mm:ss") },
                { "count", count.ToString() }
            };

            return await GetAsync<IEnumerable<UpbitMonthCandle>>(Client, "https://api.upbit.com/v1/candles/months" + SetJwtToken(parameters)).ConfigureAwait(false);
        }
    }
}

using Upbit.Net.Enums;
using Upbit.Net.Extensions;
using Upbit.Net.Objects.Models.Exchanges;

namespace Upbit.Net.Clients.ExchangeApis
{
    public class UpbitDepositApi : BaseClient
    {
        public UpbitDepositApi(HttpClient client, string accessKey, string secretKey) : base(client, accessKey, secretKey)
        {
        }

        public async Task<IEnumerable<UpbitTransfer>> GetDepositListAsync(string currency, string state, IEnumerable<string> uuids, IEnumerable<string> txids, int limit = 100, int page = 1, UpbitSortType sortType = UpbitSortType.desc)
        {
            var parameters = new Dictionary<string, string>()
            {
                { "currency", currency },
                { "state", state },
                { "uuids", uuids.ToQueryString() },
                { "txids", txids.ToQueryString() },
                { "limit", limit.ToString() },
                { "page", page.ToString() },
                { "order_by", sortType.ToString() }
            };

            return await GetAsync<IEnumerable<UpbitTransfer>>(Client, "https://api.upbit.com/v1/deposits" + SetJwtToken(parameters)).ConfigureAwait(false);
        }

        public async Task<UpbitTransfer> GetIndividualDepositAsync(string uuid = "", string txid = "", string currency = "")
        {
            var parameters = new Dictionary<string, string>()
            {
                { "uuid", uuid },
                { "txid", txid },
                { "currency", currency }
            };

            return await GetAsync<UpbitTransfer>(Client, "https://api.upbit.com/v1/deposit" + SetJwtToken(parameters)).ConfigureAwait(false);
        }

        public async Task<UpbitCoinAddressGeneration> GenerateDepositAddressAsync(string currency)
        {
            var parameters = new Dictionary<string, string>()
            {
                { "currency", currency }
            };

            return await PostAsync<UpbitCoinAddressGeneration>(Client, "https://api.upbit.com/v1/deposits/generate_coin_address" + SetJwtToken(parameters)).ConfigureAwait(false);
        }

        public async Task<IEnumerable<UpbitCoinAddressGeneration>> GetGeneralDepositAddressAsync()
        {
            return await GetAsync<IEnumerable<UpbitCoinAddressGeneration>>(Client, "https://api.upbit.com/v1/deposits/coin_addresses" + SetJwtToken()).ConfigureAwait(false);
        }

        public async Task<UpbitCoinAddressGeneration> GetIndividualDepositAddressAsync(string currency)
        {
            var parameters = new Dictionary<string, string>()
            {
                { "currency", currency }
            };

            return await GetAsync<UpbitCoinAddressGeneration>(Client, "https://api.upbit.com/v1/deposits/coin_address" + SetJwtToken(parameters)).ConfigureAwait(false);
        }

        public async Task<UpbitTransfer> DepositKrwAsync(decimal amount, UpbitTwoFactorType twoFactorType = UpbitTwoFactorType.kakao_pay)
        {
            var parameters = new Dictionary<string, string>()
            {
                { "amount", amount.ToString() },
                { "two_factor_type", twoFactorType.ToString() }
            };

            return await PostAsync<UpbitTransfer>(Client, "https://api.upbit.com/v1/deposits/krw" + SetJwtToken(parameters)).ConfigureAwait(false);
        }
    }
}

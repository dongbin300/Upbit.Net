using Upbit.Net.Enums;
using Upbit.Net.Extensions;
using Upbit.Net.Objects.Models.Exchanges;

namespace Upbit.Net.Clients.ExchangeApis
{
    public class UpbitWithdrawalApi : BaseClient
    {
        public UpbitWithdrawalApi(HttpClient client, string accessKey, string secretKey) : base(client, accessKey, secretKey)
        {
        }

        public async Task<IEnumerable<UpbitTransfer>> GetWithdrawalListAsync(string currency, string state, IEnumerable<string> uuids, IEnumerable<string> txids, int limit = 100, int page = 1, UpbitSortType sortType = UpbitSortType.desc)
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

            return await GetAsync<IEnumerable<UpbitTransfer>>(Client, "https://api.upbit.com/v1/withdraws" + SetJwtToken(parameters)).ConfigureAwait(false);
        }

        public async Task<UpbitTransfer> GetIndividualWithdrawalAsync(string uuid = "", string txid = "", string currency = "")
        {
            var parameters = new Dictionary<string, string>()
            {
                { "uuid", uuid },
                { "txid", txid },
                { "currency", currency }
            };

            return await GetAsync<UpbitTransfer>(Client, "https://api.upbit.com/v1/withdraw" + SetJwtToken(parameters)).ConfigureAwait(false);
        }

        public async Task<UpbitAvailableBalanceInfo> GetAvailableBalanceInfoAsync()
        {
            return await GetAsync<UpbitAvailableBalanceInfo>(Client, "https://api.upbit.com/v1/withdraws/chance" + SetJwtToken()).ConfigureAwait(false);
        }

        public async Task<UpbitTransfer> WithdrawalCoinsAsync(string currency, decimal amount, string address, string secondaryAddress = "", UpbitTransactionType transactionType = UpbitTransactionType.@default)
        {
            var parameters = new Dictionary<string, string>()
            {
                { "currency", currency },
                { "amount", amount.ToString() },
                { "address", address },
                { "secondary_address", secondaryAddress },
                { "transaction_type", transactionType.ToString() }
            };

            return await PostAsync<UpbitTransfer>(Client, "https://api.upbit.com/v1/withdraws/coin" + SetJwtToken(parameters)).ConfigureAwait(false);
        }

        public async Task<UpbitTransfer> WithdrawalKrwAsync(decimal amount, UpbitTwoFactorType twoFactorType = UpbitTwoFactorType.kakao_pay)
        {
            var parameters = new Dictionary<string, string>()
            {
                { "amount", amount.ToString() },
                { "two_factor_type", twoFactorType.ToString() }
            };

            return await PostAsync<UpbitTransfer>(Client, "https://api.upbit.com/v1/withdraws/krw" + SetJwtToken(parameters)).ConfigureAwait(false);
        }
    }
}

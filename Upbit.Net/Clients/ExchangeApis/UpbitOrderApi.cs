using Upbit.Net.Enums;
using Upbit.Net.Extensions;
using Upbit.Net.Objects.Models.Exchanges;

namespace Upbit.Net.Clients.ExchangeApis
{
    public class UpbitOrderApi : BaseClient
    {
        public UpbitOrderApi(HttpClient client, string accessKey, string secretKey) : base(client, accessKey, secretKey)
        {
        }

        public async Task<UpbitAvailableOrderInfo> GetAvailableOrderInfoAsync(string marketId)
        {
            var parameters = new Dictionary<string, string>()
            {
                { "market", marketId }
            };

            return await GetAsync<UpbitAvailableOrderInfo>(Client, "https://api.upbit.com/v1/orders/chance" + SetJwtToken(parameters)).ConfigureAwait(false);
        }

        public async Task<UpbitOrder> GetIndividualOrderAsync(string uuid = "", string identifier = "")
        {
            var parameters = new Dictionary<string, string>()
            {
                { "uuid", uuid },
                { "identifier", identifier }
            };

            return await GetAsync<UpbitOrder>(Client, "https://api.upbit.com/v1/order" + SetJwtToken(parameters)).ConfigureAwait(false);
        }

        public async Task<IEnumerable<UpbitOrder>> GetOrderListAsync(string marketId = "", IEnumerable<string>? uuids = null, IEnumerable<string>? identifiers = null, UpbitOrderState state = UpbitOrderState.wait,  IEnumerable<UpbitOrderState>? states = null, int page = 1, int limit = 100, UpbitSortType sortType = UpbitSortType.desc)
        {
            var parameters = new Dictionary<string, string>()
            {
                { "market", marketId },
                { "uuids", uuids.ToQueryString() },
                { "identifiers", identifiers.ToQueryString() },
                { "state", state.ToString() },
                { "states", states.ToQueryString() },
                { "page", page.ToString() },
                { "limit", limit.ToString() },
                { "order_by", sortType.ToString() },
            };

            return await GetAsync<IEnumerable<UpbitOrder>>(Client, "https://api.upbit.com/v1/orders" + SetJwtToken(parameters)).ConfigureAwait(false);
        }

        public async Task<string> CancelOrderAsync(string uuid = "", string identifier = "")
        {
            var parameters = new Dictionary<string, string>()
            {
                { "uuid", uuid },
                { "identifier", identifier }
            };

            return await DeleteAsync(Client, "https://api.upbit.com/v1/order" + SetJwtToken(parameters)).ConfigureAwait(false);
        }

        public async Task<UpbitOrder> OrderAsync(string marketId, UpbitSideType sideType, decimal volume, decimal price, UpbitOrderType orderType, string identifier = "")
        {
            var parameters = new Dictionary<string, string>()
            {
                { "market", marketId },
                { "side", sideType.ToString() },
                { "volume", volume.ToString() },
                { "price", price.ToString() },
                { "ord_type", orderType.ToString() },
                { "identifier", identifier }
            };

            return await PostAsync<UpbitOrder>(Client, "https://api.upbit.com/v1/orders" + SetJwtToken(parameters)).ConfigureAwait(false);
        }
    }
}

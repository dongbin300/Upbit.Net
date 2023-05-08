namespace Upbit.Net.Objects.Models.Exchanges
{
    public record UpbitAvailableOrderInfo(string bid_fee, string ask_fee, string maker_bid_fee, string maker_ask_fee, UpbitAvailableOrderInfoMarket market, UpbitAccount bid_account, UpbitAccount ask_account);

    public record UpbitAvailableOrderInfoMarket(string id, string name, IEnumerable<string> order_types, IEnumerable<string> order_sides, IEnumerable<string> bid_types, IEnumerable<string> ask_types, UpbitAvailableOrderInfoBid bid, UpbitAvailableOrderInfoAsk ask, string max_total, string state);

    public record UpbitAvailableOrderInfoBid(string currency, string min_total);
    public record UpbitAvailableOrderInfoAsk(string currency, string min_total);
}

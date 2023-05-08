namespace Upbit.Net.Objects.Models.Quotations
{
    public record UpbitOrderBook(string market, long timestamp, decimal total_ask_size, decimal total_bid_size, IEnumerable<UpbitOrderBookUnit> orderbook_units);
    public record UpbitOrderBookUnit(decimal ask_price, decimal bid_price, decimal ask_size, decimal bid_size);
}

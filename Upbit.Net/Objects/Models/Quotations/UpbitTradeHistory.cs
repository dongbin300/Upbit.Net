namespace Upbit.Net.Objects.Models.Quotations
{
    public record UpbitTradeHistory(string market, string trade_date_utc, string trade_time_utc, long timestamp, decimal trade_price, decimal trade_volume, decimal prev_closing_price, decimal change_price, string ask_bid, long sequential_id);
}

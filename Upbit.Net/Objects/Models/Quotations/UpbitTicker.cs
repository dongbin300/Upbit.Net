namespace Upbit.Net.Objects.Models.Quotations
{
    public record UpbitTicker(string market, string trade_date, string trade_time, string trade_date_kst, string trade_time_kst, long trade_timestamp, decimal opening_price, decimal high_price, decimal low_price, decimal trade_price, decimal prev_closing_price, string change, decimal change_price, decimal change_rate, decimal signed_change_price, decimal signed_change_rate, decimal trade_volume, decimal acc_trade_price, decimal acc_trade_price_24h, decimal acc_trade_volume, decimal acc_trade_volume_24h, decimal highest_52_week_price, string highest_52_week_date, decimal lowest_52_week_price, string lowest_52_week_date, long timestamp);
}

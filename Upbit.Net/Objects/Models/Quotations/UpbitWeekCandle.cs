namespace Upbit.Net.Objects.Models.Quotations
{
    public record UpbitWeekCandle(string market, DateTime candle_date_time_utc, DateTime candle_date_time_kst, decimal opening_price, decimal high_price, decimal low_price, decimal trade_price, long timestamp, decimal candle_acc_trade_price, decimal candle_acc_trade_volume, string first_day_of_period);
}

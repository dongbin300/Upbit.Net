namespace Upbit.Net.Objects.Models.Exchanges
{
    public record UpbitOrder(string uuid, string side, string ord_type, string price, string state, string market, DateTime created_at, string volue, string remaining_volume, string reserved_fee, string remaining_fee, string paid_fee, string locked, string executed_volume, int trades_count, IEnumerable<UpbitTrade> trades);
}

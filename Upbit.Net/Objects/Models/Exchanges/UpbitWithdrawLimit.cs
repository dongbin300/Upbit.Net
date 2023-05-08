namespace Upbit.Net.Objects.Models.Exchanges
{
    public record UpbitWithdrawLimit(string currency, string? minimum, string? onetime, string daily, string remaining_daily, string remaining_daily_krw, string? @fixed, bool can_withdraw);
}

namespace Upbit.Net.Objects.Models.Exchanges
{
    public record UpbitAvailableBalanceInfo(UpbitMemberLevel member_level, UpbitCurrency currency, UpbitAccount account, UpbitWithdrawLimit withdraw_limit);
}

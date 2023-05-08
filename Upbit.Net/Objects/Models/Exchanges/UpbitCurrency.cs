namespace Upbit.Net.Objects.Models.Exchanges
{
    public record UpbitCurrency(string code, string withdraw_fee, bool is_coin, string wallet_state, IEnumerable<string> wallet_support);
}

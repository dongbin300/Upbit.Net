namespace Upbit.Net.Objects.Models.Exchanges
{
    public record UpbitAccount(string currency, string balance, string locked, string avg_buy_price, bool avg_buy_price_modified, string unit_currency);
}
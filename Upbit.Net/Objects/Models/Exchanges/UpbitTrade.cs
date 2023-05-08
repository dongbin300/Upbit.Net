namespace Upbit.Net.Objects.Models.Exchanges
{
    public record UpbitTrade(string market, string uuid, string price, string volume, string funds, string side);
}

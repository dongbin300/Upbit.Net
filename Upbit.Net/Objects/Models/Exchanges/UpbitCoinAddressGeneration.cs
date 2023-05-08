namespace Upbit.Net.Objects.Models.Exchanges
{
    public record UpbitCoinAddressGeneration(bool success, string message, string currency, string deposit_address, string secondary_address);
}

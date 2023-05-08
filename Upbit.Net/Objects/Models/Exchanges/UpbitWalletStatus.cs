namespace Upbit.Net.Objects.Models.Exchanges
{
    public record UpbitWalletStatus(string currency, string wallet_state, string block_state, int block_height, DateTime block_updated_at);
}

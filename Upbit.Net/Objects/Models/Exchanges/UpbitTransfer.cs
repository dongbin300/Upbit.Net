using Upbit.Net.Enums;

namespace Upbit.Net.Objects.Models.Exchanges
{
    public record UpbitTransfer(string type, string uuid, string currency, string? txid, UpbitTransferState state, DateTime created_at, DateTime? done_at, string amount, string fee, string krw_amount, UpbitTransactionType transaction_type);
}

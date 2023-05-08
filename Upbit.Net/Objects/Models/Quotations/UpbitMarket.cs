using Upbit.Net.Enums;

namespace Upbit.Net.Objects.Models.Quotations
{
    public record UpbitMarket(string market, string korean_name, string english_name, UpbitMarketWarningType market_warning);
}

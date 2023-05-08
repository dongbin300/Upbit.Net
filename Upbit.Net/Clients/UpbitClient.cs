using Upbit.Net.Clients.ExchangeApis;
using Upbit.Net.Clients.QuotationApis;

namespace Upbit.Net.Clients
{
    public class UpbitClient : BaseClient
    {
        public UpbitAssetsApi Assets { get; set; }
        public UpbitDepositApi Deposit { get; set; }
        public UpbitOrderApi Order { get; set; }
        public UpbitServiceInfoApi ServiceInfo { get; set; }
        public UpbitWithdrawalApi Withdrawal { get; set; }
        public UpbitQuotationCandlesApi QuotationCandles { get; set; }
        public UpbitQuotationMarketListApi QuotationMarketList { get; set; }
        public UpbitQuotationOrderBookApi QuotationOrderBook { get; set; }
        public UpbitQuotationTickersApi QuotationTickers { get; set; }
        public UpbitQuotationTradesApi QuotationTrades { get; set; }

        public UpbitClient() : this(string.Empty, string.Empty)
        {

        }

        public UpbitClient(string accessKey, string secretKey)
        {
            Client = new HttpClient(new HttpClientHandler() { ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true });

            Assets = new UpbitAssetsApi(Client, accessKey, secretKey);
            Deposit = new UpbitDepositApi(Client, accessKey, secretKey);
            Order = new UpbitOrderApi(Client, accessKey, secretKey);
            ServiceInfo = new UpbitServiceInfoApi(Client, accessKey, secretKey);
            Withdrawal = new UpbitWithdrawalApi(Client, accessKey, secretKey);
            QuotationCandles = new UpbitQuotationCandlesApi(Client, accessKey, secretKey);
            QuotationMarketList = new UpbitQuotationMarketListApi(Client, accessKey, secretKey);
            QuotationOrderBook = new UpbitQuotationOrderBookApi(Client, accessKey, secretKey);
            QuotationTickers = new UpbitQuotationTickersApi(Client, accessKey, secretKey);
            QuotationTrades = new UpbitQuotationTradesApi(Client, accessKey, secretKey);
        }

        
    }
}

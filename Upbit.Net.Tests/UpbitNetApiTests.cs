using Upbit.Net.Clients;
using Upbit.Net.Enums;

namespace Upbit.Net.Tests
{
    public class UpbitNetApiTests
    {
        UpbitClient client;

        [SetUp]
        public void Setup()
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Gaten", "upbit_api.txt");
            var keyData = File.ReadAllLines(path);
            var accessKey = keyData[0];
            var secretKey = keyData[1];

            client = new UpbitClient(accessKey, secretKey);
        }

        #region Exchange API
        [Test]
        public async Task GetOverallAccountAsync()
        {
            try
            {
                Assert.That(await client.Assets.GetOverallAccountAsync(), Is.Not.Null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task GetDepositListAsync()
        {
            try
            {
                Assert.That(await client.Deposit.GetDepositListAsync(), Is.Not.Null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task GetIndividualDepositAsync()
        {
            try
            {
                Assert.That(await client.Deposit.GetIndividualDepositAsync(), Is.Not.Null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestCase("KRW")]
        public async Task GenerateDepositAddressAsync(string currency)
        {
            try
            {
                Assert.That(await client.Deposit.GenerateDepositAddressAsync(currency), Is.Not.Null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task GetGeneralDepositAddressAsync()
        {
            try
            {
                Assert.That(await client.Deposit.GetGeneralDepositAddressAsync(), Is.Not.Null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestCase("KRW")]
        public async Task GetIndividualDepositAddressAsync(string currency)
        {
            try
            {
                Assert.That(await client.Deposit.GetIndividualDepositAddressAsync(currency), Is.Not.Null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestCase(2)]
        [TestCase(35.5)]
        public async Task DepositKrwAsync(decimal amount)
        {
            try
            {
                Assert.That(await client.Deposit.DepositKrwAsync(amount), Is.Not.Null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestCase("KRW-BTC")]
        [TestCase("KRW-ETH")]
        [TestCase("KRW-ADA")]
        public async Task GetAvailableOrderInfoAsync(string marketId)
        {
            try
            {
                Assert.That(await client.Order.GetAvailableOrderInfoAsync(marketId), Is.Not.Null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task GetIndividualOrderAsync()
        {
            try
            {
                Assert.That(await client.Order.GetIndividualOrderAsync(), Is.Not.Null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestCase("KRW-BTC")]
        [TestCase("KRW-ETH")]
        public async Task GetOrderListAsync(string marketId)
        {
            try
            {
                Assert.That(await client.Order.GetOrderListAsync(marketId), Is.Not.Null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task CancelOrderAsync()
        {
            try
            {
                Assert.That(await client.Order.CancelOrderAsync(), Is.Not.Null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task OrderAsync()
        {
            try
            {
                Assert.That(await client.Order.OrderAsync("KRW-BTC", Enums.UpbitSideType.bid, 0.5m, 10000, Enums.UpbitOrderType.limit), Is.Not.Null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task GetWalletStatusAsync()
        {
            try
            {
                Assert.That(await client.ServiceInfo.GetWalletStatusAsync(), Is.Not.Null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task GetApiKeyListAsync()
        {
            try
            {
                Assert.That(await client.ServiceInfo.GetApiKeyListAsync(), Is.Not.Null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task GetWithdrawalListAsync()
        {
            try
            {
                Assert.That(await client.Withdrawal.GetWithdrawalListAsync(), Is.Not.Null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task GetIndividualWithdrawalAsync()
        {
            try
            {
                Assert.That(await client.Withdrawal.GetIndividualWithdrawalAsync(), Is.Not.Null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task GetAvailableBalanceInfoAsync()
        {
            try
            {
                Assert.That(await client.Withdrawal.GetAvailableBalanceInfoAsync(), Is.Not.Null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task WithdrawalCoinsAsync()
        {
            try
            {
                Assert.That(await client.Withdrawal.WithdrawalCoinsAsync("KRW-BTC", 5, "wallet_address"), Is.Not.Null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestCase(2)]
        [TestCase(35.5)]
        public async Task WithdrawalKrwAsync(decimal amount)
        {
            try
            {
                Assert.That(await client.Withdrawal.WithdrawalKrwAsync(amount), Is.Not.Null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        #endregion

        #region Quotation API
        [TestCase("KRW-BTC", UpbitMinuteInterval.TenMinutes)]
        [TestCase("KRW-ETH", UpbitMinuteInterval.OneMinute)]
        [TestCase("KRW-ADA", UpbitMinuteInterval.SixtyMinutes)]
        public async Task GetMinutesCandlesAsync(string marketId, UpbitMinuteInterval interval)
        {
            try
            {
                Assert.That(await client.QuotationCandles.GetMinutesCandlesAsync(marketId, interval), Is.Not.Null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestCase("KRW-BTC")]
        [TestCase("KRW-ETH")]
        [TestCase("KRW-ADA")]
        public async Task GetDaysCandlesAsync(string marketId)
        {
            try
            {
                Assert.That(await client.QuotationCandles.GetDaysCandlesAsync(marketId), Is.Not.Null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestCase("KRW-BTC")]
        [TestCase("KRW-ETH")]
        [TestCase("KRW-ADA")]
        public async Task GetWeeksCandlesAsync(string marketId)
        {
            try
            {
                Assert.That(await client.QuotationCandles.GetWeeksCandlesAsync(marketId), Is.Not.Null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestCase("KRW-BTC")]
        [TestCase("KRW-ETH")]
        [TestCase("KRW-ADA")]
        public async Task GetMonthsCandlesAsync(string marketId)
        {
            try
            {
                Assert.That(await client.QuotationCandles.GetMonthsCandlesAsync(marketId), Is.Not.Null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task GetMarketListAsync()
        {
            try
            {
                Assert.That(await client.QuotationMarketList.GetMarketListAsync(), Is.Not.Null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task GetOrderBooksAsync()
        {
            try
            {
                var marketIds = new List<string> { "KRW-BTC", "KRW-ETH" };
                Assert.That(await client.QuotationOrderBook.GetOrderBooksAsync(marketIds), Is.Not.Null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task GetTickersAsync()
        {
            try
            {
                var marketIds = new List<string> { "KRW-BTC", "KRW-ETH" };
                Assert.That(await client.QuotationTickers.GetTickersAsync(marketIds), Is.Not.Null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestCase("KRW-BTC")]
        [TestCase("KRW-ETH")]
        [TestCase("KRW-ADA")]
        public async Task GetRecentTradesHistoryAsync(string marketId)
        {
            try
            {
                Assert.That(await client.QuotationTrades.GetRecentTradesHistoryAsync(marketId), Is.Not.Null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        #endregion
    }
}
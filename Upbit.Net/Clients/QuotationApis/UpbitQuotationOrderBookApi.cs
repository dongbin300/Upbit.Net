using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Upbit.Net.Interfaces;
using Upbit.Net.Objects.Models.Exchanges;

namespace Upbit.Net.Clients.QuotationApis
{
    public class UpbitQuotationOrderBookApi : BaseClient
    {
        public UpbitQuotationOrderBookApi(HttpClient client, string accessKey, string secretKey) : base(client, accessKey, secretKey)
        {
        }

        public async Task<IEnumerable<UpbitAccount>> GetOverallAccount()
        {
            return await GetAsync<IEnumerable<UpbitAccount>>(Client, "https://api.upbit.com/v1/accounts").ConfigureAwait(false);
        }
    }
}

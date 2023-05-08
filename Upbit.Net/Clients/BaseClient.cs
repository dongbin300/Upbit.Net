using Newtonsoft.Json;

using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;

using Upbit.Net.Interfaces;

namespace Upbit.Net.Clients
{
    public class BaseClient : IClient
    {
        protected string accessKey { get; private set; } = string.Empty;
        protected string secretKey { get; private set; } = string.Empty;

        public HttpClient Client { get; init; }

        public BaseClient()
        {
            Client = new HttpClient();
        }

        public BaseClient(HttpClient client, string accessKey, string secretKey)
        {
            Client = client;
            this.accessKey = accessKey;
            this.secretKey = secretKey;
        }

        ~BaseClient()
        {
            Client.Dispose();
        }

        public static async Task<T> GetAsync<T>(HttpClient client, string url)
        {
            try
            {
                var response = await client.GetAsync(url).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    var jsonStringResult = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    T? data = JsonConvert.DeserializeObject<T>(jsonStringResult);
                    return data ?? default!;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
            catch
            {
                throw;
            }
        }

        public static async Task<T> PostAsync<T>(HttpClient client, string url, HttpContent? content = null)
        {
            try
            {
                var response = await client.PostAsync(url, content).ConfigureAwait(false);
                var jsonStringResult = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                T? data = JsonConvert.DeserializeObject<T>(jsonStringResult);
                return data ?? default!;
            }
            catch
            {
                throw;
            }
        }

        public static async Task<T> PostAsync<T>(HttpClient client, string url, string jsonString)
        {
            try
            {
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                return await PostAsync<T>(client, url, content);
            }
            catch
            {
                throw;
            }
        }

        public static async Task<string> DeleteAsync(HttpClient client, string url)
        {
            try
            {
                var response = await client.DeleteAsync(url).ConfigureAwait(false);
                return response.ReasonPhrase ?? string.Empty;
            }
            catch
            {
                throw;
            }
        }

        public static async Task<byte[]> GetBytesAsync(HttpClient client, string url)
        {
            try
            {
                var requestResult = await client.GetAsync(url).ConfigureAwait(false);

                var response = requestResult.EnsureSuccessStatusCode();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
                    return result;
                }
                else
                {
                    return Array.Empty<byte>();
                }
            }
            catch
            {
                return Array.Empty<byte>();
            }
        }

        public static async Task DownloadFileAsync(HttpClient client, string url, string localPath)
        {
            try
            {
                var response = await client.GetAsync(url).ConfigureAwait(false);
                using var stream = new FileStream(localPath, FileMode.CreateNew);
                await response.Content.CopyToAsync(stream).ConfigureAwait(false);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Create a JWT authorization token and set on header
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns>Query string</returns>
        /// <seealso cref="https://docs.upbit.com/docs/create-authorization-request#jwt-%EC%9D%B8%EC%A6%9D-%ED%86%A0%ED%81%B0-%EB%A7%8C%EB%93%A4%EA%B8%B0"/>
        protected string SetJwtToken(IDictionary<string, string>? parameters = null)
        {
            string queryString = string.Empty;
            string queryHash = string.Empty;
            if (parameters != null)
            {
                queryString = string.Join('&', parameters.Select(p => p.Key + "=" + p.Value).ToArray());
                byte[] queryHashByteArray = SHA512.HashData(Encoding.UTF8.GetBytes(queryString));
                queryHash = BitConverter.ToString(queryHashByteArray).Replace("-", "").ToLower();
            }

            var payload = new JwtPayload
            {
                { "access_key", accessKey },
                { "nonce", Guid.NewGuid().ToString() },
                { "query_hash", queryHash },
                { "query_hash_alg", "SHA512" }
            };

            byte[] keyBytes = Encoding.Default.GetBytes(secretKey);
            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(keyBytes);
            var credentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey, "HS256");
            var header = new JwtHeader(credentials);
            var secToken = new JwtSecurityToken(header, payload);
            var jwtToken = new JwtSecurityTokenHandler().WriteToken(secToken);

            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(jwtToken);

            return "?" + queryString;
        }
    }
}

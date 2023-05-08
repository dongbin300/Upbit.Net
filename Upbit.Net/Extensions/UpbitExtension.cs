namespace Upbit.Net.Extensions
{
    public static class UpbitExtension
    {
        public static string ToQueryString(this IEnumerable<string>? strings)
        {
            if (strings == null || !strings.Any())
            {
                return string.Empty;
            }

            return string.Join("&", strings);
        }

        public static string ToQueryString<T>(this IEnumerable<T>? values)
        {
            if (values == null || !values.Any())
            {
                return string.Empty;
            }

            return string.Join("&", values.ToString());
        }
    }
}

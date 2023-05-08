namespace Upbit.Net.Objects.Models.Exchanges
{
    public record UpbitMemberLevel(int security_level, int fee_level, bool email_verified, bool identity_auth_verified, bool bank_account_verified, bool kakao_pay_auth_verified, bool locked, bool wallet_locked);
}

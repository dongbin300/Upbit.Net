namespace Upbit.Net.Enums
{
    public enum UpbitOrderState
    {
        /// <summary>
        /// 체결 대기
        /// </summary>
        wait,

        /// <summary>
        /// 예약주문 대기
        /// </summary>
        watch,

        /// <summary>
        /// 전체 체결 완료
        /// </summary>
        done,

        /// <summary>
        /// 주문 취소
        /// </summary>
        cancel
    }
}

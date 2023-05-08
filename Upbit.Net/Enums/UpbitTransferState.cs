namespace Upbit.Net.Enums
{
    public enum UpbitTransferState
    {
        /// <summary>
        /// 대기중
        /// </summary>
        WAITING,

        /// <summary>
        /// 진행중
        /// </summary>
        PROCESSING,

        /// <summary>
        /// 완료(출금)
        /// </summary>
        DONE,

        /// <summary>
        /// 실패
        /// </summary>
        FAILED,

        /// <summary>
        /// 취소됨
        /// </summary>
        CANCELLED,

        /// <summary>
        /// 거절됨
        /// </summary>
        REJECTED,

        /// <summary>
        /// 완료(입금)
        /// </summary>
        ACCEPTED,

        /// <summary>
        /// 트래블룰 추가 인증 대기중
        /// </summary>
        TRAVEL_RULE_SUSPECTED,

        /// <summary>
        /// 반환 절차 진행중
        /// </summary>
        REFUNDING,

        /// <summary>
        /// 반환됨
        /// </summary>
        REFUNDED
    }
}

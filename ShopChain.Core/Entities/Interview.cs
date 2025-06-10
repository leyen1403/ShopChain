namespace ShopChain.Core.Entities
{
    public enum InterviewRound
    {
        First,
        Technical,
        Final,
        HR
    }

    /// <summary>Thông tin chi tiết về buổi phỏng vấn trong quy trình tuyển dụng.</summary>
    public class Interview
    {
        /// <summary>Mã định danh buổi phỏng vấn.</summary>
        public int InterviewID { get; set; }

        /// <summary>Mã đơn ứng tuyển liên quan đến buổi phỏng vấn.</summary>
        public int JobApplicationID { get; set; }

        /// <summary>Tham chiếu đến đơn ứng tuyển liên quan.</summary>
        public JobApplication JobApplication { get; set; } = null!;

        /// <summary> Thời gian phỏng vấn được lên lịch.</summary>
        public DateTime ScheduledAt { get; set; }

        /// <summary>Vòng phỏng vấn (VD: Vòng 1, Vòng kỹ thuật, v.v...).</summary>
        public InterviewRound Round { get; set; }

        /// <summary>Mã nhân viên phỏng vấn.</summary>
        public int InterviewerID { get; set; }

        /// <summary>Thông tin nhân viên phỏng vấn.</summary>
        public Employee Interviewer { get; set; } = null!;

        /// <summary>Đánh giá sau buổi phỏng vấn </summary>
        public string? Evaluation { get; set; } = string.Empty;
    }

}

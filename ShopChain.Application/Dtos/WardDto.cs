namespace ShopChain.Application.Dtos
{
    /// <summary>
    /// DTO đại diện cho Phường/Xã
    /// </summary>
    public class WardDto
    {
        /// <summary>
        /// Tên phường/xã
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Mã phường/xã
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Mã dạng chuỗi (CodeName)
        /// </summary>
        public string CodeName { get; set; } = null!;

        /// <summary>
        /// Loại đơn vị hành chính (phường/xã/thị trấn)
        /// </summary>
        public string DivisionType { get; set; } = null!;

        /// <summary>
        /// Tên viết tắt ngắn gọn
        /// </summary>
        public string ShortCodeName { get; set; } = null!;
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopChain.Core.Entities
{
    /// <summary>
    /// Thực thể Tỉnh/Thành phố
    /// </summary>
    public class Province
    {
        /// <summary>
        /// Mã tỉnh (Primary Key)
        /// </summary>
        [Key]
        public int Code { get; set; }

        /// <summary>
        /// Tên tỉnh/thành phố
        /// </summary>
        [MaxLength(100)]
        public string? Name { get; set; }

        /// <summary>
        /// Mã tên dạng chuỗi
        /// </summary>
        [MaxLength(100)]
        public string? CodeName { get; set; }

        /// <summary>
        /// Loại đơn vị hành chính (Tỉnh/Thành phố)
        /// </summary>
        [MaxLength(50)]
        public string? DivisionType { get; set; }

        /// <summary>
        /// Mã vùng điện thoại
        /// </summary>
        public int PhoneCode { get; set; }

        /// <summary>
        /// Danh sách quận/huyện thuộc tỉnh/thành
        /// </summary>
        public List<District> Districts { get; set; } = new();
    }
}

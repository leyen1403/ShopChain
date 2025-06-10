using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopChain.Core.Entities
{
    public abstract class AuditableEntity
    {
        /// <summary>Cờ xóa mềm</summary>
        public bool IsDeleted { get; set; } = false;

        /// <summary>Ngày tạo bản ghi</summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>Ngày cập nhật gần nhất</summary>
        public DateTime? UpdatedAt { get; set; }
    }

}

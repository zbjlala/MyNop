using Nop.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Core.Domain.Orders
{
    /// <summary>
    /// Represents a return request
    /// 表示返回请求
    /// </summary>
    public partial class ReturnRequest : BaseEntity
    {
        /// <summary>
        /// Custom number of return request
        /// 返回请求的自定义编号
        /// </summary>
        public string CustomNumber { get; set; }

        /// <summary>
        /// Gets or sets the store identifier
        /// 获取或设置存储标识符
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// Gets or sets the order item identifier
        /// 获取或设置订单项标识符
        /// </summary>
        public int OrderItemId { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier
        /// 获取或设置客户标识符
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the quantity
        /// 获取或设置数量
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the reason to return
        /// 获取或设置返回的原因
        /// </summary>
        public string ReasonForReturn { get; set; }

        /// <summary>
        /// Gets or sets the requested action
        /// 获取或设置请求的操作
        /// </summary>
        public string RequestedAction { get; set; }

        /// <summary>
        /// Gets or sets the customer comments
        /// 获取或设置客户评论
        /// </summary>
        public string CustomerComments { get; set; }

        /// <summary>
        /// Gets or sets identifier of the file (Download) uploaded by the customer
        /// 获取或设置客户上载的文件(下载)的标识符
        /// </summary>
        public int UploadedFileId { get; set; }

        /// <summary>
        /// Gets or sets the staff notes
        /// 获取或设置职员说明
        /// </summary>
        public string StaffNotes { get; set; }

        /// <summary>
        /// Gets or sets the return status identifier
        /// 获取或设置返回状态标识符
        /// </summary>
        public int ReturnRequestStatusId { get; set; }

        /// <summary>
        /// Gets or sets the date and time of entity creation
        /// 获取或设置实体创建的日期和时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time of entity update
        /// 获取或设置实体更新的日期和时间
        /// </summary>
        public DateTime UpdatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the return status
        /// 获取或设置返回状态
        /// </summary>
        public ReturnRequestStatus ReturnRequestStatus
        {
            get => (ReturnRequestStatus)ReturnRequestStatusId;
            set => ReturnRequestStatusId = (int)value;
        }

        /// <summary>
        /// Gets or sets the customer
        /// </summary>
        public virtual Customer Customer { get; set; }
    }
}

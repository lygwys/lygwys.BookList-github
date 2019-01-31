using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Entities.Auditing;

namespace lygwys.BookList.BookListManagement.BookTags
{
    /// <summary>
    /// 书籍标签
    /// </summary>
    public class BookTag:CreationAuditedEntity<long>
    {
        /// <summary>
        /// 标签名称
        /// </summary>
        public string TagName { get; set; }
    }
}

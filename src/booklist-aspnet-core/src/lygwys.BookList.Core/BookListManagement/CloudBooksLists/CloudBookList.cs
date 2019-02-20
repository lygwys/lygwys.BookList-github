using System.Collections.Generic;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using JetBrains.Annotations;
using lygwys.BookList.BookListManagement.Relationships;

namespace lygwys.BookList.BookListManagement.CloudBooksLists
{
    /// <summary>
    /// 书单
    /// </summary>
    [UsedImplicitly]
    public class CloudBookList : CreationAuditedEntity<long>, IMustHaveTenant
    {
        /// <summary>
        /// 书单名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 书单简介
        /// </summary>
        public string Intro { get; set; }
        public virtual ICollection<BookListAndBook> BookListAndBooks { get; set; }
        public int TenantId { get; set; }
    }
}

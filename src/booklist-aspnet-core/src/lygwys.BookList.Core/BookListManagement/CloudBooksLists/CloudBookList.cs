using Abp.Domain.Entities.Auditing;
using JetBrains.Annotations;

namespace lygwys.BookList.BookListManagement.CloudBooksLists
{
    /// <summary>
    /// 书单
    /// </summary>
    [UsedImplicitly]
    public class CloudBookList : CreationAuditedEntity<long>
    {
        /// <summary>
        /// 书单名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 书单简介
        /// </summary>
        public string Intro { get; set; }
    }
}

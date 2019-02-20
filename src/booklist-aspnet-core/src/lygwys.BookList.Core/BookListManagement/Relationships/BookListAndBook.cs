using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using lygwys.BookList.BookListManagement.Books;
using lygwys.BookList.BookListManagement.CloudBooksLists;

namespace lygwys.BookList.BookListManagement.Relationships
{
    public class BookListAndBook:CreationAuditedEntity<long>, IMustHaveTenant
    {
        public long CloudBookListId { get; set; }
        public CloudBookList CloudBookList { get; set; }

        public long BookId { get; set; }
        public Book Book { get; set; }
        public int TenantId { get; set; }
    }
}

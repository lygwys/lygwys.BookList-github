using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Entities;
using lygwys.BookList.BookListManagement.Books;
using lygwys.BookList.BookListManagement.BookTags;

namespace lygwys.BookList.BookListManagement.Relationships
{
    public class BookAndBookTag : Entity<long>, IMustHaveTenant
    {
        public long BookId { get; set; }
        public virtual Book Book { get; set; }
        public long BookTagId { get; set; }
        public virtual BookTag BookTag { get; set; }
        public int TenantId { get; set; }
    }
}

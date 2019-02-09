using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using lygwys.BookList.Authorization.Roles;
using lygwys.BookList.Authorization.Users;
using lygwys.BookList.MultiTenancy;
using lygwys.BookList.BookListManagement.Books;
using lygwys.BookList.BookListManagement.CloudBooksLists;
using lygwys.BookList.BookListManagement.BookTags;
using lygwys.BookList.BookListManagement.Relationships;

namespace lygwys.BookList.EntityFrameworkCore
{
    public class BookListDbContext : AbpZeroDbContext<Tenant, Role, User, BookListDbContext>
    {
        /* Define a DbSet for each entity of the application */
        #region 书单功能实体
        public DbSet<Book> Books{get;set;}
        public DbSet<CloudBookList> CloudBookLists{ get; set; }
        public DbSet<BookTag> BookTags { get; set; }
        public DbSet<BookAndBookTag> BookAndBookTags { get; set; }
        #endregion

        public BookListDbContext(DbContextOptions<BookListDbContext> options)
            : base(options)
        {
        }
    }
}

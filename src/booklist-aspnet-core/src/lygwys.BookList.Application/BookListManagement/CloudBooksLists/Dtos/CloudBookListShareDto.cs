using System;
using System.Collections.Generic;
using lygwys.BookList.BookListManagement.Books.Dtos;

namespace lygwys.BookList.BookListManagement.CloudBooksLists.Dtos
{
    public class CloudBookListShareDto
    {
        public string Name { get; set; }
        public string Intro { get; set; }
        public DateTime CreationTime { get; set; }
        public List<BookIncludeTagDto> Books { get; set; }
        public string UserName { get; set; }
    }
}
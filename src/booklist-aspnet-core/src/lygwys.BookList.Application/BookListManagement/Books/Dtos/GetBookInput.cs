using Abp.Runtime.Validation;
using lygwys.BookList.Dtos;

// ReSharper disable once IdentifierTypo
namespace lygwys.BookList.BookListManagement.Books.Dtos
{
    public class GetBookInput : PagedAndFilteredInputDto, IShouldNormalize  //过滤字段，排序字段（默认id）
    {
        public void Normalize()
        {
            if (string.IsNullOrWhiteSpace(Sorting))
            {
                Sorting="Id";
            }
        }
    }
}
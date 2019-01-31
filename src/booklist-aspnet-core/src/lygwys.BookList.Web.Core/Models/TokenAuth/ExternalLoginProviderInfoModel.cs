using Abp.AutoMapper;
using lygwys.BookList.Authentication.External;

namespace lygwys.BookList.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}

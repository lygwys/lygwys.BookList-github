

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using lygwys.BookList.BookListManagement.BookTags;

namespace lygwys.BookList.EntityMapper.BookTags
{
    public class BookTagCfg : IEntityTypeConfiguration<BookTag>
    {
        public void Configure(EntityTypeBuilder<BookTag> builder)
        {

            builder.ToTable("BookTags", YoYoAbpefCoreConsts.SchemaNames.CMS);

            
			builder.Property(a => a.TagName).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);


        }
    }
}



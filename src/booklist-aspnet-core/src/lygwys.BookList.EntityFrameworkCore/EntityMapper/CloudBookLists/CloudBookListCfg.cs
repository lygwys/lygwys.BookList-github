

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using lygwys.BookList.BookListManagement.CloudBooksLists;

namespace lygwys.BookList.EntityMapper.CloudBookLists
{
    public class CloudBookListCfg : IEntityTypeConfiguration<CloudBookList>
    {
        public void Configure(EntityTypeBuilder<CloudBookList> builder)
        {

            builder.ToTable("CloudBookLists", YoYoAbpefCoreConsts.SchemaNames.CMS);

            
			builder.Property(a => a.Name).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);
			builder.Property(a => a.Intro).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);
			builder.Property(a => a.BookListAndBooks).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);


        }
    }
}



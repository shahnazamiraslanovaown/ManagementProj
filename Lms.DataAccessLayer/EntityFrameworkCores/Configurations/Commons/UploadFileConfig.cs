using Lms.Entity.Commons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lms.DataAccessLayer.EntityFrameworkCores.Configurations.Commons
{
    public class UploadFileConfig : EditedBaseEntityConfig<UploadedFile>
    {
        public override void Configure(EntityTypeBuilder<UploadedFile> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.ContentType).HasMaxLength(50);
            builder.Property(x=>x.RelativePath).HasMaxLength(200);
            builder.Property(x=>x.FileName).HasMaxLength(50);

            builder.ToTable("UploadedFiles", "libraries");
        }
    }
}

using Lms.DataAccessLayer.EntityFrameworkCores.Configurations.Commons;
using Lms.Entity.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lms.DataAccessLayer.EntityFrameworkCores.Configurations.Books;

public class CategoryConfig : EditedBaseEntityConfig<Category>
{
    public override void Configure(EntityTypeBuilder<Category> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Value)
            .HasMaxLength(24);

        builder.HasData([
            new Category {Id=1,Value="Dram",CreatedId=1,CreatedDate=DateTime.UtcNow,UpdatedId=1,UpdatedDate=DateTime.UtcNow},
            new Category {Id=2,Value="Comedy",CreatedId=1,CreatedDate=DateTime.UtcNow,UpdatedId=1,UpdatedDate=DateTime.UtcNow},
            new Category {Id=3,Value="Dedectiv",CreatedId=1,CreatedDate=DateTime.UtcNow,UpdatedId=1,UpdatedDate=DateTime.UtcNow},
            new Category {Id=4,Value="Fantastic",CreatedId=1,CreatedDate=DateTime.UtcNow,UpdatedId=1,UpdatedDate=DateTime.UtcNow},
            ]);

        builder.ToTable("Categories","library");
    }
}

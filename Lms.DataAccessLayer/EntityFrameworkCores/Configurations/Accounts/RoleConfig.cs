using Lms.DataAccessLayer.EntityFrameworkCores.Configurations.Commons;
using Lms.Entity.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lms.DataAccessLayer.EntityFrameworkCores.Configurations.Accounts;

public class RoleConfig : EditedBaseEntityConfig<Role>
{
    public override void Configure(EntityTypeBuilder<Role> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Value)
            .HasColumnName("Value")
            .HasMaxLength(25);


        builder.HasData([
            new Role {Id=1,Value="Admin",CreatedId=1,CreatedDate=DateTime.UtcNow,UpdatedId=1,UpdatedDate=DateTime.UtcNow}
            ]);

        builder.ToTable("Roles", "account");
    }
}

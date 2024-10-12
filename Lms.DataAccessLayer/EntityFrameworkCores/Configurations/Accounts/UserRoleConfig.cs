using Lms.Entity.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lms.DataAccessLayer.EntityFrameworkCores.Configurations.Accounts;

internal class UserRoleConfig : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.HasKey(x => new { x.RoleId, x.UserId });

        builder.Ignore(x => x.Id);

        builder.ToTable("UserRoles", "account");
    }
}

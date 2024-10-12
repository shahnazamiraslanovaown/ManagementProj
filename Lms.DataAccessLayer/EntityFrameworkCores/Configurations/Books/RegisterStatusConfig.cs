using Lms.DataAccessLayer.EntityFrameworkCores.Configurations.Commons;
using Lms.Entity.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lms.DataAccessLayer.EntityFrameworkCores.Configurations.Books
{
    public class RegisterStatusConfig : BaseEntityConfig<RegisterStatus>
    {
        public override void Configure(EntityTypeBuilder<RegisterStatus> builder)
        {
            builder.Property(x => x.Value)
                .HasMaxLength(25)
                .HasColumnName("Value")
                .HasComment("For Registered Statuses");
            builder.ToTable("RegisterStatuses", "library");
        }
    }
}

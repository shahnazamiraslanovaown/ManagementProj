using Lms.DataAccessLayer.EntityFrameworkCores.Configurations.Commons;
using Lms.Entity.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lms.DataAccessLayer.EntityFrameworkCores.Configurations.Books;

public class AuthorConfig : EditedBaseEntityConfig<Author>
{
    public override void Configure(EntityTypeBuilder<Author> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.FirstName)
            .HasMaxLength(25)
            .IsRequired(true)
            .HasColumnName("FirstName");

        builder.Property(x => x.LastName)
            .HasMaxLength(25)
            .IsRequired(true)
            .HasColumnName("LastName");

        builder.Property(x => x.DateOfBirth)
            .IsRequired(false)
            .HasColumnType("datetime")
            .HasColumnName("DateOfBirth");


        builder.Ignore(x => x.FullName);

        builder.ToTable("Authors", "app");
    }
}
